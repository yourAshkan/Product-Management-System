using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Categories.Entities;
using ProductApp.Domain.Products.Entities;
using ProductApp.Infrastructure.Identity;

namespace ProductApp.Infrastructure.DataBaseContext;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>(options)
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

        modelBuilder.Entity<Product>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);
    }
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Product>())
        {
            if(entry.State == EntityState.Added ||  entry.State == EntityState.Modified)
                entry.Entity.IsAvailable = entry.Entity.Count > 0;
        }
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Product>())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                entry.Entity.IsAvailable = entry.Entity.Count > 0;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
