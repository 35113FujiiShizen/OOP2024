using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        //4.1.1
        public int year { get; private set; }
        public int month { get; private set; }
        public YearMonth(int year, int month) {
            this.year = year;
            this.month = month;
        }

        //4.1.2
        public bool Is21Century {
            get {
                return year >= 2001 && year <= 2100;
            }
        }

        //4.1.3
        public YearMonth AddOneMonth() {
            int year = this.year;
            int month = this.month;
            month++;
            if (month == 13) {
                year++;
                month = 1;
            }
            return new YearMonth(year, month);
        }
        //4.1.4
        public override string ToString() {
            //return year + "年" + month + "月";
            return $"{year}年{month}月";
        }
    }
}
