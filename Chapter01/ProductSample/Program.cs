using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto =new Product(123, "かりんとう",180);
            Product daifuku = new Product(123, "大福", 180);

            int price = karinto.Price;//税抜き価格
            int taxIncluded = karinto.GetPriceIncludingTax();//税込み価格

            Console.WriteLine(karinto.Name+"の税込み価格"+taxIncluded+"円（"+karinto.Price+"円+税）");

            
        }
    }
}
