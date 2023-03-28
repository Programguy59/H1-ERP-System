USE H1PD021123_Gruppe3;

CREATE TABLE Orders
(
    OrderId     INT         NOT NULL PRIMARY KEY,

    CreatedAt   DATETIME DEFAULT CURRENT_TIMESTAMP,
    CompletedAt DATETIME,

    CustomerId  INT         NOT NULL,

    OrderStatus VARCHAR(16) NOT NULL,

    OrderLineId INT         NOT NULL,

    FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
    FOREIGN KEY (OrderLineId) REFERENCES OrderLines (Id)
);
