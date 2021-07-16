CREATE DATABASE CerberusDB
GO

USE CerberusDB
GO

CREATE TABLE PrintingHouses 
(
	PrintingHouseName VARCHAR(60) PRIMARY KEY NOT NULL,
	PrintingHouseAddress VARCHAR(50) NOT NULL,
	MaxEdition INT NOT NULL
)
GO

CREATE TABLE Newspapers
(
	NewspaperName VARCHAR(60) PRIMARY KEY NOT NULL,
	NewspaperIndex VARCHAR(30) UNIQUE NOT NULL,
	EditorSecondName VARCHAR(45) NOT NULL,
	EditorFirstName VARCHAR(30) NOT NULL,
	EditorLastName VARCHAR(45) NOT NULL,
	SubPrice FLOAT NOT NULL
)
GO

CREATE TABLE PostOffices
(
	_id INT IDENTITY(1, 1) PRIMARY KEY,
	PostOfficeName VARCHAR(60) NOT NULL,
	PhoneNumber VARCHAR(12) NOT NULL,
	PostOfficeAddress VARCHAR(50) UNIQUE NOT NULL
)
GO

CREATE TABLE PrintingNewspapers 
(
	_id INT IDENTITY(1, 1) PRIMARY KEY,
	PrintingHouseName VARCHAR(60) FOREIGN KEY REFERENCES PrintingHouses(PrintingHouseName) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	NewspaperName VARCHAR(60) FOREIGN KEY REFERENCES Newspapers(NewspaperName) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	Edition FLOAT NOT NULL
)
GO

CREATE TABLE DeliveriesPostOffices
(
	_id INT IDENTITY(1, 1) PRIMARY KEY,
	_idPrintingNewspapers INT FOREIGN KEY REFERENCES PrintingNewspapers(_id) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
	_idPostOffices INT FOREIGN KEY REFERENCES PostOffices(_id) NOT NULL
)
GO

INSERT INTO PrintingHouses(PrintingHouseName, PrintingHouseAddress, MaxEdition)
VALUES ('Питер', 'ул. Гончарова, 18', 50)

INSERT INTO Newspapers(NewspaperName, NewspaperIndex, EditorSecondName, EditorFirstName, EditorLastName, SubPrice)
VALUES ('Маяк', '5435354', 'Иванов', 'Иван', 'Иванович', 200)

INSERT INTO PostOffices(PostOfficeName, PhoneNumber, PostOfficeAddress)
VALUES ('Почта России', '643636', 'ул. Пушкина, д. 8')

INSERT INTO PrintingNewspapers(PrintingHouseName, NewspaperName, Edition)
VALUES ('Питер', 'Маяк', 5)

INSERT INTO DeliveriesPostOffices(_idPrintingNewspapers, _idPostOffices)
VALUES (1, 1)
GO