using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NadinSoftTask.Domain.Products.Entities;
using NadinSoftTask.Domain.Users.Entities;

namespace NadinSoftTask.Infrastructure.DataBaseContext;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", "HR");
        modelBuilder.Entity<IdentityUserLogin<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserClaim<int>>().HasNoKey();

        modelBuilder.Entity<User>()
            .Property(x => x.FirstName)
            .HasMaxLength(15);

        modelBuilder.Entity<User>()
            .Property(x => x.LastName)
            .HasMaxLength(15);

        modelBuilder.Entity<User>()
            .Property(x => x.NationalCode)
            .HasMaxLength(10);

        modelBuilder.Entity<User>()
            .Property(x => x.PhoneNumber)
            .HasMaxLength(11);

        modelBuilder.Entity<User>()
            .Property(x => x.Email)
            .HasMaxLength(50);
    }
}
