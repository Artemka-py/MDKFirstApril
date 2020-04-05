using SvoeDelo1;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace INGWPF
{
    /// <summary>
    /// Логика взаимодействия для Pokupatel.xaml
    /// </summary>
    public partial class Pokupatel : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Pokupatel()
        {
            InitializeComponent();
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void PokupatelWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrPokupatel;
            dgFill(QR);

        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrPokupatel = qr;
            connection.PokupatelFill();
            dgPokupatel.ItemsSource = connection.dtPokupatel.DefaultView;
            dgPokupatel.Columns[0].Visibility = Visibility.Collapsed;
        }

        //Переименовка столбцов в датагрид
        private void DgPokupatel_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Pokupatelya"):
                    e.Column.Header = "Имя покупателя";
                    break;
                case ("Midlle_Name_Pokupatelya"):
                    e.Column.Header = "Фамилия покупателя";
                    break;
                case ("Last_Name_Pokupatelya"):
                    e.Column.Header = "Отчество покупателя";
                    break;
                case ("Birhady_Date_Pokupatelya"):
                    e.Column.Header = "Дата рождения";
                    break;
                case ("Document_Series_Pokupatelya"):
                    e.Column.Header = "Серия паспорта";
                    break;
                case ("Document_Number_Pokupatelya"):
                    e.Column.Header = "Номер паспорта";
                    break;                
            }
        }

        private void DgPokupatel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Изменяем данные в бд
        private void BtPokupatelUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgPokupatel.SelectedItems[0];
            procedures.ingPokupatel_update(Convert.ToInt32(ID["ID_Pokupatel"]), tbName_Pokupatelya.Text.ToString(), tbMidlle_Name_Pokupatelya.Text.ToString(), tbLast_Name_Pokupatelya.Text.ToString(), tbBirhady_Date_Pokupatelya.Text.ToString(), tbDocument_Series_Pokupatelya.Text.ToString(), tbDocument_Number_Pokupatelya.Text.ToString());
            dgFill(QR);
        }

        //Добавляем данные в бд
        private void BtPokupatelInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingPokupatel_insert( tbName_Pokupatelya.Text.ToString(), tbMidlle_Name_Pokupatelya.Text.ToString(), tbLast_Name_Pokupatelya.Text.ToString(), tbBirhady_Date_Pokupatelya.Text.ToString(), tbDocument_Series_Pokupatelya.Text.ToString(), tbDocument_Number_Pokupatelya.Text.ToString());
            dgFill(QR);
        }

        //Удаляем данные из бд
        private void BtPokupatelDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgPokupatel.SelectedItems[0];
            procedures.ingPokupatel_delete(Convert.ToInt32(ID["ID_Pokupatel"]));
            dgFill(QR);

        }

        //Поиск по значению введенному пользователем
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Name_Pokupatelya] like '%" + tbSearch.Text + "%' or [Midlle_Name_Pokupatelya] like '%" + tbSearch.Text + "%' or [Last_Name_Pokupatelya] like '%" + tbSearch.Text + "%'" +
            " or [Birhady_Date_Pokupatelya] like '%" + tbSearch.Text + "%' or [Document_Series_Pokupatelya] like '%" + tbSearch.Text + "%' or [Document_Number_Pokupatelya] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgPokupatel.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[4].ToString() == tbSearch.Text)
                        {
                            dgPokupatel.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
            
        }

        //Закрывание формы
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            PerexodPoTabl perexodPoTabl = new PerexodPoTabl();
            perexodPoTabl.Show();
            Visibility = Visibility.Collapsed;
        }

        private void ChbFilter_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    btSearch.Content = "Фильтрация";
                    break;
                case (false):
                    btSearch.Content = "Поиск";
                    dgFill(QR);
                    break;
            }
        }
    }
}
