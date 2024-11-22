using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSO.API.Models;

public class ClientDbContext : DbContext
{
  private readonly IConfiguration? _configuration;
  private readonly string? _connectionString;
  
  public DbSet<Member> Members { get; set; } = null!;

  public ClientDbContext()
  {
  }
  
    
  public ClientDbContext(DbContextOptions<ClientDbContext> options, IConfiguration configuration)
    : base(options)
  {
    

    _configuration = configuration;
    //_connectionString = _configuration.GetValue<string>("ConnectionString");

    _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    

  }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder
         //.EnableSensitiveDataLogging() // Remove this line in production
         .UseSqlServer(_connectionString);
 }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {    
    modelBuilder.Entity<Member>()
      .HasKey(p => new { p.Id })
      .HasName("Id");  
    
    
    modelBuilder.Entity<Member>()
    .Property(p => p.Id)
    .ValueGeneratedNever();
    

  }

    
}