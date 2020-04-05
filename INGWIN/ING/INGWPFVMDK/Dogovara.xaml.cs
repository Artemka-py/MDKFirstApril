using SvoeDelo1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Dogovara.xaml
    /// </summary>
    public partial class Dogovara : Window
    {
        //Создаем классы и переменные
        Procedures procedures = new Procedures();
        private string QR = "";

        public Dogovara()
        {
            InitializeComponent();
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
                dgFill(QR);
        }

        //Загрузка формы и заполнение датагрид и нужных нам компонентов
        private void DogovaraWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection2.qrDogovara;
            dgFill(QR);
            cbPFill();
            cbUFill();
        }

        //Заполнение датагрида
        private void dgFill(string qr)
        {
            Action action = () =>
            {
                DBConnection2 connection = new DBConnection2();
                DBConnection2.qrDogovara = qr;
                connection.DogovoraFill();
                dgDogovara.ItemsSource = connection.dtDogovora.DefaultView;
                dgDogovara.Columns[0].Visibility = Visibility.Collapsed;
                dgDogovara.Columns[4].Visibility = Visibility.Collapsed;
                dgDogovara.Columns[5].Visibility = Visibility.Collapsed;
            };
            Dispatcher.Invoke(action);
        }

        //Заполнение комбо-бокса
        private void cbPFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.PokupatelFill();
            cbPokupatel_ID.ItemsSource = connection.dtPokupatel.DefaultView;
            cbPokupatel_ID.SelectedValuePath = "ID_Pokupatel";
            cbPokupatel_ID.DisplayMemberPath = "Name_Pokupatelya";
        }

        //Заполнение комбо-бокса
        private void cbUFill()
        {
            DBConnection2 connection = new DBConnection2();
            connection.UslugiFill();
            cbUsluga_ID.ItemsSource = connection.dtUsluga.DefaultView;
            cbUsluga_ID.SelectedValuePath = "ID_Usluga";
            cbUsluga_ID.DisplayMemberPath = "Name_Of_Usluga";
        }

        //Переименовка столбцов в датагрид
        private void DgDogovara_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Nomer_of_Dogovor"):
                    e.Column.Header = "Номер договора";
                    break;
                case ("Raschetniy_Schet"):
                    e.Column.Header = "Расчетный счет";
                    break;
                case ("Data_Peredachi"):
                    e.Column.Header = "Дата передачи договора";
                    break;
                case ("Name_of_Usluga"):
                    e.Column.Header = "Название услуги";
                    break;
                case ("Name_Pokupatelya"):
                    e.Column.Header = "Имя покупателя";
                    break;
            }
        }

        //Добавляем данные в бд
        private void BtDogovaraInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.ingDogovora_insert(tbNomer_of_Dogovor.Text.ToString(), tbRaschetniy_Schet.Text.ToString(), tbData_Peredachi.Text.ToString(), Convert.ToInt32(cbPokupatel_ID.SelectedValue.ToString()), Convert.ToInt32(cbUsluga_ID.SelectedValue.ToString()));
            dgFill(QR);
            cbPFill();
            cbUFill();
        }

        //Изменяем данные в бд
        private void BtDogovaraUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDogovara.SelectedItems[0];
            procedures.ingDogovora_update(Convert.ToInt32(ID["ID_Dogovor"]),tbNomer_of_Dogovor.Text.ToString(), tbRaschetniy_Schet.Text.ToString(), tbData_Peredachi.Text.ToString(), Convert.ToInt32(cbPokupatel_ID.SelectedValue.ToString()), Convert.ToInt32(cbUsluga_ID.SelectedValue.ToString()));
            dgFill(QR);
            cbPFill();
            cbUFill();
        }

        //Удаляем данные из бд
        private void BtDogovaraDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dgDogovara.SelectedItems[0];
            procedures.ingDogovora_delete(Convert.ToInt32(ID["ID_Dogovor"]));
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
                    string newQR = QR + "where [Nomer_of_Dogovor] like '%" + tbSearch.Text + "%' or [Raschetniy_Schet] like '%" + tbSearch.Text + "%' or [Data_Peredachi] like '%" + tbSearch.Text + "%'" +
                         " or [Name_of_Usluga] like '%" + tbSearch.Text + "%' or [Name_Pokupatelya] like '%" + tbSearch.Text + "%'";
                    dgFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dgDogovara.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[6].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[7].ToString() == tbSearch.Text)
                        {
                            dgDogovara.SelectedItem = dataRow;
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
