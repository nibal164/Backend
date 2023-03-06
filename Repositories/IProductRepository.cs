using SoapLush.Models;

namespace SoapLush.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(int id, Product product);

        Task<Product> DeleteProductAsync(int id);
    }
}
