using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;
using ProductApp.Infrastructure.DataBaseContext;

namespace ProductApp.Infrastructure;

public class ProdcutRepository(AppDbContext _context) : IProductRepository
{
    #region Add
    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Delete
    public async Task DeleteAsync(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region GetAll
    public async Task<List<Product>> GetAllAsync()
    {
        var product = await _context.Products.ToListAsync();
        return product;
    }
    #endregion

    #region GetByID
    public async Task<Product?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Product not found!");

        var product = await _context.Products.FindAsync(id);

        return product;
    } 
    #endregion
}
