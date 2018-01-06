
CREATE TABLE [dbo].[TbCompra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoDocumentoCompra] [varchar](5) NULL,
	[NumeroDocumento] [varchar](100) NULL,
	[TotalJabas] [decimal](18, 2) NOT NULL,
	[TotalPeso_Bruto] [decimal](18, 2) NOT NULL,
	[TotalPeso_Tara] [decimal](18, 2) NOT NULL,
	[TotalPeso_Neto] [decimal](18, 2) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[MontoSubTotal] [decimal](18, 2) NOT NULL,
	[MontoIgv] [decimal](18, 2) NOT NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[TotalDevolucion] [decimal](18, 2) NULL,
	[TotalAmortizacion] [decimal](18, 2) NULL,
	[TotalSaldo] [decimal](18, 2) NULL,
	[Observacion] [varchar](500) NULL,
	[IdEstado] [varchar](3) NULL,
	[IdCaja] [int] NOT NULL,
	[IdEmpresa] [int]  NULL,
	[IdProducto] [int] NOT NULL,
	[IdCliente] [int] NULL,
	[IdPersonal] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
	[TotalUnidades] [int] NULL,
 CONSTRAINT [PK__TbCompra__07F6335A] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TbCompra] ADD  CONSTRAINT [DF_TbCompra_TotalJabas]  DEFAULT ((0)) FOR [TotalJabas]
GO

ALTER TABLE [dbo].[TbCompra] ADD  CONSTRAINT [DF_TbCompra_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[TbCompra]  WITH CHECK ADD  CONSTRAINT [FK_TbCompra_Tb_Caja] FOREIGN KEY([IdCaja])
REFERENCES [dbo].[Tb_Caja] ([IdCaja])
GO

ALTER TABLE [dbo].[TbCompra] CHECK CONSTRAINT [FK_TbCompra_Tb_Caja]
GO

ALTER TABLE [dbo].[TbCompra]  WITH CHECK ADD  CONSTRAINT [FK_TbCompra_Tb_Empresa] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Tb_Empresa] ([IdEmpresa])
GO

ALTER TABLE [dbo].[TbCompra] CHECK CONSTRAINT [FK_TbCompra_Tb_Empresa]
GO


