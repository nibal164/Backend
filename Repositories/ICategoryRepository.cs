using SoapLush.Models;

namespace SoapLush.Repositories
{
    public interface ICategoryRepository
    {
        Task <IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryAsync(int id);

        Task<Category> DeleteCategoryAsync(int id);

        Task<Category> CreateCategoryAsync(Category category);

        Task<Category> UpdateCategoryAsync(int id, Category category);
    }
}
