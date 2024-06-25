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
            tbDisp.Text += toDay.ToString("yyyy�NMM��dd�� HH��mm��ss�b") + "\r\n";
            tbDisp.Text += toDay.ToString("ggyy�NM��d���idddd�j", culture);
            //tbDisp.Text = toDay.ToString("g") + "\r\n";
        }

        private void btEx8_2_Click(object sender, EventArgs e) {

        }
    }
}
