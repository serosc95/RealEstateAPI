using BackendAPIRest.Application.Interfaces;
using BackendAPIRest.Application.Services;
using BackendAPIRest.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);
var mongoSettings = builder.Configuration.GetSection("MongoDB");

// Obtener la cadena de conexión y el nombre de la base de datos
var mongoConnectionString = mongoSettings.GetValue<string>("ConnectionString");
var databaseName = mongoSettings.GetValue<string>("DatabaseName");

// Comprobar si la cadena de conexión es válida
if (string.IsNullOrEmpty(mongoConnectionString))
{
    throw new ArgumentNullException("MongoDB.ConnectionString", "La cadena de conexión de MongoDB no está configurada.");
}

var mongoClient = new MongoClient(mongoConnectionString);
var database = mongoClient.GetDatabase(databaseName);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IMongoDatabase>(database);
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();