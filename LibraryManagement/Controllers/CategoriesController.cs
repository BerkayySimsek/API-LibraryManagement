using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
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
        ICategoryRepository categoryRepository = new CategoryRepository();

        [HttpPost("add")]
        public IActionResult Add(CategoryAddRequestDto dto)
        {
            Category category = new Category()
            {
                Name = dto.Name,
            };
            categoryRepository.Add(category);

            return Ok("Kategori Eklendi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
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
            Category category = categoryRepository.GetById(id);
            return Ok(category);
        }

    }
}
