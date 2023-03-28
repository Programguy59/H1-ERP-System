USE H1PD021123_Gruppe3;

CREATE TABLE Orders
(
    Id          INT         NOT NULL PRIMARY KEY IDENTITY(1,1),

    CreatedAt   DATETIME DEFAULT CURRENT_TIMESTAMP,
    CompletedAt DATETIME,

    CustomerId  INT         NOT NULL,
    OrderLineId INT         NOT NULL,

    OrderStatus VARCHAR(16) NOT NULL,

    FOREIGN KEY (CustomerId) REFERENCES Customers (Id),
    FOREIGN KEY (OrderLineId) REFERENCES OrderLines (Id)
);
