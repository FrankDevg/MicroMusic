using MicroBroker.Catalog.Infraestructure.Context;
using MicroBroker.Infra.Bus;
using Microsoft.EntityFrameworkCore;
using MicroBroker.Infra.IoC;
using MicroBroker.Catalog.Domain.Interfaces;
using MicroBroker.Catalog.Infraestructure.Repository;
using MicroBroker.Catalog.Application.Interfaces;
using MicroBroker.Catalog.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicCatalogConnectionString"));
});
builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<ICatalogService,CatalogService>();
builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
builder.Services.AddTransient<CatalogDbContext>();
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
