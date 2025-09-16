using ProductApp.Domain.Products.Entities;

namespace ProductApp.Domain.Products.Contracts
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
    }
}
