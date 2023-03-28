USE H1PD021123_Gruppe3;

CREATE TABLE Customers
(

    CustomerId            INT  NOT NULL,
    PersonID              INT FOREIGN KEY REFERENCES Persons(Id) NOT NULL,

    DateSinceLastPurchase DATE NOT NULL,

    PRIMARY KEY (CustomerId)
);
