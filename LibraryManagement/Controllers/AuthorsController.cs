using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Authors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    IAuthorRepository authorRepository = new AuthorRepository();

    [HttpPost("add")]
    public IActionResult Add(AuthorAddRequestDto dto)
    {
        DateTime birthDate = new DateTime(dto.BirthYear, dto.BirthMonth, dto.BirthDay);
        Author author = new Author()
        {
            FirstName = dto.FirstName,
            SurName = dto.SurName,
            BirthDate = birthDate,
        };
        authorRepository.Add(author);

        return Ok("Yazar Eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Author> authors = authorRepository.GetAll();

        List<AuthorResponseDto> responses = new List<AuthorResponseDto>();

        foreach (Author author in authors)
        {
            AuthorResponseDto authorResponseDto = new AuthorResponseDto()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                SurName = author.SurName,
                BirthDay = author.BirthDate.Day,
                BirthMonth = author.BirthDate.Month,
                BirthYear = author.BirthDate.Year,
            };
            responses.Add(authorResponseDto);
        }

        return Ok(responses);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        Author authors = authorRepository.GetById(id);
        return Ok(authors);
    }
}
