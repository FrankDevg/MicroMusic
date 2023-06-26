using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar referencia del archivo a las configuraciones del host builder 
builder.Configuration.AddJsonFile($"ocelot.development.json");
//builder.Configuration.AddJsonFile($"ocelotUser.json");


// add services ocelot
builder.Services.AddOcelot();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();

// configuration to use ocelot

