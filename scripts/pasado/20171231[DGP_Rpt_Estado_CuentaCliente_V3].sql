USE [DVGP_CITAVAL]
GO
/****** Object:  StoredProcedure [dbo].[DGP_Rpt_Estado_CuentaCliente_V3]    Script Date: 03/12/2017 10:23:12 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[DGP_Rpt_Estado_CuentaCliente_V3] (    

  @fechaInicio Datetime     

  ,@clientes varchar(1000)  = null



)    

AS    

/*    

*****************************************************    

PROCEDIMIENTO  : dbo.DGP_Rpt_EstadoCuentaCliente    

FECHA   : 01/06/2017 (dd/MM/yyyy)    

AUTOR   : Carlos Abanto G    

***************************************************** 

-- declare @fechaInicio Datetime     

 --declare @clientes varchar(1000) -- = null

 --set @fechaInicio = '2017-10-12'
 --set @clientes = '99'      

*/    

 

BEGIN  






SELECT * FROM (

  select 
		  1   as orden
		,  null as FECHA  
		, cli.Nombres as CLIENTE 
		, 'SI. Venta' as PRODUCTO
		, null as IDESTADO 
		, null as PRECIO
		, null  as TOTAL_PESO_NETO 
		, IIF( sum (v.Total_Saldo ) > 0,sum (v.Total_Saldo )  , NULL) as MONTO_VENTA
		, IIF( sum (v.Total_Saldo ) > 0 , NULL , sum (v.Total_Saldo )) as AMORTIZACION
		, null as observacion
  from dbo.Tb_Venta v   
  inner join dbo.Tb_Caja c on c.Id_Caja = v.Id_Caja  
  inner join dbo.Tb_Producto p on p.Id_Producto =v.Id_Producto  
  inner join dbo.Tb_Personal per on per.Id_Personal = v.Id_Personal  
  inner join dbo.Tb_Cliente_Proveedor cli on cli.Id_Cliente = v.Id_Cliente  
  where v.IdEstado  in ('REG' , 'CON')  
  and  v.Id_Cliente in (select * from dbo.Split(@clientes) )  
  and c.Fecha < @fechaInicio  
  group by   cli.Nombres 
  union all
  select 1 as ORDEN 
	  , null as FECHA		
	  , cli.Nombres as CLIENTE
	  , 'SI AMORTIZAcion' as PRODUCTO  
	  , null as IdEstado
	  , null as PRECIO 
	  , null as TOTAL_PESO_NETO 
	  
	  , a.Monto AS MONTO_VENTA 
	  , NULL AS  AMORTIZACION
	  , NULL OBSERVACION   
  from  dbo.Tb_Amort_Venta a
  inner join dbo.tb_documento d on d.IdDocumento = a.IdDocumento 
  inner join dbo.tb_Venta v on v.Id_Venta = a.Id_Venta   
  inner join dbo.Tb_Caja c on c.Id_Caja = v.Id_Caja  
  inner join dbo.Tb_Personal per on per.Id_Personal = a.Id_Personal 
  inner join dbo.Tb_Cliente_Proveedor cli on cli.Id_Cliente = d.IdCliente
  where v.IdEstado = 'CAN'  
  and  a.IdTipoAmortizacion in ( 'AMR')
  and  a.Id_Cliente in (select * from dbo.Split(@clientes) )  
  and d.Fecha >= @fechaInicio 
  and c.Fecha < @fechaInicio

  union all 

  select  2 as ORDEN

		 , c.FECHA 

		 , cli.Nombres as CLIENTE

		 , p.Nombre as PRODUCTO  

		 , v.IdEstado 

		 , v.TOTAL_PESO_NETO 

		 , v.PRECIO 

		 , v.Monto_Total as MONTO_venta 

		 , NULL AS AMORTIZACION

		 , NULL OBSERVACION

  from dbo.Tb_Venta v   

  inner join dbo.Tb_Caja c on c.Id_Caja = v.Id_Caja  

  inner join dbo.Tb_Producto p on p.Id_Producto =v.Id_Producto  

  inner join dbo.Tb_Personal per on per.Id_Personal = v.Id_Personal  

  inner join dbo.Tb_Cliente_Proveedor cli on cli.Id_Cliente = v.Id_Cliente  

  where v.IdEstado  not in ('ANL')  

  and  v.Id_Cliente in (select * from dbo.Split(@clientes) )  

  and c.Fecha >= @fechaInicio  

  union all

  --  Amortizacion

  select 2 as ORDEN 
	  , a.Fecha as FECHA		
	  , cli.Nombres as CLIENTE
	  , null as PRODUCTO  
	  , A.IdTipoDocumento as IdEstado
	  , null as PRECIO 
	  , null as TOTAL_PESO_NETO 
	  , NULL AS MONTO_VENTA 
	  , a.Monto*-1 AS AMORTIZACION
	  , NULL OBSERVACION  
  from dbo.tb_documento a   
  inner join dbo.Tb_Personal per on per.Id_Personal = a.IdPersonal 
  inner join dbo.Tb_Cliente_Proveedor cli on cli.Id_Cliente = a.IdCliente  
  where a.estado=1 
  and  a.IdTipoDocumento in ( 'AMR')
  and  a.IdCliente in (select * from dbo.Split(@clientes) )  
  and a.Fecha >= @fechaInicio

  ) AS VIEW_ESTADO_CUENTA

  ORDER BY FECHA

  END;


