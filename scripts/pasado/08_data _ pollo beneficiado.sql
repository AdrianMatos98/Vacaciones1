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
           ('P. Beneficiado'
           ,0
           ,5.35
           ,4.35
           ,1
           ,1
           ,getdate()
           ,1
           ,getdate()
           ,1
    )



