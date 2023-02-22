USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblUser]    Script Date: 2/22/2023 12:45:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[UserEmail] [nvarchar](250) NOT NULL,
	[UserMobileNo] [nvarchar](50) NOT NULL,
	[UserDOB] [date] NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[isActivated] [bit] NOT NULL,
 CONSTRAINT [PK_JD_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_JD_tblUser] UNIQUE NONCLUSTERED 
(
	[UserEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblUser] ADD  CONSTRAINT [DF_JD_tblUser_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[JD_tblUser] ADD  CONSTRAINT [DF_JD_tblUser_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO

ALTER TABLE [dbo].[JD_tblUser]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblUser_JD_tblUserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[JD_tblUserType] ([UserTypeId])
GO

ALTER TABLE [dbo].[JD_tblUser] CHECK CONSTRAINT [FK_JD_tblUser_JD_tblUserType]
GO


