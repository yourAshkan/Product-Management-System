using ProductApp.Domain.Products.Entities;

namespace ProductApp.Domain.Products.Contracts;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task DeleteAsync(Product product);
    Task UpdateAsync(Product product);
}
