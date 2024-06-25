using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {
            var toDay = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbDisp.Text = toDay.ToString("g") + "\r\n";
            tbDisp.Text += toDay.ToString("yyyy年MM月dd日 HH時mm分ss秒") + "\r\n";
            tbDisp.Text += toDay.ToString("ggyy年M月d日（dddd）", culture);
            //tbDisp.Text = toDay.ToString("g") + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

        }
    }
}
