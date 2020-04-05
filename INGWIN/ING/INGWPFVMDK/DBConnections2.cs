using System;
using System.Data.SqlClient;
using System.Data;

namespace INGWPF
{
    //Подключаемся к нашей БД
    public class DBConnection2
    {

        public static SqlConnection connection = new SqlConnection("Data source = DESKTOP-U8FDCVO\\SQLEXPRESS; " + "Initial Catalog = INGPROMTORG; Integrated Security = true");
            

        public DataTable dtSotrudniki = new DataTable("Sotrudniki");
        public DataTable dtDolgnost = new DataTable("Dolgnost");
        public DataTable dtTovar = new DataTable("Tovar");
        public DataTable dtUsluga = new DataTable("Usluga");
        public DataTable dtPokupatel = new DataTable("Pokupatel");
        public DataTable dtTovarnaya_Nakladnaya = new DataTable("Tovarnaya_Nakladnaya");
        public DataTable dtTransportnaya_Nakladnaya = new DataTable("Transportnaya_Nakladnaya");
        public DataTable dtDogovora = new DataTable("Dogovora");

        public static string qrSotrudniki = "SELECT [ID_Sotrudnika],[Name_Sotrudnika] ,[Midlle_Name_Sotrudnika],[Last_Name_Sotrudnika] ,[Birhady_Date_Sotrudnika] " +
            ",[Document_Series]  " +
            ",[Document_Number] ,[Sotrudnika_Login],[Sotrudnika_Password], [Dolgnost_ID],[Name_of_Dolgnost] FROM [INGPROMTORG].[dbo].[Sotrudniki] INNER JOIN [INGPROMTORG].[dbo].[Dolgnost] ON " +
            "[INGPROMTORG].[dbo].[Sotrudniki].[Dolgnost_ID] = [INGPROMTORG].[dbo].[Dolgnost].[ID_Dolgnost]",
            qrTovar = "SELECT [ID_Tovar], [Name_Tovara],[Nomer_Tovara] ,[Price_Tovara] ,[Kolichestvo_Tovara], [Tovarnoy_Nakladnoy_ID] ,[Nazv_Tovarnoy_Nakladnoy] FROM [INGPROMTORG].[dbo].[Tovar] inner join [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya]" +
            "on [INGPROMTORG].[dbo].[Tovar].[Tovarnoy_Nakladnoy_ID] = [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[ID_Tovarnoy_Nakladnoy]",
            qrDolgnost = "SELECT Dolgnost.ID_Dolgnost ,Dolgnost.Name_of_Dolgnost ,Dolgnost.Oklad_of_Dolgnost ,Dolgnost.Dostup_Dolgnost FROM dbo.Dolgnost",
            qrUsluga = "SELECT [ID_Usluga], [Name_Of_Usluga] , [Price_Usluga]  FROM [INGPROMTORG].[dbo].[Usluga]",
            qrPokupatel = "SELECT [ID_Pokupatel] ,[Name_Pokupatelya] ,[Midlle_Name_Pokupatelya] ,[Last_Name_Pokupatelya] " +
            " ,[Birhady_Date_Pokupatelya] ,[Document_Series_Pokupatelya]  ,[Document_Number_Pokupatelya] FROM [INGPROMTORG].[dbo].[Pokupatel]",
            qrDogovara = " select [ID_Dogovor], [Nomer_of_Dogovor], [Raschetniy_Schet], [Data_Peredachi], [Pokupatel_ID], [Usluga_ID], [Name_of_Usluga], [Name_Pokupatelya] " +
            "from [dbo].[Dogovora] inner join [dbo].[Usluga] on [dbo].[Dogovora].[Usluga_ID] = " +
            "[dbo].[Usluga].[ID_Usluga] inner join [dbo].[Pokupatel] on [dbo].[Dogovora].[Pokupatel_ID] = [dbo].[Pokupatel].[ID_Pokupatel]",
            qrTovarnoy_Nakladnoy = "SELECT [ID_Tovarnoy_Nakladnoy],[Nazv_Tovarnoy_Nakladnoy] ,[Nomer_Tovarnoy_Nakladnoy] ,[Dogovor_ID]," +
            "[Sotrudnika_ID], [Nomer_of_Dogovor] , [Name_Sotrudnika] FROM [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya]" +
            " inner join [INGPROMTORG].[dbo].[Dogovora] on [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[Dogovor_ID] = [INGPROMTORG].[dbo].[Dogovora].[ID_Dogovor] inner join" +
            "[INGPROMTORG].[dbo].[Sotrudniki] on [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[Sotrudnika_ID] = [INGPROMTORG].[dbo].[Sotrudniki].[ID_Sotrudnika]",
            qrTransportnaya_Nakladnaya = "SELECT [ID_Transportnoy_Nakladnoy] ,[Nazv_Transportnoy_Nakladnoy],[Nomer_Transportnoy_Nakladnoy],[Adress_Dostavki]," +
            "[Dogovor_ID_TR],[Sotrudnika_ID_TR], [Nomer_of_Dogovor], [Name_Sotrudnika] " +
            " FROM [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya] inner join [INGPROMTORG].[dbo].[Dogovora] on [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya].[Dogovor_ID_TR] " +
            "= [INGPROMTORG].[dbo].[Dogovora].[ID_Dogovor] inner join [INGPROMTORG].[dbo].[Sotrudniki] on [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya].[Sotrudnika_ID_TR] = [INGPROMTORG].[dbo].[Sotrudniki].[ID_Sotrudnika]";


