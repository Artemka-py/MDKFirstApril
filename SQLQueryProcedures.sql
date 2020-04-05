set ansi_padding on
go
set quoted_identifier on
go
set ansi_nulls on
go

use [INGPROMTORG]
go

create procedure [dbo].[Dolgnost_insert]
@Name_of_Dolgnost [varchar] (30), @Oklad_of_Dolgnost [int], @Dostup_Dolgnost [varchar] (8)
as 
	insert into [dbo].[Dolgnost] ([Name_of_Dolgnost], [Oklad_of_Dolgnost], [Dostup_Dolgnost]) 
	values (@Name_of_Dolgnost, @Oklad_of_Dolgnost, @Dostup_Dolgnost)
go

create procedure [dbo].[Dolgnost_update]
@ID_Dolgnost [int], @Name_of_Dolgnost [varchar] (30), @Oklad_of_Dolgnost [int], @Dostup_Dolgnost [varchar] (8)
as 
	update [dbo].[Dolgnost] set 
	[Name_of_Dolgnost] = @Name_of_Dolgnost,
	[Oklad_of_Dolgnost] = @Oklad_of_Dolgnost,
	[Dostup_Dolgnost] = @Dostup_Dolgnost
	where 
		[ID_Dolgnost] = @ID_Dolgnost
go

create procedure [dbo].[Dolgnost_delete]
@ID_Dolgnost [int]
as
	delete from [dbo].[Dolgnost]
	where
		[ID_Dolgnost] = @ID_Dolgnost
go

create procedure [dbo].[Dolgnost_filter]
@Name_of_Dolgnost [varchar] (30), @Oklad_of_Dolgnost [int], @Dostup_Dolgnost [varchar] (8)
as 
	select * from [dbo].[Dolgnost]
	where 
		([Name_of_Dolgnost] like @Name_of_Dolgnost or
		[Oklad_of_Dolgnost] like @Oklad_of_Dolgnost or
		[Dostup_Dolgnost] like @Dostup_Dolgnost)
go

create procedure [dbo].[Sotrudniki_update]
@ID_Sotrudnika [int], @Name_Sotrudnika [varchar] (30), @Midlle_Name_Sotrudnika [varchar] (30),
@Last_Name_Sotrudnika [varchar] (30), @Birhady_Date_Sotrudnika [varchar] (10),
@Document_Series [varchar] (4), @Document_Number [varchar] (6), @Sotrudnika_Login [varchar] (16),
@Sotrudnika_Password [varchar] (16), @Dolgnost_ID [int]
as
	update [dbo].[Sotrudniki] set
		[Name_Sotrudnika] = @Name_Sotrudnika,
		[Midlle_Name_Sotrudnika] = @Midlle_Name_Sotrudnika,
		[Last_Name_Sotrudnika] = @Last_Name_Sotrudnika,
		[Birhady_Date_Sotrudnika] = @Birhady_Date_Sotrudnika,
		[Document_Series] = @Document_Series,
		[Document_Number] = @Document_Number,
		[Sotrudnika_Login] = @Sotrudnika_Login,
		[Sotrudnika_Password] = @Sotrudnika_Password,
		[Dolgnost_ID] = @Dolgnost_ID
	where 
		[ID_Sotrudnika] = @ID_Sotrudnika

go

create procedure [dbo].[Sotrudniki_insert]
@Name_Sotrudnika [varchar] (30), @Midlle_Name_Sotrudnika [varchar] (30),
@Last_Name_Sotrudnika [varchar] (30), @Birhady_Date_Sotrudnika [varchar] (10),
@Document_Series [varchar] (4), @Document_Number [varchar] (6), @Sotrudnika_Login [varchar] (16),
@Sotrudnika_Password [varchar] (16), @Dolgnost_ID [int]
as
	insert into [dbo].[Sotrudniki]
	([Name_Sotrudnika], [Midlle_Name_Sotrudnika], [Last_Name_Sotrudnika],
	[Birhady_Date_Sotrudnika], [Document_Series], [Document_Number],[Sotrudnika_Login],
	[Sotrudnika_Password], [Dolgnost_ID]) values
	 (@Name_Sotrudnika,@Midlle_Name_Sotrudnika,@Last_Name_Sotrudnika,
	 @Birhady_Date_Sotrudnika,@Document_Series,@Document_Number, @Sotrudnika_Login,
	 @Sotrudnika_Password,@Dolgnost_ID)
