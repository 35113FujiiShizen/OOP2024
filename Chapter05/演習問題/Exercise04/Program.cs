using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            //String str = line.Replace("Novelist=", "作家:").Replace("BestWork=", "代表作：").Replace("Born=", "誕生年：");
            foreach (var item in line.Split(';')) {
                var array = item.Split('=');
                Console.WriteLine("{0}:{1}", ToJapanese(array[0]), array[1]);
            }
        }

        private static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家 ";
                case "BestWork":
                    return "代表作 ";
                case "Born":
                    return "誕生年 ";
            }
            throw new ArgumentException("引数に誤りがあります");
        }
    }
}

