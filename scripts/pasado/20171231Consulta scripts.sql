declare @Cliente varchar(100)
declare @IdCliente int
set @Cliente = 'delia'

declare @FechaInicial date

set @FechaInicial = '2017-09-30'

select * from dbo.Tb_Cliente_Proveedor where Nombres like  '%' + @Cliente + '%' 
select @IdCliente = Id_Cliente from dbo.Tb_Cliente_Proveedor where Id_Cliente =24

select caj.fecha , v.* from Tb_Venta v 
inner join tb_caja caj on caj.Id_caja = v.id_caja
where v.id_cliente = @IdCliente

select c.Fecha , v.* from dbo.Tb_Venta v
inner join dbo.Tb_Caja c on c.Id_Caja = v.Id_Caja
where Id_cliente = @IdCliente
and v.IdEstado  not in ('ANL' )
order by c.fecha

select d.IdPersonal, d.* from dbo.Tb_documento d where IdCliente = @IdCliente  order by fecha


select p.Fecha , c.Nombres, v.Precio as precioventa , p.Precio as preciocompra , v.Precio - p.Precio  as margen 
from [dbo].[Tb_Venta] v
inner join [dbo].[Tb_Caja]  caj on caj.Id_caja = v.Id_Caja
inner join [dbo].[Tb_preciocompra] p on p.IdProducto = v.Id_Producto and caj.Fecha = p.Fecha
inner join [dbo].Tb_Cliente_Proveedor c on c.Id_Cliente = v.Id_Cliente 
where 
p.IdProducto in (1, 8)
and v.id_Cliente = @IdCliente
and IdEstado not in ('ANL')


and Nombres not in ('Calle')

order by p.fecha