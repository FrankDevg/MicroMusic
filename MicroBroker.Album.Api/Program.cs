using MicroBroker.Album.Application.Interfaces;
using MicroBroker.Album.Application.Services;
using MicroBroker.Album.Infraestructure.Context;
using MicroBroker.Album.Infraestructure.Repository;
using MicroBroker.Album.Domain.Interfaces;
using MicroBroker.Infra.Bus;
using MicroBroker.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AlbumDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicAlbumConnectionString"));
});
builder.Services.AddDbContext<TracklistDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicAlbumConnectionString"));
});
builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IAlbumRepository, AlbumRepository>();
builder.Services.AddTransient<AlbumDbContext>();

builder.Services.AddTransient<ITracklistService, TracklistService>();

builder.Services.AddTransient<ITracklistRepository, TracklistRepository>();
builder.Services.AddTransient<ISongServiceRemote, SongServiceRemote>();

builder.Services.AddTransient<TracklistDbContext>();
// comunicacion sincrona 

builder.Services.AddHttpClient("Song", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Songs"]);
});
//////Comunicacion microservicios
////builder.Services.AddTransient<IEventHandler<UserPlaylistCreatedEvent>, UserPlaylistEventHandler>();

//////Subscriptions
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
