CREATE TABLE OrderItem(
	OrderItemID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL,
    
    FOREIGN KEY(OrderID) REFERENCES User_Order(OrderID),
    FOREIGN KEY(ProductID) REFERENCES Product(ProductID)
);

SELECT * FROM OrderItem;

INSERT INTO OrderItem
	(OrderID, ProductID, Quantity, UnitPrice)
VALUES
	('2', '27', '1', '1899.99');