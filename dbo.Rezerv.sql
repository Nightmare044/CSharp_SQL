CREATE TABLE [dbo].[Rezerv] (
    [Id]     INT           NOT NULL,
    [Imja]   NVARCHAR (20) NULL,
    [Room]   NVARCHAR (20) NULL,
    [Place]  INT           NULL,
    [Number] INT           NULL,
    [Price]  INT           NULL,
	[Image]  IMAGE         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

