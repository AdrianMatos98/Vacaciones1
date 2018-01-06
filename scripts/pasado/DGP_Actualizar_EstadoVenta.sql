








alter     PROCEDURE [dbo].[DGP_Actualizar_EstadoVenta](

@intIdVenta	INT

, @intCancelarVenta int = 0

) 

/*

**************************************************

PROCEDIMIENTO	: dbo.DGP_Actualizar_EstadoVenta

FECHA CREACION	: 29/03/2009 (dd/MM/yyyy)

AUTOR		: Alexander Macuri

**************************************************

*/

AS

BEGIN

	SET NOCOUNT OFF

	if @intCancelarVenta = 1 

	begin

		UPDATE dbo.Tb_Venta SET

			IdEstado = dbo.DGP_VENTA_ESTADO_CANCELADO()

		WHERE Id_Venta = @intIdVenta

	end

	else

	begin

		UPDATE dbo.Tb_Venta SET

			IdEstado = dbo.DGP_VENTA_ESTADO_CANCELADO()

		WHERE Id_Venta = @intIdVenta

			AND Total_Saldo = 0;

	

	end;

END












