CREATE TABLE Review(
	ReviewID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    UserID INT NOT NULL,
    ProductID INT NOT NULL,
    Rating TINYINT NOT NULL CHECK(Rating BETWEEN 1 AND 10),
    Comment VARCHAR(255) NOT NULL,
    ReviewDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    
    FOREIGN KEY(UserID) REFERENCES User(UserID),
    FOREIGN KEY(ProductID) REFERENCES Product(ProductID)
);

SELECT * FROM Review;

INSERT INTO Review
	(UserID, ProductID, Rating, Comment)
VALUES
	('1', '1', '10', 'This tested really well, total success :)');