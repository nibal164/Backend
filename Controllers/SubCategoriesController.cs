using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoapLush.InputModels;
using SoapLush.Repositories;

namespace SoapLush.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryRepository subCategoryRepository;

        public SubCategoriesController(ISubCategoryRepository subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var subCategories = await subCategoryRepository.GetAllSubCategoriesAsync();
            var subCategoriesDto = new List<Dtos.SubCategoryDto>();

            subCategories.ToList().ForEach(subCategory =>
            {
                var subCategoryDto = new Dtos.SubCategoryDto()
                {
                    id = subCategory.id,
                    Name = subCategory.Name,
                    CategoryId = subCategory.CategoryId,
                };

                subCategoriesDto.Add(subCategoryDto);
            });

            return Ok(subCategoriesDto);
        }

        [HttpGet("{id:int}")]
        [ActionName("GetSubCategoryById")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var subCategory = await subCategoryRepository.GetSubCategoryAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            var subCategoryDto = new Dtos.SubCategoryDto()
            {
               id = subCategory.id,
               Name = subCategory.Name,
               CategoryId = subCategory.CategoryId,

            };
            return Ok(subCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryInputModel createSubCategoryInputModel)
        {
            var subCategory = new Models.SubCategory()
            {
               Name = createSubCategoryInputModel.Name,
               CategoryId = createSubCategoryInputModel.CategoryId,
            };

            subCategory = await subCategoryRepository.CreateSubCategoryAsync(subCategory);

            var subCategoryDto = new Dtos.SubCategoryDto()
            {
               id = subCategory.id,
               Name = subCategory.Name,
               CategoryId = subCategory.CategoryId,
            };

            return CreatedAtAction(nameof(GetSubCategoryById), new { id = subCategoryDto.id }, subCategoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await subCategoryRepository.DeleteSubCategoryAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            var subCategoryDto = new Dtos.SubCategoryDto()
            {
                id = subCategory.id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,

            };

            return Ok(subCategoryDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSubCategory(int id, UpdateSubCategoryInputModel updateSubCategoryInputModel)
        {
            var subCategory = new Models.SubCategory()
            {
                Name = updateSubCategoryInputModel.Name,
                CategoryId= updateSubCategoryInputModel.CategoryId,
            };

            subCategory = await subCategoryRepository.UpdateSubCategoryAsync(id, subCategory);

            if (subCategory == null) { return NotFound(); }

            var subCategoryDto = new Dtos.SubCategoryDto()
            {
                id = subCategory.id,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId,

            };

            return Ok(subCategoryDto);
        }
    }
}
