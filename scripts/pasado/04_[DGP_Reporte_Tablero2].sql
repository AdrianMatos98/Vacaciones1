USE [DVGP_CITAVAL]
GO
/****** Object:  StoredProcedure [dbo].[DGP_Reporte_Tablero2]    Script Date: 07/11/2017 03:25:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER          PROCEDURE [dbo].[DGP_Reporte_Tablero2] (
@dtFechaInicial	DATETIME = NULL , 
@dtFechaFinal	DATETIME = NULL ,
@vcListProductos varchar(200),
@vcListZonas	varchar(200) 
)
AS
/*
*****************************************************
PROCEDIMIENTO		: dbo.DGP_Reporte_Tablero
FECHA			: 04/03/2009 (dd/MM/yyyy)
AUTOR			: Carlos Abanto G
*****************************************************
*/
Declare @bOk  bit
Declare @I  int
Declare @filas int
DECLARE @Id_Linea_Venta  int
DECLARE @Id_Venta  int
DECLARE @Peso_Bruto  decimal(28,8) 
DECLARE @Cantidad_Javas  int 
DECLARE @Obs_Detalle  varchar(500 )
DECLARE @IdEstado varchar(5)
DECLARE @Obs_Venta  varchar(500 )
DECLARE @Total_Peso_Bruto  decimal(28,8) 
DECLARE @Total_Peso_Tara  decimal(28,8) 
DECLARE @Total_Peso_Neto  decimal(28,8) 
DECLARE @Precio  decimal(28,8) 
DECLARE @Monto_Total  decimal(28,8) 
DECLARE @Total_Devolucion  decimal(28,8) 
DECLARE @Total_Amortizacion  decimal(28,8) 
DECLARE @Total_Saldo  decimal(28,8) 
DECLARE @cliente varchar(100)
DECLARE @Id_Caja int 
DECLARE @fecha_caja datetime 
DECLARE @Zona varchar(150 ) 
DECLARE @Producto varchar(100 )
--
DECLARE @tbl_id_tablero int
DECLARE @tbl_id_venta  int
DECLARE @tbl_Nombre_Cliente varchar(50)
DECLARE @tbl_Peso_bruto1  decimal(28,8)
DECLARE @tbl_Peso_bruto2 decimal(28,8)
DECLARE @tbl_Total_Bruto decimal(28,8)
DECLARE @tbl_Total_Tara decimal(28,8)
DECLARE @tbl_Total_Neto_Devoluciones decimal(28,8)
DECLARE @tbl_Total_Neto decimal(28,8)
DECLARE @tbl_Total_Importe decimal(28,8)
DECLARE @tbl_Total_Amortizacion decimal(28,8)
DECLARE @tbl_Total_Saldo decimal(28,8)
DECLARE @tbl_Total_Jabas decimal(28,8)
DECLARE @tbl_Observacion varchar(2000)
--
DECLARE @J int
DECLARE @Columnas int
DECLARE @Temp_Index int
DECLARE @Temp_Pos int
DECLARE @fila_reporte int
DECLARE @id_venta_anterior int
DECLARE @fila_nueva int


DECLARE @tablero TABLE (
		id_tablero int IDENTITY (1,1) ,
		fecha_venta datetime ,
		str_fecha_venta varchar(10) ,
		zona varchar(100) ,
		producto varchar(100) ,
		Nombre_Cliente varchar(100) ,
		Peso_bruto1 decimal(28,8) ,
		Peso_bruto2 decimal(28,8) ,
		Total_Bruto decimal(28,8) ,
		Total_Tara decimal(28,8) ,
		Total_Neto_Devoluciones decimal(28,8) ,
		Total_Neto decimal(28,8) ,
		Total_Importe decimal(28,8) ,
		Total_Amortizacion decimal(28,8) ,
		Total_Saldo decimal(28,8) ,
		Total_Jabas int ,
		Observacion varchar(2000) ,
		Primera_Fila bit
		)

DECLARE @detalle_venta TABLE (
		id_detalle int IDENTITY (1,1) ,
		Id_Linea_Venta  int,
		id_venta int ,
		Peso_Bruto  decimal(28,8) ,
		Cantidad_Javas  int , 
		Obs_Detalle  varchar(500 ),
		IdEstado varchar(5),
		Obs_Venta  varchar(500 ),
		Total_Peso_Bruto  decimal(28,8) ,
		Total_Peso_Tara  decimal(28,8) ,
		Total_Peso_Neto  decimal(28,8) ,
		Precio  decimal(28,8) ,
		Monto_Total  decimal(28,8) ,
		Total_Devolucion  decimal(28,8) ,
		Total_Amortizacion  decimal(28,8) ,
		Total_Saldo  decimal(28,8) ,
		cliente varchar(100),
		Id_Caja int ,
		fecha_caja datetime ,
		Zona varchar(150 ) ,
		producto varchar(100) 
		)

