using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoapLush.InputModels;
using SoapLush.Repositories;

namespace SoapLush.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllProductsAsync();
            var productsDto = new List<Dtos.ProductDto>();

            products.ToList().ForEach(product =>
            {
                var productDto = new Dtos.ProductDto()
                {
                    id = product.id,
                    Name = product.Name,
                    Image = product.Image,
                    Description= product.Description,
                    Ingredients= product.Ingredients,
                    Price= product.Price,
                    CategoryId = product.CategoryId,
                    SubCategoryId= product.SubCategoryId,
                };

                productsDto.Add(productDto);
            });

            return Ok(productsDto);
        }

        [HttpGet("{id:int}")]
        [ActionName("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productRepository.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = new Dtos.ProductDto()
            {
                id= product.id,
                Name = product.Name,
                Image = product.Image,
                Description= product.Description,
                Ingredients= product.Ingredients,
                Price= product.Price,
                CategoryId= product.CategoryId,
                SubCategoryId= product.SubCategoryId,
            };
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductInputModel createProductInputModel)
        {
            var product = new Models.Product()
            {
                Name = createProductInputModel.Name,
                Image = createProductInputModel.Image,
                Description = createProductInputModel.Description,
                Ingredients = createProductInputModel.Ingredients,
                Price = createProductInputModel.Price,
                CategoryId = createProductInputModel.CategoryId,
            };

            product = await productRepository.CreateProductAsync(product);

            var productDto = new Dtos.ProductDto()
            {
                id = product.id,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Ingredients = product.Ingredients,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
            };

            return CreatedAtAction(nameof(GetProductById), new {id =productDto.id}, productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productRepository.DeleteProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = new Dtos.ProductDto()
            {
                id = product.id,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Ingredients = product.Ingredients,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
            };

            return Ok(productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductInputModel updateProductInputModel)
        {
            var product = new Models.Product()
            {
                Name = updateProductInputModel.Name,
                Image = updateProductInputModel.Image,
                Description = updateProductInputModel.Description,
                Ingredients = updateProductInputModel.Ingredients,
                Price = updateProductInputModel.Price,
                CategoryId = updateProductInputModel.CategoryId,
                SubCategoryId = updateProductInputModel.SubCategoryId,
            };

            product = await productRepository.UpdateProductAsync(id, product);

            if (product == null) { return NotFound(); }

            var productDto = new Dtos.ProductDto()
            {
                id = product.id,
                Name = product.Name,
                Image = product.Image,
                Description = product.Description,
                Ingredients = product.Ingredients,
                Price = product.Price,
                CategoryId = product.CategoryId,
                SubCategoryId = product.SubCategoryId,
            };

            return Ok(productDto);
        }
    }
}
