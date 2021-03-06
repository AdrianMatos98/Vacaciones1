



create  PROCEDURE [dbo].DGP_AnularAmortizacionesVenta (
@IdVenta		INT
,@idUsuario	INT
) AS
/*
**************************************************
PROCEDIMIENTO	: dbo.DGP_Eliminar_LineaVenta
FECHA CREACION	: 11/04/2009 (dd/MM/yyyy)
AUTOR		: Alexander Macuri
**************************************************
*/
BEGIN
	SET NOCOUNT OFF

	--no se usa existe un SP [DGP_EliminarAmortizacion]
	update  a set
	a.IdEstado = dbo.DGP_VENTA_ESTADO_ANULADO()
	, a.FechaModificacion = getdate()
    , a.UsuarioModificacion = @idUsuario
	from [Tb_Amort_Venta] a 
	WHERE a.Id_Venta = @IdVenta
	and a.IdEstado <>dbo.DGP_VENTA_ESTADO_ANULADO()

		
END;



