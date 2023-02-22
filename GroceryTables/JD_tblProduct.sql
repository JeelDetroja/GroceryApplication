USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblProduct]    Script Date: 2/22/2023 12:43:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[ProductPrice] [money] NOT NULL,
	[Discount] [int] NULL,
	[ProductPhotoPath] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[isActivated] [bit] NOT NULL,
 CONSTRAINT [PK_JD_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblProduct] ADD  CONSTRAINT [DF_JD_tblProduct_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[JD_tblProduct] ADD  CONSTRAINT [DF_JD_tblProduct_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO

ALTER TABLE [dbo].[JD_tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblProduct_JD_tblUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[JD_tblUser] ([UserId])
GO

ALTER TABLE [dbo].[JD_tblProduct] CHECK CONSTRAINT [FK_JD_tblProduct_JD_tblUser]
GO

ALTER TABLE [dbo].[JD_tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblProduct_JD_tblUser1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[JD_tblUser] ([UserId])
GO

ALTER TABLE [dbo].[JD_tblProduct] CHECK CONSTRAINT [FK_JD_tblProduct_JD_tblUser1]
GO


