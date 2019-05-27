
--New field added--------------Invoice
--IGST
--CGST
--SGST
--New field added---------------InvoiceItems
--IGST
--IGSTAmt
--CGST
--CGSTAmt
--SGST
--SGSTAmt
--TotAmt



/****** Object:  Table [dbo].[Invoice]    Script Date: 5/27/2019 12:45:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceCode] [nvarchar](max) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Total] [float] NOT NULL,
	[PaymentMethod] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[Discount] [float] NOT NULL,
	[IGST] [float] NOT NULL,
	[CGST] [float] NOT NULL,
	[SGST] [float] NOT NULL,
	[GrandTotal] [float] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[InvoiceItems]    Script Date: 5/27/2019 12:45:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InvoiceItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[IGST] [float] NULL,
	[IGSTAmt] [float] NULL,
	[CGST] [float] NULL,
	[CGSTAmt] [float] NULL,
	[SGST] [float] NULL,
	[SGSTAmt] [float] NULL,
	[TotAmt] [float] NULL,
	[InvoiceId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.InvoiceItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Invoice_dbo.Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_dbo.Invoice_dbo.Project_ProjectId]
GO

ALTER TABLE [dbo].[InvoiceItems]  WITH CHECK ADD  CONSTRAINT [FK_dbo.InvoiceItems_dbo.Invoice_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[InvoiceItems] CHECK CONSTRAINT [FK_dbo.InvoiceItems_dbo.Invoice_InvoiceId]
GO


