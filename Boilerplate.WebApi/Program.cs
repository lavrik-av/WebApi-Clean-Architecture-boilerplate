// --------------------------------------------------------------------
// Name: Template for Micro service on ASP.NET Core API with
// Author: Alex Lavrik © 2005-2023 Calabonga SOFT
// Version: 7.0.2
// Based on: .NET 7.0.x
// --------------------------------------------------------------------
// Contacts
// --------------------------------------------------------------------
// Description:
// This template implements Web API 
// functionality. Also, support two type of Authentication:
// Cookie and Bearer
// --------------------------------------------------------------------

using Eshop.Application;
using Eshop.WebApi.Definitions.AppDefinitionExtensions;
using Eshop.WebApi;
using Eshop.Persistence;
using Eshop.WebApi.Middleware;
using Eshop.WebApi.JsonConverters;
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

// TODO uncomment it to disable Swagger at Production
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
