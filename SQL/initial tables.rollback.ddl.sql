USE Brighters
GO

IF OBJECT_ID('OrderDaysBooked', 'U') IS NOT NULL
BEGIN
	DROP TABLE OrderDaysBooked
	PRINT 'Dropped [OrderDaysBooked] table successfully'
END	

IF OBJECT_ID('Orders', 'U') IS NOT NULL
BEGIN
	DROP TABLE Orders
	PRINT 'Dropped [Orders] table successfully'
END	

IF OBJECT_ID('CleanerAvailability', 'U') IS NOT NULL
BEGIN
	DROP TABLE CleanerAvailability
	PRINT 'Dropped [CleanerAvailability] table successfully'
END	


IF OBJECT_ID('Cleaners', 'U') IS NOT NULL
BEGIN
	DROP TABLE Cleaners
	PRINT 'Dropped [Cleaners] table successfully'
END

IF OBJECT_ID('Users', 'U') IS NOT NULL
BEGIN
	DROP TABLE Users
	PRINT 'Dropped [Users] table successfully'
END