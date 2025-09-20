using Microsoft.EntityFrameworkCore;
using ProductApp.Infrastructure.DataBaseContext;
using ProductApp.Domain.Products.Contract;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Infrastructure.Repositories;

public class ProdcutRepository(AppDbContext _context) : IProductRepository
{
    #region Add
    public async Task AddAsync(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
    }
    #endregion

    #region Update
    public async Task UpdateAsync(Product product)
    {
        _context.Update(product);
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
    public async Task<List<Product?>> GetAllAsync()
    {
        var product = await _context.Products
            .Include(x=>x.Category)
            .ToListAsync();
        return product;
    }
    #endregion

    #region GetByID
    public async Task<Product?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Product not found!");

        var product = await _context.Products
            .Include(x=>x.Category)
            .FirstOrDefaultAsync(x=>x.Id == id);

        return product;
    }
    #endregion
}
