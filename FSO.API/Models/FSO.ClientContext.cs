using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection;
using System.Net.Sockets;

namespace FSO.API.Models;

public class ClientDbContext : DbContext
{
    private readonly IConfiguration? _configuration;
    private readonly string? _connectionString;
    
    public DbSet<Member> Members { get; set; } = null!;
    
    public ClientDbContext()
    {
    }

  
    public ClientDbContext(DbContextOptions<ClientDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
      
        //_connectionString = _configuration.GetValue<string>("ConnectionString");      // For local User Secrets
        _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");    // For Enviroment Variables


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        //.EnableSensitiveDataLogging() // Remove this line in production
        .UseSqlServer(_connectionString);
      

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("fso");

        modelBuilder.Entity<Member>()
        .HasKey(p => new { p.Id })
        .HasName("Id");

        modelBuilder.Entity<Member>()
        .Property(p => p.Id)
        .ValueGeneratedOnAdd();

    
    }





}
