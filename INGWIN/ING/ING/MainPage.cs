using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            lblFIO.Text = Program.FIOSotr;
        }

        private void btObrabotkaZakaza_Click(object sender, EventArgs e)
        {
            ObrabotkaZakaza obrabotkaZakaza = new ObrabotkaZakaza();
            obrabotkaZakaza.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btSchetOtZavoda_Click(object sender, EventArgs e)
        {
            SchetOtZavoda otZavoda =new SchetOtZavoda();
            otZavoda.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btPogruzkaTovara_Click(object sender, EventArgs e)
        {
            PogruzkaTovara pogruzkaTovara = new PogruzkaTovara();
            pogruzkaTovara.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            Authorization_From authorizationFrom = new Authorization_From();
            authorizationFrom.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btExitAppl_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btSoglasovanie_Click(object sender, EventArgs e)
        {
            Soglasovanie soglasovanie = new Soglasovanie();
            soglasovanie.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void btPriemTovara_Click(object sender, EventArgs e)
        {
            PriemkaTovara priemkaTovara = new PriemkaTovara();
            priemkaTovara.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }
    }
}
