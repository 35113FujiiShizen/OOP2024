using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetBooks();
            //foreach (var book in GetBooks()){
            //    Console.WriteLine(book.Title);
            //}
            //InsertBooks();
            //AddAuthors();
            //AddBooks();
            //UpdateBook();
            //DeleteBook();
            //en1AddAuthors();
            //en1AddBooks();
            //DisplayAllBooks();
            DisplayAllBooks2();
            Console.WriteLine();
            Console.WriteLine("#1.3");
            DisplayAllbooks3();

            Console.WriteLine();
            Console.WriteLine("#1.4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("#1.5");
            Exercise1_5();

            Console.ReadLine(); //コンソールアプリだが F5 でデバッグ実行したいために記述
        }

        private static void Exercise1_4()
        {
            using (var db = new BooksDbContext())
            {
                var books = db.Books
                    .Include(nameof(Author))
                    .OrderBy(b => b.PublishedYear)
                    .Take(3);
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title},{book.Author.Name}");
                }
            }
        }

        private static void Exercise1_5()
        {
            using (var db = new BooksDbContext())
            {
                var authors = db.Authors.OrderByDescending(a => a.Birthday).ToList();//即時実行でauthorをすべて持ってくる
                foreach (var author in authors)
                {
                    Console.WriteLine("{0}", author.Name);
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine("  {0},{1}", book.Title, book.PublishedYear);
                    }

                }
            }
        }
        //データの取得
        static IEnumerable<Book> GetBooks()
        {
            using (var db = new BooksDbContext())
            {
                return db.Books
                         //.Where(book => book.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }
        static IEnumerable<Author> GetAuthor()
        {
            using (var db = new BooksDbContext())
            {
                return db.Authors.ToList();
            }
        }

        static void InsertBooks()
        {
            using (var db = new BooksDbContext())
            {
                var book1 = new Book
                {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author
                    {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };

                db.Books.Add(book1);

                var book2 = new Book
                {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author
                    {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges(); //データベースを更新
            }
        }
        public static void AddAuthors()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = new Author
                {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author1);
                var author2 = new Author
                {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }
        public static void AddBooks()
        {
            using (var db = new BooksDbContext())
            {
                //Authorから該当するデータを取得
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book
                {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);

                //Authorから該当するデータを取得
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book
                {
                    Title = "鉄道銀河の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            };


        }
        public static void UpdateBook()
        {
            using (var db = new BooksDbContext())
            {
                var book = db.Books.Single(x => x.Title == "鉄道銀河の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }
        public static void DeleteBook()
        {
            using (var db = new BooksDbContext())
            {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book == null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
        //書籍の追加Exercise1_1
        public static void en1AddAuthors()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = new Author
                {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛"
                };
                db.Authors.Add(author1);
                var author2 = new Author
                {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "川端康成"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }
        public static void en1AddBooks()
        {
            using (var db = new BooksDbContext())
            {
                //Authorから該当するデータを取得
                var author1 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book1 = new Book
                {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "川端康成");
                var book2 = new Book
                {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author2,
                };
                db.Books.Add(book2);
                var author3 = db.Authors.Single(a => a.Name == "菊池寛");
                var book3 = new Book
                {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author3,
                };
                db.Books.Add(book3);
                var author4 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book4 = new Book
                {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author4,
                };
                db.Books.Add(book4);
                db.SaveChanges();
            }
        }
        //テーブルの全表示
        static void DisplayAllBooks()
        {
            var books = GetBooks();
            var authors = GetAuthor();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} {book.PublishedYear}");
            };
            Console.ReadLine();
        }
        //Exercise1_2
        static void DisplayAllBooks2()
        {
            using (var db = new BooksDbContext())
            {
                foreach (var book in db.Books.ToList())
                {
                    Console.WriteLine(("{0} {1}年 {2} ({3:yyyy/MM/dd})"),
                        book.Title,
                        book.PublishedYear,
                        book.Author.Name,
                        book.Author.Birthday
                        );
                }
            }
        }
        //Exercise1_3

        static void DisplayAllbooks3()
        {
            using (var db = new BooksDbContext())
            {
                var books = db.Books
                     .Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));
                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }

            }
        }
    }
}