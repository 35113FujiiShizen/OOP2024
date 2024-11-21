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
        private string selectedImagePath;

        private void InputItemsAllClear() {
            NameTextBox.Text = "";
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
        }

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
                ImagePath = selectedImagePath,
            };
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
        }

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
            item.ImagePath = selectedImagePath;
            selectedImagePath = null;

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.Update(item);
            }
            ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();
                CustomerListView.ItemsSource = _customers;
                InputItemsAllClear();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

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

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;

            if (item != null) {
                NameTextBox.Text = item.Name;
                PhoneTextBox.Text = item.Phone;
                AddressTextBox.Text = item.Address;
                TestImage.Source = null;

                // selectedImagePath が null または空でないことを確認し、画像を表示する
                if (!string.IsNullOrEmpty(item.ImagePath)) {
                    try {
                        BitmapImage bitmap = new BitmapImage(new Uri(item.ImagePath));
                        TestImage.Source = bitmap;  // 画像を表示する
                    }
                    catch (Exception ex) {
                        MessageBox.Show("画像の読み込みに失敗しました: " + ex.Message);
                    }
                }
            }
        }



        private void Hirakubutton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog {
                Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (openFileDialog.ShowDialog() == true) {
                try {
                    selectedImagePath = openFileDialog.FileName;  // 画像のファイルパスを保存
                    BitmapImage bitmap = new BitmapImage(new Uri(selectedImagePath));
                    TestImage.Source = bitmap;  // TestImage の Source を直接設定
                }
                catch (Exception ex) {
                    MessageBox.Show("画像を読み込む際にエラーが発生しました" + ex.Message);
                }
            }
        }

        private void Clearbutton_Click(object sender, RoutedEventArgs e) {
            TestImage.Source = null;
        }
    }
}
