USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblCartItem]    Script Date: 2/22/2023 12:42:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblCartItem](
	[CartItemId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [money] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[isActivated] [bit] NOT NULL,
 CONSTRAINT [PK_JD_tblCartItem] PRIMARY KEY CLUSTERED 
(
	[CartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblCartItem] ADD  CONSTRAINT [DF_JD_tblCartItem_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[JD_tblCartItem] ADD  CONSTRAINT [DF_JD_tblCartItem_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO


