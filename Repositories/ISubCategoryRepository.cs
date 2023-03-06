using SoapLush.Models;

namespace SoapLush.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync();

        Task<SubCategory> GetSubCategoryAsync(int id);

        Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory);

        Task<SubCategory> UpdateSubCategoryAsync(int id, SubCategory subCategory);

        Task<SubCategory> DeleteSubCategoryAsync(int id);
    }
}
