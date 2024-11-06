using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FSO.Client.Models;

public class ClientDbContext : DbContext
{
  
  private readonly string? _connectionString;
  
  public DbSet<MemberViewModel> Members { get; set; } = null!;

  public ClientDbContext()
  {
  }
  
    
  public ClientDbContext(DbContextOptions<ClientDbContext> options, IConfiguration configuration)
    : base(options)
  {
    //_connectionString = configuration.GetConnectionString("ConnectionStrings:DefaultConnection");

    //_configuration = configuration;
    _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
    

  }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 {
     optionsBuilder
         .EnableSensitiveDataLogging() // Remove this line in production
         .UseSqlServer(_connectionString);
 }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {    
    modelBuilder.Entity<MemberViewModel>()
      .HasKey(p => new { p.Id })
      .HasName("Id");  
    
    /*
    modelBuilder.Entity<MemberViewModel>()
    .Property(p => p.Timestamp)
    .ValueGeneratedNever();
    */

  }

    
}