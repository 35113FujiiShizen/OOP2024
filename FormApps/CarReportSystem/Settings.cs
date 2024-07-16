using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {
        //自分自身のインスタンスを格納
        private static Settings? instance;

        public int MainFormColor { get; set; }
        //コンストラクタ(privateにすることによりnewできなくなる)
        private Settings() { }
        //自インスタンスを返却するメソッド
        public static Settings getInstance() {
            if (instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
