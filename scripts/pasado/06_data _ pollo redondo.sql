USE [DVGP_CITAVAL]
GO

INSERT INTO [dbo].[Tb_Producto]
           ([Nombre]
           ,[Tara]
           ,[PrecioVenta]
           ,[PrecioCompra]
           ,[Margen]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion]
           ,[idTipoProducto])
     VALUES
           ('P.Redondo'
           ,6
           ,4.35
           ,4.15
           ,2
           ,1
           ,getdate()
           ,1
           ,getdate()
           ,1
		   
    )



