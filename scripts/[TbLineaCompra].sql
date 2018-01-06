

CREATE TABLE [dbo].[TbLineaCompra](
	[IdLineaCompra] [int] IDENTITY(1,1) NOT NULL,
	[TaraEditada] [decimal](8, 2) NULL,
	[PesoBruto] [decimal](8, 2) NOT NULL,
	[PesoTara] [decimal](8, 2) NOT NULL,
	[PesoNeto] [decimal](8, 2) NOT NULL,
	[CantidadJavas] [int] NOT NULL,
	[EsDevolucion] [char](1) NULL,
	[EsPesoTaraEditado] [char](1) NULL,
	[Observacion] [varchar](500) NULL,
	[IdEstado] [varchar](3) NULL,
	[IdCompra] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
	[Unidades] [int] NULL,

) ON [PRIMARY]

GO



ALTER TABLE [dbo].[TbLineaCompra] ADD  CONSTRAINT [DFTbLineaCompraFechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[TbLineaCompra]  WITH CHECK ADD  CONSTRAINT [FKTbLineaCompraTbCompra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[TbCompra] ([IdCompra])
GO

ALTER TABLE [dbo].[TbLineaCompra] CHECK CONSTRAINT [FKTbLineaCompraTbCompra]
GO


