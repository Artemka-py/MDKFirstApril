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
    /// Логика взаимодействия для Tovar.xaml
    /// </summary>
    public partial class Tovar : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Tovar()
        {
            InitializeComponent();
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void TovarWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrTovar;
            dgFill(QR);
            cbPFill();

        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrTovar = qr;
            connection.TovarFill();
            dgTovar.ItemsSource = connection.dtTovar.DefaultView;
            dgTovar.Columns[0].Visibility = Visibility.Collapsed;
            dgTovar.Columns[5].Visibility = Visibility.Collapsed;
        }

        //Заполнение комбо-бокса
        private void cbPFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.Tovarnoy_NakladnoyFill();
            cbTovarnoy_Nakladnoy_ID.ItemsSource = connection.dtTovarnaya_Nakladnaya.DefaultView;
            cbTovarnoy_Nakladnoy_ID.SelectedValuePath = "ID_Tovarnoy_Nakladnoy";
            cbTovarnoy_Nakladnoy_ID.DisplayMemberPath = "Nazv_Tovarnoy_Nakladnoy";
        }

        //Переименовка столбцов в датагрид
        private void DgTovar_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Name_Tovara"):
                    e.Column.Header = "Название товара";
                    break;
                case ("Nomer_Tovara"):
                    e.Column.Header = "Номер товара";
                    break;
                case ("Price_Tovara"):
                    e.Column.Header = "Цена товара";
                    break;
                case ("Kolichestvo_Tovara"):
                    e.Column.Header = "Кол-во товара";
                    break;
                case ("Nazv_Tovarnoy_Nakladnoy"):
                    e.Column.Header = "Название транспортной накладной";
                    break;
            }
        }

        private void DgTovar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Добавляем данные в бд
        private void BtDogovaraInsertType_Click(object sender, RoutedEventArgs e)
        {
            if (!(tbNomer_Tovara.Text.Length > 30) && !string.IsNullOrEmpty(tbNomer_Tovara.Text.ToString()) && !(tbName_Tovara.Text.Length > 100) && 
                !string.IsNullOrEmpty(tbName_Tovara.Text.ToString()) && !(tbPrice_Tovara.Text.Length < 0) && 
                !string.IsNullOrEmpty(tbKolichestvo_Tovara.Text.ToString()) && !(cbTovarnoy_Nakladnoy_ID.SelectedIndex == -1) )
            {
                procedures.ingTovar_insert(tbName_Tovara.Text.ToString(), tbNomer_Tovara.Text.ToString(), Convert.ToInt32(tbPrice_Tovara.Text.ToString()), Convert.ToInt32(tbPrice_Tovara.Text.ToString()), Convert.ToInt32(cbTovarnoy_Nakladnoy_ID.SelectedValue.ToString()));
                dgFill(QR);
                cbPFill();
            }
            else
            {
                MessageBox.Show("Робит", "Неправильный ввод данных!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Изменяем данные в бд
        private void BtDogovaraUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTovar.SelectedItems[0];
            if (!string.IsNullOrEmpty(ID.ToString()) && !(tbNomer_Tovara.Text.Length > 30) && !string.IsNullOrEmpty(tbNomer_Tovara.Text.ToString()) && !(tbName_Tovara.Text.Length > 100) &&
                !string.IsNullOrEmpty(tbName_Tovara.Text.ToString()) && !(tbPrice_Tovara.Text.Length < 0) &&
                !string.IsNullOrEmpty(tbKolichestvo_Tovara.Text.ToString()) && !(cbTovarnoy_Nakladnoy_ID.SelectedIndex == -1))
            {
                procedures.ingTovar_update(Convert.ToInt32(ID["ID_Tovar"]), tbName_Tovara.Text.ToString(), tbNomer_Tovara.Text.ToString(), Convert.ToInt32(tbPrice_Tovara.Text.ToString()), Convert.ToInt32(tbPrice_Tovara.Text.ToString()), Convert.ToInt32(cbTovarnoy_Nakladnoy_ID.SelectedValue.ToString()));
                dgFill(QR);
                cbPFill();
            }
            else
            {
                MessageBox.Show("Робит", "Неправильный ввод данных!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        //Удаляем данные из бд
        private void BtDogovaraDeleteType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView ID = (DataRowView)dgTovar.SelectedItems[0];
                if (!string.IsNullOrEmpty(ID.ToString()))
                {
                    procedures.ingTovar_delete(Convert.ToInt32(ID["ID_Tovar"]));
                    dgFill(QR);
                    cbPFill();
                }
                
            }
            catch
            {
                MessageBox.Show("Робит", "Неправильный ввод данных!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        //Поиск по значению введенному пользователем
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Name_Tovara] like '%" + tbSearch.Text + "%' or [Nomer_Tovara] like '%" + tbSearch.Text + "%' or [Price_Tovara] like '%" + tbSearch.Text + "%'" +
                " or [Kolichestvo_Tovara] like '%" + tbSearch.Text + "%' or [Nazv_Tovarnoy_Nakladnoy] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgTovar.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[6].ToString() == tbSearch.Text)
                        {
                            dgTovar.SelectedItem = dataRow;
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

        private void TbName_Tovara_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
