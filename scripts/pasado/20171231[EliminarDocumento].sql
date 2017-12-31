USE [DVGP_CITAVAL]
GO
/****** Object:  StoredProcedure [dbo].[InsertarDocumento]    Script Date: 19/12/2017 10:57:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROCEDURE [dbo].[EliminarDocumento](
@IdDocumento int
,@Usuario int
,@observacion varchar(100) = null
) AS

BEGIN

UPDATE [dbo].[Tb_documento]
   SET [estado] = 0
       ,[Observacion] = @observacion
	   ,[FechaEliminacion] = GETDATE()
	   ,[UsuarioEliminacion] = @Usuario
 WHERE IdDocumento = @IdDocumento

END



