using System;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class PogruzkaTovara : Form
    {
        private static string Zapros = "";

        public PogruzkaTovara()
        {
            Table_Class Nomera = new Table_Class($"SELECT dbo.NomeraDogovorov({Program.intID}, 0 )");
            Zapros = Nomera.table.Rows[0][0].ToString();
            InitializeComponent();
            dgPriemka.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void PogruzkaTovara_Load(object sender, EventArgs e)
        {
            PogruzkaTovaraFill(Zapros);
        }

        private void PogruzkaTovaraFill(string query)
        {
            Action action = () =>
            {
                Table_Class tableClass = new Table_Class(query);
                tableClass.Dependency.OnChange += Dependency_OnChange; ;
                dgPriemka.DataSource = tableClass.table.DefaultView;
            };
            Invoke(action);
        }

        private void Dependency_OnChange(object sender, System.Data.SqlClient.SqlNotificationEventArgs e)
        {
            if (e.Info != System.Data.SqlClient.SqlNotificationInfo.Invalid)
            {
                PogruzkaTovaraFill(Zapros);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void nudNomerDog_ValueChanged(object sender, EventArgs e)
        {
            if (nudNomerDog.Text != null && nudNomerDog.Value != 0)
            {
                Table_Class Nomera = new Table_Class($"SELECT dbo.NomeraDogovorov ({Program.intID},{nudNomerDog.Value})");
                Zapros = Nomera.table.Rows[0][0].ToString();
                PogruzkaTovaraFill(Zapros);
            }
            else
            {
                Table_Class Nomera = new Table_Class($"SELECT dbo.NomeraDogovorov({Program.intID}, 0 )");
                Zapros = Nomera.table.Rows[0][0].ToString();
                PogruzkaTovaraFill(Zapros);
            }
        }
    }
}