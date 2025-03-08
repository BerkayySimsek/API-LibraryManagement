using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
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

    IBookService bookService = new BookService();

    // HttpGet  : Kaynaktan veri okuma işlemleri için kullanılır.
    // HttpPost : Kaynağa veri ekleme, silme, güncelleme işlemleri için kullanılır.

    [HttpPost("add")]
    public IActionResult Add(BookAddRequestDto dto)
    {
        // INSERT INTO BOOKS() VALUES();

        bookService.Add(dto);
        return Ok("Başarıyla eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        // SELECT * FROM Books

        List<BookResponseDto> books = bookService.GetAll();

        return Ok(books);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        // SELECT * FROM Books WHERE Id = 1

        // Book book = context.Books.FirstOrDefault(x => x.Id == id);

        // Book book = context.Books.Find(id);

        BookResponseDto book = bookService.GetById(id);

        // Book book = context.Books.Where(x => x.Id == id).SingleOrDefault();

        return Ok(book);
    }
    [HttpDelete("delete")]
    public IActionResult DeleteById(int id)
    {
        bookService.Delete(id);
        return Ok("Başarıyla silindi.");
    }
}
