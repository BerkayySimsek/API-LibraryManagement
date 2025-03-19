using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Exceptions.Type;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Books;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    // http://localhost:5271/api/Book/add

    private IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // HttpGet  : Kaynaktan veri okuma işlemleri için kullanılır.
    // HttpPost : Kaynağa veri ekleme, silme, güncelleme işlemleri için kullanılır.

    [HttpPost("add")]
    public IActionResult Add(BookAddRequestDto dto)
    {
            _bookService.Add(dto);
            return Ok("Başarıyla eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        // SELECT * FROM Books

        List<BookResponseDto> books = _bookService.GetAll();

        return Ok(books);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
             
            // Book book = context.Books.Where(x => x.Id == id).SingleOrDefault();

            BookResponseDto book = _bookService.GetById(id);
            return Ok(book);
        
    }
    [HttpDelete("delete")]
    public IActionResult DeleteById(int id)
    {
        _bookService.Delete(id);
        return Ok("Başarıyla silindi.");
    }
}
