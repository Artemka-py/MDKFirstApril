using System;  
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class Soglasovanie : Form
    {
        public Soglasovanie()
        {
            InitializeComponent();
            dgObrabotkaZakaz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Soglasovanie_Load(object sender, EventArgs e)
        {
            dgObrabotkaZakazFill();
        }

        private void dgObrabotkaZakazFill()
        {
            Action action = () =>
            {
                Table_Class tableClass = new Table_Class("  select [Nomer_of_Dogovor] as \"Номер договора\",[Raschetniy_Schet] as \"Расчетный счет\",[Data_Peredachi] as \"Дата передачи договора\", [Name_of_Usluga] as \"Название услуги\", [Name_Pokupatelya] as \"Имя покупателя\" " +
                                                         "from [INGPROMTORG].[dbo].[Dogovora] inner join [INGPROMTORG].[dbo].[Usluga] on [INGPROMTORG].[dbo].[Dogovora].[Usluga_ID] = " +
                                                         "[INGPROMTORG].[dbo].[Usluga].[ID_Usluga] inner join [INGPROMTORG].[dbo].[Pokupatel] on [INGPROMTORG].[dbo].[Dogovora].[Pokupatel_ID] = [INGPROMTORG].[dbo].[Pokupatel].[ID_Pokupatel] " +
                                                         "INNER JOIN [dbo].[Tovarnaya_Nakladnaya] on [INGPROMTORG].[dbo].[Dogovora].[ID_Dogovor] = [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[Dogovor_ID] " +
                                                         $"WHERE [dbo].[Tovarnaya_Nakladnaya].[Sotrudnika_ID] = '{Program.intID}'");
                tableClass.Dependency.OnChange += Dependency_OnChange;
                dgObrabotkaZakaz.DataSource = tableClass.table.DefaultView;
            };
            Invoke(action);

        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != System.Data.SqlClient.SqlNotificationInfo.Invalid)
            {
                dgObrabotkaZakazFill();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
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
    }
}
