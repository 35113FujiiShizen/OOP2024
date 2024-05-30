using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        }

        private static void Exercise3_1(string text) {
            int count = text.Count(c => c == ' ');
            Console.WriteLine("空白文字数："+count);
        }

        private static void Exercise3_2(string text) {
            var spaces = text.Replace("big", "small");
            Console.WriteLine(spaces);
        }

        private static void Exercise3_3(string text) {
            int count = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}", count);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words){
                Console.WriteLine(word);
            }
            //int count = text.Split(' ').Length;
            //if (count <= 4) {
            //    for
            //}
        }

        private static void Exercise3_5(string text) {
            
        }
    }
}