        private static SqlCommand command = new SqlCommand("", connection);
        

        public static Int32 IDRecord, IDUser, Proverka;
        public static string sot, dol, pokup, usl, tovar, tovn, trann, dog;
        public static string Dostup;

        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            command.Notification = null;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT [ID_Sotrudnika] FROM [INGPROMTORG].[dbo].[Sotrudniki] WHERE [Sotrudnika_Login] = '" + login + "' and [Sotrudnika_Password] = '" + password + "'";

            try
            {
                connection.Open();
                IDUser = Convert.ToInt32(command.ExecuteScalar().ToString());
                command.CommandText = "SELECT [Dolgnost_ID] FROM [INGPROMTORG].[dbo].[Sotrudniki] WHERE [ID_Sotrudnika] like '%" + IDUser.ToString() + "%'";
                Proverka = Convert.ToInt32(command.ExecuteScalar().ToString());
                command.CommandText = "SELECT [Dostup_Dolgnost] FROM [INGPROMTORG].[dbo].[Dolgnost] WHERE [ID_Dolgnost] like '%" + Proverka.ToString() + "%'";
                Dostup = command.ExecuteScalar().ToString();
                sot = Dostup[0].ToString();
                dol = Dostup[1].ToString();
                pokup = Dostup[2].ToString();
                usl = Dostup[3].ToString();
                tovar = Dostup[4].ToString();
                tovn = Dostup[5].ToString();
                trann = Dostup[6].ToString();
                dog = Dostup[7].ToString();
            }
            catch
            {
                IDUser = 0;
            }
            finally
            {
                connection.Close();
            }
        }

        public void SotrudnikiFill()
        {
            dtFill(dtSotrudniki, qrSotrudniki);
        }

        public void DolgnostFill()
        {
            dtFill(dtDolgnost, qrDolgnost);
        }

        public void SotrudnikiDolFill()
        {
            dtFill(dtSotrudniki, qrDolgnost);
        }

        public void UslugiFill()
        {
            dtFill(dtUsluga, qrUsluga);
        }

        public void PokupatelFill()
        {
            dtFill(dtPokupatel, qrPokupatel);
        }

        public void DogovoraFill()
        {
            dtFill(dtDogovora, qrDogovara);
        }

        public void Transportnaya_NakladnayaFill()
        {
            dtFill(dtTransportnaya_Nakladnaya, qrTransportnaya_Nakladnaya);
        }

        public void Tovarnoy_NakladnoyFill()
        {
            dtFill(dtTovarnaya_Nakladnaya, qrTovarnoy_Nakladnoy);
        }

        public void TovarFill()
        {
            dtFill(dtTovar, qrTovar);
        }
    }


}
