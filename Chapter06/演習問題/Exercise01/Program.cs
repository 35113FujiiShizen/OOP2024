using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var maxnum = numbers.Max();
            Console.WriteLine(maxnum.ToString());
        }

        private static void Exercise1_2(int[] numbers) {
            var last2 = numbers.Skip(numbers.Length - 2).ToArray();
            foreach (var x in last2) {
                Console.WriteLine(x);
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var strings = numbers.Select(x => x.ToString("000")).ToArray();
            foreach (var item in strings) {
                Console.WriteLine(item);
            }

        }

        private static void Exercise1_4(int[] numbers) {
            var sortednumber = numbers.OrderBy(x => x).Take(3).ToArray();
            foreach (var item in sortednumber) {
                Console.WriteLine(item.ToString());
            }

        }

        private static void Exercise1_5(int[] numbers) {
            var results = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(results);
        }
    }
}
