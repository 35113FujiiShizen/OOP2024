using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };
            IEnumerable<String> query = names.Where(s => s.Contains(" "))
                                             .Select(s => s.ToUpper());
            foreach (string s in query) {
                Console.WriteLine(s);
            }
        }
    }
}
