using System;
using System.Threading;
using System.Windows.Forms;
using CryptLibraryING;

namespace ING
{
    static class Program
    {
        public static string intID = "";
        public static string FIOSotr = "";
        public static Int32 intDropStatis = 0;
        public static string strStatus = "Null";
        public static bool connect = false;
        private static Mutex _instanse;
        private const string _app_name = "ИНЖПРОМТОРГ";
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool Create_app;
            _instanse = new Mutex(true, _app_name, out Create_app);
            if (Create_app)
            {
                try
                {
                    Configuration_class configuration = new Configuration_class();
                    configuration.SQL_Server_Configuration_get();
                    Configuration_class.connection.Open();
                    connect = true;
                }
                catch
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Connection_Form conection = new Connection_Form();
                    conection.ShowDialog();
                }
                finally
                {
                    Configuration_class.connection.Close();
                    switch (connect)
                    {
                        case false:
                            MessageBox.Show("Ошибка подключения", "ИНЖПРОМТОРГ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(0);
                            break;
                        case true:
                            try
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new Authorization_From());
                            }
                            catch { }
                            break;
                    }
                }
            }
        }
    }
}
