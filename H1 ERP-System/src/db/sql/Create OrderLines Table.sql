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
