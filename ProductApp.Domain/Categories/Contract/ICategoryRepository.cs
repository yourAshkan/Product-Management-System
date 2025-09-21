using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Domain.Categories.Contract
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task SoftDeleteAsync(int categoryId);
        Task<Category?> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
    }
}
