using System;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace CryptLibraryING
{
    public class Procedure_CLass
    {
        SqlCommand command = new SqlCommand("", Configuration_class.connection);
        /// <summary>
        /// Мктод обращения к любой хранимой процедуре M SQL serever
        /// </summary>
        /// <param name="Procedure_Name"> вводимое знание процедуры из бд</param>
        /// <param name="filed_value"> Не типизированная коллекция значений приложения</param>
        public void procedure_Execution(string Procedure_Name, ArrayList filed_value)
        {
            //запрос на вывод списка параметров, конкретной хранимой процедуры
            //в зависимости от введённого разработчиком названия STORED pROCEDURE
            Table_Class table = new Table_Class(string.Format("Select name from sys.parameters where " + "Object_id =" +
                "(select object_id from sys.procedures where name = '{0}')", Procedure_Name));
            try
            {
                //Настройка SQLCommand для работы сс хранимыми процедурами
                command.CommandType = CommandType.StoredProcedure;
                //Присвоение в текст команды названия хранимой процеуры
                command.CommandText = string.Format("[dbo].[{0}]", Procedure_Name);
                //Очистка параметров
                command.Parameters.Clear();
                for (int i = 0; i < table.table.Rows.Count; i++)
                {
                    command.Parameters.AddWithValue(table.table.Rows[i][0].ToString(), filed_value[i]);
                }
                Configuration_class.connection.Open();
                //Обьявление события на перехват сообщение из БД
                Configuration_class.connection.InfoMessage += Connection_InfoMessage;
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                Configuration_class.connection.Close();
            }
        }

        /// <summary>
        /// Обработчик событий о получении с сервера БД
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Аргумент сообщения сервера</param>
        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message);
            Configuration_class.connection.InfoMessage -= Connection_InfoMessage;
        }
    }

    public class Configuration_class
    {
        public event Action<DataTable> server_Collection;
        //Получение коллекцию доступных серверов
        public event Action<DataTable> Data_Base_Collection;
        //Получения коллекции доступных БД на сервере
        public event Action<bool> connection_checked;
        //Статус подключения
        public string DS = "Empty", //Переменная data Source
            IC = "Empty";
        public string ds = ""; //Проверка подключение data source
        public static SqlConnection connection = new SqlConnection();

        /// <summary>
        /// Так можно отдать ссылку на метод
        /// </summary>
        public void SQL_Server_Configuration_get()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            try
            {
                DS = key.GetValue("DS").ToString();
                IC = key.GetValue("IC").ToString();
            }
            catch
            {
                DS = "Empty";
                IC = "Empty";
            }
            finally
            {
                //Обновление строки подключения
                connection.ConnectionString = "Data Source = " + DS + "; Initial Catalog = " + IC + "; Integrated Security = true;";
            }
        }
        /// <summary>
        /// Метод обновения информации о подключение к источнику данных
        /// по технологии ADO.NET
        /// </summary>
        public void SQL_Server_Configuration_Set(string ds, string ic)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_Configuration");
            key.SetValue("DS", ds);//Запись значения в переменную реестра
            key.SetValue("IC", ic);
            SQL_Server_Configuration_get();
        }
        /// <summary>
        /// Метод возвращает список доустпных сервров в локалке
        /// </summary>

        public void SQL_Server_Enumurator()
        {
            //получить сведения доступных серверов
            SqlDataSourceEnumerator sourceEnumerator = SqlDataSourceEnumerator.Instance;
            //Присвоение Event Action списка серверов ввиде таблицы
            server_Collection(sourceEnumerator.GetDataSources());
        }
        /// <summary>
        /// Метод проверки подключение к источнику данных
        /// </summary>
        public void SQL_Data_Base_Checking()
        {
            connection.ConnectionString = "Data source = " + ds + "; " + "Initial Catalog = master; Integrated Security = true";
            try
            {
                //Если подключение по источнику данных
                //в приваивает true
                connection.Open();
                connection_checked(true);
            }
            catch
            //В противном случае false
            {
                connection_checked(false);
            }
            finally
            {
                connection.Close();
            }

        }

        public void SQL_Data_Base_Collection()
        {
            //нахождение базы с названием Sale_Data_Base и не назвыается master,model и т.п
            SqlCommand command = new SqlCommand("select name from sys.databases " + "where name not in ('master','tempdb','model','msdb')", connection);
            try
            {
                connection.Open();
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                Data_Base_Collection(table);
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public static string Organiztion_Name, Save_Files_Path, Machine_Name;
        public static Int32 doc_Left_Merge, doc_Right_Merge, doc_Top_Merge, doc_Bottom_Merge;

        public void Document_Configuration_Get()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("Server_COnfiduration");
            try
            {
                Organiztion_Name = key.GetValue("Organization_Name").ToString();
                doc_Left_Merge = Convert.ToInt32(key.GetValue("doc_Left_Merge").ToString());
                doc_Right_Merge = Convert.ToInt32(key.GetValue("doc_Right_Merge").ToString());
                doc_Top_Merge = Convert.ToInt32(key.GetValue("doc_Top_Merge").ToString());
                doc_Bottom_Merge = Convert.ToInt32(key.GetValue("doc_Bottom_Merge").ToString());
            }
            catch
            {
                Organiztion_Name = "ИНЖПРОМТОРГ";
                doc_Left_Merge = 0;
                doc_Right_Merge = 0;
                doc_Top_Merge = 0;
                doc_Bottom_Merge = 0;

            }
        }
    }

    public class Table_Class
    {
        //Глообальный класс виртуальной таблицы
        public DataTable table = new DataTable();
        //Локальная переменная SQLCommand
        private SqlCommand command = new SqlCommand("", Configuration_class.connection);
        //Глобальная переменная организации взависимости и прослушивание серверов
        public SqlDependency Dependency = new SqlDependency();
        /// <summary>
        /// Заполнение DataTable в зависимости от введеного SQL запроса
        /// </summary>
        /// <param name="SQL_Select_Query"></param>
        public Table_Class(String SQL_Select_Query)
        {
            command.Notification = null; //Отключение уведомлений
            command.CommandText = SQL_Select_Query;//Присвоение SQL запроса SqlCommand
            Dependency.AddCommandDependency(command);//Присвоение команд в связку
            //прослушивание
            try
            {
                //Запуск прослушиания
                SqlDependency.Start(Configuration_class.connection.ConnectionString);
                //Открытия подключения
                Configuration_class.connection.Open();
                //Запись данных в табличном виде в вирт. табл.
                table.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                //Сообщение об ошибке
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //Закрытие подключения
                Configuration_class.connection.Close();
            }
        }
    }

    
}
