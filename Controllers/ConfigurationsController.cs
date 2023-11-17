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
            FullName = @"Rachel Abbott",
            BiographyEn = @"Rachel Abbott is a British author and successful creator of bestselling psychological thriller novels. Abbott began his previous career as an executive in business and technology, but focused on writing after his retirement. His first novel, ""Only the Innocent"" (2011), was a huge international success and made Abbott a household name in the literary world. His works, which stand out with character development, gripping stories and unexpected twists, draw their readers into the depths of the thriller genre. By combining her passion for writing with her dedication to exploring complex relationships and the darker aspects of human nature, Abbott has forged her own brand in the psychological thriller genre.",
            BiographyTr = @"Rachel Abbott, İngiliz yazar ve çok satan psikolojik gerilim romanlarının başarılı bir yaratıcısıdır. Abbott, önceki kariyerine ticaret ve teknoloji alanında yöneticilik yaparak başlamış, ancak emekliliğinden sonra yazmaya odaklanmıştır. İlk romanı olan ""Only the Innocent"" (2011), uluslararası alanda büyük bir başarı elde etti ve Abbott'u edebi dünyada tanınan bir isim haline getirdi. Karakter gelişimi, sürükleyici hikayeler ve beklenmedik twist'lerle dikkat çeken eserleri, okuyucularını gerilim türünün derinliklerine çekiyor. Abbott, yazma tutkusunu, karmaşık ilişkileri ve insan doğasının karanlık yönlerini keşfetmeye olan bağlılığıyla birleştirerek, psikolojik gerilim türünde kendi markasını oluşturdu.",
            ProfilePhotoImgUrl = "https://m.media-amazon.com/images/S/amzn-author-media-prod/fv4v7cjf0766c96baua29u1ede._SY1000_CR0%2C0%2C1000%2C1000_.jpg"
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
            AuthorId = _context.Authors.Where(p=>p.FullName == "Rachel Abbott").FirstOrDefault().Id,
            TitleTr = "Hiçbir Yerde Çocuk: Kısa Bir Roman",
            TitleEn = "Nowhere Child: A Short Novel",
            SubTitleTr = @"Rachel Abbott'un çok satan romanı Yabancı Çocuk Birisi Tasha'yı Arıyor'la aynı karakterlerin yer aldığı bağımsız bir kısa roman. Ama bulunmayı istiyor mu? Sekiz ay önce Tasha Joseph kaçtı ve üvey annesi Emma o zamandan beri onu arıyor. Tasha'ya hak ettiği evi ve güvenliği vermek konusunda çaresizdir. Sorun şu ki, Tasha'yı arayan tek kişi Emma değil. Polis de onu bulmaya çalışıyor. Bir ceza davasında hayati bir tanık olabilir ve DCI Tom Douglas'ın sürekli olarak onu gözetleyen bir ekibi var.",
            SubTitleEn = @"A stand-alone novella featuring the same characters as Rachel Abbott’s bestselling novel Stranger Child Someone is looking for Tasha. But does she want to be found? Eight months ago Tasha Joseph ran away, and her stepmother, Emma, has been searching for her ever since. She is desperate to give Tasha the home and security she deserves. The problem is, Emma isn’t the only one looking for Tasha. The police are keen to find her too. She could be a vital witness in a criminal trial, and DCI Tom Douglas has a team constantly on the lookout for her.",
            MainImgUrl = "https://m.media-amazon.com/images/I/7139zSoVSWL._SL1360_.jpg",
            ISBN = "0957652259",
            Quantity = 100,
            DescriptionEn = @"""Nowhere Child: A Short Novel"" is a captivating literary journey that seamlessly blends mystery and emotion. In this concise yet compelling narrative, readers are immersed in a tale that transcends boundaries and explores the depths of human connection. Set against a backdrop of intrigue and self-discovery, the story unfolds with a poetic cadence, drawing readers into the protagonist's quest for identity and belonging.

This short novel is not merely a story; it's a reflection on the universal themes of family, loss, and resilience. As you navigate the pages, you'll find yourself on a poignant exploration of the human spirit, contemplating the significance of our roots and the profound impact of personal history.

""Nowhere Child"" is a literary gem that leaves an indelible mark, making it a must-read for those who seek narratives that resonate on a profound level. This short novel is not just about a character's journey; it's an exploration of the shared human experience, beautifully crafted to linger in the reader's mind long after the final page is turned.",


            DescriptionTr = @"""Hiçbir Yerde Çocuk: Kısa Bir Roman"" gizemi ve duyguyu kusursuz bir şekilde harmanlayan büyüleyici bir edebi yolculuk. Bu kısa ama ilgi çekici anlatımda okuyucular, sınırları aşan ve insanlar arasındaki bağın derinliklerini araştıran bir hikayenin içinde kayboluyorlar. Entrika ve kendini keşfetmenin arka planında yer alan hikaye şiirsel bir ritimle gelişiyor ve okuyucuları kahramanın kimlik ve aidiyet arayışına çekiyor.

