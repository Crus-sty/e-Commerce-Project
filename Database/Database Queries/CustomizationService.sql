CREATE TABLE CustomizationService(
	ServiceID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    CategoryID INT NOT NULL,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    ExtraCost DECIMAL(7,2) NOT NULL,
    
    FOREIGN KEY(CategoryID) REFERENCES Category(CategoryID)
);

SELECT * FROM CustomizationService;

INSERT INTO CustomizationService
	(CategoryID, Name, Description, ExtraCost)
VALUES
	('1', 'Test Service', 'This is a Test CustomizationService', '0');