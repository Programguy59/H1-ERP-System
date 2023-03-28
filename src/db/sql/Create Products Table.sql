USE H1PD021123_Gruppe3;

CREATE TABLE Products
(
    Id            INT            NOT NULL IDENTITY(1,1),

    Name          VARCHAR(50)    NOT NULL,
    Description   VARCHAR(100)   NOT NULL,

    SalesPrice    DECIMAL(10, 2) NOT NULL,
    PurchasePrice DECIMAL(10, 2) NOT NULL,
    
    Location      CHAR(4)        NOT NULL,
    Stock         DECIMAL(10, 2) NOT NULL,

    Unit          VARCHAR(10)    NOT NULL,

    PRIMARY KEY (Id)
);
