using SvoeDelo1;
using System;
using System.IO;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using System.Management;

namespace INGWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string sot, dol, pokup, usl, tovar, tovn, trann, dog;

        private void Authorization_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ChangeSize((int)e.NewSize.Width, (int)e.NewSize.Height);
        }

        public MainWindow()
        {
            SystemChek();
            switch (startup)
            {
                case true:
                    InitializeComponent();
                    tbEnterLogin.Clear();
                    tbEnterPassword.Clear();
                    ChangeSize((int)Width, (int)Height);
                    break;
                case false:
                    Close();
                    break;

            }
        }



        //Авторизация 
        private void BtEnter_Click(object sender, RoutedEventArgs e)
        {
            PerexodPoTabl perexodPoTabl = new PerexodPoTabl();
            Procedures procedures = new Procedures();
            string login = tbEnterLogin.Password.ToString();
            string password = tbEnterLogin.Password.ToString();
            string Acess = procedures.ingAuth(login, password);
            switch (Acess)
            {
                case (""):
                    MessageBox.Show("Не верно введен логин или пароль! \n" +
                        "Повторите попытку в ввода", "ИНЖПРОМТОРГ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                default:
                    sot = Acess[0].ToString();
                    dol = Acess[1].ToString();
                    pokup = Acess[2].ToString();
                    usl = Acess[3].ToString();
                    tovar = Acess[4].ToString();
                    tovn = Acess[5].ToString();
                    trann = Acess[6].ToString();
                    dog = Acess[7].ToString();
                    perexodPoTabl.Show();
                    Visibility = Visibility.Collapsed;
                    break;
            }
        }

        bool startup = true;
        private void SystemChek()
        {
            int Major = Environment.OSVersion.Version.Major;
            int Minor = Environment.OSVersion.Version.Minor;
            RegistryKey adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe");
            RegistryKey frame = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP");
            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") ||
                File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe"))
            {
                MessageBox.Show("Не установлен Chrome !", "ИНЖПРОМТОРГ");
                startup = false;
            }

            if (!File.Exists(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe") ||
                !File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
            {
                MessageBox.Show("Не установлен Firefox !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            if (!File.Exists(@"C:\Users\PC martin\AppData\Local\Programs\Opera"))
            {
                MessageBox.Show("Не установлен Opera !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            if (!File.Exists(@"C:\Users\PC martin\AppData\Local\Programs\Internet Explorer"))
            {
                MessageBox.Show("Не установлен Internet Explorer !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            if (frame != null)
            {
                MessageBox.Show("Не установлен .NET Framework !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            if (adobe != null)
            {
                RegistryKey acrobatReader = adobe.OpenSubKey("Acrobat Reader");

                if (acrobatReader != null)
                {
                    MessageBox.Show("Не установлен Acrobat Reader !", "ИНЖПРОМТОРГ");
                    startup = false;
                }
            }
            RegistryKey frecKey = Registry.LocalMachine;
            Type excel = Type.GetTypeFromProgID("Excel.Application");
            if (excel != null)
            {
                MessageBox.Show("Не установлен Excel !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            Type word = Type.GetTypeFromProgID("Word.Application");
            if (word == null)
            {
                MessageBox.Show("Не установлен Word !", "ИНЖПРОМТОРГ");
                startup = false;
            }

            frecKey = frecKey.OpenSubKey(
               @"HARDWARE\DESCRIPTION\System\CentralProcessor\0", false);
            Int32 MHz = Convert.ToInt32(frecKey.GetValue("~MHz").ToString());
            if (MHz < 1333)
            {
                MessageBox.Show("Не хватает тактовой частоты процессора !", "ИНЖПРОМТОРГ");
                startup = false;
            }
            if (new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory > 1)
            {
                MessageBox.Show("Не хватает оперативной памяти на компьютере!", "ИНЖПРОМТОРГ");
                startup = false;
            }

            foreach (var drive in DriveInfo.GetDrives())
            {
                try
                {
                    if (drive.AvailableFreeSpace > 5e+9)
                    {
                        MessageBox.Show("Не хватает памяти на жестком диске!", "ИНЖПРОМТОРГ");
                        startup = false;
                    }
                }
                catch { }
            }
            if ((Major >= 6) && (Minor >= 0))
            {
                RegistryKey registrySQL = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                if (registrySQL == null)
                {
                    MessageBox.Show("Запуск системы не возможен, " +
                        "в системе отсутсвует Microsoft SQL Server ",
                        "ИНЖПРОМТОРГ");
                    startup = false;
                }
                else
                {
                    try
                    {
                        DBConnection2.connection.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Не возможно подключиться к источнику данных", "ИНЖПРОМТОРГ");
                        startup = false;
                    }
                    finally
                    {
                        DBConnection2.connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Данная операционная система не предназначена для запуска приложения!", "ИНЖПРОМТОРГ");
                startup = false;
            }
        }

        private void ChangeSize(int X, int Y)
        {
            if ((X >= 0 && Y >= 0 ) && (X < 800 && Y < 600))
            {
                lblEnterLogin.FontSize = 12;
                lblEbterPassword.FontSize = 12;
                tbEnterLogin.FontSize = 12;
                tbEnterPassword.FontSize = 12;
                btEnter.FontSize = 12;
                btLeave.FontSize = 12;
            }
            else
            {
                if ((X >= 800 && Y >= 600) && (X <=1280 && Y <= 1024))
                {
                    lblEnterLogin.FontSize = 24;
                    lblEbterPassword.FontSize = 24;
                    tbEnterLogin.FontSize = 24;
                    tbEnterPassword.FontSize = 24;
                    btEnter.FontSize = 24;
                    btLeave.FontSize = 24;
                }
                else
                {
                    if ((X >= 1280 && Y >= 1024) && (X <= 1920 && Y <= 1080))
                    {
                        lblEnterLogin.FontSize = 36;
                        lblEbterPassword.FontSize = 36;
                        tbEnterLogin.FontSize = 36;
                        tbEnterPassword.FontSize = 36;
                        btEnter.FontSize = 36;
                        btLeave.FontSize = 36;
                    }
                }
            }
        }

        //Выход
        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
