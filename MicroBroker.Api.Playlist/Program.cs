using MediatR;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.Infra.Bus;
using MicroBroker.Infra.IoC;
using MicroBroker.Playlist.Application.Interfaces;
using MicroBroker.Playlist.Application.Services;
using MicroBroker.Playlist.Infraestructure.Context;
using MicroBroker.Playlist.Infraestructure.Repository;
using MicroBroker.Playlist.Domain.CommandHandlers;
using MicroBroker.Playlist.Domain.Commands;
using MicroBroker.Playlist.Domain.EventHandlers;
using MicroBroker.Playlist.Domain.Events;
using MicroBroker.Playlist.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<PlaylistDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicPlaylistConnectionString"));
});

builder.Services.AddDbContextPool<PlaylistSongDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicPlaylistConnectionString"));
});

builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<IPlaylistService, PlaylistService>();
builder.Services.AddTransient<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddTransient<PlaylistDbContext>();


builder.Services.AddTransient<IPlaylistSongService, PlaylistSongService>();
builder.Services.AddTransient<ISongServiceRemote, SongServiceRemote>();

builder.Services.AddTransient<IPlaylistSongRepository, PlaylistSongRepository>();

builder.Services.AddTransient<PlaylistSongDbContext>();
//Comunicacion microservicios
builder.Services.AddTransient<IEventHandler<UserPlaylistCreatedEvent>,UserPlaylistEventHandler>();

builder.Services.AddTransient<IRequestHandler<GetSongPlaylistCommand, bool>, SongPlaylistCommandHandler>();

// comunicacion sincrona 

builder.Services.AddHttpClient("Song", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Songs"]);
});


//Subscriptions
builder.Services.AddTransient<UserPlaylistEventHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();
//registrar microservices como subscriber

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<UserPlaylistCreatedEvent, UserPlaylistEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();


