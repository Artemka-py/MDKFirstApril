using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class PriemkaTovara : Form
    {
        public PriemkaTovara()
        {
            InitializeComponent();
        }

        private void btBack_Click_1(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btRedakt_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\djart\\Desktop\\MDK\\INGWIN\\ING\\INGWPFVMDK\\bin\\Debug\\INGWPF.exe");
        }

        private void PriemTovara_Load(object sender, EventArgs e)
        {
            dgSchetOtZavodaFill();
            dgTovarnNaklFill();
        }

        private void dgTovarnNaklFill()
        {
            Action action = () =>
            {
                Table_Class tableClass = new Table_Class($"SELECT Tovarnaya_Nakladnaya.Nazv_Tovarnoy_Nakladnoy as \"Название товарной накладной\" " +
                                                         $",Tovarnaya_Nakladnaya.Nomer_Tovarnoy_Nakladnoy as \"Номер товарной накладной\"\r\n ,Sotrudniki.Name_Sotrudnika as \"Фамилия\"\r\n " +
                                                         $",Sotrudniki.Midlle_Name_Sotrudnika as \"Имя\"\r\n ,Sotrudniki.Last_Name_Sotrudnika as \"Отчество\"\r\n " +
                                                         $",Pokupatel.Name_Pokupatelya as \"Имя покупателя\"\r\n ,Pokupatel.Midlle_Name_Pokupatelya as \"Фамилия покупателя\"\r\n " +
                                                         $",Pokupatel.Last_Name_Pokupatelya as \"Отчество покупателя\" FROM dbo.Tovarnaya_Nakladnaya " +
                                                         $"INNER JOIN dbo.Sotrudniki\r\n  ON Tovarnaya_Nakladnaya.Sotrudnika_ID = Sotrudniki.ID_Sotrudnika" +
                                                         $" INNER JOIN dbo.Dogovora\r\n  ON Tovarnaya_Nakladnaya.Dogovor_ID = Dogovora.ID_Dogovor " +
                                                         $"INNER JOIN dbo.Pokupatel\r\n  ON Dogovora.Pokupatel_ID = Pokupatel.ID_Pokupatel " +
                                                         $"WHERE Sotrudnika_ID = {Program.intID}");
                tableClass.Dependency.OnChange += Dependency_OnChange;
                dgTovNakl.DataSource = tableClass.table.DefaultView;
            };
            Invoke(action);
        }

        private void dgSchetOtZavodaFill()
        {
            Action action = () =>
            {
                Table_Class tableClass = new Table_Class($"SELECT [Name_Tovara] as \"Название товара\", [Nomer_Tovara] as \"Номер товара\", " +
                                                         $"[Price_Tovara] as \"Цена товара\", [Kolichestvo_Tovara] as \"Кол-во товара\", " +
                                                         $"[Nazv_Tovarnoy_Nakladnoy] as \"Название товарной накладной\" FROM dbo.Tovar " +
                                                         $"inner join [dbo].[Tovarnaya_Nakladnaya] on dbo.Tovar.Tovarnoy_Nakladnoy_ID = [dbo].[Tovarnaya_Nakladnaya].[ID_Tovarnoy_Nakladnoy]" +
                                                         $"where [dbo].[Tovarnaya_Nakladnaya].[Sotrudnika_ID] = '{Program.intID}'");
                tableClass.Dependency.OnChange += Dependency_OnChange;
                dgTovar.DataSource = tableClass.table.DefaultView;
            };
            Invoke(action);
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != System.Data.SqlClient.SqlNotificationInfo.Invalid)
            {
                dgSchetOtZavodaFill();
                dgTovarnNaklFill();
            }
        }
    }
}
