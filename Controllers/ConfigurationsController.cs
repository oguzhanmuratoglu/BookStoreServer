using BookStoreServer.Context;
using BookStoreServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace BookStoreServer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ConfigurationsController : ControllerBase
{
    BookwormDbContext _context = new BookwormDbContext();


    [HttpGet]
    public IActionResult AddAUser()
    {
        var user1 = new User
        {
            Name = "Ali",
            LastName = "Yılmaz",
            DisplayName = "ali_34",
            Email = "ali@gmail.com",
            Password = "123456",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "ali@gmail.com",
            ContactName = "Ali Yılmaz",
            ContactPhoneNumber = "05551234567",
            City = "İSTANBUL",
            Country = "Turkey",
            ZipCode ="34000",
            AddressDescription = "Kadıköy Mah. Aydın Apt. No: 5/2 Kadıköy/İstanbul",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "ali@gmail.com",
            ContactName = "Ali Yılmaz",
            ContactPhoneNumber = "05551234567",
            City = "İSTANBUL",
            Country = "Turkey",
            ZipCode ="34000",
            AddressDescription = "Kadıköy Mah. Aydın Apt. No: 5/2 Kadıköy/İstanbul",
        }
    }
        };

        var user2 = new User
        {
            Name = "Ayşe",
            LastName = "Kaya",
            DisplayName = "ayse_28",
            Email = "ayse@gmail.com",
            Password = "abcdef",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "ayse@gmail.com",
            ContactName = "Ayşe Kaya",
            ContactPhoneNumber = "05557654321",
            City = "ANKARA",
            Country = "Turkey",
            ZipCode ="06000",
            AddressDescription = "Çankaya Mah. Gül Sok. No: 10/3 Çankaya/Ankara",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "ayse@gmail.com",
            ContactName = "Ayşe Kaya",
            ContactPhoneNumber = "05557654321",
            City = "ANKARA",
            Country = "Turkey",
            ZipCode ="06000",
            AddressDescription = "Çankaya Mah. Gül Sok. No: 10/3 Çankaya/Ankara",
        }
    }
        };

        var user3 = new User
        {
            Name = "Mehmet",
            LastName = "Kurtuluş",
            DisplayName = "mehmet_45",
            Email = "mehmet@gmail.com",
            Password = "789012",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "mehmet@gmail.com",
            ContactName = "Mehmet Kurtuluş",
            ContactPhoneNumber = "05559876543",
            City = "İZMİR",
            Country = "Turkey",
            ZipCode ="35000",
            AddressDescription = "Konak Mah. Atatürk Cad. No: 15/4 Konak/İzmir",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "mehmet@gmail.com",
            ContactName = "Mehmet Kurtuluş",
            ContactPhoneNumber = "05559876543",
            City = "İZMİR",
            Country = "Turkey",
            ZipCode ="35000",
            AddressDescription = "Konak Mah. Atatürk Cad. No: 15/4 Konak/İzmir",
        }
    }
        };

        var user4 = new User
        {
            Name = "Fatma",
            LastName = "Şahin",
            DisplayName = "fatma_23",
            Email = "fatma@gmail.com",
            Password = "xyz789",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "fatma@gmail.com",
            ContactName = "Fatma Şahin",
            ContactPhoneNumber = "05551234567",
            City = "ISTANBUL",
            Country = "Turkey",
            ZipCode ="34000",
            AddressDescription = "Levent Mah. Cemal Sk. No: 7/3 Levent/ISTANBUL",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "fatma@gmail.com",
            ContactName = "Fatma Şahin",
            ContactPhoneNumber = "05551234567",
            City = "ISTANBUL",
            Country = "Turkey",
            ZipCode ="34000",
            AddressDescription = "Levent Mah. Cemal Sk. No: 7/3 Levent/ISTANBUL",
        }
    }
        };

        var user5 = new User
        {
            Name = "Mustafa",
            LastName = "Yılmaz",
            DisplayName = "mustafa_56",
            Email = "mustafa@gmail.com",
            Password = "abc123",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "mustafa@gmail.com",
            ContactName = "Mustafa Yılmaz",
            ContactPhoneNumber = "05557654321",
            City = "ANKARA",
            Country = "Turkey",
            ZipCode ="06000",
            AddressDescription = "Kızılay Mah. Atatürk Cad. No: 12/5 Kızılay/ANKARA",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "mustafa@gmail.com",
            ContactName = "Mustafa Yılmaz",
            ContactPhoneNumber = "05557654321",
            City = "ANKARA",
            Country = "Turkey",
            ZipCode ="06000",
            AddressDescription = "Kızılay Mah. Atatürk Cad. No: 12/5 Kızılay/ANKARA",
        }
    }
        };

        var user6 = new User
        {
            Name = "Zeynep",
            LastName = "Güneş",
            DisplayName = "zeynep_78",
            Email = "zeynep@gmail.com",
            Password = "def456",

            Addresses = new List<Address>
    {
        new Address
        {
            AddressType = "Billing",
            ContactEmail = "zeynep@gmail.com",
            ContactName = "Zeynep Güneş",
            ContactPhoneNumber = "05559876543",
            City = "IZMIR",
            Country = "Turkey",
            ZipCode ="35000",
            AddressDescription = "Alsancak Mah. İnönü Cad. No: 20/2 Alsancak/IZMIR",
        },
        new Address
        {
            AddressType = "Shipping",
            ContactEmail = "zeynep@gmail.com",
            ContactName = "Zeynep Güneş",
            ContactPhoneNumber = "05559876543",
            City = "IZMIR",
            Country = "Turkey",
            ZipCode ="35000",
            AddressDescription = "Alsancak Mah. İnönü Cad. No: 20/2 Alsancak/IZMIR",
        }
    }
        };


        _context.Users.AddRange(user1, user2, user3, user4, user5, user6);
        _context.SaveChanges();

        return Ok(_context.Users.ToList());
    }

    [HttpGet]
    public IActionResult AddAuthor()
    {
        var author = new Author
        {
            FullName = "İlber Ortaylı",
            BiographyEn = @"İlber Ortaylı is a Turkish historian, writer and academic born in Vienna on July 4, 1947. After studying at Ankara University Faculty of Languages, History and Geography, he completed his doctorate on Medieval and Modern History at Paris-Sorbonne University. Ortaylı, who is considered one of the important historians of Turkey, is especially known for his studies on the history of the Ottoman Empire and his popular history books. In addition, he gave lectures at various universities and instilled historical awareness in large audiences with national television programs. İlber Ortaylı, known for his knowledge of languages and deep history, is known as one of the important names in the field of history in Turkey.",
            BiographyTr = @"İlber Ortaylı, 4 Temmuz 1947 tarihinde Viyana'da doğan Türk tarihçi, yazar ve akademisyendir. Ankara Üniversitesi Dil ve Tarih-Coğrafya Fakültesi'nde öğrenim gördükten sonra, Paris-Sorbonne Üniversitesi'nde Ortaçağ ve Yakınçağ Tarihi üzerine doktorasını tamamlamıştır. Türkiye'nin önemli tarihçilerinden biri olarak kabul edilen Ortaylı, özellikle Osmanlı İmparatorluğu tarihi üzerine yaptığı çalışmalar ve popüler tarih kitaplarıyla tanınır. Ayrıca, çeşitli üniversitelerde dersler vermiş ve ulusal-televizyon programlarıyla geniş kitlelere tarih bilinci aşılamıştır. Dil bilgisi ve derin tarih bilgisiyle tanınan İlber Ortaylı, Türkiye'de tarih alanındaki önemli isimlerden biri olarak bilinmektedir.",
            ProfilePhotoImgUrl = "https://yt3.googleusercontent.com/ytc/APkrFKY_Y8RfewUFjc6JcVxtciOMCaF85QAw8Pgbe6sE=s900-c-k-c0x00ffffff-no-rj"
        };
        _context.Authors.Add(author);
        _context.SaveChanges();
        return Ok(_context.Authors.ToList());
    }



    [HttpGet]
    public  async Task<IActionResult> AddSampleBook()
    {
        var random = new Random();

        // Kullanıcı sayısını alın
        var userCount = _context.Users.Count();

        // Rastgele bir indeks oluşturun
        var randomIndex = random.Next(1, userCount + 1);

        // Oluşturulan indeksteki kullanıcıyı seçin
        var randomUser = _context.Users.Skip(randomIndex - 1).FirstOrDefault();

        var book = new Book
        {
            AuthorId = _context.Authors.Where(p=>p.FullName == "İlber Ortaylı").FirstOrDefault().Id,
            TitleTr = "Cumhuriyet’in Doğuşu: Kurtuluş ve Kuruluş Yılları",
            TitleEn = "Birth of the Republic: Years of Independence and Foundation",
            SubTitleTr = @"İLBER ORTAYLI'NIN KALEMİNDEN KURTULUŞ VE KURULUŞ YILLARI
""Türkiye Cumhuriyeti'ni kuran insanlar basit maceracılar, küskünler veya kendine yer arayanlar değildir. Her birinin imparatorlukta komutan olarak, bürokrat olarak, münevver olarak seçkin bir yeri zaten vardı. Türkiye Cumhuriyeti'ni kuran insanların idealini takip etmemiz gerekiyor. Çünkü onlar devrin modası olan demokrasi düşmanlığına değil, kurdukları cumhuriyetin demokrasi niyetli bir devlet olarak devamına çalıştılar. Hepsini şükranla anıyoruz ve anmalıyız.""
- İlber Ortaylı",
            SubTitleEn = @"THE YEARS OF Liberation AND FOUNDATION FROM THE PEN OF İLBER ORTAYLI
""The people who founded the Republic of Turkey were not simple adventurers, resentful people, or those looking for a place for themselves. Each of them already had a distinguished place in the empire as commanders, bureaucrats, and intellectuals. We need to follow the ideals of the people who founded the Republic of Turkey. Because they were the fashionable people of the time."" ""They worked not for hostility towards democracy, but for the continuation of the republic they founded as a state with democratic intentions. We remember and should remember all of them with gratitude.""
- İlber Ortaylı",
            MainImgUrl = "https://m.media-amazon.com/images/I/719G9fwtWdL._SL1200_.jpg",
            ISBN = "6256774019",
            Quantity = 100,
            DescriptionEn = @"The book ""Birth of the Republic: Years of Independence and Foundation"" is a reference book that deals in depth with the birth and founding years of the Republic, which was a turning point in Turkey's history. This work, written by İlber Ortaylı, presents from an illuminating perspective the period in which the collapse of the Ottoman Empire, the victory of the War of Independence, and the foundations of the Republic of Turkey were laid. Written with detailed research, rich historical information and a fluent style, the book offers readers a unique opportunity to understand the Turkish nation's struggle for independence and the birth of a new state. ""The Birth of the Republic"" offers a resource for history enthusiasts, students and everyone who wants to get in-depth information about important periods of Turkey.",


            DescriptionTr = @"""Cumhuriyet’in Doğuşu: Kurtuluş ve Kuruluş Yılları"" kitabı, Türkiye'nin tarihinde kırılma noktası olan Cumhuriyet'in doğuşunu ve kuruluş yıllarını derinlemesine ele alan bir başvuru kitabıdır. İlber Ortaylı'nın kaleminden çıkan bu eser, Osmanlı İmparatorluğu'nun çöküşü, Kurtuluş Savaşı'nın zaferle sonuçlanması ve Türkiye Cumhuriyeti'nin temellerinin atıldığı dönemi aydınlatıcı bir bakış açısıyla sunar. Detaylı araştırmalar, zengin tarih bilgisi ve akıcı bir üslupla kaleme alınan kitap, okuyuculara Türk milletinin bağımsızlık mücadelesini ve yeni bir devletin doğuşunu anlamak için benzersiz bir fırsat sunar. ""Cumhuriyet’in Doğuşu"", tarih meraklılarına, öğrencilere ve herkesin Türkiye'nin önemli dönemlerine dair derinlemesine bilgi edinmek istediği bir kaynak sunmaktadır.",

            

            BookVariations = new List<BookVariation>
                    {
                        new BookVariation
                        {
                            FormatEn = Enums.BookFormatEnumEn.Hardcover,
                            FormatTr = Enums.BookFormatEnumTr.Ciltli,
                            Prices = new List<Price>
                            {
                                new Price
                                {
                                    PriceAmount = 49.99m,
                                    DiscountedPriceAmount = 39.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "304 sayfa",
                                FormatEn = "304 pages",
                                Dimensions = "13 x 2 x 23 cm",
                                PublicationDate = new DateTime(2023, 10, 23),
                                PublisherTr = "Kronik Kitap; 1. basım",
                                PublisherEn = "Chronicle Book; 1st edition",
                                LanguageTr = "Türkçe",
                                LanguageEn = "Turkish"
                            },

                        },
                        new BookVariation
                        {
                            FormatEn = Enums.BookFormatEnumEn.Audiobook,
                            FormatTr = Enums.BookFormatEnumTr.SesliKitap,
                            Prices = new List<Price>
                            {
                                new Price
                                {
                                    PriceAmount = 19.99m,
                                    DiscountedPriceAmount = 9.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "3 saat 49 dakika",
                                FormatEn = "3 hours and 49 minutes",
                                Dimensions = "13 x 2 x 23 cm",
                                PublicationDate = new DateTime(2023, 10, 23),
                                PublisherTr = "Kronik Kitap; 1. basım",
                                PublisherEn = "Chronicle Book; 1st edition",
                                LanguageTr = "Türkçe",
                                LanguageEn = "Turkish"
                            },

                        },
                        new BookVariation
                        {
                            FormatEn = Enums.BookFormatEnumEn.Kindle,
                            FormatTr = Enums.BookFormatEnumTr.EKitap,
                            Prices = new List<Price>
                            {
                                new Price
                                {
                                    PriceAmount = 19.99m,
                                    //DiscountedPriceAmount = 44.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "351984 KB",
                                FormatEn = "351984 KB",
                                Dimensions = "13 x 2 x 23 cm",
                                PublicationDate = new DateTime(2023, 10, 23),
                                PublisherTr = "Kronik Kitap; 1. basım",
                                PublisherEn = "Chronicle Book; 1st edition",
                                LanguageTr = "Türkçe",
                                LanguageEn = "Turkish"
                            },

                        },
                    },
            BookImgUrls = new List<BookImgUrl>
                    {
                        new BookImgUrl
                        {
                            ImgUrl = "https://static.nadirkitap.com/fotograf/999464/34/Kitap_2023102614415999946413.jpg"
                        },
                        new BookImgUrl
                        {
                            ImgUrl = "https://s3.cloud.ngn.com.tr/kitantik/images/2023-11-07/1br9qfwlon7mfki1j3u.jpg"
                        },
                        //new BookImgUrl
                        //{
                        //    ImgUrl = "https://m.media-amazon.com/images/I/71jzkfju+6L._SL1200_.jpg"
                        //},
                        //new BookImgUrl
                        //{
                        //    ImgUrl = "https://m.media-amazon.com/images/I/61xx7rHwdTL._SL1200_.jpg"
                        //}
                    },
            BookVideoUrls = new List<BookVideoUrl>
                    {
                        new BookVideoUrl
                        {
                            CoverImgUrl = "https://i.ytimg.com/vi/dZbGovqBQmU/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBAsIvgM7lAx3el6RmSEPO4X76vWA",
                            VideoUrl="https://www.youtube.com/embed/dZbGovqBQmU?si=hNJuHZ5b8O1Yzm-y",
                        },
                        //new BookVideoUrl
                        //{
                        //    CoverImgUrl ="https://i.ytimg.com/vi/g8wkulcRPTY/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLDpr_ZNJLhzb-mneGlEmC6-SQimnQ",
                        //    VideoUrl = "https://www.youtube.com/embed/g8wkulcRPTY?si=nnnW_BGPURsuttOM",
                        //},

                    },
            BookReviews = new List<BookReview>
                    {
                        new BookReview
                        {
                            UserId = randomUser.Id,
                            CommentTitleEn = "It arrived undamaged",
                            CommentTitleTr = "Hasarsız geldi",
                            CommentEn = @"I love our teacher Ilber's books, they arrived intact.",


                            CommentTr = @"ilber hocamızın kitaplarını seviyorum sağlam geldi",
                            Raiting = 5,
                            CreatedAt = DateTime.Now,
                        },
                        new BookReview
                        {
                            UserId = randomUser.Id,
                            CommentTitleEn = "story of salvation",
                            CommentTitleTr = "Kurtuluşun hikayesi",
                            CommentEn = @"İlber Ortaylı has made his pen speak louder again. 100 years of history of the Republic.",


                            CommentTr = @"İlber Ortaylı yine kalemini konuşturmuş. Cumhuriyet'in 100 yıllık tarihi.",
                            Raiting = 5,
                            CreatedAt = DateTime.Now,
                        }
                    },
            

        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        var bookCategories = new List<BookCategory>
        {
            new BookCategory
            {
                BookId = book.Id,
                CategoryId = 1
            },
            new BookCategory
            {
                BookId = book.Id,
                CategoryId = 2
            }
        };


        _context.BooksCategories.AddRange(bookCategories);


        //var bookCategory = new BookCategory
        //{
            
        //        BookId = book.Id,
        //        CategoryId = 1
            
        //};

        //_context.BooksCategories.Add(bookCategory);


        await _context.SaveChangesAsync();

        return Ok(_context.Books.ToListAsync());
    }


    [HttpGet]
    public IActionResult GetBooksCategories() 
    {
        return Ok(_context.BooksCategories.ToList());
    }
}
