CREATE TABLE User (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Phone VARCHAR(20),
    Role ENUM('Customer', 'Admin') NOT NULL DEFAULT 'Customer',
    DateCreated DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

SELECT * FROM User;

INSERT INTO User
    (FirstName, LastName, Email, PasswordHash, Phone)
VALUES
    ('John', 'Doe', 'johndoe@gmail.com', 'Test123!', '0800000000');