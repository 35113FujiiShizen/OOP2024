using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("数字を入力：");
            string str1 = Console.ReadLine();
            int.TryParse(str1, out int num1);
            var num2 = num1.ToString("#,0");
            Console.WriteLine(num2);
        }
    }
}
