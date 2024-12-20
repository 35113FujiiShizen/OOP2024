﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 

    public partial class MainWindow : Window {
        private byte alpha = 255; // alphaをフィールドとして定義
        private MemoryStream saveMemoryStrem;
        MyColor currentColor;// = new MyColor();　構造体にしたからnewは不要
        private MyColor previousStockedColor = default;
        private MyColor[] colorsTable;
        public MainWindow() {
            InitializeComponent();
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //スライドを動かすと呼ばれるイベントハンドラー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(currentColor.Color);
            currentColor.Name = null;
            colorArea.Background = new SolidColorBrush(currentColor.Color);

            
            //var rvalue = (int)rSlider.Value;
            //rValue.Text = rvalue.ToString();
            //var gvalue = (int)gSlider.Value;
            //gValue.Text = gvalue.ToString();
            //var bvalue = (int)bSlider.Value;
            //bValue.Text = bvalue.ToString();
            //byte alpha = 255;
            //colorArea.Background = new SolidColorBrush(Color.FromArgb(alpha, (byte)rvalue, (byte)gvalue, (byte)bvalue));
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            //既に登録されている場合は登録しない。
            currentColor.Name = GetColorList().FirstOrDefault(c => c.Color.Equals(currentColor.Color)).Name;

            
            if (!currentColor.Color.Equals(previousStockedColor.Color)) {
                stockList.Items.Insert(0, currentColor);//MyColorを構造体にすることで参照型ではなく値型と同じようになる。
                previousStockedColor = currentColor;
                
            } else if(currentColor.Color.Equals(previousStockedColor.Color)) {
                MessageBox.Show("既にその色は登録済みです！");
            } 
            //var rvalue = (int)rSlider.Value;
            //var gvalue = (int)gSlider.Value;
            //var bvalue = (int)bSlider.Value;
            //var color = new MyColor {
            //    Color = Color.FromArgb(alpha, (byte)rvalue, (byte)gvalue, (byte)bvalue)
            //};
            //stockList.Items.Add(color);
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem != null) {
                MyColor selectedItem = (MyColor)stockList.SelectedItem; 
                setSliderText(selectedItem);
            }
        }

        private void setSliderText(MyColor selectedItem) {
            rValue.Text = selectedItem.Color.R.ToString();
            gValue.Text = selectedItem.Color.G.ToString();
            bValue.Text = selectedItem.Color.B.ToString();
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = currentColor =(MyColor)((ComboBox)sender).SelectedItem;
            //各スライダーの値を設定
            setSliderText(mycolor);
            currentColor.Name = mycolor.Name;//Nameプロパティの文字列を再設定

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem != null) {
                stockList.Items.Remove(stockList.SelectedItem);
            } else {
                MessageBox.Show("削除する色を選択してください！");
            }
        }
    }
}
