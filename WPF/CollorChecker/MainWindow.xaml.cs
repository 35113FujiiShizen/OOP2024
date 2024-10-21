using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        private byte alpha = 255; // alphaをフィールドとして定義

        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            var rvalue = (int)rSlider.Value;
            rValue.Text = rvalue.ToString();
            var gvalue = (int)gSlider.Value;
            gValue.Text = gvalue.ToString();
            var bvalue = (int)bSlider.Value;
            bValue.Text = bvalue.ToString();
            byte alpha = 255;

            
            colorArea.Background = new SolidColorBrush(Color.FromArgb(alpha, (byte)rvalue, (byte)gvalue, (byte)bvalue));
        }
    }
}
