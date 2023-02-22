USE [ContisTraineeLab]
GO

/****** Object:  Table [dbo].[JD_tblOrder]    Script Date: 2/22/2023 12:44:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JD_tblOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[GrandTotal] [money] NOT NULL,
	[isDelivered] [bit] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveredDate] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JD_tblOrder] ADD  CONSTRAINT [DF_JD_tblOrder_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO

ALTER TABLE [dbo].[JD_tblOrder] ADD  CONSTRAINT [DF_JD_tblOrder_DeliveredDate]  DEFAULT (getdate()) FOR [DeliveredDate]
GO

ALTER TABLE [dbo].[JD_tblOrder]  WITH CHECK ADD  CONSTRAINT [FK_JD_tblOrder_JD_tblUser] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[JD_tblUser] ([UserId])
GO

ALTER TABLE [dbo].[JD_tblOrder] CHECK CONSTRAINT [FK_JD_tblOrder_JD_tblUser]
GO