go

create procedure [dbo].[Sotrudniki_delete]
@ID_Sotrudnika [int]
as
	delete from [dbo].[Sotrudniki]
	where 
		[ID_Sotrudnika] = @ID_Sotrudnika
go

create procedure [dbo].[Pokupatel_insert]
@Name_Pokupatelya [varchar] (30), @Midlle_Name_Pokupatelya [varchar] (30),
@Last_Name_Pokupatelya [varchar] (30), @Birhady_Date_Pokupatelya [varchar] (10),
@Document_Series_Pokupatelya [varchar] (4), @Document_Number_Pokupatelya [varchar] (6)
as
	insert into [dbo].[Pokupatel] 
	([Name_Pokupatelya], [Midlle_Name_Pokupatelya],
	[Last_Name_Pokupatelya], [Birhady_Date_Pokupatelya],
	[Document_Series_Pokupatelya], [Document_Number_Pokupatelya]) values
	(@Name_Pokupatelya, @Midlle_Name_Pokupatelya, @Last_Name_Pokupatelya,
	@Birhady_Date_Pokupatelya, @Document_Series_Pokupatelya, @Document_Number_Pokupatelya)
go

create procedure [dbo].[Pokupatel_update]
@ID_Pokupatel [int], @Name_Pokupatelya [varchar] (30), @Midlle_Name_Pokupatelya [varchar] (30),
@Last_Name_Pokupatelya [varchar] (30), @Birhady_Date_Pokupatelya [varchar] (10),
@Document_Series_Pokupatelya [varchar] (4), @Document_Number_Pokupatelya [varchar] (6)
as
	update [dbo].[Pokupatel] set 
	[Name_Pokupatelya] = @Name_Pokupatelya,
	[Midlle_Name_Pokupatelya] = @Midlle_Name_Pokupatelya,
	[Last_Name_Pokupatelya] = @Last_Name_Pokupatelya,
	[Birhady_Date_Pokupatelya] = @Birhady_Date_Pokupatelya,
	[Document_Series_Pokupatelya] = @Document_Series_Pokupatelya,
	[Document_Number_Pokupatelya] = @Document_Number_Pokupatelya
	where
		[ID_Pokupatel] = @ID_Pokupatel
go

create procedure [dbo].[Pokupatel_delete]
@ID_Pokupatel [int]
as
	delete from [dbo].[Pokupatel]
	where
		[ID_Pokupatel] = @ID_Pokupatel
go

create procedure [dbo].[Usluga_insert]
@Name_of_Usluga [varchar] (30), @Price_Usluga [int]
as
	insert into [dbo].[Usluga]
	([Name_Of_Usluga], [Price_Usluga]) values
	(@Name_of_Usluga, @Price_Usluga)
go

create procedure [dbo].[Usluga_update]
@ID_Usluga [int], @Name_of_Usluga [varchar] (30), @Price_Usluga [int]
as
	update [dbo].[Usluga] set
	[Name_Of_Usluga] = @Name_of_Usluga,
	[Price_Usluga] = @Price_Usluga
	where 
		[ID_Usluga] = @ID_Usluga 
go

create procedure [dbo].[Usluga_delete]
@ID_Usluga [int]
as
	delete from [dbo].[Usluga]
	where 
		[ID_Usluga] = @ID_Usluga 
go

create procedure [dbo].[Dogovora_update]
@ID_Dogovor [int], @Nomer_of_Dogovor [varchar] (100),
@Raschetniy_Schet [varchar] (20), @Data_Peredachi [varchar] (10),
@Pokupatel_ID [int], @Usluga_ID [int]
as 
	update [dbo].[Dogovora] set
	[Nomer_of_Dogovor] = @Nomer_of_Dogovor,
	[Raschetniy_Schet] = @Raschetniy_Schet,
	[Data_Peredachi] = @Data_Peredachi,
	[Pokupatel_ID] = @Pokupatel_ID,
	[Usluga_ID] = @Usluga_ID
	where
		[ID_Dogovor] = @ID_Dogovor
go

