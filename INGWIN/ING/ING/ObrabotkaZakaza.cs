using System;
using System.Diagnostics;
using System.Windows.Forms;
using CryptLibraryING;
using Sale_App;

namespace ING
{
    public partial class ObrabotkaZakaza : Form
    {
        Table_Class test = new Table_Class("SELECT * from [INGPROMTORG].[dbo].[Dogovora]");

        public ObrabotkaZakaza()
        {
            InitializeComponent();

            dgObrabotkaZakaz.AutoGenerateColumns = true;
            dgTovNakl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgObrabotkaZakaz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ObrabotkaZakaza_Load(object sender, EventArgs e)
        {
            dgObrabotkaZakazFill();
            dgTovarnNaklFill();
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

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != System.Data.SqlClient.SqlNotificationInfo.Invalid)
            {
                dgObrabotkaZakazFill();
                dgTovarnNaklFill();
            }
        }

        private void btRedakt_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\djart\\Desktop\\MDK\\INGWIN\\ING\\INGWPFVMDK\\bin\\Debug\\INGWPF.exe");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btSchetOtZavoda_Click(object sender, EventArgs e)
        {
            SchetOtZavoda otZavoda = new SchetOtZavoda();
            otZavoda.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btDogKupProdagProvodka_Click(object sender, EventArgs e)
        {
            Document_Class documentClass = new Document_Class();
            documentClass.Document_Create(Document_Class.Document_Type.Report, Document_Class.Document_Format.Word, "TestWord", test.table);
            documentClass.Document_Create(Document_Class.Document_Type.Report, Document_Class.Document_Format.Excel, "TestXLS", test.table);
        }

        private void btTovarNaklProvod_Click(object sender, EventArgs e)
        {
            Document_Class documentClass = new Document_Class();
            documentClass.Document_Create(Document_Class.Document_Type.Statistic, Document_Class.Document_Format.Word, "TovNakl", test.table);
            documentClass.Document_Create(Document_Class.Document_Type.Statistic, Document_Class.Document_Format.Excel, "TovNakl", test.table);
        }
    }
}


