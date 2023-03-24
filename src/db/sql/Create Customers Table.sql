USE H1PD021123_Gruppe3;
DROP TABLE Customers;
GO
CREATE TABLE Customers (
    
    CustomerId INT NOT NULL,
	PersonID INT FOREIGN KEY REFERENCES Persons(Id) NOT NULL,

	DateSinceLastPurchase Date NOT NULL,

    PRIMARY KEY (CustomerId)
	
);