using Microsoft.VisualBasic;
using System.Drawing.Text;
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

            var dateTime = DateTime.Now;
            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                var day = NextWeek(dateTime, (DayOfWeek)dayofweek);
                var str = string.Format("{0:yy/MM/dd}�̎��T��{1}�F", dateTime, (DayOfWeek)dayofweek);
                tbDisp.Text += str + day + "\r\n";
            }
        }
        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            return nextweek.AddDays(days);
        }

        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = String.Format("�������Ԃ�{0}�ł���", duration.TotalNanoseconds);
            tbDisp.Text += str + "\r\n";
        }
    }
    class TimeWatch {
        private DateTime _time;

        public void Start() {

        }
        public TimeSpan Stop() {
            return 
        }
    }
}