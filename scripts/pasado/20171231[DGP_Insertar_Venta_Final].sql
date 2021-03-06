

ALTER              PROCEDURE [dbo].[DGP_Insertar_Venta_Final] (
@intIdVenta		INT
,@decPrecioVenta		decimal(8,2) = null
,@IdUsuario int  = 1
) AS
/*
**************************************************
PROCEDIMIENTO	: dbo.DGP_Insertar_Venta_Final
FECHA CREACION	: 07/03/2009 (dd/MM/yyyy)
AUTOR		: Alexander Macuri
**************************************************
*/
DECLARE @varEstadoRegistrado	VARCHAR(5);
DECLARE @varEsDevolucion	CHAR(1);
DECLARE @decIGV			DECIMAL(8,2);
DECLARE @decTotalJabas		DECIMAL(8,2);
DECLARE @decPrecio		DECIMAL(8,2);
DECLARE @decTotalPesoBruto	DECIMAL(8,2);
DECLARE @decTotalPesoTara	DECIMAL(8,2);
DECLARE @decTotalPesoNeto	DECIMAL(8,2);
DECLARE @decMontoSubTotal	DECIMAL(8,2);
DECLARE @decMontoIGV		DECIMAL(8,2);
DECLARE @decMontoTotal		DECIMAL(8,2);
DECLARE @decTotalDevolucion	DECIMAL(8,2);
DECLARE @decTotalAmortizacion	DECIMAL(8,2);
DECLARE @intTotalUnidades	INT;
declare      @decTotalDevolucionUnidades int;
declare @PrecioVentaBD		decimal(8,2)
BEGIN
	SET NOCOUNT OFF
	/** Establecer valores a los parametrods generales **/
	SET @varEstadoRegistrado =dbo.DGP_VENTA_ESTADO_REGISTRADO() ; --// Valor de dbo.Tb_ParametroDetalle

	SELECT @decIGV = CONVERT(DECIMAL(8,2), VALOR) --// Valor de dbo.Tb_ParametroDetalle
	FROM dbo.Tb_ParametroDetalle
	WHERE Id_Parametro = 6;

	SELECT @decPrecio = isnull ( @decPrecioVenta , Precio ) , @PrecioVentaBD = Precio  --// Valor de dbo.Tb_Venta
	FROM dbo.Tb_Venta
	WHERE Id_Venta = @intIdVenta;

	/** Obtener los Pesos de la Linea de Ventas **/
	SET @varEsDevolucion = 'N';
	SELECT 	
		@decTotalPesoBruto = ISNULL(SUM(Peso_Bruto), 0)
		,@decTotalJabas = ISNULL(SUM(Cantidad_Javas), 0)
		,@decTotalPesoTara = ISNULL(SUM(Peso_Tara), 0)
		,@decTotalPesoNeto = ISNULL(SUM(Peso_Neto), 0)
		,@intTotalUnidades = isnull(sum(unidades), 0 )
	FROM dbo.Tb_Linea_Venta
	WHERE IdEstado = @varEstadoRegistrado
		AND EsDevolucion = @varEsDevolucion
		AND Id_Venta = @intIdVenta;

	/** Validar si tiene Devolucion **/
	DECLARE @chrTieneDevolucion CHAR(1);
	SET @decTotalDevolucion = 0;
             SET @decTotalDevolucionUnidades = 0;

	SET @chrTieneDevolucion = 'N';
	SET @varEsDevolucion = 'S';
	IF EXISTS (SELECT Id_Linea_Venta
			FROM dbo.Tb_Linea_Venta
			WHERE IdEstado = @varEstadoRegistrado
				AND EsDevolucion = @varEsDevolucion
				AND Id_Venta = @intIdVenta
		)
		BEGIN
			SET @chrTieneDevolucion = 'S';
			SELECT @decTotalDevolucion = ISNULL(SUM(Peso_Neto), 0)
				 , @decTotalDevolucionUnidades =  ISNULL(SUM(Unidades), 0)
			FROM dbo.Tb_Linea_Venta
			WHERE IdEstado = @varEstadoRegistrado
				AND EsDevolucion = @varEsDevolucion
				AND Id_Venta = @intIdVenta;
		END;

	/** Establecer los Montos **/

	SET @decMontoTotal = ((@decTotalPesoNeto - @decTotalDevolucion) * @decPrecio);
	SET @decMontoSubTotal = (@decMontoTotal/(1 + @decIGV));
	SET @decMontoIGV = (@decMontoSubTotal * @decIGV);
	/*si hay cambio de precio anulamos amortizaciones*/
	if @PrecioVentaBD <>@decPrecioVenta
	begin
		exec [dbo].[DGP_AnularAmortizacionesVenta] @intIdVenta
														    ,@idUsuario
	end;
	/** Obtener el Total de Amortizaciones **/
	SET @decTotalAmortizacion = 0;
	SET @decTotalAmortizacion = dbo.DGP_Obtener_TotalAmortizaciones(@intIdVenta);
	print cast(@decTotalAmortizacion as varchar(100))
	/** Actualizar la Venta **/
	UPDATE dbo.Tb_Venta SET
		  Precio	= @decPrecio
		,Total_Jabas = @decTotalJabas
		,Total_Peso_Bruto = @decTotalPesoBruto
		,Total_Peso_Tara = @decTotalPesoTara
		,Total_Peso_Neto = (@decTotalPesoNeto - @decTotalDevolucion)
		,Monto_SubTotal = @decMontoSubTotal --// Importe
		,Monto_Igv = @decMontoIGV
		,Monto_Total = @decMontoTotal 
		,TieneDevolucion = @chrTieneDevolucion
		,Total_Devolucion = @decTotalDevolucion
		,Total_Amortizacion = @decTotalAmortizacion 
		,Total_Saldo = (@decMontoTotal - @decTotalAmortizacion)
		,IdEstado = case (@decMontoTotal - @decTotalAmortizacion) 
			   	 when  0 then dbo.DGP_VENTA_ESTADO_CANCELADO()
			    	  else dbo.DGP_VENTA_ESTADO_REGISTRADO()
			    end
		,TotalUnidades = @intTotalUnidades - @decTotalDevolucionUnidades

	WHERE Id_Venta = @intIdVenta;

END;


