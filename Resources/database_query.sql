
-- Distance prices table
CREATE TABLE [dbo].[DistancePrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistanceFrom] [int] NOT NULL,
	[DistanceTo] [int] NULL,
	[FixedPrice] [int] NOT NULL,
	[PricePerKm] [int] NOT NULL,
	[PianoPrice] [int] NOT NULL,
 CONSTRAINT [PK_DistancePrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Volume prices table
CREATE TABLE [dbo].[VolumePrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaximumArea] [int] NOT NULL,
	[AtticAreaMultiplier] [int] NOT NULL,
	[PricePerCar] [int] NOT NULL,
 CONSTRAINT [PK_VolumePrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Users table
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](500) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Offers table
CREATE TABLE [dbo].[Offers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Distance] [int] NOT NULL,
	[LivingArea] [int] NOT NULL,
	[AtticArea] [int] NOT NULL,
	[PianoIncluded] [bit] NOT NULL,
	[TotalPrice] [int] NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_Offers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_Offers_Users]
GO


-- Insert distance prices
insert into DistancePrices values (1, 49, 1000, 10, 5000);
insert into DistancePrices values (50, 99, 5000, 8, 5000);
insert into DistancePrices values (100, NULL, 10000, 7, 5000);

-- Insert volume prices
insert into VolumePrices values (49, 2, 1100);

-- Insert users
insert into Users values (newid(), 'username1', 'User', 'One');
insert into Users values (newid(), 'username2', 'User', 'Two');