Declare @tblListProductos  Table(
	id_producto int
	
	)
Declare @tblListZonas  Table(
	id_zona int
	
	)

BEGIN
	

	Set @bOk = 1
	Set @Columnas = 2
	print ' primer elemento  '		
	Insert into @detalle_venta (
					Id_Linea_Venta ,
					Id_Venta ,
					Peso_Bruto   ,
					Cantidad_Javas   , 
					Obs_Detalle ,
					IdEstado ,
					Obs_Venta  ,
					Total_Peso_Bruto   ,
					Total_Peso_Tara   ,
					Total_Peso_Neto   ,
					Precio   ,
					Monto_Total   ,
					Total_Devolucion   ,
					Total_Amortizacion   ,
					Total_Saldo   ,
					cliente ,
					Id_Caja  ,
					fecha_caja  ,
					Zona  ,
					producto
				)
	SELECT 
			DV.Id_Linea_Venta ,
			v.Id_Venta ,
			DV.Peso_Bruto ,
			V.Total_Jabas , 
			DV.Observacion , 
			DV.IdEstado ,
			DV.Observacion ,
			V.Total_Peso_Bruto ,
			V.Total_Peso_Tara ,
			V.Total_Peso_Neto ,
			V.Precio ,
			V.Monto_Total ,
			V.Total_Devolucion ,
			V.Total_Amortizacion ,
			V.Total_Saldo ,
			isnull( C.Nombres , V.ClienteEventual) cliente ,
			V.Id_Caja ,
			CJ.Fecha fecha_caja  ,
			isnull(Z.Descripcion	,'Calle'),
			tp.nombre	
	FROM Tb_Linea_Venta DV
	INNER JOIN Tb_Venta V  ON DV.Id_Venta = V.Id_Venta
	INNER JOIN Tb_Caja CJ  ON CJ.Id_Caja = V.Id_Caja
	INNER JOIN Tb_producto PD  ON pd.Id_Producto = V.Id_Producto
	INNER JOIN TipoProducto tp on tp.idTipoProducto = PD.idTipoProducto
	LEFT JOIN Tb_Cliente_Proveedor C ON C.Id_Cliente = V.Id_Cliente 
	LEFT JOIN Tb_Zona Z  ON Z.Id_Zona = C.Id_Zona		
	WHERE DV.EsDevolucion = 'N'
             AND   v.idEstado not in ('ANL')
	AND DV.IdEstado = dbo.DGP_VENTA_ESTADO_REGISTRADO()
	AND cj.Fecha  between @dtFechaInicial AND @dtFechaFinal
	order by Z.Descripcion , CJ.Fecha , V.id_venta , isnull( C.Nombres , V.ClienteEventual),DV.Id_Linea_Venta
		
	Set @filas =@@ROWCOUNT
	print ' @filas  ' + cast(@filas as varchar(100))
		
	Set @fila_reporte = 0
	Set @I = 1
	Set @J = 0
	Set @id_venta = 1
	Set @id_venta_anterior = 0

	WHILE (@filas >0) AND (@I <= @filas)
	BEGIN
		
			
		SELECT 
				@Id_Linea_Venta 	=	Id_Linea_Venta ,
				@Id_Venta 		= Id_Venta ,
				@Peso_Bruto   		=	Peso_Bruto   ,
				@Cantidad_Javas    	=	Cantidad_Javas ,   
				@Obs_Detalle 		=	Obs_Detalle ,
				@IdEstado 		=	IdEstado ,
				@Obs_Venta  		=	Obs_Venta , 
				@Total_Peso_Bruto   	=	Total_Peso_Bruto   ,
				@Total_Peso_Tara   	=	Total_Peso_Tara   ,
				@Total_Peso_Neto   	=	Total_Peso_Neto   ,
				@Precio   		=	Precio   ,
				@Monto_Total   		=	Monto_Total ,  
				@Total_Devolucion   	=	Total_Devolucion   ,
				@Total_Amortizacion   	=	Total_Amortizacion  , 
				@Total_Saldo   		=	Total_Saldo   ,
				@cliente 		=	cliente ,
				@Id_Caja  		=	Id_Caja  ,
				@fecha_caja  		=	fecha_caja,  
				@Zona 			=	Zona 	,	
				@Producto		=	Producto		
		FROM @detalle_venta
		WHERE id_detalle = @I

		print '@id_venta:' + cast( @id_venta as varchar(100)) + '@id_venta_anterior:' + cast( @id_venta_anterior as varchar(100))
		IF (@id_venta = @id_venta_anterior) 
		BEGIN	
			--print 'segundo while @id_venta:' + cast( @id_venta as varchar(100))
			
			Set @fila_nueva = (@J % @Columnas) 

			print 'OJO PRIMERA CONDICION @fila_nueva:' + cast( @fila_nueva as varchar(100))
			print 'PRIMERA CONDICION while @J:' + cast( @J as varchar(100))
			IF @fila_nueva = 0
			BEGIN
				INSERT INTO @tablero (
						Nombre_Cliente ,
						Producto ,
						fecha_venta  ,
						str_fecha_venta ,
						zona  ,
						Peso_bruto1 ,
						Peso_bruto2  ,
						Total_Bruto  ,
						Total_Tara  ,
						Total_Neto_Devoluciones ,
						Total_Neto  ,
						Total_Importe  ,
						Total_Amortizacion  ,
						Total_Saldo  ,
						Total_Jabas  ,
						Observacion ,
						Primera_Fila
						) VALUES 
						(
						   @cliente ,
						   @Producto ,
						   @fecha_caja ,  
						   convert (varchar(10),@fecha_caja , 103) ,
						   @Zona ,
						   @Peso_Bruto ,
						   NULL ,
						   0 ,
						   0 ,
						   0 , 
						   0, 
						   0 , 
						   0 ,
						   0 ,
						   0 ,
						   @Obs_Venta + @Obs_Detalle	,
						   0
						)
						SET @tbl_id_tablero = SCOPE_IDENTITY( )
				print 'PRIMERA CONDICION NUEVA FILA DE UN GRUPO @tbl_id_tablero:' + cast( @tbl_id_tablero as varchar(100))
			END -- fin del @fila_nueva = 1			
			IF @fila_nueva = 1
			BEGIN
				UPDATE @tablero SET
					Peso_bruto2 = @Peso_Bruto ,
					Observacion = Observacion + @Obs_Detalle
				WHERE
					id_tablero = @tbl_id_tablero
				print 'PRIMERA CONDICION FILA ACTUALIZAR @tbl_id_tablero:' + cast( @tbl_id_tablero as varchar(100))
			
			END -- fin del @fila_nueva = 2
			Set @J = @J + 1	
		END --fin del iIF
		ELSE
		BEGIN
			INSERT INTO @tablero (
						Nombre_Cliente ,
						Producto ,
						fecha_venta  ,
						str_fecha_venta , 
						zona  ,
						Peso_bruto1 ,
						Peso_bruto2  ,
						Total_Bruto  ,
						Total_Tara  ,
						Total_Neto_Devoluciones ,
						Total_Neto  ,
						Total_Importe  ,
						Total_Amortizacion  ,
						Total_Saldo  ,
						Total_Jabas  ,
						Observacion ,
						Primera_Fila
						) VALUES 
						(
						   @cliente ,
						   @Producto ,
						   @fecha_caja ,  
						   convert (varchar(10),@fecha_caja , 103) ,
						   @Zona ,
						   @Peso_Bruto ,
						   NULL ,
						   @Total_Peso_Bruto ,
						   @Total_Peso_Tara ,
						   @Total_Devolucion , 
						   @Total_Peso_Neto, 
						   @Monto_Total , 
						   @Total_Amortizacion ,
						   @Total_Saldo ,
						   @Cantidad_Javas ,
						   @Obs_Venta + @Obs_Detalle	,
						   1
						)
						SET @tbl_id_tablero = SCOPE_IDENTITY( )
				print 'SEGUNDA CONDICION NUEVO GRUPO identity @tbl_id_tablero:' + cast( @tbl_id_tablero as varchar(100))
				Set @J = 1	
					
		END --FIN DEL ELSE

		Set @id_venta_anterior = @id_venta
		Set @I = @I + 1

	END --fin del 2do while
	-- IF @id_venta_anterior = @id_venta
	select * from @tablero
	order by Nombre_Cliente
END  -- del procedimiento
