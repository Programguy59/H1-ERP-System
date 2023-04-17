USE H1PD021123_Gruppe3;

CREATE TABLE Companies
(
    Id           INT         NOT NULL IDENTITY(1,1),
    CompanyName  VARCHAR(50) NOT NULL,
    
    AddressId    INT         NOT NULL,

    Currency     VARCHAR(3)  NOT NULL, -- ISO 4217

    PRIMARY KEY (Id),
    
    FOREIGN KEY (AddressId) 
        REFERENCES Addresses(Id) ON DELETE CASCADE,
);
