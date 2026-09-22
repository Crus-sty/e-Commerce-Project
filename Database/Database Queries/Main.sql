CREATE DATABASE EcommerceDB;

USE EcommerceDB;

SHOW databases;

SHOW tables;

DESCRIBE payment;
DESCRIBE user_order;
DESCRIBE wishlist;
DESCRIBE orderitem;

SELECT * FROM cart;
SELECT * FROM cartitem;
SELECT * FROM category;
SELECT * FROM customizationservice;
SELECT * FROM orderitem;
SELECT * FROM payment;
SELECT * FROM product;
SELECT * FROM review;
SELECT * FROM specification;
SELECT * FROM user;
SELECT * FROM user_order;
SELECT * FROM wishlist;
SELECT * FROM wishlistitem;
DROP TABLE admin;
DROP TABLE orders;
DROP TABLE reviews;
DROP TABLE wishlist_items;

UPDATE product SET CategoryID = 11 WHERE CategoryID = 10;
ALTER TABLE user_order ADD COLUMN PaymentMethod VARCHAR(255);
ALTER TABLE user ADD COLUMN Role enum('Admin', 'Customer');

ALTER TABLE wishlist DROP COLUMN user_id;
DELETE FROM cartitem WHERE ProductID = 1;
ALTER TABLE user DROP COLUMN password_hash;
ALTER TABLE user DROP COLUMN user_name;

ALTER TABLE product MODIFY COLUMN Name VARCHAR(100) NOT NULL;
ALTER TABLE product MODIFY COLUMN Price DECIMAL(10,2) NOT NULL;