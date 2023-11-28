using AutoMapper;
using BookStoreServer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly BookwormDbContext _context;
    private readonly IMapper _mapper;

    public UsersController(BookwormDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserNameById(int userId)
    {
        var userName = _context.Users.Where(u => u.Id==userId).Select(u=>u.Name).FirstOrDefault();
        return Ok(userName);
    }
}
