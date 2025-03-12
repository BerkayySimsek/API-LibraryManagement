using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Categories;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService categoryService = new CategoryService();
        ICategoryRepository categoryRepository = new CategoryRepository();

        [HttpPost("add")]
        public IActionResult Add(CategoryAddRequestDto dto)
        {
            categoryService.Add(dto);
            return Ok("Kategori eklendi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            return Ok(categoryService.GetById(id));
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return Ok("Kategori Silindi.");
        }
    }
}
