﻿namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbRssUrl = new System.Windows.Forms.TextBox();
            this.tbGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tbRssUrl
            // 
            this.tbRssUrl.Location = new System.Drawing.Point(29, 21);
            this.tbRssUrl.Name = "tbRssUrl";
            this.tbRssUrl.Size = new System.Drawing.Size(576, 19);
            this.tbRssUrl.TabIndex = 0;
            // 
            // tbGet
            // 
            this.tbGet.Location = new System.Drawing.Point(611, 21);
            this.tbGet.Name = "tbGet";
            this.tbGet.Size = new System.Drawing.Size(85, 20);
            this.tbGet.TabIndex = 1;
            this.tbGet.Text = "取得";
            this.tbGet.UseVisualStyleBackColor = true;
            this.tbGet.Click += new System.EventHandler(this.tbGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(29, 72);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(575, 124);
            this.lbRssTitle.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.tbGet);
            this.Controls.Add(this.tbRssUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRssUrl;
        private System.Windows.Forms.Button tbGet;
        private System.Windows.Forms.ListBox lbRssTitle;
    }
}

