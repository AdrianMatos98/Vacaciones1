/****** Script for SelectTopNRows command from SSMS  ******/

update [Tb_Producto] set
[idTipoProducto] = [Id_Producto]


INSERT INTO [dbo].[TipoProducto]
           ([idTipoProducto]
           ,[Nombre])
SELECT     [Id_Producto]
		   ,[Nombre]
FROM [Tb_Producto]