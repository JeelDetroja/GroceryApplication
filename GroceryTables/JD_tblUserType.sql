USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblUserType]    Script Date: 2/22/2023 12:45:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblUserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[isActivated] [bit] NOT NULL,
 CONSTRAINT [PK_JD_tblUserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_JD_tblUserType] UNIQUE NONCLUSTERED 
(
	[UserType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblUserType] ADD  CONSTRAINT [DF_JD_tblUserType_CreationOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[JD_tblUserType] ADD  CONSTRAINT [DF_JD_tblUserType_UpdationOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO


