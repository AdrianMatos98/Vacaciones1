

CREATE TABLE [dbo].[Tb_Amort_Compra](
	[IdAmortCompra] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[NumeroDocumento] [varchar](20) NULL,
	[IdFormaPago] [varchar](5) NOT NULL,
	[IdTipoAmortizacion] [varchar](5) NOT NULL,
	[Observacion] [varchar](100) NULL,
	[IdEstado] [varchar](3) NOT NULL,
	[IdCompra] [int] NULL,
	[IdCliente] [int] NULL,
	[IdPersonal] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[UsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
	[idCaja] [int] NULL,
	[IdDocumento] [int] NULL,
 CONSTRAINT [PK__Tb_Amort_Compra__2D27B809] PRIMARY KEY CLUSTERED 
(
	[IdAmortCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Tb_Amort_Compra] ADD  CONSTRAINT [DF_Tb_Amort_Compra_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO



