USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblProductCategory]    Script Date: 2/22/2023 12:44:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblProductCategory](
	[ProductCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCategoryName] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[isActivated] [bit] NOT NULL,
 CONSTRAINT [PK_JD_tblProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_JD_tblProductCategory] UNIQUE NONCLUSTERED 
(
	[ProductCategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblProductCategory] ADD  CONSTRAINT [DF_JD_tblProductCategory_CreationOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[JD_tblProductCategory] ADD  CONSTRAINT [DF_JD_tblProductCategory_UpdationOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO

ALTER TABLE [dbo].[JD_tblProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblProductCategory_JD_tblUser] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[JD_tblUser] ([UserId])
GO

ALTER TABLE [dbo].[JD_tblProductCategory] CHECK CONSTRAINT [FK_JD_tblProductCategory_JD_tblUser]
GO

ALTER TABLE [dbo].[JD_tblProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblProductCategory_JD_User] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[JD_tblUser] ([UserId])
GO

ALTER TABLE [dbo].[JD_tblProductCategory] CHECK CONSTRAINT [FK_JD_tblProductCategory_JD_User]
GO


