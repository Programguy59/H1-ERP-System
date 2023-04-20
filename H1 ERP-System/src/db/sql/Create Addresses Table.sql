USE H1PD021123_Gruppe3;

CREATE TABLE Addresses
(

    Id           INT IDENTITY (1,1),

    StreetName   VARCHAR(50) NOT NULL,
    StreetNumber VARCHAR(10) NOT NULL,

    ZipCode      VARCHAR(10) NOT NULL,
    City         VARCHAR(50) NOT NULL,

    Country      VARCHAR(50) NOT NULL,

    PRIMARY KEY (Id)
);
