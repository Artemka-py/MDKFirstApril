using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class SchetOtZavoda : Form
    {
        public SchetOtZavoda()
        {
            InitializeComponent();
            dgSchetOtZavoda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SchetOtZavoda_Load(object sender, EventArgs e)
        {
            dgSchetOtZavodaFill();
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
                dgSchetOtZavoda.DataSource = tableClass.table.DefaultView;
            };
            Invoke(action);
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != System.Data.SqlClient.SqlNotificationInfo.Invalid)
            {
                dgSchetOtZavodaFill();
            }
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
            ObrabotkaZakaza obrabotkaZakaza = new ObrabotkaZakaza();
            obrabotkaZakaza.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }
    }
}
