using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]//api/users 
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]//api/users/fdsfdsf
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    /*[HttpGet("~/find")]//api/byName
    public async Task<ActionResult<User>> FindForName(string name)
    {
        return await _context.Users.FindAsync(_context.Users.Where(u =>u.Id==name).ToList());
    }*/
}