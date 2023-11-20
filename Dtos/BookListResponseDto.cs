﻿using BookStoreServer.Models;

namespace BookStoreServer.Dtos;

public class BookListResponseDto
{
    public int BookId { get; set; }
    public string MainImgUrl { get; set; }
    public string TitleTr { get; set; }
    public string TitleEn { get; set; }
    public List<PriceDto> Prices { get; set; }
    public string AuthorName { get; set; }
    public int AuthorId { get; set; }
    public double? BookAverageReviewRating { get; set; }
    public int ReviewCount { get; set; }
    public List<LanguageDto> Languages { get; set; }
    public DateTime PublishDate { get; set; }
    public string CategoryName { get; set; }
}
