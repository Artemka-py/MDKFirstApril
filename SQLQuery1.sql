set ansi_padding on
go
set ansi_nulls on
go
set quoted_identifier on
GO

--use master
--go

--drop database [INGPROMTORG]
--go

create database [INGPROMTORG]
go

use [INGPROMTORG]
go

create table [dbo].[Dolgnost]
(
	[ID_Dolgnost] [int] not null identity (1,1),
	[Name_of_Dolgnost] [varchar] (30) not null,
	[Oklad_of_Dolgnost] [int] not null,
	[Dostup_Dolgnost] [varchar] (8) not null,
	constraint [PK_Dolgnost] primary key clustered
	([ID_Dolgnost] ASC) on [PRIMARY],
	constraint [UQ_Name_of_Dolgnost] unique ([Name_of_Dolgnost]),
	constraint [CH_Dostup_Dolgnost] check ([Dostup_Dolgnost] like '[0-1][0-1][0-1][0-1][0-1][0-1][0-1][0-1]')
)
go

insert into [dbo].[Dolgnost] ([Name_of_Dolgnost], [Oklad_of_Dolgnost], [Dostup_Dolgnost]) values
('Директор','20000','11111111'),('Уборщица','1000','00000000'),('Подопытный','20000','10101010')
go

--INSERT INTO [dbo].[Dolgnost] ([Name_of_Dolgnost], [Oklad_of_Dolgnost], [Dostup_Dolgnost]) VALUES
--  ('Гость','0','00000000')
--  GO


create table [dbo].[Sotrudniki]
(
	[ID_Sotrudnika] [int] not null identity (1,1),
	[Name_Sotrudnika] [varchar] (30) not null,
	[Midlle_Name_Sotrudnika] [varchar] (30) not null,
	[Last_Name_Sotrudnika] [varchar] (30) null default ('-'),
	[Birhady_Date_Sotrudnika] [varchar] (10) not null,
	[Document_Series] [varchar] (4) not null,
	[Document_Number] [varchar] (6) not null,
	[Sotrudnika_Login] [varchar] (16) not null,
	[Sotrudnika_Password] [varchar] (16) not null,
	[Dolgnost_ID] [int] not null,
	constraint [PK_ID_Sotrudnika] primary key clustered
	([ID_Sotrudnika] ASC) on [PRIMARY],
	constraint [CH_Document_Series] check ([Document_Series] like '[0-9][0-9][0-9][0-9]'),
	constraint [CH_Document_Number] check ([Document_Number] like '[0-9][0-9][0-9][0-9][0-9][0-9]'),
	constraint [UQ_Sotrudnika_Login] unique ([Sotrudnika_Login]),
	constraint [FK_Sotrudniki_Dolgnost] foreign key ([Dolgnost_ID])
	references [dbo].[Dolgnost] ([ID_Dolgnost])	 
)
go

insert into  [dbo].[Sotrudniki] ([Name_Sotrudnika], [Midlle_Name_Sotrudnika], [Last_Name_Sotrudnika],
	[Birhady_Date_Sotrudnika], [Document_Series], [Document_Number],[Sotrudnika_Login],
	[Sotrudnika_Password], [Dolgnost_ID]) values
	('Артем','Лыткин','Ник','11.11.1111','1234','123456','Artem','Artem','1'),('Артем','Лыткин','Ник','11.11.1111','1233','123456','Artem565','Artem565','3')
go



create table [dbo].[Pokupatel]
(
	[ID_Pokupatel] int not null identity (1,1),
	[Name_Pokupatelya] [varchar] (30) not null,
	[Midlle_Name_Pokupatelya] [varchar] (30) not null,
	[Last_Name_Pokupatelya] [varchar] (30) null default ('-'),
	[Birhady_Date_Pokupatelya] [varchar] (10) not null,
	[Document_Series_Pokupatelya] [varchar] (4) not null,
	[Document_Number_Pokupatelya] [varchar] (6) not null,
	constraint [PK_ID_Pokupatel] primary key clustered
	([ID_Pokupatel] ASC) on [PRIMARY],
	constraint [CH_Document_Series_Pokupatelya] check ([Document_Series_Pokupatelya] like '[0-9][0-9][0-9][0-9]'),
	constraint [CH_Document_Number_Pokupatelya] check ([Document_Number_Pokupatelya] like '[0-9][0-9][0-9][0-9][0-9][0-9]')
)
go

insert into  [dbo].[Pokupatel] ([Name_Pokupatelya], [Midlle_Name_Pokupatelya],
	[Last_Name_Pokupatelya], [Birhady_Date_Pokupatelya],
	[Document_Series_Pokupatelya], [Document_Number_Pokupatelya]) values
	('Вася','Васильевич','Ник','11.11.1111','1234','123456'),('Петр','Петрович','Ник','11.11.1111','1233','123456')
go


create table [dbo].[Usluga]
(
	[ID_Usluga] [int] not null identity (1,1),
	[Name_Of_Usluga] [varchar] (30) not null,
	[Price_Usluga] [int] not null, 
	constraint [PK_ID_Usluga] primary key clustered
	([ID_Usluga] ASC) on [PRIMARY],
	constraint [UQ_Name_Of_Usluga] unique ([Name_Of_Usluga])
)
go

insert into [dbo].[Usluga] ([Name_of_Usluga], [Price_Usluga]) values
('Доставка','1000'),('Перевозка','2000')
go

