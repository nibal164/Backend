using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoapLush.InputModels;
using SoapLush.Repositories;

namespace SoapLush.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllCategoriesAsync();
            var categoriesDto = new List<Dtos.CategoryDto>();

            categories.ToList().ForEach(category =>
            {
                var categoryDto = new Dtos.CategoryDto()
                {
                    id = category.id,
                    Name = category.Name,
                    Image = category.Image,
                    SubCategories = category.SubCategories,
                };

                categoriesDto.Add(categoryDto);
            });

            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}")]
        [ActionName("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = new Dtos.CategoryDto()
            {
                id = category.id,
                Name = category.Name,
                Image = category.Image,
                SubCategories = category.SubCategories,
            };
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryInputModel createCategoryInputModel)
        {
            var category = new Models.Category()
            {
                Name = createCategoryInputModel.Name,
                Image = createCategoryInputModel.Image,
                SubCategories = createCategoryInputModel.SubCategories,
            };

            category = await categoryRepository.CreateCategoryAsync(category);

            var categoryDto = new Dtos.CategoryDto()
            {
                id = category.id,
                Name = category.Name,
                Image = category.Image,
                SubCategories = category.SubCategories,
            };

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.id }, categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.DeleteCategoryAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new Dtos.CategoryDto()
            {
               id = category.id,
               Name = category.Name,
               Image = category.Image,
               SubCategories = category.SubCategories,
            };

            return Ok(categoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryInputModel updateCategoryInputModel)
        {
            var category = new Models.Category()
            {
                Name = updateCategoryInputModel.Name,
                Image = updateCategoryInputModel.Image,
                SubCategories = updateCategoryInputModel.SubCategories,
            };

            category = await categoryRepository.UpdateCategoryAsync(id, category);

            if (category == null) { return NotFound(); }

            var categoryDto = new Dtos.CategoryDto()
            {
                id = category.id,
                Name = category.Name,
                Image = category.Image,
                SubCategories= category.SubCategories,
            };

            return Ok(categoryDto);
        }

    }
}
