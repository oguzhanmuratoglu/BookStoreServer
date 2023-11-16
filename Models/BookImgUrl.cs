﻿namespace BookStoreServer.Models;

public class BookImgUrl
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public string ImgUrl { get; set; }
}
