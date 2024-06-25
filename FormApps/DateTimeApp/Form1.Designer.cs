namespace DateTimeApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            btDateCount = new Button();
            tbDisp = new TextBox();
            dtpBirthday = new DateTimePicker();
            nudDay = new NumericUpDown();
            btDayBefore = new Button();
            btDayAfter = new Button();
            btAge = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 16F);
            label1.Location = new Point(61, 54);
            label1.Name = "label1";
            label1.Size = new Size(57, 30);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(262, 122);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(138, 47);
            btDateCount.TabIndex = 1;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 20F);
            tbDisp.Location = new Point(52, 301);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(285, 43);
            tbDisp.TabIndex = 2;
            // 
            // dtpBirthday
            // 
            dtpBirthday.Font = new Font("Yu Gothic UI", 18F);
            dtpBirthday.Location = new Point(141, 49);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(196, 39);
            dtpBirthday.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 18F);
            nudDay.Location = new Point(52, 198);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(193, 39);
            nudDay.TabIndex = 4;
            nudDay.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // btDayBefore
            // 
            btDayBefore.Font = new Font("Yu Gothic UI", 18F);
            btDayBefore.Location = new Point(262, 175);
            btDayBefore.Name = "btDayBefore";
            btDayBefore.Size = new Size(131, 43);
            btDayBefore.TabIndex = 5;
            btDayBefore.Text = "日前";
            btDayBefore.UseVisualStyleBackColor = true;
            btDayBefore.Click += btDayBefore_Click;
            // 
            // btDayAfter
            // 
            btDayAfter.Font = new Font("Yu Gothic UI", 18F);
            btDayAfter.Location = new Point(262, 224);
            btDayAfter.Name = "btDayAfter";
            btDayAfter.Size = new Size(131, 43);
            btDayAfter.TabIndex = 5;
            btDayAfter.Text = "日後";
            btDayAfter.UseVisualStyleBackColor = true;
            btDayAfter.Click += btDayAfter_Click;
            // 
            // btAge
            // 
            btAge.Font = new Font("Yu Gothic UI", 18F);
            btAge.Location = new Point(399, 198);
            btAge.Name = "btAge";
            btAge.Size = new Size(101, 50);
            btAge.TabIndex = 6;
            btAge.Text = "年齢";
            btAge.UseVisualStyleBackColor = true;
            btAge.Click += btAge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 520);
            Controls.Add(btAge);
            Controls.Add(btDayAfter);
            Controls.Add(btDayBefore);
            Controls.Add(nudDay);
            Controls.Add(dtpBirthday);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btDateCount;
        private TextBox tbDisp;
        private DateTimePicker dtpBirthday;
        private NumericUpDown nudDay;
        private Button btDayBefore;
        private Button btDayAfter;
        private Button btAge;
    }
}
