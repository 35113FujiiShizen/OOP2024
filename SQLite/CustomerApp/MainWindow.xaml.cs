using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }
        private byte[] selectedImageData;

        private void InputItemsAllClear() {
            NameTextBox.Text = "";
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
            TestImage.Source = null;
        }

        //登録ボタン
        private void Savebutton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(NameTextBox.Text) && string.IsNullOrEmpty(AddressTextBox.Text) && string.IsNullOrEmpty(PhoneTextBox.Text)) {
                MessageBox.Show("何も入力されていません");
                return;
            }
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(AddressTextBox.Text) || string.IsNullOrEmpty(PhoneTextBox.Text)) {
                MessageBox.Show("名前、住所、電話番号のいずれかが未入力です");
                return;
            }
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImageData = selectedImageData,
            };
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
                
            }
            ReadDatabase();
        }

        //更新ボタン
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (string.IsNullOrEmpty(NameTextBox.Text) && string.IsNullOrEmpty(AddressTextBox.Text) && string.IsNullOrEmpty(PhoneTextBox.Text)) {
                MessageBox.Show("何も入力されていません");
                return;
            }
            if (string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(AddressTextBox.Text) || string.IsNullOrEmpty(PhoneTextBox.Text)) {
                MessageBox.Show("名前、住所、電話番号のいずれかが未入力です");
                return;
            }
            item.Name = NameTextBox.Text;
            item.Phone = PhoneTextBox.Text;
            item.Address = AddressTextBox.Text;
            item.ImageData = selectedImageData;
            selectedImageData = null;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.Update(item);
            }
            ReadDatabase();
            InputItemsAllClear();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;
            }
        }

        //検索ボックス
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        //削除ボタン
        private void Deletebutton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);
                ReadDatabase();
            }
        }

        //ListViewの中を選ぶと…
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;
                TestImage.Source = null;

                // selectedImageData が null または空でないことを確認し、画像を表示する
                if (item.ImageData != null && item.ImageData.Length > 0) {
                    try {
                        using (MemoryStream stream = new MemoryStream(item.ImageData)) {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = stream;  
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();

                            // 画像を表示する
                            TestImage.Source = bitmap;
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("画像の読み込みに失敗しました: " + ex.Message);
                    }
                }
            }
        }


        //開くボタン
        private void Hirakubutton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog {
                Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (openFileDialog.ShowDialog() == true) {
                try {
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    selectedImageData = imageData;  
                    using (MemoryStream stream = new MemoryStream(selectedImageData)) {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;  
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        // 画像を表示
                        TestImage.Source = bitmap;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("画像を読み込む際にエラーが発生しました" + ex.Message);
                }
            }
        }

        //プレビュー画像を削除
        private void Clearbutton_Click(object sender, RoutedEventArgs e) {
            TestImage.Source = null;
        }
    }
}
