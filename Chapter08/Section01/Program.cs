using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var dt1 = new DateTime(2024, 6, 19);
            //var dt2 = new DateTime(2005, 1, 4, 8, 45, 20);
            //Console.WriteLine(dt1);
            //Console.WriteLine(dt2);

            //var today = DateTime.Today;
            //var now = DateTime.Now;
            //Console.WriteLine("Today : {0}", today);
            //Console.WriteLine("Now : {0}", now);

            //var isLeapYear = DateTime.IsLeapYear(2023);
            //if (isLeapYear) {
            //    Console.WriteLine("閏年です");
            //} else {
            //    Console.WriteLine("閏年ではありません");
            //}
            //Console.WriteLine("-----------------------");

            Console.WriteLine("生年月日を入力");
            Console.Write("年：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());

            var birthday = new DateTime(year, month, day);

            //何曜日にうまれたか表示するプログラム↓
            //DayOfWeek dayOfWeek = birthday.DayOfWeek;
            //string[] japaneseDays = { "日", "月", "火", "水", "木", "金", "土" };
            //string japaneseDayOfWeek = japaneseDays[(int)dayOfWeek];
            //Console.WriteLine("あなたは" + japaneseDayOfWeek + "曜日に生まれました");

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日dddd", culture);
            Console.WriteLine("あなたは"+str+"に生まれました");

            var nowDay = DateTime.Now;
            TimeSpan diff = nowDay.Date - birthday.Date;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です", diff.Days);
        }
    }
}
