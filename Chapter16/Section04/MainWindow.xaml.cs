using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Section04 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void bt_16_10_Click(object sender, RoutedEventArgs e) {
            var text = await GetPageAsync(@"http://www.bing.com");
            textBlock.Text = text;
            }

        private HttpClient _httpClient = new HttpClient();

        private async  Task<string> GetPageAsync(string urlstr) {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }
    }
}
