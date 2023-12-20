using AutoMapper;
using BookStoreServer.Context;
using BookStoreServer.Dtos;
using BookStoreServer.Models;
using BookStoreServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly BookwormDbContext _context;
    private readonly IMapper _mapper;
    private readonly JwtService _jwtService;

    public UsersController(BookwormDbContext context, IMapper mapper, JwtService jwtService)
    {
        _context = context;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    [HttpPost]
    public IActionResult LoginUser(LoginRequestDto request)
    {
        var user = _context.Users.Where(u => u.DisplayName == request.UserNameOrEmail 
        || u.Email == request.UserNameOrEmail).FirstOrDefault();
        if (user == null)
        {
            return BadRequest(new { Message = "No user registered in the system was found!" });
        }
        if (user.Password != request.Password)
        {
            return BadRequest(new { Message = "Wrong Password!" });
        }

        var token = _jwtService.CreateToken(user, request.RememberMe);

        return Ok(new { AccessToken = token });
    }

    [HttpPost]
    public IActionResult CreateUser(User userRequest)
    {
        var hasEmail = _context.Users.Any(u=>u.Email == userRequest.Email);
        var hasUserName = _context.Users.Any(u => u.DisplayName == userRequest.DisplayName);
        if (hasEmail)
        {
            return BadRequest(new {Message = "This user is already registered! Please try with a different email address." });
        }
        if (hasUserName)
        {
            return BadRequest(new { Message = "This user is already registered! Please try with a different user name." });
        }
        _context.Users.Add(userRequest);
        _context.SaveChanges();
        return Ok(new { Message = "The process was successful and the user was created" });
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserNameById(int userId)
    {
        var userName = _context.Users.Where(u => u.Id==userId).Select(u=>u.Name).FirstOrDefault();
        return Ok(userName);
    }
}
