USE Brighters
GO

BEGIN TRANSACTION
	IF OBJECT_ID('Users', 'U') IS NOT NULL
	BEGIN
		DROP TABLE Users
		PRINT 'Dropped [Users] table successfully'
	END

	CREATE TABLE Users (
		Id INT IDENTITY(1, 1) NOT NULL,
		Email varchar(1000), --username as well
		PasswordHash binary,
		PasswordSalt binary,
		KnownAs varchar(250),
		CreatedDate DateTime,
		CONSTRAINT PK_User PRIMARY KEY CLUSTERED(Id),
	)

	PRINT 'Created table [Users] successfully'

COMMIT TRANSACTION
GO


BEGIN TRANSACTION
	IF OBJECT_ID('Cleaners', 'U') IS NOT NULL
	BEGIN
		DROP TABLE Cleaners
		PRINT 'Dropped [Cleaners] table successfully'
	END

	CREATE TABLE Cleaners (
		Id INT IDENTITY(1, 1) NOT NULL,
		UserId INT NOT NULL,
		FirstName varchar(250),
		LastName varchar(250),
		HourlyRate FLOAT(2),
		Postcode varchar(10),
		RangeKm int,
		StartDate DateTime,
		EndDate DateTime,
		CONSTRAINT PK_Cleaner PRIMARY KEY CLUSTERED(Id),
		FOREIGN KEY (UserId) REFERENCES Users(Id)
	)

	PRINT 'Created table [Cleaners] successfully'

COMMIT TRANSACTION
GO


BEGIN TRANSACTION
	IF OBJECT_ID('CleanerAvailability', 'U') IS NOT NULL
	BEGIN
		DROP TABLE CleanerAvailability
		PRINT 'Dropped [CleanerAvailability] table successfully'
	END	

	CREATE TABLE CleanerAvailability (
		Id INT IDENTITY(1, 1) NOT NULL,
		CleanerId INT NOT NULL,
		Day VARCHAR(100),
		AvailableFrom DATETIME,
		AvailableTo DATETIME

		CONSTRAINT PK_CleanerAvailability PRIMARY KEY CLUSTERED(Id),
		FOREIGN KEY(CleanerId) REFERENCES Cleaners(Id)
	)

COMMIT TRANSACTION
GO


BEGIN TRANSACTION
	IF OBJECT_ID('Orders', 'U') IS NOT NULL
	BEGIN
		DROP TABLE Orders
		PRINT 'Dropped [Orders] table successfully'
	END	

	CREATE TABLE Orders (
		Id INT NOT NULL IDENTITY(1,1),
		UserId INT NOT NULL,
		CleanerId INT,
		OrderDate DATETIME,
		Days VARCHAR(20),
		PaymentSuccessful bit,
		PaymentMethod VARCHAR(100)

		CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED(Id),
		FOREIGN KEY(UserId) REFERENCES Users(Id),
		FOREIGN KEY(CleanerId) REFERENCES Cleaners(Id)
	)

	PRINT 'Created [Orders] table successfully'

COMMIT TRANSACTION
GO

BEGIN TRANSACTION
	IF OBJECT_ID('OrderDaysBooked', 'U') IS NOT NULL
	BEGIN
		DROP TABLE OrderDaysBooked
		PRINT 'Dropped [OrderDaysBooked] table successfully'
	END	

	CREATE TABLE OrderDaysBooked (
		Id INT NOT NULL,
		OrderId INT NOT NULL,
		CleanerId INT,
		Day VARCHAR(10),
		StartTime DATETIME,
		EndTime DATETIME,
		ActualHourlyRate FLOAT(2),
		
		CONSTRAINT PK_OrderDaysBooked PRIMARY KEY CLUSTERED(Id),
		FOREIGN KEY(OrderId) REFERENCES Orders(Id),
		FOREIGN KEY(CleanerId) REFERENCES Cleaners(Id)
	)
		
		PRINT 'Created [OrderDaysBooked] table successfully'

COMMIT TRANSACTION
GO

