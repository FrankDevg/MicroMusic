using MediatR;
using MicroBroker.Infra.Bus;
using MicroBroker.Infra.IoC;
using MicroBroker.Playlist.Application.Interfaces;
using MicroBroker.Playlist.Application.Services;
using MicroBroker.User.Application.Interfaces;
using MicroBroker.User.Application.Services;
using MicroBroker.User.Infraestructure.Context;
using MicroBroker.User.Infraestructure.Repository;
using MicroBroker.User.Domain.CommandHandlers;
using MicroBroker.User.Domain.Commands;
using MicroBroker.User.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDD_BytesMusicUserConnectionString"));
});
builder.Services.Configure<AzureServicesBusSettings>(builder.Configuration.GetSection("AzureServicesBusSettings"));

builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserDbContext>();

builder.Services.AddTransient<IRequestHandler<CreateUserPlaylistCommand, bool>, UserPlaylistCommandHandler>();
builder.Services.AddTransient<IRequestHandler<SendEmailUserLoginCommand, bool>, EmailUserLoginCommandHandler>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();

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
