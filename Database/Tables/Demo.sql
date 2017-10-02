CREATE TABLE [dbo].[Demo]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[DemoString] VARCHAR(250) NOT NULL,
	[DemoBool] BIT NOT NULL,
	[DemoDate] DATETIME NOT NULL

	constraint [PK_Demo] PRIMARY KEY (Id)
)
