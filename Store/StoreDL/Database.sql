CREATE TABLE Costumers(
	costumerId int PRIMARY KEY,
	costumerName varchar(50),
	costumerNumber varchar(50),
	costumerAddress varchar(50),
	costumerEmail varchar(50)
)

CREATE TABLE Products(
	productId int PRIMARY KEY,
	productName varchar(50),
	productPrice float,
	productDescription tinytext,
	productCategory varchar(50)
)

CREATE TABLE Stores(
	storeNumber int PRIMARY KEY,
	storeName varchar(50),
	storeAddress varchar(50)
)

CREATE TABLE Orders(
	orderNumber int PRIMARY KEY,
	orderStore varchar(50),
	orderPrice float
)