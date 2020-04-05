using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SvoeDelo1
{
    public class DBConnection
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
        
        public static string qrSotrudniki = "SELECT [ID_Sotrudnika] as \"Фамилия\" ,[Name_Sotrudnika] ,[Midlle_Name_Sotrudnika] as \"Имя\",[Last_Name_Sotrudnika] as \"Отчество\",[Birhady_Date_Sotrudnika] as \"Дата рождения\"" +
            ",[Document_Series] as \"Серия паспорта\" " +
            ",[Document_Number] as \"Номер паспорта\",[Sotrudnika_Login] as \"Логин\",[Sotrudnika_Password], [Name_of_Dolgnost] FROM [INGPROMTORG].[dbo].[Sotrudniki] INNER JOIN [INGPROMTORG].[dbo].[Dolgnost] ON " +
            "[INGPROMTORG].[dbo].[Sotrudniki].[Dolgnost_ID] = [INGPROMTORG].[dbo].[Dolgnost].[ID_Dolgnost]",
            qrTovar = "SELECT [ID_Tovar], [Name_Tovara] as \"Название товара\",[Nomer_Tovara] as \"Номер товара\" ,[Price_Tovara] as \"Цена товара\",[Kolichestvo_Tovara] as \"Кол-во товара\", [Tovarnoy_Nakladnoy_ID] ,[Nazv_Tovarnoy_Nakladnoy] as \"Название транспортной накладной\" FROM [INGPROMTORG].[dbo].[Tovar] inner join [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya]" +
            "on [INGPROMTORG].[dbo].[Tovar].[Tovarnoy_Nakladnoy_ID] = [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[ID_Tovarnoy_Nakladnoy]",
            qrDolgnost = "SELECT [ID_Dolgnost],[Name_of_Dolgnost] as \"Название должности\",[Oklad_of_Dolgnost] as \"Оклад\",[Dostup_Dolgnost] as \"Доступ\" FROM[INGPROMTORG].[dbo].[Dolgnost]",
            qrUsluga = "SELECT [ID_Usluga], [Name_Of_Usluga] as \"Название услуги\", [Price_Usluga] as \"Цена услуги\" FROM [INGPROMTORG].[dbo].[Usluga]",
            qrPokupatel = "SELECT [ID_Pokupatel] ,[Name_Pokupatelya] as \"Имя покупателя\" ,[Midlle_Name_Pokupatelya] as \"Фамилия покупателя\" ,[Last_Name_Pokupatelya] as \"Отчество покупателя\"" +
            " ,[Birhady_Date_Pokupatelya] as \"Дата рождения\",[Document_Series_Pokupatelya] as \"Серия паспорта\" ,[Document_Number_Pokupatelya] as \"Номер паспорта\" FROM [INGPROMTORG].[dbo].[Pokupatel]",
            qrDogovara = "  select [ID_Dogovor],[Nomer_of_Dogovor] as \"Номер договора\",[Raschetniy_Schet] as \"Расчетный счет\",[Data_Peredachi] as \"Дата передачи договора\",[Pokupatel_ID],[Usluga_ID], [Name_of_Usluga] as \"Название услуги\", [Name_Pokupatelya] as \"Имя покупателя\" " +
            "from [INGPROMTORG].[dbo].[Dogovora] inner join [INGPROMTORG].[dbo].[Usluga] on [INGPROMTORG].[dbo].[Dogovora].[Usluga_ID] = " +
            "[INGPROMTORG].[dbo].[Usluga].[ID_Usluga] inner join [INGPROMTORG].[dbo].[Pokupatel] on [INGPROMTORG].[dbo].[Dogovora].[Pokupatel_ID] = [INGPROMTORG].[dbo].[Pokupatel].[ID_Pokupatel]",
            qrTovarnoy_Nakladnoy = "SELECT [ID_Tovarnoy_Nakladnoy],[Nazv_Tovarnoy_Nakladnoy] as \"Название товарной накладной\",[Nomer_Tovarnoy_Nakladnoy] as \"Номер товарной накладной\",[Dogovor_ID]," +
            "[Sotrudnika_ID], [Nomer_of_Dogovor] as \"Номер договора\", [Name_Sotrudnika] as \"Фамилия\" FROM [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya]" +
            " inner join [INGPROMTORG].[dbo].[Dogovora] on [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[Dogovor_ID] = [INGPROMTORG].[dbo].[Dogovora].[ID_Dogovor] inner join" +
            "[INGPROMTORG].[dbo].[Sotrudniki] on [INGPROMTORG].[dbo].[Tovarnaya_Nakladnaya].[Sotrudnika_ID] = [INGPROMTORG].[dbo].[Sotrudniki].[ID_Sotrudnika]",
            qrTransportnaya_Nakladnaya = "SELECT [ID_Transportnoy_Nakladnoy] ,[Nazv_Transportnoy_Nakladnoy] as \"Навзвание транспортной накладной\",[Nomer_Transportnoy_Nakladnoy],[Adress_Dostavki] as \"Адрес доставки\"," +
            "[Dogovor_ID_TR],[Sotrudnika_ID_TR], [Nomer_of_Dogovor] as \"Номер договора\", [Name_Sotrudnika] as \"Фамилия\"" +
            " FROM [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya] inner join [INGPROMTORG].[dbo].[Dogovora] on [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya].[Dogovor_ID_TR] " +
            "= [INGPROMTORG].[dbo].[Dogovora].[ID_Dogovor] inner join [INGPROMTORG].[dbo].[Sotrudniki] on [INGPROMTORG].[dbo].[Transportnaya_Nakladnaya].[Sotrudnika_ID_TR] = [INGPROMTORG].[dbo].[Sotrudniki].[ID_Sotrudnika]";
            

        private static SqlCommand command = new SqlCommand("", connection);
        public SqlDependency dependency = new SqlDependency();

        public static Int32 IDRecord, IDUser, Proverka;
        public static string sot, dol, pokup, usl, tovar, tovn, trann, dog;
        public static string Dostup;

        static void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
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
            dtFill(dtSotrudniki,qrSotrudniki);
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