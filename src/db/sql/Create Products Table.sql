﻿USE H1PD021123_Gruppe3;

CREATE TABLE Products (
    
    Id INT NOT NULL,
    
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(100) NOT NULL,
    
    SalesPrice DECIMAL(10,2) NOT NULL,
    PurchasePrice DECIMAL(10,2) NOT NULL,
    
    Location VARCHAR(50) NOT NULL,
    Stock INT NOT NULL,
    
    Unit VARCHAR(10) NOT NULL,
    
    PRIMARY KEY (Id)
);
