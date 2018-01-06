
create    PROCEDURE [dbo].DGP_ObtenerAmortizacionSinAplicar (

  @IdCliente int

) AS

BEGIN

select sum(vi.vueltos )
from (

select 
		doc.Monto- (select isnull(sum(a.Monto),0) 
					from Tb_Amort_Venta  a 
					where a.IdDocumento = doc.IdDocumento 
						and  a.IdEstado = dbo.DGP_VENTA_ESTADO_REGISTRADO() 
							and a.IdTipoAmortizacion = dbo.DGP_TIPO_AMOR_AMORTIZACION())  as vueltos

							
	    
		
from Tb_documento doc  
where 1=1
AND doc.estado = 1 and doc.IdCliente = @IdCliente
) as vi

END