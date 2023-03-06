using Microsoft.EntityFrameworkCore;
using SoapLush.Data;
using SoapLush.Models;
using System.Collections.Immutable;

namespace SoapLush.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SoapLushDbContext _soapLushDbContext;
        public ProductRepository(SoapLushDbContext soapLushDbContext)
        {
            this._soapLushDbContext = soapLushDbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _soapLushDbContext.Products.AddAsync(product);
            await _soapLushDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await _soapLushDbContext.Products.FirstOrDefaultAsync(x => x.id == id);
            if (product == null)
            {
                return null;
            }
            _soapLushDbContext.Products.Remove(product);
            await _soapLushDbContext.SaveChangesAsync(); 
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _soapLushDbContext.Products.ToListAsync();

        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _soapLushDbContext.Products.FirstOrDefaultAsync(x => x.id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _soapLushDbContext.Products.FirstOrDefaultAsync(x => x.id == id);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Ingredients= product.Ingredients;
            existingProduct.Image= product.Image;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.SubCategoryId = product.SubCategoryId;

            await _soapLushDbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
