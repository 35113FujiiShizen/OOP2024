﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("文字1を入力：");
            string str1 = Console.ReadLine();
            Console.Write("文字2を入力：");
            string str2 = Console.ReadLine();

            if (String.Compare(str1, str2, ignoreCase:true) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
