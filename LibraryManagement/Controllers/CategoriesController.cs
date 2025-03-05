using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private BaseDbContext dbContext = new BaseDbContext();

        [HttpPost("add")]
        public IActionResult Add(CategoryAddRequestDto dto)
        {
            Category category = new Category()
            {
                Name = dto.Name,
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            return Ok("Kategori Eklendi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Category> categories = dbContext.Categories.ToList();
            List<CategoryResponseDto> responses = new List<CategoryResponseDto>();

            foreach (Category category in categories)
            {
                CategoryResponseDto categoryResponseDto = new CategoryResponseDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                };
                responses.Add(categoryResponseDto);
            }
            return Ok(responses);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            Category category = dbContext.Categories.SingleOrDefault(x => x.Id == id);
            return Ok(category);
        }

    }
}
