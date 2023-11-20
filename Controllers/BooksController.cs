using AutoMapper;
using BookStoreServer.Context;
using BookStoreServer.Dtos;
using BookStoreServer.Models;
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


    [HttpPost]
    public IActionResult GetBooksByFilter(CategoryDetailRequestDto request)
    {
        var response = new CategoryDetailResponseDto();
        var booksByFilter = _context.BooksCategories
            .Include(bc=>bc.Category)
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
            .Where(bc => bc.CategoryId == request.CategoryId)
            .Select(bc => new BookListResponseDto
            {
                BookId = bc.Book.Id,
                MainImgUrl = bc.Book.MainImgUrl,
                TitleTr = bc.Book.TitleTr,
                TitleEn = bc.Book.TitleEn,
                Prices = bc.Book.BookVariations.Where(bv => bv.FormatEn == Enums.BookFormatEnumEn.Hardcover)
                    .SelectMany(bv => bv.Prices.Select(p => new PriceDto
                    {
                        PriceId = p.Id,
                        PriceAmount = p.PriceAmount,
                        DiscountedPriceAmount = p.DiscountedPriceAmount,
                        PriceCurrency = p.PriceCurrency
                    })).ToList(),
                AuthorName = bc.Book.Author.FullName,
                AuthorId = bc.Book.Author.Id,
                CategoryName = bc.Category.Name,
                PublishDate= bc.Book.BookVariations.FirstOrDefault().ProductDetail.PublicationDate,
                Languages = bc.Book.BookVariations.Where(bv => bv.FormatEn == Enums.BookFormatEnumEn.Hardcover)
                .Select(bv => new LanguageDto
                {
                    LanguageTr = bv.ProductDetail.LanguageTr,
                    LanguageEn = bv.ProductDetail.LanguageEn
                }).ToList(),
                ReviewCount = bc.Book.BookReviews.Count(),
                BookAverageReviewRating =
                bc.Book.BookReviews != null && bc.Book.BookReviews.Any()
                ? Math.Round(bc.Book.BookReviews.Select(br => br.Raiting).Average(), 1, MidpointRounding.AwayFromZero)
                : (double?)null
            }).ToList();

        if (request.AuthorIds.Count!=0)
        {
            List<BookListResponseDto> books = new();
            foreach (var authorId in request.AuthorIds)
            {
                books.AddRange(booksByFilter.Where(b=>b.AuthorId == authorId).ToList());
            }
            booksByFilter = books;
        }
        if(request.Languages.Count!=0)
        {
            List<BookListResponseDto> books = new();
            foreach (var language in request.Languages)
            {
                books.AddRange(booksByFilter.Where(b => b.Languages.Any(l => l.LanguageEn == language || l.LanguageTr == language)).ToList());
            }
            booksByFilter = books;
        }
        if(request.ReviewRatings.Count != 0)
        {
            List<BookListResponseDto> books = new();
            foreach (var reviewRaiting in request.ReviewRatings)
            {
                books.AddRange(booksByFilter.Where(b => b.BookAverageReviewRating==reviewRaiting).ToList());
            }
            booksByFilter = books;
        }

        

        if(!string.IsNullOrEmpty(request.SortFilter))
        {
            switch (request.SortFilter)
            {
                case "popularity":
                    booksByFilter = booksByFilter.OrderByDescending(book => book.ReviewCount).ToList();
                    break;
                case "default":
                    booksByFilter = booksByFilter.OrderByDescending(book => book.BookAverageReviewRating).ToList();
                    break;
                case "date":
                    booksByFilter = booksByFilter.OrderBy(book => book.PublishDate).ToList();
                    break;
                case "price":
                    booksByFilter = booksByFilter.OrderBy(book => book.Prices.FirstOrDefault().PriceAmount).ToList();
                    break;
                case "price-desc":
                    booksByFilter = booksByFilter.OrderByDescending(book => book.Prices.FirstOrDefault().PriceAmount).ToList();
                    break;
                default:
                    break;
            }
        }

        
        response.Data = booksByFilter = booksByFilter
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .ToList();
        response.CategoryName = booksByFilter.FirstOrDefault()?.CategoryName;
        response.TotalPageCount = (int)Math.Ceiling(booksByFilter.Count() / (double)request.PageSize);
        response.IsFirstPage = request.PageNumber == 1;
        response.IsLastPage = request.PageNumber == response.TotalPageCount;

        return Ok(response);
    }

    //Eski API
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
                ReviewCount = bc.Book.BookReviews.Count(),
                BookAverageReviewRating =

                bc.Book.BookReviews != null && bc.Book.BookReviews.Any()
                ? Math.Round(bc.Book.BookReviews.Select(br => br.Raiting).Average(), 1, MidpointRounding.AwayFromZero)
                : (double?)null
                }).ToList();

        return Ok(booksByCategoryId);
    }
}
