USE H1PD021123_Gruppe3;

CREATE TABLE Persons
(
    Id           INT         NOT NULL IDENTITY(1,1),
    AddressId    INT         NOT NULL,
    
    FirstName    VARCHAR(50) NOT NULL,
    LastName     VARCHAR(50) NOT NULL,

    Email        varchar(50) NOT NULL,
    PhoneNumber  varchar(16) NOT NULL,
    
    PRIMARY KEY (Id),
    
    FOREIGN KEY (AddressId) 
        REFERENCES Addresses(Id) ON DELETE CASCADE
);
