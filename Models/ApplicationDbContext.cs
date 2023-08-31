using Microsoft.EntityFrameworkCore;

namespace RateIO.Models;



public class ApplicationDbContext : DbContext
{
   public DbSet<User> Users { get; set; }

   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
}