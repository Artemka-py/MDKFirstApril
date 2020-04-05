using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using AesCrypt;

namespace INGWPF
{
    /// PrivateWifi99
    /// <summary>
    /// Логика взаимодействия для PerexodPoTabl.xaml
    /// </summary>
    public partial class PerexodPoTabl : Window
    {
        //Проверяем доступ сотрудника который авторизовался
        public PerexodPoTabl()
        {
            InitializeComponent();

            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Nevagno");
            
            string result = key.GetValue("result").ToString();
            string _pass = "127812";
            Rijndael cipher = new Rijndael();
            string Acess = cipher.Decode(result.Trim(), _pass.Trim(), 256, true);

            btSotrudniki.IsEnabled = Acess[0].ToString() != "0";
            btDolgnost.IsEnabled = Acess[1].ToString() != "0";
            btPokupatel.IsEnabled = Acess[2].ToString() != "0";
            btUslugi.IsEnabled = Acess[3].ToString() != "0";
            btTovar.IsEnabled = Acess[4].ToString() != "0";
            btTovarnoy_Nakladnoy.IsEnabled = Acess[5].ToString() != "0";
            btTransportnaya_Nakladnaya.IsEnabled = Acess[6].ToString() != "0";
            btDogovara.IsEnabled = Acess[7].ToString() != "0";
        }

        //Открытие формы
        private void BtDolgnost_Click(object sender, RoutedEventArgs e)
        {
            Dolgnost dolgnost = new Dolgnost();
            dolgnost.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtDogovara_Click(object sender, RoutedEventArgs e)
        {
            Dogovara Dogovara = new Dogovara();
            Dogovara.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtUslugi_Click(object sender, RoutedEventArgs e)
        {
            Uslugi uslugi = new Uslugi();
            uslugi.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtPokupatel_Click(object sender, RoutedEventArgs e)
        {
            Pokupatel Pokupatel = new Pokupatel();
            Pokupatel.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtTransportnaya_Nakladnaya_Click(object sender, RoutedEventArgs e)
        {
            Transportnaya_Nakladnaya Transportnaya_Nakladnaya = new Transportnaya_Nakladnaya();
            Transportnaya_Nakladnaya.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtTovarnoy_Nakladnoy_Click(object sender, RoutedEventArgs e)
        {
            Tovarnoy_Nakladnoy Tovarnoy_Nakladnoy = new Tovarnoy_Nakladnoy();
            Tovarnoy_Nakladnoy.Show();
            Visibility = Visibility.Collapsed;
        }

        //Открытие формы
        private void BtTovar_Click(object sender, RoutedEventArgs e)
        {
            Tovar Tovar = new Tovar();
            Tovar.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
