CREATE TABLE User_Order(
	OrderID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    UserID INT NOT NULL,
    Order_Date DATE NOT NULL DEFAULT (CURRENT_DATE),
    Status VARCHAR(50) NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    ShippingAddress VARCHAR(100) NOT NULL,
    
    FOREIGN KEY(UserID) REFERENCES User(UserID)
);

SELECT * FROM User_Order;
update user_order set totalamount = '1899.99' where orderid = '2';

INSERT INTO User_Order
	(UserID, Status, TotalAmount, ShippingAddress)
VALUES
	('2',  'Checking...', '99', 'Checking Lane');