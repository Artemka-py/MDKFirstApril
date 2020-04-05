using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SvoeDelo1
{
    //Выгружаем хранимые процедуры из БД
    public class Procedures
    {
        private SqlCommand command = new SqlCommand("", DBConnection.connection);

        private void commandConfig(string config)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[" + config + "]";
            command.Parameters.Clear();
        }

        public string ingAuth(string login, string password)
        {
            string Acess = "";
            commandConfig("Auth");
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select [dbo].[Auth] ('" + login + "','" + password + "')";
            DBConnection.connection.Open();
            Acess = command.ExecuteScalar().ToString();
            DBConnection.connection.Close();
            return (Acess);
        }

        public void ingDolgnost_insert(string Name_of_Dolgnost, Int32 Oklad_of_Dolgnost, string Dostup_Dolgnost)
        {
            commandConfig("Dolgnost_insert");

            command.Parameters.AddWithValue("@Name_of_Dolgnost", Name_of_Dolgnost);
            command.Parameters.AddWithValue("@Oklad_of_Dolgnost", Oklad_of_Dolgnost);
            command.Parameters.AddWithValue("@Dostup_Dolgnost", Dostup_Dolgnost);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingDolgnost_update(Int32 ID_Dolgnost, string Name_of_Dolgnost, Int32 Oklad_of_Dolgnost, string Dostup_Dolgnost)
        {
            commandConfig("Dolgnost_update");

            command.Parameters.AddWithValue("@ID_Dolgnost", ID_Dolgnost);
            command.Parameters.AddWithValue("@Name_of_Dolgnost", Name_of_Dolgnost);
            command.Parameters.AddWithValue("@Oklad_of_Dolgnost", Oklad_of_Dolgnost);
            command.Parameters.AddWithValue("@Dostup_Dolgnost", Dostup_Dolgnost);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingDolgnost_delete(Int32 ID_Dolgnost)
        {
            commandConfig("Dolgnost_delete");

            command.Parameters.AddWithValue("@ID_Dolgnost", ID_Dolgnost);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingSotrudniki_update(Int32 ID_Sotrudnika, string Name_Sotrudnika,
            string Midlle_Name_Sotrudnika, string Last_Name_Sotrudnika, string Birhady_Date_Sotrudnika,
            string Document_Series, string Document_Number, string Sotrudnika_Login, string Sotrudnika_Password,
            Int32 Dolgnost_ID)
        {
            commandConfig("Sotrudniki_update");

            command.Parameters.AddWithValue("@ID_Sotrudnika", ID_Sotrudnika);
            command.Parameters.AddWithValue("@Name_Sotrudnika", Name_Sotrudnika);
            command.Parameters.AddWithValue("@Midlle_Name_Sotrudnika", Midlle_Name_Sotrudnika);
            command.Parameters.AddWithValue("@Last_Name_Sotrudnika", Last_Name_Sotrudnika);
            command.Parameters.AddWithValue("@Birhady_Date_Sotrudnika", Birhady_Date_Sotrudnika);
            command.Parameters.AddWithValue("@Document_Series", Document_Series);
            command.Parameters.AddWithValue("@Document_Number", Document_Number);
            command.Parameters.AddWithValue("@Sotrudnika_Login", Sotrudnika_Login);
            command.Parameters.AddWithValue("@Sotrudnika_Password", Sotrudnika_Password);
            command.Parameters.AddWithValue("@Dolgnost_ID", Dolgnost_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingSotrudniki_insert(string Name_Sotrudnika,
            string Midlle_Name_Sotrudnika, string Last_Name_Sotrudnika, string Birhady_Date_Sotrudnika,
            string Document_Series, string Document_Number, string Sotrudnika_Login, string Sotrudnika_Password,
            Int32 Dolgnost_ID)
        {
            commandConfig("Sotrudniki_insert");

            command.Parameters.AddWithValue("@Name_Sotrudnika", Name_Sotrudnika);
            command.Parameters.AddWithValue("@Midlle_Name_Sotrudnika", Midlle_Name_Sotrudnika);
            command.Parameters.AddWithValue("@Last_Name_Sotrudnika", Last_Name_Sotrudnika);
            command.Parameters.AddWithValue("@Birhady_Date_Sotrudnika", Birhady_Date_Sotrudnika);
            command.Parameters.AddWithValue("@Document_Series", Document_Series);
            command.Parameters.AddWithValue("@Document_Number", Document_Number);
            command.Parameters.AddWithValue("@Sotrudnika_Login", Sotrudnika_Login);
            command.Parameters.AddWithValue("@Sotrudnika_Password", Sotrudnika_Password);
            command.Parameters.AddWithValue("@Dolgnost_ID", Dolgnost_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingSotrudniki_delete(Int32 ID_Sotrudnika)
        {
            commandConfig("Sotrudniki_delete");

            command.Parameters.AddWithValue("@ID_Sotrudnika", ID_Sotrudnika);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingPokupatel_insert(string Name_Pokupatelya, string Midlle_Name_Pokupatelya,
            string Last_Name_Pokupatelya, string Birhady_Date_Pokupatelya, string Document_Series_Pokupatelya,
            string Document_Number_Pokupatelya)
        {
            commandConfig("Pokupatel_insert");

            command.Parameters.AddWithValue("@Name_Pokupatelya", Name_Pokupatelya);
            command.Parameters.AddWithValue("@Midlle_Name_Pokupatelya", Midlle_Name_Pokupatelya);
            command.Parameters.AddWithValue("@Last_Name_Pokupatelya", Last_Name_Pokupatelya);
            command.Parameters.AddWithValue("@Birhady_Date_Pokupatelya", Birhady_Date_Pokupatelya);
            command.Parameters.AddWithValue("@Document_Series_Pokupatelya", Document_Series_Pokupatelya);
            command.Parameters.AddWithValue("@Document_Number_Pokupatelya", Document_Number_Pokupatelya);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingPokupatel_update(Int32 ID_Pokupatel, string Name_Pokupatelya, string Midlle_Name_Pokupatelya,
            string Last_Name_Pokupatelya, string Birhady_Date_Pokupatelya, string Document_Series_Pokupatelya,
            string Document_Number_Pokupatelya)
        {
            commandConfig("Pokupatel_update");

            command.Parameters.AddWithValue("@ID_Pokupatel", ID_Pokupatel);
            command.Parameters.AddWithValue("@Name_Pokupatelya", Name_Pokupatelya);
            command.Parameters.AddWithValue("@Midlle_Name_Pokupatelya", Midlle_Name_Pokupatelya);
            command.Parameters.AddWithValue("@Last_Name_Pokupatelya", Last_Name_Pokupatelya);
            command.Parameters.AddWithValue("@Birhady_Date_Pokupatelya", Birhady_Date_Pokupatelya);
            command.Parameters.AddWithValue("@Document_Series_Pokupatelya", Document_Series_Pokupatelya);
            command.Parameters.AddWithValue("@Document_Number_Pokupatelya", Document_Number_Pokupatelya);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingPokupatel_delete(Int32 ID_Pokupatel)
        {
            commandConfig("Pokupatel_delete");

            command.Parameters.AddWithValue("@ID_Pokupatel", ID_Pokupatel);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingUsluga_delete(Int32 ID_Usluga)
        {
            commandConfig("Usluga_delete");

            command.Parameters.AddWithValue("@ID_Usluga", ID_Usluga);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingUsluga_update(Int32 ID_Usluga, string Name_of_Usluga, Int32 Price_Usluga)
        {
            commandConfig("Usluga_update");

            command.Parameters.AddWithValue("@ID_Usluga", ID_Usluga);
            command.Parameters.AddWithValue("@Name_of_Usluga", Name_of_Usluga);
            command.Parameters.AddWithValue("@Price_Usluga", Price_Usluga);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingUsluga_insert(string Name_of_Usluga, Int32 Price_Usluga)
        {
            commandConfig("Usluga_insert");

            command.Parameters.AddWithValue("@Name_of_Usluga", Name_of_Usluga);
            command.Parameters.AddWithValue("@Price_Usluga", Price_Usluga);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingDogovora_delete(Int32 ID_Dogovor)
        {
            commandConfig("Dogovora_delete");

            command.Parameters.AddWithValue("@ID_Dogovor", ID_Dogovor);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingDogovora_update(Int32 ID_Dogovor,string Nomer_of_Dogovor, string Raschetniy_Schet,string Data_Peredachi, Int32 Pokupatel_ID, Int32 Usluga_ID)
        {
            commandConfig("Dogovora_update");

            command.Parameters.AddWithValue("@ID_Dogovor", ID_Dogovor);
            command.Parameters.AddWithValue("@Nomer_of_Dogovor", Nomer_of_Dogovor);
            command.Parameters.AddWithValue("@Raschetniy_Schet", Raschetniy_Schet);
            command.Parameters.AddWithValue("@Data_Peredachi", Data_Peredachi);
            command.Parameters.AddWithValue("@Pokupatel_ID", Pokupatel_ID);
            command.Parameters.AddWithValue("@Usluga_ID", Usluga_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingDogovora_insert(string Nomer_of_Dogovor, string Raschetniy_Schet, string Data_Peredachi, Int32 Pokupatel_ID, Int32 Usluga_ID)
        {
            commandConfig("Dogovora_insert");

            command.Parameters.AddWithValue("@Nomer_of_Dogovor", Nomer_of_Dogovor);
            command.Parameters.AddWithValue("@Raschetniy_Schet", Raschetniy_Schet);
            command.Parameters.AddWithValue("@Data_Peredachi", Data_Peredachi);
            command.Parameters.AddWithValue("@Pokupatel_ID", Pokupatel_ID);
            command.Parameters.AddWithValue("@Usluga_ID", Usluga_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTovarnaya_Nakladnaya_insert(string Nazv_Tovarnoy_Nakladnoy, string Nomer_Tovarnoy_Nakladnoy, Int32 Dogovor_ID, Int32 Sotrudnika_ID)
        {
            commandConfig("Tovarnaya_Nakladnaya_insert");

            command.Parameters.AddWithValue("@Nazv_Tovarnoy_Nakladnoy", Nazv_Tovarnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Nomer_Tovarnoy_Nakladnoy", Nomer_Tovarnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Dogovor_ID", Dogovor_ID);
            command.Parameters.AddWithValue("@Sotrudnika_ID", Sotrudnika_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTovarnaya_Nakladnaya_update(Int32 ID_Tovarnoy_Nakladnoy, string Nazv_Tovarnoy_Nakladnoy, string Nomer_Tovarnoy_Nakladnoy, Int32 Dogovor_ID, Int32 Sotrudnika_ID)
        {
            commandConfig("Tovarnaya_Nakladnaya_update");

            command.Parameters.AddWithValue("@Nazv_Tovarnoy_Nakladnoy", Nazv_Tovarnoy_Nakladnoy);
            command.Parameters.AddWithValue("@ID_Tovarnoy_Nakladnoy", ID_Tovarnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Nomer_Tovarnoy_Nakladnoy", Nomer_Tovarnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Dogovor_ID", Dogovor_ID);
            command.Parameters.AddWithValue("@Sotrudnika_ID", Sotrudnika_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTovarnaya_Nakladnaya_delete(Int32 ID_Tovarnoy_Nakladnoy)
        {
            commandConfig("Tovarnaya_Nakladnaya_delete");

            command.Parameters.AddWithValue("@ID_Tovarnoy_Nakladnoy", ID_Tovarnoy_Nakladnoy);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTransportnaya_Nakladnaya_delete(Int32 ID_Transportnoy_Nakladnoy)
        {
            commandConfig("Transportnaya_Nakladnaya_delete");

            command.Parameters.AddWithValue("@ID_Transportnoy_Nakladnoy", ID_Transportnoy_Nakladnoy);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTransportnaya_Nakladnaya_update(Int32 ID_Transportnoy_Nakladnoy,string Nazv_Transportnoy_Nakladnoy, string Nomer_Transportnoy_Nakladnoy,
            string Adress_Dostavki, Int32 Dogovor_ID_TR, Int32 Sotrudnika_ID_TR)
        {
            commandConfig("Transportnaya_Nakladnaya_update");

            command.Parameters.AddWithValue("@Nazv_Transportnoy_Nakladnoy", Nazv_Transportnoy_Nakladnoy);
            command.Parameters.AddWithValue("@ID_Transportnoy_Nakladnoy", ID_Transportnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Nomer_Transportnoy_Nakladnoy", Nomer_Transportnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Adress_Dostavki", Adress_Dostavki);
            command.Parameters.AddWithValue("@Dogovor_ID_TR", Dogovor_ID_TR);
            command.Parameters.AddWithValue("@Sotrudnika_ID_TR", Sotrudnika_ID_TR);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTransportnaya_Nakladnaya_insert(string Nazv_Transportnoy_Nakladnoy, string Nomer_Transportnoy_Nakladnoy,
            string Adress_Dostavki, Int32 Dogovor_ID_TR, Int32 Sotrudnika_ID_TR)
        {
            commandConfig("Transportnaya_Nakladnaya_insert");

            command.Parameters.AddWithValue("@Nazv_Transportnoy_Nakladnoy", Nazv_Transportnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Nomer_Transportnoy_Nakladnoy", Nomer_Transportnoy_Nakladnoy);
            command.Parameters.AddWithValue("@Adress_Dostavki", Adress_Dostavki);
            command.Parameters.AddWithValue("@Dogovor_ID_TR", Dogovor_ID_TR);
            command.Parameters.AddWithValue("@Sotrudnika_ID_TR", Sotrudnika_ID_TR);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();
        }

        public void ingTovar_insert(string Name_Tovara,string Nomer_Tovara, Int32 Price_Tovara,Int32 Kolichestvo_Tovara,Int32 Tovarnoy_Nakladnoy_ID)
        {
            commandConfig("Tovar_insert");

            command.Parameters.AddWithValue("@Name_Tovara", Name_Tovara);
            command.Parameters.AddWithValue("@Nomer_Tovara", Nomer_Tovara);
            command.Parameters.AddWithValue("@Price_Tovara", Price_Tovara);
            command.Parameters.AddWithValue("@Kolichestvo_Tovara", Kolichestvo_Tovara);
            command.Parameters.AddWithValue("@Tovarnoy_Nakladnoy_ID", Tovarnoy_Nakladnoy_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();

        }

        public void ingTovar_update(Int32 ID_Tovar, string Name_Tovara, string Nomer_Tovara, Int32 Price_Tovara, Int32 Kolichestvo_Tovara, Int32 Tovarnoy_Nakladnoy_ID)
        {
            commandConfig("Tovar_update");

            command.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);
            command.Parameters.AddWithValue("@Name_Tovara", Name_Tovara);
            command.Parameters.AddWithValue("@Nomer_Tovara", Nomer_Tovara);
            command.Parameters.AddWithValue("@Price_Tovara", Price_Tovara);
            command.Parameters.AddWithValue("@Kolichestvo_Tovara", Kolichestvo_Tovara);
            command.Parameters.AddWithValue("@Tovarnoy_Nakladnoy_ID", Tovarnoy_Nakladnoy_ID);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();

        }

        public void ingTovar_delete(Int32 ID_Tovar)
        {
            commandConfig("Tovar_delete");

            command.Parameters.AddWithValue("@ID_Tovar", ID_Tovar);

            DBConnection.connection.Open();
            command.ExecuteNonQuery();
            DBConnection.connection.Close();

        }
    }
}