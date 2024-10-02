using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books
                             .Max(b => b.Price);
            var book = Library.Books
                .First(b => b.Price == max);

            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var groups = Library.Books
                                .GroupBy(b => b.PublishedYear)
                                .Select(c => new { PublishedYear = c.Key, Count = c.Count() })
                                .OrderBy(g => g.PublishedYear)
                                ;
            foreach (var item in groups) {
                Console.WriteLine("{0}年　{1}冊", item.PublishedYear, item.Count);
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books
                               .OrderByDescending(b => b.PublishedYear)
                               .ThenByDescending(b => b.Price)
                               .Join(Library.Categories,//結合する2番目のシーケンス
                                     book => book.CategoryId,//対象シーケンスの結合キー
                                     category => category.Id,//2番目のシーケンスの結合キー
                                     (book, category) => new {//結合した結果として得られるオブジェクトの生成関数
                                         Title = book.Title,
                                         Price = book.Price,
                                         Category = category.Name,
                                         PublishedYear = book.PublishedYear
                                     }
                               );
            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年,{book.Price}円,{book.Title},({book.Category})");
            }
        }

        private static void Exercise1_5() {
            var years = 2016;
            var books = Library.Books
                               .Where(b => b.PublishedYear == years)
                               .Join(Library.Categories,//結合する2番目のシーケンス
                                     book => book.CategoryId,//対象シーケンスの結合キー
                                     category => category.Id,//2番目のシーケンスの結合キー
                                     (book, category) => new {//結合した結果として得られるオブジェクトの生成関数
                                         Category = category.Name,
                                         PublishedYear = book.PublishedYear
                                     })
                               .Distinct()
                               ;
            foreach (var book in books) {
                Console.WriteLine($"{book.PublishedYear}年,カテゴリー：{book.Category}");
            }
        }

        private static void Exercise1_6() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                    category => category.Id,
                                    book => book.CategoryId,
                                    (category, books) => new {
                                        Category = category.Name,
                                        Books = books
                                    }
                                )
                                .OrderBy(g => g.Category)
                                ;
            foreach (var group in groups) {
                Console.WriteLine("#" + group.Category);
                foreach (var book in group.Books) {
                    Console.WriteLine($" {book.Title}");
                }
            }

        }

        private static void Exercise1_7() {
            var categoriesId = Library.Categories.Single(c => c.Name == "Development").Id;
            var query = Library.Books.Where(b => b.CategoryId == categoriesId)
                                     .GroupBy(b => b.PublishedYear)
                                     .OrderBy(b => b.Key);
            foreach (var group in query) {
                Console.WriteLine("#" + group.Key+"年");
                foreach (var book in group) {
                    Console.WriteLine($" {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
        }
    }
}
