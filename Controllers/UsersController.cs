using Microsoft.AspNetCore.Mvc;
using MinhaApiEstudo.Data;
using MinhaApiEstudo.Models;

namespace MinhaApiEstudo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Users.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingUser = _context.Users.Find(id);
        if (existingUser == null)
        {
            return NotFound();
        }
        return Ok(existingUser);
    }


    [HttpPost]
    public IActionResult Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        var existingUser = _context.Users.Find(id);
        if (existingUser == null)
        {
            return NotFound();
        }
        existingUser.Nome = user.Nome;
        existingUser.Email = user.Email;
        existingUser.Endereco = user.Endereco;
        _context.SaveChanges();
        return Ok(existingUser);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }

}