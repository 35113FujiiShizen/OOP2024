using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Book {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
    }

    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);

        }

        private static void Exercise2_1(List<Book> books) {
            var targetBook = books.Where(b => b.Title == "ワンダフル・C#ライフ");
            //Console.WriteLine("価格：" + targetBook.Price.ToString());
            //Console.WriteLine("ページ数：" + targetBook.Pages.ToString());
            foreach (var book in targetBook) {
                Console.WriteLine("{0}:{1}円 {2}ページ", book.Title, book.Price, book.Pages);
            }
        }

        private static void Exercise2_2(List<Book> books) {
            var count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(count + "冊");
        }

        private static void Exercise2_3(List<Book> books) {
            var cSharpBooks = books.Where(b => b.Title.Contains("C#")).ToList();
            var averagePages = cSharpBooks.Average(b => b.Pages);
            Console.WriteLine(averagePages);
        }

        private static void Exercise2_4(List<Book> books) {
            var target = books.FirstOrDefault(b => b.Price >= 4000);
            Console.WriteLine(target.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var pages = books.Where(b=>b.Price <4000).Max(b => b.Pages);
            Console.WriteLine(pages);
        }

        private static void Exercise2_6(List<Book> books) {

        }

        private static void Exercise2_7(List<Book> books) {

        }
    }

}
