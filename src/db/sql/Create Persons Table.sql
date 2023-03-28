USE H1PD021123_Gruppe3;

CREATE TABLE Persons
(

    Id           INT         NOT NULL,

    FirstName    VARCHAR(50) NOT NULL,
    LastName     VARCHAR(50) NOT NULL,

    Email        varchar(50) NOT NULL,
    PhoneNumber  varchar(16) NOT NULL,

    StreetName   VARCHAR(50) NOT NULL,
    StreetNumber VARCHAR(10) NOT NULL,
    ZipCode      VARCHAR(10) NOT NULL,
    City         VARCHAR(50) NOT NULL,
    Country      VARCHAR(50) NOT NULL,

    PRIMARY KEY (Id)
);
