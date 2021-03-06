

create   PROCEDURE [InsertarDocumento](

@IdTipoDocumento varchar(10)
,@Fecha datetime
,@Monto decimal(18,2)
,@Usuario int
,@IdCaja int
,@IdCliente int
,@IdPersonal int
) AS

BEGIN
	
	INSERT INTO [Tb_documento]
           ([IdTipoDocumento]
           ,[Fecha]
           ,[Monto]
           ,[estado]
           ,[FechaCreacion]
		   ,[FechaModificacion]
		   ,[idCliente]
		   ,[IdPersonal]
		   ,[IdCaja]
           
)
     VALUES
           (
		    @IdTipoDocumento 
		   ,@Fecha 
		   ,@Monto 
		   ,1
		   ,getdate()
		   ,null
		   ,@idCliente
		   ,@IdPersonal
		   ,@IdCaja
		   )



		   SELECT SCOPE_IDENTITY();

END



