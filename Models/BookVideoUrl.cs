namespace BookStoreServer.Models;

public class BookVideoUrl
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public string CoverImgUrl { get; set; }
    public string VideoUrl { get; set; }
}
