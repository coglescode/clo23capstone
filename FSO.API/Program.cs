using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using FSO.API.Models;
using Microsoft.Extensions.Options;
using System;
using FSO.API.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;



// Add services to the container.
//var testString = builder.Configuration.AddEnvironmentVariables(prefix: "CONNECTION_STRING_"); // You need to check the usage of this  line

//string? connectstring = builder.Configuration["CONNECTION_STRING_"];
//builder.Services.AddAwsSecretsManager(builder.Configuration);


string? connectionstring = builder.Configuration.GetConnectionString("CONNECTION_STRING");


builder.Services.AddControllers();

builder.Services.AddDbContext<ClientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring)));

builder.Configuration.AddEnvironmentVariables();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapEventEndpoints();

app.Run();
