
INSERT INTO [dbo].[Tb_documento]
           ([IdTipoDocumento]
           ,[Fecha]
           ,[Monto]
           ,[estado]
           ,[EsEliminado]
           ,[FechaEliminacion]
           ,[FechaModificacion]
           ,[FechaCreacion]
           ,[UsuarioModificacion]
           ,[UsuarioCreacion]
           ,[UsuarioEliminacion]
           ,[IdCliente]
           ,[IdPersonal]
           ,[IdCaja])
select 
			'AMR'
			,a.FechaPago 
			,sum (a.Monto)
			,1 --estado
			,1
			,null --fecha eliminacion
			,null -- fecha modificacion
			,getdate()
			,null
			,1
			,null
			,a.Id_Cliente
			
			, a.Id_Personal
			, 1  
from [dbo].[Tb_Amort_Venta] a
where 1=1
and a.IdTipoAmortizacion = 'AMR' and a.IdFormaPago = 'EFE'
group by a.FechaPago , a.Id_Personal, a.Id_Cliente
order by a.FechaPago desc
----------------

update    a set
a.idDocumento =D.IdDocumento
from [Tb_Amort_Venta] a
inner join [Tb_documento] d on d.IdTipoDocumento = 'AMR' and d.estado = 1 and d.Fecha = a.FechaPago and a.Id_Personal = d.IdPersonal and a.Id_Cliente = d.IdCliente and d.IdCaja = 1
where
1=1 and a.IdTipoAmortizacion = 'AMR' and a.IdFormaPago = 'EFE'

-------------------
update    a set
a.idDocumento = (select  idDocumento from Tb_documento d where IdCliente is null and IdTipoDocumento = 'AMR'  and d.Fecha = a.fechaPago and a.Id_Personal = d.IdPersonal  and d.IdCaja = 1
)
from [Tb_Amort_Venta] a
where
1=1 and a.IdTipoAmortizacion = 'AMR' and  a.Id_Cliente is null


select d.IdDocumento ,  d.Monto , sum (a.Monto)
from [Tb_documento] d
inner join [Tb_Amort_Venta] a on a.IdDocumento = d.IdDocumento
where d.IdTipoDocumento = 'AMR'
group by d.Monto , d.IdDocumento