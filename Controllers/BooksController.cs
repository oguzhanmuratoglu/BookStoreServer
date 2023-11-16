using AutoMapper;
using BookStoreServer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BooksController : ControllerBase
{

    private readonly BookwormDbContext _context;
    private readonly IMapper _mapper;

    public BooksController(BookwormDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet("{id}")]
    public IActionResult GetBooksByCategoryId(int id)
    {
        var booksByCategoryId = _context.BooksCategories
            .Where(bc => bc.CategoryId == id)
            .Select(bc => bc.Book).ToList();

        return Ok(booksByCategoryId);
    }
}
