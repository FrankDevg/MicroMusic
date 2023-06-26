
using MicroBroker.Infra.Bus;
using MicroBroker.Infra.IoC;
using MicroBroker.Artist.Application.Interfaces;
using MicroBroker.Artist.Application.Services;
using MicroBroker.Artist.Infraestructure.Context;
using MicroBroker.Artist.Infraestructure.Repository;
using MicroBroker.Artist.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ArtistDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicArtistConnectionString"));
});
builder.Services.AddDbContext<PlayerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicArtistConnectionString"));
});
builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<ArtistDbContext>();

builder.Services.AddTransient<IPlayerService, PlayerService>();

builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<ISongServiceRemote, SongServiceRemote>();

builder.Services.AddTransient<PlayerDbContext>();


// comunicacion sincrona 

builder.Services.AddHttpClient("Song", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Songs"]);
});
//Comunicacion microservicios
//builder.Services.AddTransient<IEventHandler<UserPlaylistCreatedEvent>, UserPlaylistEventHandler>();

//Subscriptions
//builder.Services.AddTransient<UserPlaylistEventHandler>();
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
