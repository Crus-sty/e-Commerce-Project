CREATE TABLE Payment(
	PaymentID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    OrderID INT NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    PaymentStatus VARCHAR(50) NOT NULL,
    PaymentDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    
    FOREIGN KEY(OrderID) REFERENCES User_Order(OrderID)
);

SELECT * FROM Payment;

INSERT INTO Payment
	(OrderID, PaymentMethod, PaymentStatus)
VALUES
	('1', 'Test Method', 'Testing');