using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
//using FSO.Client.Services;
using FSO.API.Models;
using Microsoft.Extensions.Options;
using System;
//using FSO.Client.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var testString = builder.Configuration.AddEnvironmentVariables(prefix: "CONNECTION_STRING_");
Console.WriteLine(testString);

string? connectstring = builder.Configuration["CONNECTION_STRING_"];

builder.Services.AddControllers();
builder.Services.AddDbContext<ClientDbContext>(options =>
    //options.UseSqlServer("Members"));
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectstring)));


//builder.Configuration.AddEnvironmentVariables();


//Data Source=192.168.1.218,1433;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False

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

app.Run();
