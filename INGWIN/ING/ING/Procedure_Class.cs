using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CryptLibraryING;

namespace ING
{
    class Procedure_Class
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
}
