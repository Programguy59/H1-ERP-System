USE H1PD021123_Gruppe3;

CREATE TABLE Companies
(
    Id           INT         NOT NULL IDENTITY(1,1),
    CompanyName  VARCHAR(50) NOT NULL,

    StreetName   VARCHAR(50) NOT NULL,
    StreetNumber VARCHAR(10) NOT NULL,
    ZipCode      VARCHAR(10) NOT NULL,
    City         VARCHAR(50) NOT NULL,
    Country      VARCHAR(50) NOT NULL,

    Currency     VARCHAR(3) NOT NULL, -- ISO 4217

    PRIMARY KEY (Id)
);
