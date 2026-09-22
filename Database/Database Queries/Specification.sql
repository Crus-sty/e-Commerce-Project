CREATE TABLE Specification(
	SpecificationID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    ProductID INT NOT NULL,
    Name VARCHAR(50) NOT NULL,
    Spec_Value VARCHAR(50) NOT NULL, 
    
    FOREIGN KEY(ProductID) REFERENCES Product(ProductID)
);

SELECT * FROM Specification;

INSERT INTO Specification
	(ProductID, Name, Spec_Value)
VALUES
	('1', 'Test Specification', '0.00');