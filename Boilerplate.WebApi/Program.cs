// --------------------------------------------------------------------
// Name: Boilerplate for WebAPI built on Clear Architecutre pattern
// Author: Alex Lavrik © 2023
// Based on: .NET 7.x.x
// --------------------------------------------------------------------

using Boilerplate.Application;
using Boilerplate.WebApi.Definitions.AppDefinitionExtensions;
using Boilerplate.WebApi;
using Boilerplate.Persistence;
using Boilerplate.WebApi.Middleware;
using Boilerplate.WebApi.JsonConverters;
using System.Text.Json.Serialization;
using Autofac;

var builder = WebApplication.CreateBuilder(args);
var containerBuilder = new ContainerBuilder();

// Add definitions for the application
builder.Services.AddDefinitions(builder, typeof(Program));

// Add services to the container.
builder.Services.ConfigureApplication();
builder.Services.ConfigurePersistence(builder.Configuration);

var AllowSpecificOrigins = "_AllowSpecificOrigins";
builder.Services.ConfigureWebApi(AllowSpecificOrigins);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions
            .Converters.Add(new JsonConverterGuid());
        options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Uncomment it to disable Swagger at Production
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(AllowSpecificOrigins);

app.MapControllers();

app.Run();
