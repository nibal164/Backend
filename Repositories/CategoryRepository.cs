using Microsoft.EntityFrameworkCore;
using SoapLush.Data;
using SoapLush.Models;

namespace SoapLush.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SoapLushDbContext _soapLushDbContext;
        public CategoryRepository(SoapLushDbContext soapLushDbContext)
        {
            this._soapLushDbContext = soapLushDbContext;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _soapLushDbContext.Categories.AddAsync(category);
            await _soapLushDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await _soapLushDbContext.Categories.FirstOrDefaultAsync(x => x.id == id);
            if (category == null) { return null; }
            _soapLushDbContext.Categories.Remove(category);
            await _soapLushDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _soapLushDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _soapLushDbContext.Categories.FirstOrDefaultAsync(x => x.id == id);
            if (category == null)
            {
                return null;
            }

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await _soapLushDbContext.Categories.FirstOrDefaultAsync(x => x.id ==id);
            if (existingCategory == null) { return null; }

            existingCategory.Name= category.Name;
            existingCategory.Image = category.Image;
            existingCategory.SubCategories = category.SubCategories;

            return  existingCategory;

        }
    }
}
