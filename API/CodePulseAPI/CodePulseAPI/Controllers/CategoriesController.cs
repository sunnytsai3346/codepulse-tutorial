using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulseAPI.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var categorylist = await categoryRepository.GetListAsync();
            List<CategoryDto> response = new List<CategoryDto>();
            foreach (var category in categorylist)
            {
                CategoryDto o = new CategoryDto
                {
                    Name = category.Name,
                    UrlHandle = category.UrlHandle,
                    Id = category.Id
                };
                response.Add(o);

            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            }; 
            // call categoryRepository 
            // with respsitory pattern , controller doesn't need to know how about dbcontext
            await categoryRepository.CreateAsync(category);

            // Domain Model to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }
        [HttpGet]
        [Route("/api/Categories/{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            //Model to Dto
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

        }
        [HttpPut]
        [Route("/api/Categories/{id:Guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id,CategoryDto request)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            
            //DTO to model 
            category.Name = request.Name;
            category.UrlHandle = request.UrlHandle;   
            
            category =await categoryRepository.UpdateAsync(category);
                       
            return Ok(category);

        }

        [HttpDelete]
        [Route("/api/Categories/{id:Guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            
            category = await categoryRepository.RemoveAsync(category);

            return Ok(category);

        }
    }
}
