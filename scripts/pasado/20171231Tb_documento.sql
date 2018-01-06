/*
   martes, 19 de diciembre de 201710:11:28 p.m.
   User: sa
   Server: USER-PC\SQLEXPRESS
   Database: DVGP_CITAVAL
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Tb_documento ADD
	IdTipoPago varchar(10) NULL,
	Observacion varchar(200) NULL
GO
ALTER TABLE dbo.Tb_documento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
