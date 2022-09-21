CREATE TABLE [dbo].[Runner]
(
	[ID]			NVARCHAR (15)	NOT NULL,
	[EMPID]			NVARCHAR (10)	NULL,
	[Name]			NVARCHAR (100)	NULL,
	[Phone]			NVARCHAR (15)	NULL,
	[Role]			NCHAR (10)		NULL,
	[DayRate]		MONEY			NULL,
	[NoOfShifts]	NCHAR		NULL,
	[Tips]			MONEY			NULL,
	PRIMARY KEY CLUSTERED ([ID] ASC) 
)
