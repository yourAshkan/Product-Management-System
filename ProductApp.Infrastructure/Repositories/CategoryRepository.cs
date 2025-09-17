using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Categories.Contract;
using ProductApp.Domain.Categories.Entities;
using ProductApp.Infrastructure.DataBaseContext;

namespace ProductApp.Infrastructure.Repositories
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

        #region Delete
        public async Task DeleteAsync(Category category)
        {
            _context.Remove(category);
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
            try
            {
                var categories = await _context.Categories
                    .Include(x=>x.Products)
                    .ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
    }
}
