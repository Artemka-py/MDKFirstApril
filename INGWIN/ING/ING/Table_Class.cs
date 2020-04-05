using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ING
{
    class Table_Class
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
