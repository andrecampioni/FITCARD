USE [FITCARD]
GO

/****** Object:  Table [dbo].[Estabelecimento]    Script Date: 20/10/2018 14:02:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Estabelecimento](
	[IDEstabelecimento] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
	[RazaoSocial] [varchar](250) NOT NULL,
	[NomeFantasia] [varchar](250) NULL,
	[Email] [varchar](100) NULL,
	[Endereco] [varchar](max) NULL,
	[Cidade] [varchar](150) NULL,
	[Estado] [varchar](2) NULL,
	[Telefone] [varchar](14) NULL,
	[DataCadastro] [datetime] NULL,
	[Categoria] [varchar](150) NULL,
	[Status] [int] NULL,
	[Agencia] [varchar](4) NULL,
	[Conta] [varchar](6) NULL,
 CONSTRAINT [PK_Estabelecimento] PRIMARY KEY CLUSTERED 
(
	[IDEstabelecimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Estabelecimento] ADD  CONSTRAINT [DF_Estabelecimento_Status]  DEFAULT ((1)) FOR [Status]
GO