create procedure [dbo].[Dogovora_insert]
@Nomer_of_Dogovor [varchar] (100),@Raschetniy_Schet [varchar] (20), 
@Data_Peredachi [varchar] (10), @Pokupatel_ID [int], @Usluga_ID [int]
as 
	insert into [dbo].[Dogovora] 
	([Nomer_of_Dogovor], [Raschetniy_Schet],
	[Data_Peredachi], [Pokupatel_ID], [Usluga_ID]) values
	(@Nomer_of_Dogovor, @Raschetniy_Schet, 
	@Data_Peredachi, @Pokupatel_ID, @Usluga_ID)
go

create procedure [dbo].[Dogovora_delete]
@ID_Dogovor [int]
as
	delete from [dbo].[Dogovora]
	where
		[ID_Dogovor] = @ID_Dogovor
go

create procedure [dbo].[Tovarnaya_Nakladnaya_insert]
@Nazv_Tovarnoy_Nakladnoy [varchar] (100),@Nomer_Tovarnoy_Nakladnoy [varchar] (100), @Dogovor_ID [int], @Sotrudnika_ID [int]
as
	insert into [dbo].[Tovarnaya_Nakladnaya]
	([Nazv_Tovarnoy_Nakladnoy],[Nomer_Tovarnoy_Nakladnoy], [Dogovor_ID], [Sotrudnika_ID]) values
	(@Nazv_Tovarnoy_Nakladnoy,@Nomer_Tovarnoy_Nakladnoy, @Dogovor_ID, @Sotrudnika_ID)
go

create procedure [dbo].[Tovarnaya_Nakladnaya_update]
@ID_Tovarnoy_Nakladnoy [int],@Nazv_Tovarnoy_Nakladnoy [varchar] (100), @Nomer_Tovarnoy_Nakladnoy [varchar] (100),
@Dogovor_ID [int], @Sotrudnika_ID [int]
as
	update [dbo].[Tovarnaya_Nakladnaya] set
		[Nazv_Tovarnoy_Nakladnoy] = @Nazv_Tovarnoy_Nakladnoy,
		[Nomer_Tovarnoy_Nakladnoy] = @Nomer_Tovarnoy_Nakladnoy, 
		[Dogovor_ID] = @Dogovor_ID, 
		[Sotrudnika_ID] = @Sotrudnika_ID
	where
		[ID_Tovarnoy_Nakladnoy] = @ID_Tovarnoy_Nakladnoy
go

create procedure [dbo].[Tovarnaya_Nakladnaya_delete]
@ID_Tovarnoy_Nakladnoy [int]
as
	delete from [dbo].[Tovarnaya_Nakladnaya]
	where
		[ID_Tovarnoy_Nakladnoy] = @ID_Tovarnoy_Nakladnoy
go

create procedure [dbo].[Transportnaya_Nakladnaya_insert]
@Nazv_Transportnoy_Nakladnoy [varchar] (100),@Nomer_Transportnoy_Nakladnoy [varchar] (100), @Adress_Dostavki [varchar] (100),
@Dogovor_ID_TR [int], @Sotrudnika_ID_TR [int]
as
	insert into [dbo].[Transportnaya_Nakladnaya] 
	([Nazv_Transportnoy_Nakladnoy],[Nomer_Transportnoy_Nakladnoy], [Adress_Dostavki],
	[Dogovor_ID_TR], [Sotrudnika_ID_TR]) values
	(@Nazv_Transportnoy_Nakladnoy,@Nomer_Transportnoy_Nakladnoy, @Adress_Dostavki, @Dogovor_ID_TR,
	@Sotrudnika_ID_TR)
go

create procedure [dbo].[Transportnaya_Nakladnaya_update]
@ID_Transportnoy_Nakladnoy [int],@Nazv_Transportnoy_Nakladnoy [varchar] (100), @Nomer_Transportnoy_Nakladnoy [varchar] (100), @Adress_Dostavki [varchar] (100),
@Dogovor_ID_TR [int], @Sotrudnika_ID_TR [int]
as
	update [dbo].[Transportnaya_Nakladnaya] set
		[Nazv_Transportnoy_Nakladnoy] = @Nazv_Transportnoy_Nakladnoy,
		[Nomer_Transportnoy_Nakladnoy] = @Nomer_Transportnoy_Nakladnoy,
		[Adress_Dostavki] = @Adress_Dostavki,
		[Dogovor_ID_TR] = @Dogovor_ID_TR,
		[Sotrudnika_ID_TR] = @Sotrudnika_ID_TR
	where
		[ID_Transportnoy_Nakladnoy] = @ID_Transportnoy_Nakladnoy
