/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
  FROM [DVGP_CITAVAL].[dbo].[Tb_documento] 
  where idCliente = 461
  order by [IdDocumento] desc

  SELECT *
  FROM [DVGP_CITAVAL].[dbo].[Tb_Amort_Venta] 
  WHERE ID_cLIENTE = 461 AND iDeSTADO = 'REG'
  order by Id_Amort_Venta desc

SELECT * FROM [dbo].[Tb_Venta] WHERE Id_Cliente = 461 