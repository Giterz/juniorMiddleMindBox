/*Имя БД*/
USE [1]
GO
/*Скрипт создания таблицы "Категории"*/
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Categories] ADD  DEFAULT (NEWID()) FOR [Id]
GO

/*Заполнение таблицы "Категории"*/
INSERT INTO Categories VALUES ('FFB3FA32-A6BC-4C99-8797-02B3AA4BB818','C1')
INSERT INTO Categories VALUES ('B5CB06D1-F5FD-43C2-91D8-6DB5DAFAE7E7','C2')
INSERT INTO Categories VALUES ('927CF08F-F56C-47FB-8B48-9344494E4BB4','C3')
INSERT INTO Categories VALUES (NEWID(),'C4')
GO

/*Скрипт создания таблицы "Продукты"*/
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products] ADD  DEFAULT (newid()) FOR [Id]
GO

/*Заполнение таблицы "Продукты"*/
INSERT INTO Products VALUES ('A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A3A7','P1')
INSERT INTO Products VALUES ('A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A343','P2')
INSERT INTO Products VALUES ('A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A444','P3')
INSERT INTO Products VALUES (default,'P4')
INSERT INTO Products VALUES (default,'P5')
GO

/*Скрипт создания вспомогательной таблицы "Категории/Продукты" 
для реализации связи многие-ко-многим*/
CREATE TABLE [dbo].[CategoriesProducts](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NULL,
	[CategoryId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CategoriesProducts] ADD  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[CategoriesProducts]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesProducts_CategoriesId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[CategoriesProducts] CHECK CONSTRAINT [FK_CategoriesProducts_CategoriesId]
GO

ALTER TABLE [dbo].[CategoriesProducts]  WITH CHECK ADD  CONSTRAINT [FK_CategoriesProducts_ProductsId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[CategoriesProducts] CHECK CONSTRAINT [FK_CategoriesProducts_ProductsId]
GO

/*Заполнение таблицы "Категории/Продукты"*/
INSERT INTO CategoriesProducts VALUES (default, 'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A3A7','FFB3FA32-A6BC-4C99-8797-02B3AA4BB818')
INSERT INTO CategoriesProducts VALUES (default, 'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A343','FFB3FA32-A6BC-4C99-8797-02B3AA4BB818')
INSERT INTO CategoriesProducts VALUES (default, 'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A444','B5CB06D1-F5FD-43C2-91D8-6DB5DAFAE7E7')
INSERT INTO CategoriesProducts VALUES (default,'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A444','B5CB06D1-F5FD-43C2-91D8-6DB5DAFAE7E7')
INSERT INTO CategoriesProducts VALUES (default,'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A343','927CF08F-F56C-47FB-8B48-9344494E4BB4')
INSERT INTO CategoriesProducts VALUES (default,'A5D4CC9D-862B-4A1D-96D2-1A8CE2E0A444','927CF08F-F56C-47FB-8B48-9344494E4BB4')

/*Запрос для выбора всех пар "Имя продукта – Имя категории"*/
SELECT dbo.Products.Name As 'Продукт', dbo.Categories.Name As 'Категория'
FROM dbo.Categories RIGHT JOIN 
		(dbo.Products LEFT JOIN dbo.CategoriesProducts ON dbo.Products.Id = dbo.CategoriesProducts.ProductId) 
		ON dbo.Categories.Id = dbo.CategoriesProducts.CategoryId;
