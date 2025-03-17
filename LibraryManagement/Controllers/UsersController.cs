
using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Exceptions.Type;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Users;
using LibraryManagement.Services.Abstracts;
using LibraryManagement.Services.Concretes;
using Microsoft.AspNetCore.Mvc;



namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost("add")]
    public IActionResult Add(UserAddRequestDto user)
    {
        _userService.Add(user);
        return Ok("Kullanıcı eklendi.");
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(string id)
    {
        try
        {
            UserResponseDto userResponseDto = _userService.GetById(id);
            return Ok(userResponseDto);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }   
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("getbyemail")]
    public IActionResult GetByEmail(string email)
    {
        UserResponseDto userResponseDto = _userService.GetByEmail(email);
        return Ok(userResponseDto);
    }
}
