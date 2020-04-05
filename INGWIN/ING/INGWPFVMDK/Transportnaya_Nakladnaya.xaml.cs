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
    /// Логика взаимодействия для Transportnaya_Nakladnaya.xaml
    /// </summary>
    public partial class Transportnaya_Nakladnaya : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Transportnaya_Nakladnaya()
        {
            InitializeComponent();
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void Transportnaya_NakladnayaWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrTransportnaya_Nakladnaya;
            dgFill(QR);
            cbPFill();
            cbUFill();

        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            DBConnection2 connection = new DBConnection2();
            DBConnection2.qrTransportnaya_Nakladnaya = qr;
            connection.Transportnaya_NakladnayaFill();
            dgTransportnaya_NakladnayaWPF.ItemsSource = connection.dtTransportnaya_Nakladnaya.DefaultView;
            dgTransportnaya_NakladnayaWPF.Columns[0].Visibility = Visibility.Collapsed;
            dgTransportnaya_NakladnayaWPF.Columns[4].Visibility = Visibility.Collapsed;
            dgTransportnaya_NakladnayaWPF.Columns[5].Visibility = Visibility.Collapsed;
        }

        //Заполнение комбо-бокса
        private void cbPFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.DogovoraFill();
            cbNomer_of_Dogovor.ItemsSource = connection.dtDogovora.DefaultView;
            cbNomer_of_Dogovor.SelectedValuePath = "ID_Dogovor";
            cbNomer_of_Dogovor.DisplayMemberPath = "Nomer_of_Dogovor";
        }

        //Заполнение комбо-бокса
        private void cbUFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.SotrudnikiFill();
            cbName_Sotrudnika.ItemsSource = connection.dtSotrudniki.DefaultView;
            cbName_Sotrudnika.SelectedValuePath = "ID_Sotrudnika";
            cbName_Sotrudnika.DisplayMemberPath = "Name_Sotrudnika";
        }

        //Переименовка столбцов в датагрид
        private void DgTransportnaya_NakladnayaWPF_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Nazv_Transportnoy_Nakladnoy"):
                    e.Column.Header = "Навзвание транспортной накладной";
                    break;
                case ("Nomer_Transportnoy_Nakladnoy"):
                    e.Column.Header = "Номер транспортной накладной";
                    break;
                case ("Adress_Dostavki"):
                    e.Column.Header = "Адрес доставки";
                    break;
                case ("Nomer_of_Dogovor"):
                    e.Column.Header = "Номер договора";
                    break;
                case ("Name_Sotrudnika"):
                    e.Column.Header = "Имя покупателя";
                    break;
            }
        }

        private void DgTransportnaya_NakladnayaWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Добавляем данные в бд
        private void BtTransportnaya_NakladnayaInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingTransportnaya_Nakladnaya_insert(tbNazv_Transportnoy_Nakladnoy.Text.ToString(), tbNomer_Transportnoy_Nakladnoy.Text.ToString(), tbAdress_Dostavki.Text.ToString(), Convert.ToInt32(cbNomer_of_Dogovor.SelectedValue.ToString()), Convert.ToInt32(cbName_Sotrudnika.SelectedValue.ToString()));
            dgFill(QR);
            cbPFill();
            cbUFill();
        }

        //Изменяем данные в бд
        private void BtTransportnaya_NakladnayaUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTransportnaya_NakladnayaWPF.SelectedItems[0];
            procedures.ingTransportnaya_Nakladnaya_update(Convert.ToInt32(ID["ID_Transportnoy_Nakladnoy"]), tbNazv_Transportnoy_Nakladnoy.Text.ToString(), tbNomer_Transportnoy_Nakladnoy.Text.ToString(), tbAdress_Dostavki.Text.ToString(), Convert.ToInt32(cbNomer_of_Dogovor.SelectedValue.ToString()), Convert.ToInt32(cbName_Sotrudnika.SelectedValue.ToString()));
            dgFill(QR);
            cbPFill();
            cbUFill();
        }

        //Удаляем данные из бд
        private void BtTransportnaya_NakladnayaDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgTransportnaya_NakladnayaWPF.SelectedItems[0];
            procedures.ingTransportnaya_Nakladnaya_delete(Convert.ToInt32(ID["ID_Transportnoy_Nakladnoy"]));
            dgFill(QR);
            cbPFill();
            cbUFill();

        }

        //Поиск по значению введенному пользователем
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Nazv_Transportnoy_Nakladnoy] like '%" + tbSearch.Text + "%' or [Nomer_Transportnoy_Nakladnoy] like '%" + tbSearch.Text + "%' or [Adress_Dostavki] like '%" + tbSearch.Text + "%' or [Nomer_of_Dogovor] like '%" + tbSearch.Text + "%'" +
                        " or [Name_Sotrudnika] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgTransportnaya_NakladnayaWPF.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[6].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[7].ToString() == tbSearch.Text)
                        {
                            dgTransportnaya_NakladnayaWPF.SelectedItem = dataRow;
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
