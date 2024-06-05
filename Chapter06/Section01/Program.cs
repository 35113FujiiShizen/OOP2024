using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var bookPrice = Books.GetBooks().OrderByDescending(x => x.Price).ToList() ;
            foreach (var book in bookPrice){
                Console.WriteLine(book.Title+":"+book.Price+"円");
            }
            
        }
    }
}
