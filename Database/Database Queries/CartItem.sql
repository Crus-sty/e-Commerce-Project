CREATE TABLE CartItem(
	CartItemID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    CartID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    
    FOREIGN KEY(CartID) REFERENCES Cart(CartID),
    FOREIGN KEY(ProductID) REFERENCES Product(ProductID)
);

SELECT * FROM CartItem;

INSERT INTO CartItem
	(CartID, ProductID, Quantity)
VALUES
	('1', '1', '0');