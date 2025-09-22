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
        modelBuilder.Entity<IdentityUserRole<int>>().HasKey(x=> new {x.UserId,x.RoleId});
        modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(x=>x.UserId);
        modelBuilder.Entity<IdentityUserToken<int>>().HasKey(x=>x.UserId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
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
