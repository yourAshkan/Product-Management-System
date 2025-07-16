using Microsoft.EntityFrameworkCore;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products.Entities;
using NadinSoftTask.Infrastructure.DataBaseContext;

namespace NadinSoftTask.Infrastructure;

public class ProdcutRepository(AppDbContext _context) : IProductRepository
{
    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var product = await _context.Products.ToListAsync();
        return product;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Product not found!");

        var product = await _context.Products.FindAsync(id);
        return product;
    }
}
