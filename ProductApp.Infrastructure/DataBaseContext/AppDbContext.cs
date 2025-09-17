using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Categories.Entities;
using ProductApp.Domain.Products.Entities;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Infrastructure.DataBaseContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserClaim<int>>().HasNoKey();

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
