using AutoMapper;
using BookStoreServer.Context;
using BookStoreServer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            .Include(bc => bc.Book)
                .ThenInclude(b => b.BookVariations)
                    .ThenInclude(bv => bv.Prices)
            .Include(bc => bc.Book)
                .ThenInclude(b => b.BookVariations)
                    .ThenInclude(bv => bv.ProductDetail)
            .Include(bc => bc.Book)
                .ThenInclude(b => b.Author)
            .Include(bc => bc.Book)
                .ThenInclude(b => b.BookReviews)
            .Where(bc => bc.CategoryId == id)
            .Select(bc => new BookListResponseDto
            {
                BookId = bc.Book.Id,
                MainImgUrl = bc.Book.MainImgUrl,
                TitleTr = bc.Book.TitleTr,
                TitleEn = bc.Book.TitleEn,
                Prices = bc.Book.BookVariations.Where(bv=>bv.FormatEn==Enums.BookFormatEnumEn.Hardcover)
                    .SelectMany(bv => bv.Prices.Select(p => new PriceDto
                    {
                        PriceId = p.Id,
                        PriceAmount = p.PriceAmount,
                        DiscountedPriceAmount = p.DiscountedPriceAmount,
                        PriceCurrency = p.PriceCurrency
                    })).ToList(),
                AuthorName = bc.Book.Author.FullName,
                AuthorId = bc.Book.Author.Id,
                Languages = bc.Book.BookVariations.Where(bv=>bv.FormatEn == Enums.BookFormatEnumEn.Hardcover)
                .Select(bv => new LanguageDto
                {
                    LanguageTr = bv.ProductDetail.LanguageTr,
                    LanguageEn = bv.ProductDetail.LanguageEn
                }).ToList(),
                BookAverageReviewRating = 
                bc.Book.BookReviews != null && bc.Book.BookReviews.Any()
                ? bc.Book.BookReviews.Select(br => br.Raiting).Average()
                : (double?)null
            }).ToList();

        return Ok(booksByCategoryId);
    }
}
