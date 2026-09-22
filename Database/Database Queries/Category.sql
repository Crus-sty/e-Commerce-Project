CREATE TABLE Category(
	CategoryID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    Description VARCHAR(255) NOT NULL
);

ALTER TABLE Category
ADD ImageURL VARCHAR(255);

SELECT * FROM Category;


INSERT INTO Category
	(CategoryName, Description)
VALUES
	('Test Category', 'This is a test category. We will not actually use it :)');