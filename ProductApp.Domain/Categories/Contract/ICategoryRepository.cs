using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Domain.Categories.Contract
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task DeleteAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
    }
}
