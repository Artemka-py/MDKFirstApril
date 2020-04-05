using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    public partial class Registr : Form
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean Proverka = false;
                foreach (TextBox textBox in tblpRegistr.Controls.OfType<TextBox>())
                {
                    if (textBox.Text != null && textBox.TextLength > 1)
                    {
                        Proverka = true;
                    }
                    else
                    {
                        MessageBox.Show("Чето не так с вами, какое-то пустое значение переписывай!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (textBox.Name == tbDocument_Series.Name)
                        if (textBox.TextLength != 4)
                        {
                            MessageBox.Show("Чето не так с серией переписывай!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    if (textBox.Name == tbDocument_Number.Name)
                        if (textBox.TextLength != 6)
                        {
                            MessageBox.Show("Чето не так с номером переписывай!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                }

                if (Proverka == true && tbBirhady_Date_Sotrudnika.Text != null)
                {
                    RegisterGuest();
                }
                else
                {
                    MessageBox.Show("Чето не так переписывай!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch 
            {
                MessageBox.Show("Чето не так переписывай в программе!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RegisterGuest()
        {
            try
            {
                Procedure_CLass procedureCLass = new Procedure_CLass();
                ArrayList fieldValueList = new ArrayList() { tbName_Sotrudnika.Text, tbMidlle_Name_Sotrudnika.Text, tbLast_Name_Sotrudnika.Text, 
                    tbBirhady_Date_Sotrudnika.Text, tbDocument_Series.Text, tbDocument_Number.Text, tbSotrudnika_Login.Text, tbSotrudnika_Password.Text, 5 };
                procedureCLass.procedure_Execution("Sotrudniki_insert", fieldValueList);
                Authorization_From authorizationFrom = new Authorization_From();
                authorizationFrom.Show();
                this.Visible = false;
                this.ShowInTaskbar = false;
            }
            catch 
            {
                MessageBox.Show("Чето не так переписывай в программе insert!", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Authorization_From authorizationFrom = new Authorization_From();
            authorizationFrom.Show();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }
    }
}
