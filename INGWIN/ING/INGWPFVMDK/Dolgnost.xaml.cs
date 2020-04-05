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
using SvoeDelo1;

namespace INGWPF
{
    /// <summary>
    /// Логика взаимодействия для Dolgnost.xaml
    /// </summary>
    public partial class Dolgnost : Window
    {
        Procedures procedures = new Procedures();
        private string QR = "";

        public Dolgnost()
        {
            InitializeComponent();
        }

        //Переименовка столбцов в датагрид
        private void DgDolgnost_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_of_Dolgnost"):
                    e.Column.Header = "Название должности";
                    break;
                case ("Oklad_of_Dolgnost"):
                    e.Column.Header = "Оклад";
                    break;
                case ("Dostup_Dolgnost"):
                    e.Column.Header = "Доступ";
                    break;
            }
        }

        //Для филтрации
        private void DgDolgnost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Поиск по значению введенному пользователем
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Name_of_Dolgnost] like '%" + tbSearch.Text + "%' or [Oklad_of_Dolgnost] like '%" + tbSearch.Text + "%' or [Dostup_Dolgnost] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgDolgnost.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text)
                        {
                            dgDolgnost.SelectedItem = dataRow;
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

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void DolgnostWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrDolgnost;
            dgFill(QR);
        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrDolgnost = qr;
            connection.DolgnostFill();
            dgDolgnost.ItemsSource = connection.dtDolgnost.DefaultView;
            dgDolgnost.Columns[0].Visibility = Visibility.Collapsed;
        }

        //Добавляем данные в бд
        private void BtDolgnostInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingDolgnost_insert(tbName_Dolgnost.Text.ToString(), Convert.ToInt32(tbOklad.Text.ToString()), tbDostup_Dolgnost.Text.ToString());
            dgFill(QR);
        }

        //Изменяем данные в бд
        private void BtDolgnostUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDolgnost.SelectedItems[0];
            procedures.ingDolgnost_update(Convert.ToInt32(ID["ID_Dolgnost"]),tbName_Dolgnost.Text.ToString() ,Convert.ToInt32(tbOklad.Text.ToString()), tbDostup_Dolgnost.Text.ToString());
            dgFill(QR);

        }

        //Удаляем данные из бд
        private void BtDolgnostDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDolgnost.SelectedItems[0];
            procedures.ingDolgnost_delete(Convert.ToInt32(ID["ID_Dolgnost"]));
            dgFill(QR);

        }

        private void ChbFilter_Checked(object sender, RoutedEventArgs e)
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
