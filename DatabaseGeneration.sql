USE [weather]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Forecasts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[MinDayTemperature] [float] NOT NULL,
	[MaxDayTemperature] [float] NOT NULL,
	[MinNightTemperature] [float] NOT NULL,
	[MaxNightTemperature] [float] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Observations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[AirTemperature] [float] NOT NULL
) ON [PRIMARY]
GO