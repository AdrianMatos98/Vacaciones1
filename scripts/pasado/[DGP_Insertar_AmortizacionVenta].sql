alter       PROCEDURE [dbo].[DGP_Insertar_AmortizacionVenta](

@decMonto		DECIMAL(8,2)

,@varNumeroDocumento	VARCHAR(20)

,@varIdFormaPago	VARCHAR(5)

,@datFechaPago		DATETIME

,@varIdTipoAmortizacion	VARCHAR(5)

,@varObservacion	VARCHAR(100)

,@varIdEstado		VARCHAR(5)

,@intIdVenta		INT

,@intIdCliente		INT = NULL

,@intIdPersonal		INT

,@intIdUsuarioCreacion	INT

, @intIdCaja INT
,@intIdDocumento INT
)

AS

/*

**************************************************

PROCEDIMIENTO	: dbo.DGP_Insertar_AmortizacionVenta

FECHA CREACION	: 29/03/2009 (dd/MM/yyyy)

AUTOR		: Alexander Macuri

**************************************************

*/

BEGIN

	SET NOCOUNT OFF

	INSERT INTO dbo.Tb_Amort_Venta (

		Monto

		,NumeroDocumento

		,IdFormaPago

		,FechaPago

		,IdTipoAmortizacion

		,Observacion

		,IdEstado

		,Id_Venta

		,Id_Cliente

		,Id_Personal

		,UsuarioCreacion

		,FechaCreacion

		,Id_Caja
		,IdDocumento

	) VALUES (

		@decMonto

		,@varNumeroDocumento

		,@varIdFormaPago

		,@datFechaPago

		,@varIdTipoAmortizacion

		,@varObservacion

		,@varIdEstado

		,@intIdVenta

		,@intIdCliente

		,@intIdPersonal

		,@intIdUsuarioCreacion

		,GETDATE()

		,@intIdCaja
		,@intIdDocumento
	);

END



