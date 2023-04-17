USE H1PD021123_Gruppe3;

CREATE TABLE Customers
(
    Id                    INT NOT NULL IDENTITY(1,1),
    PersonId              INT NOT NULL,
    
    DateSinceLastPurchase DATE NOT NULL,
    
    PRIMARY KEY (Id),
    
    FOREIGN KEY (PersonId) 
        REFERENCES Persons(Id) ON DELETE CASCADE
);
