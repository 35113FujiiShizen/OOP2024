using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();
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




            String prefecture;
            String YesOrNo;
            String uwagakiPrefecturalCapital;
            String prefecturalCapital;

            for (int i = 0; i < 5; i++) {
                while (true) {
                    //都道府県の入力
                    Console.Write("都道府県:");
                    prefecture = Console.ReadLine();

                    if (prefecture == null) {
                        break;
                    }

                    if (prefOfficeDict.ContainsKey(prefecture)) {
                        Console.WriteLine("上書きしますか？ y/n");
                        YesOrNo = Console.ReadLine();
                        if (YesOrNo == "y") {
                            //上書きする
                            Console.Write("県庁所在地：");
                            uwagakiPrefecturalCapital = Console.ReadLine();
                            prefOfficeDict[prefecture] = uwagakiPrefecturalCapital;
                        } else {
                            //上書きしない
                            Console.Write("県庁所在地：");
                            prefecturalCapital = Console.ReadLine();
                            prefOfficeDict.Add(prefecture, prefecturalCapital);
                        }

                    }

                    bool endFlag = false;
                    while (!endFlag) {
                        int menuNum = menuDisp();//メニュー表示
                        if (menuNum == 1) {
                            display();
                            break;
                        }

                        if (menuNum == 2) {
                            //検索処理
                            //都道府県の入力
                            search();
                            break;
                        }

                        if (menuNum == 9) {
                            endFlag = true;
                            break;
                        }
                    }
                }
            }

            private static void display() {

                foreach (var item in prefOfficeDict) {
                    //一覧表示
                    Console.WriteLine("{0}の県庁所在地は{1}です", item.Key, item.Value);
                }
            }

            private static void search() {
                //検索処理
                Console.Write("都道府県：");
                var prefecture2 = Console.ReadLine();
                if (prefOfficeDict.ContainsKey(prefecture2)) {
                    Console.WriteLine("県庁所在地：" + prefOfficeDict[prefecture2]);
                }
            }

            private static int menuDisp() {
                //メニュー表示
                Console.WriteLine(" ");
                Console.WriteLine("＊メニュー＊");
                Console.WriteLine("1：一覧表示");
                Console.WriteLine("2：検索");
                Console.WriteLine("9：終了");
                Console.Write("数字を入力してください：");
                var menuNum = int.Parse(Console.ReadLine());
                return menuNum;
            }
        }
    }
}