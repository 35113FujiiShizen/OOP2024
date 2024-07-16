namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVersionOk = new Button();
            label1 = new Label();
            lbVersion = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // btVersionOk
            // 
            btVersionOk.Location = new Point(351, 246);
            btVersionOk.Name = "btVersionOk";
            btVersionOk.Size = new Size(75, 23);
            btVersionOk.TabIndex = 0;
            btVersionOk.Text = "OK";
            btVersionOk.UseVisualStyleBackColor = true;
            btVersionOk.Click += btVersionOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("UD デジタル 教科書体 NK-B", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label1.Location = new Point(51, 35);
            label1.Name = "label1";
            label1.Size = new Size(259, 31);
            label1.TabIndex = 1;
            label1.Text = "CarReportSystem";
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("UD デジタル 教科書体 NK-B", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(127, 90);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(36, 18);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("UD デジタル 教科書体 NK-B", 12F, FontStyle.Bold);
            label3.Location = new Point(51, 157);
            label3.Name = "label3";
            label3.Size = new Size(58, 18);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 338);
            Controls.Add(label3);
            Controls.Add(lbVersion);
            Controls.Add(label1);
            Controls.Add(btVersionOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVersionOk;
        private Label label1;
        private Label lbVersion;
        private Label label3;
    }
}