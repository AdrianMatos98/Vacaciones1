USE [DVGP_CITAVAL]
GO
/****** Object:  StoredProcedure [dbo].[DGP_Listar_Venta_Cabecera]    Script Date: 02/12/2017 07:04:40 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  

ALTER      PROCEDURE [dbo].[DGP_Listar_Venta_Cabecera](  

@intIdVenta   INT = NULL  

,@varIdTipoDocumentoVenta VARCHAR(5) = NULL  

,@varNumeroDocumento  VARCHAR(100) = NULL  

,@intIdCliente   INT = NULL  

,@intIdProducto   INT = NULL  

,@intIdEmpresa   INT = NULL  

,@datFechaInicial  DATETIME  

,@datFechaFinal   DATETIME  

,@varFilterIdVentas VARCHAR(255) = NULL  

, @TienePrecioVariable bit = NULL

) AS  

/*  

**************************************************  

PROCEDIMIENTO : dbo.DGP_Listar_Venta  

FECHA CREACION : 05/04/2009 (dd/MM/yyyy)  

AUTOR  : Alexander Macuri  

**************************************************  

*/  

BEGIN



  

 SELECT V.Id_Venta  

  ,V.Id_Cliente  

  ,[Cliente] = ISNULL(C.Nombres, 'CE : ' + V.ClienteEventual)  
  ,V.Id_Producto  
  ,[Producto] = P.Nombre  
  ,V.IdTipoDocumentoVenta  
  ,[TipoDocumentoVenta] = ''  
   ,V.NumeroDocumento  
  ,CJ.Fecha as FechaCreacion  
  ,[CantidadJavas] = dbo.DGP_Obtener_CantidadJavas(V.Id_Venta)  
  ,V.Total_Peso_Bruto  
  ,V.Total_Peso_Tara  
   ,V.Total_Peso_Neto  
  ,V.Precio  
  ,V.Monto_SubTotal --// Importe  
  ,V.Monto_Igv  
  ,V.Monto_Total  
  ,V.Total_Devolucion  
  ,V.Total_Amortizacion --// Pago Efectuado  
  ,V.Total_Saldo --// Saldo Anterior  
   ,[Estado] = V.IdEstado  
  , isnull (V.TotalUnidades , 0) TotalUnidades  
  , P.Margen 
  , C.TienePrecioVariable
 FROM dbo.Tb_Venta AS V  

  LEFT JOIN dbo.Tb_Cliente_Proveedor AS C ON (V.Id_Cliente = C.Id_Cliente)  

  INNER JOIN dbo.Tb_Producto AS P ON (V.Id_Producto = P.Id_Producto)  

  INNER JOIN dbo.Tb_Caja AS CJ ON (CJ.Id_Caja = V.Id_Caja)   

 WHERE 1= 1   

  AND V.Id_Venta = ISNULL(@intIdVenta, V.Id_Venta)  

  AND ISNULL(V.IdTipoDocumentoVenta, '-1') = ISNULL(@varIdTipoDocumentoVenta, ISNULL(V.IdTipoDocumentoVenta, '-1'))  

  AND ISNULL(V.NumeroDocumento, '') LIKE '%' + ISNULL(@varNumeroDocumento, '') + '%'  

  AND ISNULL(V.Id_Cliente, -1) = ISNULL(@intIdCliente, ISNULL(V.Id_Cliente, -1))  

  AND V.Id_Producto = ISNULL(@intIdProducto, V.Id_Producto)  

  AND V.Id_Empresa = ISNULL(@intIdEmpresa, V.Id_Empresa)  

  AND CONVERT(VARCHAR, CJ.FECHA , 112) BETWEEN CONVERT(VARCHAR, @datFechaInicial, 112) AND CONVERT(VARCHAR, @datFechaFinal, 112)  

  AND isnull (C.TienePrecioVariable , 0 ) = isnull (@TienePrecioVariable , isnull (C.TienePrecioVariable , 0 )  )
  AND V.IdEstado NOT IN (dbo.DGP_VENTA_ESTADO_ANULADO() )  

  OR (v.Id_Venta in (select * from dbo.Split(@varFilterIdVentas) ) 

	  AND V.IdEstado NOT IN (dbo.DGP_VENTA_ESTADO_ANULADO() )

  )

 ORDER BY Cliente ASC , CJ.Fecha ;  

END  

  
