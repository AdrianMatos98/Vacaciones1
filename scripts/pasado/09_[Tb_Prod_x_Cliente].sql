
INSERT INTO [dbo].[Tb_Prod_x_Cliente]
           ([Tara]
           ,[Margen]
           ,[PrecioVenta]
           ,[PrecioCompra]
           ,[Id_Cliente]
           ,[Id_Producto]
           ,[UsuarioCreacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[FechaModificacion])
SELECT
		 p.[Tara]
		,p.[Margen]
		,p.[PrecioVenta]
		,p.[PrecioCompra]      
		,cli.Id_Cliente
	    ,p.[Id_Producto]
		,1
		,getdate()
		,1
		,getdate()
      
FROM [dbo].[Tb_Producto] p
cross join [dbo].[Tb_Cliente_Proveedor] cli 
left join [Tb_Prod_x_Cliente] pc on pc.Id_Cliente = cli.Id_Cliente and pc.Id_Producto = p.Id_Producto
where  pc.Id_Cliente is null