create table [dbo].[Dogovora]
(
	[ID_Dogovor] [int] not null identity (1,1),
	[Nomer_of_Dogovor] [varchar] (100) not null,
	[Raschetniy_Schet] [varchar] (20) not null,
	[Data_Peredachi] [varchar] (10) not null,
	[Pokupatel_ID] [int] not null,
	[Usluga_ID] [int] not null,
	constraint [PK_ID_Dogovor] primary key clustered
	([ID_Dogovor] ASC) on [PRIMARY],
	constraint [UQ_Nomer_of_Dogovor] unique ([Nomer_of_Dogovor]),
	constraint [FK_Dogovora_Pokupatel] foreign key ([Pokupatel_ID])
	references [dbo].[Pokupatel] ([ID_Pokupatel]),
	constraint [FK_Pokupatel_Usluga] foreign key ([Usluga_ID])
	references [dbo].[Usluga] ([ID_Usluga])	
)
GO

--DBCC CHECKIDENT('dbo.Dogovora', RESEED, 1)
--  GO

insert into [dbo].[Dogovora] 
	([Nomer_of_Dogovor], [Raschetniy_Schet],
	[Data_Peredachi], [Pokupatel_ID], [Usluga_ID]) values
	('12', '1234567', '11.11.1111', '1', '1'),('13', '657893', '12.11.1111', '2', '2')
go

create table [dbo].[Tovarnaya_Nakladnaya]
(
	[ID_Tovarnoy_Nakladnoy] [int] not null identity (1,1),
	[Nazv_Tovarnoy_Nakladnoy] [varchar] (100) not null,
	[Nomer_Tovarnoy_Nakladnoy] [varchar]  (100) not null,
	[Dogovor_ID] [int] not null,
	[Sotrudnika_ID] [int] not null,
	constraint [PK_ID_Tovarnoy_Nakladnoy] primary key clustered
	([ID_Tovarnoy_Nakladnoy] ASC) on [PRIMARY],
	constraint [UQ_Nomer_Tovarnoy_Nakladnoy] unique ([Nomer_Tovarnoy_Nakladnoy]),
	constraint [FK_Tovarnaya_Nakladnaya_Dogovora] foreign key ([Dogovor_ID])
	references [dbo].[Dogovora] ([ID_Dogovor]),
	constraint [FK_Tovarnaya_Nakladnaya_Sotrudniki] foreign key ([Sotrudnika_ID])
	references [dbo].[Sotrudniki] ([ID_Sotrudnika])
)
go 

insert into [dbo].[Tovarnaya_Nakladnaya]
([Nazv_Tovarnoy_Nakladnoy],[Nomer_Tovarnoy_Nakladnoy], [Dogovor_ID], [Sotrudnika_ID]) values
('Доставка 1','12','1','1'),('Перевозка 1','13','2','2')
go

create table [dbo].[Transportnaya_Nakladnaya]
(
	[ID_Transportnoy_Nakladnoy] [int] not null identity (1,1),
	[Nazv_Transportnoy_Nakladnoy] [varchar] (100) not null,
	[Nomer_Transportnoy_Nakladnoy] [varchar] (100) not null,
	[Adress_Dostavki] [varchar] (100) not null,
	[Dogovor_ID_TR] [int] not null,
	[Sotrudnika_ID_TR] [int] not null,
	constraint [PK_ID_Transportnoy_Nakladnoy] primary key clustered
	([ID_Transportnoy_Nakladnoy] ASC) on [PRIMARY],
	constraint [UQ_Nomer_Transportnoy_Nakladnoy] unique ([Nomer_Transportnoy_Nakladnoy]),
	constraint [FK_Transportnaya_Nakladnaya_Dogovora] foreign key ([Dogovor_ID_TR])
	references [dbo].[Dogovora] ([ID_Dogovor]),
	constraint [FK_Transportnaya_Nakladnaya_Sotrudniki] foreign key ([Sotrudnika_ID_TR])
	references [dbo].[Sotrudniki] ([ID_Sotrudnika])
)
go 

insert into [dbo].[Transportnaya_Nakladnaya] 
([Nazv_Transportnoy_Nakladnoy],[Nomer_Transportnoy_Nakladnoy], [Adress_Dostavki],
[Dogovor_ID_TR], [Sotrudnika_ID_TR]) values
('Грузовик 1','12','Миклухо-маклая','1','1'),('Грузовик 2','13','лебедянская','2','2')
go

create table [dbo].[Tovar]
(
	[ID_Tovar] [int] not null identity (1,1),
	[Name_Tovara] varchar (100) not null,
	[Nomer_Tovara] [varchar] (30) not null,
	[Price_Tovara] [int] not null, 
	[Kolichestvo_Tovara] [int] not null,
	[Tovarnoy_Nakladnoy_ID] [int] not null,
	constraint [PK_ID_Tovar] primary key clustered
	([ID_Tovar] ASC) on [PRIMARY],
	constraint [UQ_Nomer_Tovara] unique ([Nomer_Tovara]),
	constraint [FK_Tovar_Tovarnaya_Nakladnaya] foreign key ([Tovarnoy_Nakladnoy_ID])
	references [dbo].[Tovarnaya_Nakladnaya] ([ID_Tovarnoy_Nakladnoy])
)
go

insert into [dbo].[Tovar] 
([Name_Tovara],[Nomer_Tovara], [Price_Tovara], [Kolichestvo_Tovara], [Tovarnoy_Nakladnoy_ID]) 
values
('Кольцо','12','2000','15','1'),('Плиты','13','1000','45','2')
go