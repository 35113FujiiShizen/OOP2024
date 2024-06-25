namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            var toDay = DateTime.Now;

            TimeSpan diff = toDay - dtpBirthday.Value;
            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            double doubleValue = Decimal.ToDouble(nudDay.Value);
            var past = dtpBirthday.Value.AddDays(-(double)doubleValue);
            tbDisp.Text = past.ToString("D");
        }

    }
}
