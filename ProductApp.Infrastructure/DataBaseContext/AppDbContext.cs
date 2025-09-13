using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Users.Entities;
using ProductApp.Domain.Products.Entities;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Infrastructure.DataBaseContext;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserClaim<int>>().HasNoKey();
    }
}
