using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RateIO.Models;

namespace RateIO.Data;



public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<User> Users { get; set; }

    public DbSet<UserPost> UserPosts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserPosts)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.UserId);
    }

}