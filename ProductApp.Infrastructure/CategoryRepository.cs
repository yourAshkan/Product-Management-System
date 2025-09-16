using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;
using ProductApp.Infrastructure.DataBaseContext;

namespace ProductApp.Infrastructure
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        #region Add
        public async Task AddAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region GetByID
        public async Task<Category?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid ID!");

            var result = _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return await result;
        }
        #endregion

        #region GetAll
        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        } 
        #endregion
    }
}
