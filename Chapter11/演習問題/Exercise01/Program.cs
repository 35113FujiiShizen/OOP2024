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

            foreach (var item in sports) {
                var sportname = item.Element("name");
                Console.Write(sportname.Value + " ");
                var teammembers = item.Element("teammembers");
                Console.WriteLine(teammembers.Value);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            var sports = xdoc.Root.Elements()
                                  .OrderByDescending(x => (int)x.Element("firstplayed"));
            foreach (var item in sports) {
                var name = item.Element("name");
                var namekanji = name.Attribute("kanji").Value;
                var firstplayed = item.Element("firstplayed").Value;
                Console.WriteLine(namekanji + "," + firstplayed);
            }

        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load("Sample.xml");
            var sport = xdoc.Root.Elements()
                                 .OrderByDescending(x => x.Element("teammembers").Value)
                                 .First();

            Console.WriteLine($"{sport.Element("name").Value}");

            //var sports = xdoc.Root.Elements()
            //                      .Select(x=>new{
            //                          Name = x.Element("name").Value,
            //                          Teammember = x.Element("teammembers").Value,
            //                        })
            //                      ;
            //var maxteammember = sports.Max(x => x.Teammember);
            //foreach (var item in sports){
            //    if (maxteammember == item.Teammember) {
            //        Console.WriteLine(item.Name);
            //    }    
        }
        private static void Exercise1_4(string file, string newfile) {
            var element = new XElement("ballsport",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1848")
              );
            var xdoc = XDocument.Load("Sample.xml");
            xdoc.Root.Add(element);
            xdoc.Save(newfile);

            Console.Write("名称：");
            var name = Console.ReadLine();
            Console.Write("漢字：");
            var kanji = Console.ReadLine();
            Console.Write("人数：");
            var teammember = Console.ReadLine();
            Console.Write("起源年：");
            var firstplayed = Console.ReadLine();

            
        }
    }
}