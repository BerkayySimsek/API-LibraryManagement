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
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(CategoryAddRequestDto dto)
        {
            _categoryService.Add(dto);
            return Ok("Kategori eklendi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {List<CategoryResponseDto> categories = _categoryService.GetAll();  
            return Ok(categories);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_categoryService.GetById(id));
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok("Kategori Silindi.");
        }
    }
}
