CREATE TABLE WishlistItem(
	WishlistItemID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    ProductID INT NOT NULL,
    WishlistID INT NOT NULL,
    
    FOREIGN KEY(ProductID) REFERENCES Product(ProductID),
    FOREIGN KEY(WishlistID) REFERENCES Wishlist(WishlistID)
);

SELECT * FROM WishlistItem;

INSERT INTO WishlistItem
	(ProductID, WishlistID)
VALUES
	('1', '1');