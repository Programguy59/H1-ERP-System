USE H1PD021123_Gruppe3;

CREATE TABLE OrderLines
(
    Id        INT           NOT NULL IDENTITY(1,1),
    
    OrderId   INT           NOT NULL,
    ProductId INT           NOT NULL,
    Quantity  DECIMAL(10,2) NOT NULL,
    
    PRIMARY KEY (Id),
    
    FOREIGN KEY (ProductId) 
        REFERENCES Products (Id) ON DELETE CASCADE,
    FOREIGN KEY (OrderId) 
        REFERENCES Orders (Id)   ON DELETE CASCADE
);

CREATE TABLE Orders
(
    Id          INT         NOT NULL PRIMARY KEY IDENTITY(1,1),

    CreatedAt   DATETIME    DEFAULT CURRENT_TIMESTAMP,
    CompletedAt DATETIME,
    
    CustomerId  INT         NOT NULL,

    OrderStatus VARCHAR(16) NOT NULL,

    FOREIGN KEY (CustomerId) 
        REFERENCES Customers (Id) ON DELETE CASCADE
);
