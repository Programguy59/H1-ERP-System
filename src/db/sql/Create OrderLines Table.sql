USE H1PD021123_Gruppe3;

CREATE TABLE OrderLines
(
    Id        INT NOT NULL PRIMARY KEY IDENTITY(1,1),

    OrderId   INT NOT NULL,
    ProductId INT NOT NULL,

    Quantity  INT NOT NULL,

    FOREIGN KEY (ProductId) REFERENCES Products (Id)
);
