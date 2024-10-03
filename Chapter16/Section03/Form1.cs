using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section03 {
    public partial class bt_16_6 : Form {
        public bt_16_6() {
            InitializeComponent();
        }

        private async void tb16_6_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(() => DoSomething());
            toolStripStatusLabel1.Text = "終了";

        }

        private void DoSomething() {
            Thread.Sleep(5000);
        }

        private async void bt_16_7_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoSomething2());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        private long DoSomething2() {
            var sw = Stopwatch.StartNew();
            Thread.Sleep(5000);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        private async void bt_16_8_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await DoSomethingAsysnc();
            toolStripStatusLabel1.Text = "終了";
        }
        //非同期メソッド
        private async Task DoSomethingAsysnc() {
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
        }

        private async void bt_16_9_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoSomethingAsysnc2();
            toolStripStatusLabel1.Text = "終了";
        }
        //非同期メソッド
        private async Task<long> DoSomethingAsysnc2() {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(5000);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
