using MicroBroker.Song.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using MicroBroker.Infra.Bus;
using MicroBroker.Infra.IoC;
using MicroBroker.Song.Application.Interfaces;
using MicroBroker.Song.Application.Services;
using MicroBroker.Song.Domain.Interfaces;
using MicroBroker.Song.Infraestructure.Repository;
using MicroBroker.Domain.Core.Bus;
using MicroBroker.Playlist.Domain.Events;
using MicroBroker.Playlist.Domain.CommandHandlers;
using MediatR;
using MicroBroker.Song.Domain.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SongDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicSongConnectionString"));
});
builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<ISongService, SongService>();
builder.Services.AddTransient<ISongRepository,SongRepository>();
builder.Services.AddTransient<SongDbContext>();

//////Comunicacion microservicios
//builder.Services.AddTransient<IEventHandler<SongPlaylistGetEvent>, SongPlaylistEventHandler>();

//////Subscriptions
builder.Services.AddTransient<SongPlaylistEventHandler>();

///
////builder.Services.AddTransient<UserPlaylistEventHandler>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();
//registrar microservices como subscriber

//var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<UserPlaylistCreatedEvent, UserPlaylistEventHandler>();
//registrar microservices como subscriber

//var eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<SongPlaylistGetEvent, SongPlaylistEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
