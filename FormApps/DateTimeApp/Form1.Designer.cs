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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 16F);
            label1.Location = new Point(61, 54);
            label1.Name = "label1";
            label1.Size = new Size(101, 30);
            label1.TabIndex = 0;
            label1.Text = "生年月日";
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(61, 120);
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
            tbDisp.Location = new Point(61, 211);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(273, 43);
            tbDisp.TabIndex = 2;
            // 
            // dtpBirthday
            // 
            dtpBirthday.Font = new Font("Yu Gothic UI", 16F);
            dtpBirthday.Location = new Point(182, 54);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(184, 36);
            dtpBirthday.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpBirthday);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btDateCount;
        private TextBox tbDisp;
        private DateTimePicker dtpBirthday;
    }
}
