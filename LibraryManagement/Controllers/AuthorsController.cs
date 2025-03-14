using LibraryManagement.Models.Dtos.Authors;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private IAuthorService _authorService;
    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost("add")]
    public IActionResult Add(AuthorAddRequestDto dto)
    {
        _authorService.Add(dto);
        return Ok("Yazar Eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_authorService.GetAll());
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        return Ok(_authorService.GetById(id));
    }
    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _authorService.Delete(id);
        return Ok("Yazar Silindi.");
    }
}
