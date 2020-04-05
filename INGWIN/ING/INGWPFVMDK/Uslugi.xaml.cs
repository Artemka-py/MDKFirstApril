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
    /// Логика взаимодействия для Uslugi.xaml
    /// </summary>
    public partial class Uslugi : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Uslugi()
        {
            InitializeComponent();
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void UslugiWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrUsluga;
            dgFill(QR);
        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrUsluga = qr;
            connection.UslugiFill();
            dgUslugi.ItemsSource = connection.dtUsluga.DefaultView;
            dgUslugi.Columns[0].Visibility = Visibility.Collapsed;
        }

        //Добавляем данные в бд
        private void BtUslugiInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingUsluga_insert(tbName_Of_Usluga.Text.ToString(),Convert.ToInt32( tbPrice_Usluga.Text.ToString()));
            dgFill(QR);
        }

        //Изменяем данные в бд
        private void BtUslugiUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgUslugi.SelectedItems[0];
            procedures.ingUsluga_update(Convert.ToInt32(ID["ID_Usluga"]),tbName_Of_Usluga.Text.ToString(), Convert.ToInt32(tbPrice_Usluga.Text.ToString()));
            dgFill(QR);
        }

        //Удаляем данные из бд
        private void BtUslugiDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgUslugi.SelectedItems[0];
            procedures.ingUsluga_delete(Convert.ToInt32(ID["ID_Usluga"]));
            dgFill(QR);
        }

        //Закрывание формы
        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            PerexodPoTabl perexodPoTabl = new PerexodPoTabl();
            perexodPoTabl.Show();
            Visibility = Visibility.Collapsed;
        }

        //Поиск по значению введенному пользователем
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Name_Of_Usluga] like '%" + tbSearch.Text + "%' or [Price_Usluga] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgUslugi.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text)
                        {
                            dgUslugi.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
            
        }

        //Переименовка столбцов в датагрид
        private void DgUslugi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Of_Usluga"):
                    e.Column.Header = "Название услуги";
                    break;
                case ("Price_Usluga"):
                    e.Column.Header = "Цена услуги";
                    break;
            }
        }

        private void DgUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
