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
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Sotrudniki()
        {
            InitializeComponent();
        }

        //Переименовка столбцов в датагрид
        private void DgSotrudnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Sotrudnika"):
                    e.Column.Header = "Фамилия сотрудники";
                    break;
                case ("Midlle_Name_Sotrudnika"):
                    e.Column.Header = "Имя сотрудники";
                    break;
                case ("Last_Name_Sotrudnika"):
                    e.Column.Header = "Отчество сотрудники";
                    break;
                case ("Birhady_Date_Sotrudnika"):
                    e.Column.Header = "Дата рождения";
                    break;
                case ("Document_Series"):
                    e.Column.Header = "Серия паспорта";
                    break;
                case ("Document_Number"):
                    e.Column.Header = "Номер паспорта";
                    break;
                case ("Sotrudnika_Login"):
                    e.Column.Header = "Логин сотрудника";
                    break;
                case ("Sotrudnika_Password"):
                    e.Column.Header = "Пароль сотрудника";
                    break;
                case ("Name_of_Dolgnost"):
                    e.Column.Header = "Имя должности";
                    break;
            }
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void Sotrudniki_Loaded(object sender, RoutedEventArgs e)
        {
                QR = DBConnection2.qrSotrudniki;
                dgFill(QR);
                cbFill();
            
        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrSotrudniki = qr;
            connection.SotrudnikiFill();
            dgSotrudnik.ItemsSource = connection.dtSotrudniki.DefaultView;
            dgSotrudnik.Columns[0].Visibility = Visibility.Collapsed;
            dgSotrudnik.Columns[8].Visibility = Visibility.Collapsed;
            dgSotrudnik.Columns[9].Visibility = Visibility.Collapsed;
        }

        //Заполнение комбо-бокса
        private void cbFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.DolgnostFill();
            cbDolgnost.ItemsSource = connection.dtDolgnost.DefaultView;
            cbDolgnost.SelectedValuePath = "ID_Dolgnost";
            cbDolgnost.DisplayMemberPath = "Name_of_Dolgnost";
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
                    string newQR = QR + "where [Name_Sotrudnika] like '%" + tbSearch.Text + "%' or [Midlle_Name_Sotrudnika] like '%" + tbSearch.Text + "%' or [Last_Name_Sotrudnika] like '%" + tbSearch.Text + "%'" +
                " or [Birhady_Date_Sotrudnika] like '%" + tbSearch.Text + "%' or [Document_Series] like '%" + tbSearch.Text + "%' or [Document_Number] like '%" + tbSearch.Text + "%' or [Sotrudnika_Login] like '%" + tbSearch.Text + "%' " +
                "or [Sotrudnika_Password] like '%" + tbSearch.Text + "%' or [Name_of_Dolgnost] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgSotrudnik.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[7].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[10].ToString() == tbSearch.Text)
                        {
                            dgSotrudnik.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
            
        }

        //Добавляем данные в бд
        private void BtSotrudnikInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingSotrudniki_insert(tbName_Sotrudnika.Text.ToString(), tbMidlle_Name_Sotrudnika.Text.ToString(), tbLast_Name_Sotrudnika.Text.ToString(), 
                tbDate_Sotrudnika.Text.ToString(), tbSeries_Sotrudnika.Text.ToString(), tbNumber_Sotrudnika.Text.ToString(), tbLogin_Sotrudnika.Text.ToString(), 
                tbPassword_Sotrudnika.Text.ToString(), Convert.ToInt32(cbDolgnost.SelectedValue.ToString()));
            dgFill(QR);
            cbFill();
        }

        //Изменяем данные в бд
        private void BtSotrudnikUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgSotrudnik.SelectedItems[0];
            procedures.ingSotrudniki_update(Convert.ToInt32(ID["ID_Sotrudnika"]), tbName_Sotrudnika.Text.ToString(), tbMidlle_Name_Sotrudnika.Text.ToString(), tbLast_Name_Sotrudnika.Text.ToString(),
               tbDate_Sotrudnika.Text.ToString(), tbSeries_Sotrudnika.Text.ToString(), tbNumber_Sotrudnika.Text.ToString(), tbLogin_Sotrudnika.Text.ToString(),
               tbPassword_Sotrudnika.Text.ToString(), Convert.ToInt32(cbDolgnost.SelectedValue.ToString()));
            dgFill(QR);
            cbFill();
        }

        //Удаляем данные из бд
        private void BtSotrudnikDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgSotrudnik.SelectedItems[0];
            procedures.ingSotrudniki_delete(Convert.ToInt32(ID["ID_Sotrudnika"]));
            dgFill(QR);
            cbFill();
        }

        //Сортировка
        private void DgSotrudnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
