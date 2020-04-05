using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AesCrypt;
using CryptLibraryING;
using Microsoft.Win32;

namespace ING
{
    public partial class Authorization_From : Form
    {
        public static string sot, dol, pokup, usl, tovar, tovn, trann, dog;

        public Authorization_From()
        {
            InitializeComponent();
            this.CenterToScreen();
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load("C:\\Users\\djart\\Desktop\\MDK\\INGWIN\\ING\\ING\\laba.xml");
            //XmlElement xRoot = xDoc.DocumentElement;
            //foreach (XmlNode xnode in xRoot)
            //{
            //    if (xnode.Attributes.Count > 0)
            //    {
            //        XmlNode attr = xnode.Attributes.GetNamedItem("text");
            //        if (attr != null)
            //        {
            //            radioButton1.Text = attr.Value;
            //            radioButton2.Text = attr.Value;
            //            radioButton3.Text = attr.Value;
            //        }
            //    }
            //}
        }

        private void btEnter_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text.ToString();
            string password = tbPassword.Text.ToString();
            Table_Class tableClass = new Table_Class($"SELECT dbo.Auth ('{login}','{password}')");
            if (tableClass.table.Rows[0][0] != DBNull.Value)
            {
                Table_Class isSotrClass = new Table_Class($"SELECT ID_Sotrudnika, Name_Sotrudnika, Midlle_Name_Sotrudnika, Last_Name_Sotrudnika FROM [dbo].[Sotrudniki] WHERE [Sotrudnika_Login] = '{login}'");
                Program.intID = isSotrClass.table.Rows[0][0].ToString();
                FIO(isSotrClass.table.Rows[0][1].ToString(), isSotrClass.table.Rows[0][2].ToString(), isSotrClass.table.Rows[0][3].ToString());
                string Acess = tableClass.table.Rows[0][0].ToString();
                sot = Acess[0].ToString();
                dol = Acess[1].ToString();
                pokup = Acess[2].ToString();
                usl = Acess[3].ToString();
                tovar = Acess[4].ToString();
                tovn = Acess[5].ToString();
                trann = Acess[6].ToString();
                dog = Acess[7].ToString();

                string _pass = "127812";
                Rijndael cipher = new Rijndael();
                string result = cipher.Encode(Acess.Trim(), _pass.Trim(), 256, true);

                RegistryKey registry = Registry.CurrentUser;
                RegistryKey key = registry.CreateSubKey("Nevagno");
                key.SetValue("result", result);

                MainPage mainPage = new MainPage();
                mainPage.Show();
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            else
            {
                MessageBox.Show("Не правильно введен логин или пароль!!!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbPassword.Text = "";
            }
        }

        private void FIO(string first, string second, string last)
        {
            string inicialF = first[0] + ". ";
            string inicialL = last[0] + ".";
            Program.FIOSotr = second + " " + inicialL + inicialF;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }
    }
}
