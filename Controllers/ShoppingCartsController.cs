using AutoMapper;
using BookStoreServer.Context;
using BookStoreServer.Dtos;
using BookStoreServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace BookStoreServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ShoppingCartsController : ControllerBase
{

    private readonly BookwormDbContext _context;
    private readonly IMapper _mapper;

    public ShoppingCartsController(BookwormDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddItemToCart(CartItemRequestDto request)
    {
        var cartId = _context.ShoppingCarts.Where(s => s.UserId == request.UserId).Select(s => s.Id).FirstOrDefault();

        if (cartId ==0)
        {
            var cart = new ShoppingCart
            {
                UserId = request.UserId,
                ShoppingCartItems = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem
                    {
                        BookVariationId = request.BookVariationId,
                        Quantity = request.Quantity,
                    }
                }
            };
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
        }
        else
        {
            var cartItem = new ShoppingCartItem
            {
                BookVariationId = request.BookVariationId,
                Quantity = request.Quantity,
                ShoppingCartId = cartId,
            };

            _context.ShoppingCartItems.Add(cartItem);
            _context.SaveChanges();
        }

        return NoContent();
    }

    [HttpPost]
    public IActionResult RemoveCartItemFromDatabase(CartItemRequestDto request)
    {
        var cartId = _context.ShoppingCarts.Where(s=>s.UserId== request.UserId).Select(s=>s.Id).FirstOrDefault();

        var cartItem = _context.ShoppingCartItems
            .FirstOrDefault(c => c.ShoppingCartId == cartId && c.BookVariationId == request.BookVariationId);
        if (cartItem != null)
        {
            _context.ShoppingCartItems.Remove(cartItem);
            _context.SaveChanges();
        }
        return NoContent();
    }

    [HttpGet("{userId}")]
    public IActionResult GetDataFromDatabase(int userId)
    {
        var result = _context.ShoppingCarts
            .Where(s => s.UserId == userId)
            .Include(s => s.ShoppingCartItems).ThenInclude(sci => sci.BookVariation)
            .Select(s => new
            {
                ShoppingCartItems = s.ShoppingCartItems.Select(sci => new
                {
                    Book = _context.Books
                        .Include(b => b.Author)
                        .Include(b => b.BookVariations)
                            .ThenInclude(bv => bv.Prices)
                        .Include(b => b.BookReviews)
                        .Where(b => b.BookVariations.Any(bv => bv.Id == sci.BookVariationId))
                        .Select(dto => new Book
                        {
                            Id = dto.Id,
                            Author = dto.Author,
                            AuthorId = dto.AuthorId,
                            BookImgUrls = dto.BookImgUrls,
                            BookReviews = dto.BookReviews,
                            BookVideoUrls = dto.BookVideoUrls,
                            DescriptionEn = dto.DescriptionEn,
                            TitleEn = dto.TitleEn,
                            DescriptionTr = dto.DescriptionTr,
                            MainImgUrl = dto.MainImgUrl,
                            ISBN = dto.ISBN,
                            SubTitleEn = dto.SubTitleEn,
                            SubTitleTr = dto.SubTitleTr,
                            TitleTr = dto.TitleTr,
                            VisitedCount = dto.VisitedCount,
                            BookVariations = dto.BookVariations
                                .Where(bv => bv.Id == sci.BookVariationId)
                                .ToList()
                        }).FirstOrDefault(),

                    Quantity = sci.Quantity
                })
                .ToList(),
            })
            .ToList();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult SetDataFromLocalStorage(ShoppingCartDto cartDto)
    {
        var shoppingCart = _context.ShoppingCarts
                            .Include(s=>s.ShoppingCartItems).FirstOrDefault(s=>s.UserId==cartDto.UserId);
        if (shoppingCart != null)
        {

            for (int i = 0; i < cartDto.ShoppingCartItems.Count; i++)
            {
                var cartItem = new ShoppingCartItem
                {
                    BookVariationId = cartDto.ShoppingCartItems[i].BookVariationId,
                    Quantity = cartDto.ShoppingCartItems[i].Quantity
                };
                shoppingCart.ShoppingCartItems.Add(cartItem);
            }
            _context.ShoppingCarts.Update(shoppingCart);
            _context.SaveChanges();
        }
        else
        {
            var cart = new ShoppingCart
            {
                UserId = cartDto.UserId,
                ShoppingCartItems = new List<ShoppingCartItem>()
            };

            for (int i = 0; i < cartDto.ShoppingCartItems.Count; i++)
            {
                var cartItem = new ShoppingCartItem
                {
                    BookVariationId = cartDto.ShoppingCartItems[i].BookVariationId,
                    Quantity = cartDto.ShoppingCartItems[i].Quantity
                };
                cart.ShoppingCartItems.Add(cartItem);
            }

            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
        }

        return NoContent();
    }

    [HttpGet("{code}")]
    public IActionResult CheckCouponsCode(string code)
    {
        var dateTimeNow = DateTime.Now;

        var coupon = _context.Coupons.Where(c => c.Code == code).FirstOrDefault();
        if (coupon is null)
        {
            return NotFound(new { Message = "No coupon was found for the code you entered!", IsActivated = false });
        }
        TimeSpan couponExpiredTime = coupon.EndDate - dateTimeNow;

        if (couponExpiredTime.TotalMinutes < 0)
        {
            return BadRequest(new { Message = "The coupon has expired. Please try again with another coupon!", IsActivated = false });
        }
        if (coupon.Quantity <= 0)
        {
            return BadRequest(new { Message = "This coupon has expired. Please try again with another coupon!", IsActivated = false });
        }
        if (!coupon.IsActivated)
        {
            return BadRequest(new { Message = "This is not active. Please try again with another coupon!", IsActivated = false });
        }
        coupon.Quantity--;
        _context.Update(coupon);
        _context.SaveChanges();
        var entity = _mapper.Map<Coupon, CouponResponseDto>(coupon);

        return Ok(entity);

    }
}
