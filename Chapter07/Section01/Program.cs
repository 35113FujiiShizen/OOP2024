using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var flowerDict = new Dictionary<string, int>() {
            //{ "sunflower", 400 },
            //{ "pansy", 300 },
            //{ "tulip", 350 },
            //{ "rose", 500 },
            //{ "dahlia", 450 },
            //};
            //Console.WriteLine(flowerDict["sunflower"]);
            //Console.WriteLine(flowerDict["dahlia"]);

            //var employeeDict = new Dictionary<int, Employee> {
            //{ 100, new Employee(100, "清水遼久") },
            //{ 112, new Employee(112, "芹沢洋和") },
            //{ 125, new Employee(125, "岩瀬奈央子") },
            //};
            //employeeDict.Add(126, new Employee(126, "庄野遥花"));

            //var name = employeeDict.Where(n => n.Value.Name.Contains("和"));


            //foreach (var item in employeeDict.Values) {
            //    Console.WriteLine($"{item.Id} {item.Name}");
            //}




            var prefOfficeDict = new Dictionary<string, string>();
            for (int i = 0; i < 5; i++) {
                Console.Write(" ");
                Console.Write("都道府県：");
                var prefecture = Console.ReadLine();

                if (prefOfficeDict.ContainsKey(prefecture)) {
                    Console.WriteLine("上書きしますか？ y/n");
                    var YesOrNo = Console.ReadLine();
                    if (YesOrNo == "y") {
                        //上書きする
                        Console.Write("県庁所在地：");
                        var uwagakiPrefecturalCapital = Console.ReadLine();
                        prefOfficeDict[prefecture] = uwagakiPrefecturalCapital;
                    } else {
                        Console.Write("県庁所在地：");
                        var prefecturalCapital = Console.ReadLine();
                        prefOfficeDict.Add(prefecture, prefecturalCapital);
                    }

                }

                bool endFlag = false;
                while (!endFlag) {
                    Console.WriteLine(" ");
                    Console.WriteLine("＊メニュー＊");
                    Console.WriteLine("1：一覧表示");
                    Console.WriteLine("2：検索");
                    Console.WriteLine("9：終了");
                    Console.Write("数字を入力してください：");
                    var menuNum = int.Parse(Console.ReadLine());

                    if (menuNum == 1) {
                        foreach (var item in prefOfficeDict) {
                            Console.WriteLine("{0}の県庁所在地は{1}です", item.Key, item.Value);
                        }
                        break;
                    }

                    if (menuNum == 2) {
                        Console.Write("都道府県：");
                        var prefecture2 = Console.ReadLine();
                        if (prefOfficeDict.ContainsKey(prefecture2)) {
                            Console.WriteLine("県庁所在地：" + prefOfficeDict[prefecture2]);
                        }
                        break;
                    }

                    if (menuNum == 9) {
                        endFlag = true;
                        break;
                    }
                }
            }
        }
    }
}