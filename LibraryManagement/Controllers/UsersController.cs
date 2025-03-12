using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserRepository userRepository = new UserRepository();

    [HttpPost("add")]
    public IActionResult Add(User user)
    {
        userRepository.Add(user);
        return Ok("Kullanıcı eklendi.");
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(string id)
    {
        Guid newId = Guid.Parse(id);
        User user=userRepository.GetById(newId);
        return Ok(user);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<User> users = userRepository.GetAll();
        return Ok(users);
    }
}
