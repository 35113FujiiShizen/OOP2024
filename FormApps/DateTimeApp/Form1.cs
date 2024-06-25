namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            var toDay = DateTime.Now;

            TimeSpan diff = toDay - dtpBirthday.Value;
            tbDisp.Text = (diff.Days + 1) + "ì˙ñ⁄";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            //double doubleValue = Decimal.ToDouble(nudDay.Value);
            var past = dtpBirthday.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = past.ToString("D");
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            //double doubleValue = Decimal.ToDouble(nudDay.Value);
            var past = dtpBirthday.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = past.ToString("D");
        }

        private void btAge_Click(object sender, EventArgs e) {
            var toDay = DateTime.Now;
            int age = toDay.Year - dtpBirthday.Value.Year;
            tbDisp.Text = age.ToString("D")+"çŒ";
        }
    }
}