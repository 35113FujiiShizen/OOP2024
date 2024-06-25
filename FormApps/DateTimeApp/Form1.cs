namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            var toDay = DateTime.Now;

            TimeSpan diff = toDay - dtpBirthday.Value;
            tbDisp.Text = (diff.Days + 1) + "����";
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
            var birthday = dtpBirthday.Value;
            int age = GetAge(birthday,toDay);

            tbDisp.Text = age.ToString("D")+"��";
        }
        //�a�����ɔN�1�Ώオ���ʓI�ȔN������߂郁�\�b�h
        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
    }
}