go

create procedure [dbo].[Transportnaya_Nakladnaya_delete]
@ID_Transportnoy_Nakladnoy [int]
as
	delete from [dbo].[Transportnaya_Nakladnaya]
	where
		[ID_Transportnoy_Nakladnoy] = @ID_Transportnoy_Nakladnoy
go

create procedure [dbo].[Tovar_insert]
@Name_Tovara [varchar] (100),@Nomer_Tovara [varchar] (30), @Price_Tovara [int], 
@Kolichestvo_Tovara [int], @Tovarnoy_Nakladnoy_ID [int]
as
	insert into [dbo].[Tovar] 
		([Name_Tovara],[Nomer_Tovara], [Price_Tovara], [Kolichestvo_Tovara], [Tovarnoy_Nakladnoy_ID]) 
	values
		(@Name_Tovara,@Nomer_Tovara, @Price_Tovara, @Kolichestvo_Tovara, @Tovarnoy_Nakladnoy_ID)
go

create procedure [dbo].[Tovar_update]
@ID_Tovar [int],@Name_Tovara [varchar] (100), @Nomer_Tovara [varchar] (30), @Price_Tovara [int], 
@Kolichestvo_Tovara [int], @Tovarnoy_Nakladnoy_ID [int]
as
	update [dbo].[Tovar] set
		[Name_Tovara] = @Name_Tovara,
		[Nomer_Tovara] = @Nomer_Tovara, 
		[Price_Tovara] = @Price_Tovara, 
		[Kolichestvo_Tovara] = @Kolichestvo_Tovara,
		[Tovarnoy_Nakladnoy_ID] = @Tovarnoy_Nakladnoy_ID
	where
		[ID_Tovar] = @ID_Tovar
go

create procedure [dbo].[Tovar_delete]
@ID_Tovar [int]
as
	delete from [dbo].[Tovar]
	where
		[ID_Tovar] = @ID_Tovar
go

--create function [dbo].[Aut]
--(@Sotrudnika_Login [varchar] (16), @Sotrudnika_Password [varchar] (16)) 
--returns [int]
--with execute as caller 
--as 
--begin
--	declare @ID_Record [int]= (select [ID_Sotrudnika] from [dbo].[Sotrudniki] where [Sotrudnika_Login] = @Sotrudnika_Login
--	and [Sotrudnika_Password] = @Sotrudnika_Password)
--	if @ID_Record is null
--		begin
--			set @ID_Record = 0
--		end	
--	return(@ID_record)
--end
--go

--create function [dbo].[Authorization]
--(@ID_record [int])
--returns [varchar] (8)
--with execute as caller 
--as
--begin
--		begin
--			declare @Proverka [int] = (SELECT [Dolgnost_ID] FROM [dbo].[Sotrudniki] WHERE [ID_Sotrudnika] = @ID_Record)
--			declare @Dostup [varchar] = (SELECT [Dostup_Dolgnost] FROM [INGPROMTORG].[dbo].[Dolgnost] WHERE [ID_Dolgnost] = @Proverka)
--		end

--	return(@Dostup)
--end
--go

create function [dbo].[Auth] (@Sotrudnika_Login [varchar] (16), @Sotrudnika_Password [varchar] (16))
returns [varchar] (8)
with execute as caller
as
begin
	declare @Access [varchar] (8) = (select [Dostup_Dolgnost] from [dbo].[Dolgnost] where [dbo].[Dolgnost].[ID_Dolgnost] = 
	(select [Dolgnost_ID] from [dbo].[Sotrudniki] where [dbo].[Sotrudniki].[Sotrudnika_Login] = @Sotrudnika_Login and 
	[dbo].[Sotrudniki].[Sotrudnika_Password] = @Sotrudnika_Password))
	if @Access is null 
		begin
		set @Access = null
		end
	return(@Access)
end
go