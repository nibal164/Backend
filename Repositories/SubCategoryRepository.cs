using Microsoft.EntityFrameworkCore;
using SoapLush.Data;
using SoapLush.Models;

namespace SoapLush.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly SoapLushDbContext _soapLushDbContext;
        public SubCategoryRepository(SoapLushDbContext soapLushDbContext)
        {
            this._soapLushDbContext = soapLushDbContext;
        }
        public async Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory)
        {
            await _soapLushDbContext.AddAsync(subCategory);
            await _soapLushDbContext.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> DeleteSubCategoryAsync(int id)
        {
            var category = await _soapLushDbContext.SubCategories.FirstOrDefaultAsync(x => x.id == id);
            if (category == null) { return null; }
            _soapLushDbContext.SubCategories.Remove(category);
            await _soapLushDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await _soapLushDbContext.SubCategories.ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryAsync(int id)
        {
            var subCategory = await _soapLushDbContext.SubCategories.FirstOrDefaultAsync(x => x.id == id);
            if (subCategory == null) { return null; }
            return subCategory;
        }

        public async Task<SubCategory> UpdateSubCategoryAsync(int id, SubCategory subCategory)
        {
            var existingSubCategory = await _soapLushDbContext.SubCategories.FirstOrDefaultAsync(x => x.id == id);
            if (existingSubCategory == null) { return null; }

            existingSubCategory.Name = subCategory.Name;
            existingSubCategory.CategoryId = subCategory.CategoryId;

            await _soapLushDbContext.SaveChangesAsync();
            return existingSubCategory;
        }
    }
}