Bu kısa roman yalnızca bir hikaye değil; bu, aile, kayıp ve dayanıklılık gibi evrensel temaların bir yansımasıdır. Sayfalarda gezinirken, kendinizi insan ruhunun dokunaklı bir incelemesinde bulacaksınız, köklerimizin önemini ve kişisel tarihimizin derin etkisini düşünüyorsunuz.

""Hiçbir Yerdeki Çocuk"" silinmez bir iz bırakan edebi bir mücevherdir ve derin düzeyde yankı uyandıran anlatılar arayanlar için mutlaka okunması gereken bir kitaptır. Bu kısa roman sadece bir karakterin yolculuğunu anlatmıyor; Bu, son sayfa çevrildikten çok sonra bile okuyucunun aklında kalacak şekilde güzelce hazırlanmış, paylaşılan insan deneyiminin bir keşfi.",

            

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
                                    PriceAmount = 69.99m,
                                    DiscountedPriceAmount = 49.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "178 sayfa",
                                FormatEn = "178 pages",
                                Dimensions = "12.7 x 1.04 x 20.32 cm",
                                PublicationDate = new DateTime(2015, 01, 29),
                                PublisherTr = "Siyah Nokta Yayıncılık",
                                PublisherEn = "Black Dot Publishing",
                                LanguageTr = "İngilizce",
                                LanguageEn = "English"
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
                                    PriceAmount = 39.99m,
                                    DiscountedPriceAmount = 19.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "3 saat 45 dakika",
                                FormatEn = "3 hours and 45 minutes",
                                Dimensions = "12.7 x 1.04 x 20.32 cm",
                                PublicationDate = new DateTime(2015, 01, 29),
                                PublisherTr = "Siyah Nokta Yayıncılık",
                                PublisherEn = "Black Dot Publishing",
                                LanguageTr = "İngilizce",
                                LanguageEn = "English"
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
                                    PriceAmount = 5.99m,
                                    //DiscountedPriceAmount = 44.99m,
                                    PriceCurrency = "₺"
                                }
                            },
                            ProductDetail = new ProductDetail
                            {
                                FormatTr = "604 KB",
                                FormatEn = "604 KB",
                                Dimensions = "12.7 x 1.04 x 20.32 cm",
                                PublicationDate = new DateTime(2015, 01, 29),
                                PublisherTr = "Siyah Nokta Yayıncılık",
                                PublisherEn = "Black Dot Publishing",
                                LanguageTr = "İngilizce",
                                LanguageEn = "English"
                            },

                        },
                    },
            BookImgUrls = new List<BookImgUrl>
                    {
                //mainImgUrl
                        new BookImgUrl
                        {
                            ImgUrl = "https://m.media-amazon.com/images/I/7139zSoVSWL._SL1360_.jpg"
                        },
                //mainImgUrl
                        new BookImgUrl
                        {
                            ImgUrl = "https://m.media-amazon.com/images/I/718RCgJRSgL._SL1360_.jpg"
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
                    CoverImgUrl = "https://i.ytimg.com/vi/5s0HY5D-Y5M/hqdefault.jpg?sqp=-oaymwEcCOADEI4CSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLAhGTYt5s1NuWRddOOcRMEuvqPeBw",
                    VideoUrl="https://www.youtube.com/embed/5s0HY5D-Y5M?si=fyWYS_dhg7knTemp",
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
                            CommentTitleEn = "Such an excellent fast paced read.",
                            CommentTitleTr = "Böyle mükemmel, hızlı tempolu bir okuma.",
                            CommentEn = @"Characters are vivid and the way Rachel writes it's easy to identify relationips and the emotions being experienced between people.",


                            CommentTr = @"Karakterler canlıdır ve Rachel'ın yazma şekli, insanlar arasında yaşanan ilişkileri ve duyguları tanımlamak kolaydır.",
                            Raiting = 5,
                            CreatedAt = DateTime.Now,
                        },
                        new BookReview
                        {
                            UserId = randomUser.Id,
                            CommentTitleEn = "Tasha's story continues",
                            CommentTitleTr = "Tasha'nın hikayesi devam ediyor",
                            CommentEn = @"This novella by Rachel Abbott picks up the story of Tasha Joseph where Stranger Child left off. Tasha is on the run, certain that her family hate her for what happened to little Ollie and knowing that if she stays still, her old family, the gang she used to work for, will find her. The best she could hope for would be to put to work in a brothel, the worst could mean her death. People are searching for her, but she doesn’t know if the are friend or foe and she cannot take any chances. Her only option is to stay hidden.

This is a great short story in which we learn more about Tasha, about the life she is living now on the streets and that which she lived before; under the control of the gang that used her for shoplifting and drug running. She is a feisty character for sure, but she is also just a teenager and she is scared. Having spent so long being beaten down she sees nothing good in herself and although she has found a friend on the streets, she will never truly be safe.

Tapping into the plight of the homeless people of Manchester, Rachel Abbott manages to create a tense, compelling and fraught read which feels authentic but also ties up a lot of loose ends for both Tasha and Emma. I really felt for Tasha, and some sections were hard to read, or in m case listen to as I chose the audio book option, but it was still compelling. Although this isn’t really a Tom Douglas story he does still feature, albeit in a much smaller role. Still, it’s nice to see him stop by. And the ending brings hope for both Emma and Tasha. Whether we hear from either again I don’t know but they are going to be characters that are hard to forget.",


                            CommentTr = @"Rachel Abbott'un bu kısa romanı, Tasha Joseph'in hikayesini Yabancı Çocuk'un bıraktığı yerden devam ettiriyor. Tasha kaçmaktadır, küçük Ollie'nin başına gelenlerden dolayı ailesinin ondan nefret ettiğinden emindir ve hareketsiz kalırsa eski ailesinin, yani eskiden çalıştığı çetenin onu bulacağını bilir. Umabileceği en iyi şey bir genelevde çalışmaya başlamaktı, en kötüsü ise ölümü anlamına gelebilirdi. İnsanlar onu arıyor ama o, onların dost mu düşman mı olduğunu bilmiyor ve işini şansa bırakamaz. Tek seçeneği gizli kalmaktır.

Bu, Tasha hakkında, şu anda sokaklarda yaşadığı ve daha önce yaşadığı hayat hakkında daha fazla şey öğrendiğimiz harika bir kısa hikaye; Onu hırsızlık ve uyuşturucu kaçakçılığı için kullanan çetenin kontrolü altında. Kesinlikle alıngan bir karakter ama aynı zamanda henüz bir genç ve korkuyor. O kadar uzun süre dövüldükten sonra kendinde iyi bir şey göremiyor ve sokaklarda bir arkadaş bulsa da hiçbir zaman tam anlamıyla güvende olamayacak.

Manchester'daki evsizlerin içinde bulunduğu kötü duruma değinen Rachel Abbott, hem Tasha hem de Emma için gerçekçi hissettiren ama aynı zamanda pek çok yarım kalmış işi de bağlayan gergin, ilgi çekici ve endişe verici bir okuma yaratmayı başarıyor. Tasha'yı gerçekten hissettim ve bazı bölümleri okumak ya da sesli kitap seçeneğini seçtiğim için dinlemek zordu ama yine de ilgi çekiciydi. Her ne kadar bu aslında bir Tom Douglas hikayesi olmasa da, çok daha küçük bir rolle de olsa hâlâ öne çıkıyor. Yine de onun uğradığını görmek güzel. Ve sonu hem Emma'ya hem de Tasha'ya umut veriyor. İkisinden de bir daha haber alır mıyız bilmiyorum ama unutulması zor karakterler olacaklar.",
                            Raiting = 4,
                            CreatedAt = DateTime.Now,
                        },
                        new BookReview
                        {
                            UserId = randomUser.Id,
                            CommentTitleEn = "Excellent",
                            CommentTitleTr = "Harika",
                            CommentEn = @"Not been able to put down any of this author's book's. They are some of the best ones I have read.",


                            CommentTr = @"Bu yazarın hiçbir kitabını elimden bırakamadım. Onlar okuduklarım arasında en iyilerinden bazıları.",
                            Raiting = 5,
                            CreatedAt = DateTime.Now,
                        },
                        new BookReview
                        {
                            UserId = randomUser.Id,
                            CommentTitleEn = "Awsome",
                            CommentTitleTr = "Süper",
                            CommentEn = @"This 2nd book about Tom ,Emma and Rasta was worth reading a conclusion to A terrible story of a child's life after her mother dies .
Really enjoying this series",


                            CommentTr = @"Tom, Emma ve Rasta hakkındaki bu 2. kitap, Annesi öldükten sonra bir çocuğun hayatının korkunç hikayesinin bir sonucu olarak okunmaya değerdi.
Bu seriden gerçekten keyif alıyorum",
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
                CategoryId = 2
            },
            new BookCategory
            {
                BookId = book.Id,
                CategoryId = 1
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

        var books = await _context.Books.ToListAsync();

        return Ok(books);
    }


    [HttpGet]
    public IActionResult GetBooksCategories() 
    {
        return Ok(_context.BooksCategories.ToList());
    }
}
