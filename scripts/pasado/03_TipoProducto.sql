USE [DVGP_CITAVAL]
GO

/****** Object:  Table [dbo].[TipoProducto]    Script Date: 07/11/2017 03:15:59 p.m. ******/
DROP TABLE [dbo].[TipoProducto]
GO

/****** Object:  Table [dbo].[TipoProducto]    Script Date: 07/11/2017 03:15:59 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoProducto](
	[idTipoProducto] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[idTipoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


