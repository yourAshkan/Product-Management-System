using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Domain.Products;
using NadinSoftTask.Domain.Users;

namespace NadinSoftTask.Infrastructure.DataBaseContext;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User", "HR");

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
            .Property(x => x.EmailAddress)
            .HasMaxLength(50);

    }
}
