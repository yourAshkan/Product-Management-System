using ProductApp.Domain.Products.Entities;

namespace ProductApp.Domain.Products.Contract;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product?>> GetAllAsync();
    Task AddAsync(Product product);
    Task SoftDeleteAsync(int productId);
    Task UpdateAsync(Product product);
}
