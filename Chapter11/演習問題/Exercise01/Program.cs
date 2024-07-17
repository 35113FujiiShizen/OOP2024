using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine("-----");
            Exercise1_2(file);
            Console.WriteLine("-----");
            Exercise1_3(file);
            Console.WriteLine("-----");

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            var sports = xdoc.Root.Elements();

            foreach (var item in sports){
                var sportname = item.Element("name");
                Console.Write(sportname.Value+" ");
                var teammembers = item.Element("teammembers");
                Console.WriteLine(teammembers.Value);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            var sports = xdoc.Root.Elements()
                                  .OrderByDescending(x=>x.Element("first_played"));
            foreach (var item in sports){
                var name = item.Element("name");
                var namekanji = name.Attribute("kanji").Value;
                var firstplayed = item.Element("firstplayed").Value;
                Console.WriteLine(namekanji,firstplayed);
            }

        }

        private static void Exercise1_3(string file) {

        }

        private static void Exercise1_4(string file, string newfile) {

        }
    }
}
