CREATE TABLE Product(
	ProductID INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    CategoryID INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    Brand VARCHAR(50) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    ImageURL VARCHAR(255) NOT NULL,
    
    FOREIGN KEY(CategoryID) REFERENCES Category(CategoryID)
);

SELECT * FROM Product;
update product set discount = '0.5' where productid = '27';
update product set discount = '0.33' where productid = '33';

INSERT INTO Product
	(CategoryID, Name, Description, Brand, Price, StockQuantity, ImageURL, ImageURL2, ImageURL3)
VALUES
	('2', 'Corsair NAUTILUS 360 RS ARGB Liquid CPU Cooler', '360mm AIO – Low-Noise – Direct Motherboard Connection – Daisy-Chain – Intel LGA 1851/1700, AMD AM5/AM4 – 3x RS120 ARGB Fans Included – Black', 'Corsair', '3000.00', '25', 'https://m.media-amazon.com/images/I/510X4+092JL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/51u9DAh2AJL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/515+l0FREmL._AC_SX569_.jpg'),
    ('2', 'Patriot Memory Signature Line', '2GB 800MHz DDR2 DIMM Memory Module, Green', 'Patriot Memory', '500.00', '50', 'https://m.media-amazon.com/images/I/5179tDuracL._AC_SY450_.jpg', '', ''),
    ('4', 'Dell 27 Monitor', 'SE2725HM, Full HD (1920x1080), 100Hz, IPS, 5ms, VESA (100x100mm), HDMI, VGA, 3 Year Warranty, Black', 'Dell', '2700.00', '12', 'https://m.media-amazon.com/images/I/71mffiFrbDL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/71mnWk8d0uL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/71Jc8BspY3L._AC_SX569_.jpg'),
    ('4', 'Samsung Odyssey G5 QHD Gaming Monitor', 'Samsung Odyssey G55C QHD gaming monitor, featuring a 32-inch curved screen with a 1000R curvature, delivers an immersive viewing experience ideal for gaming and multimedia.', 'Samsung', '5000.00', '10', 'https://m.media-amazon.com/images/I/71cGqUHoDJL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/71QrBNpwhpL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/61pphxGUP6L._AC_SX569_.jpg'),
    ('7', 'Jabra Evolve2 85 Wireless Headset', 'Bluetooth - 10x Mic - ANC Active Noise Cancelling in Microphone & Headphones - Spatial Audio 40mm Speakers - 37hr Batt - 30m Range - Teams + Open Office - PC USB A', 'Jabra', '7000.00', '45', 'https://m.media-amazon.com/images/I/61gt7dO+6sL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/61H6Sa5RnWL._AC_SX569_.jpg', 'https://m.media-amazon.com/images/I/71js+Kj10CL._AC_SX569_.jpg'),
    ('7', 'Redragon Adiemus 2 X 3W RGB Usb Aux PC 2.0 Sound Bar Gaming Speaker', 'Touch Control Backlit, Audio-light Sync, 4 RGB Modes, 4w Output, 16in Wide, Soundbar for TV, Laptop And Smartphone, Black', 'Redragon', '449.99', '50', 'https://m.media-amazon.com/images/I/716toi4r3WL._AC_SL1500_.jpg', 'https://m.media-amazon.com/images/I/71FnsTXZDxL._AC_SY450_.jpg', 'https://m.media-amazon.com/images/I/71+LIICO+ZL._AC_SY450_.jpg'),
    ('8', 'Bestoss 256GB SSD Internal', 'TLC NAND Flash Storage; Supports PC, Laptop, NAS Systems; Faster Boot and File Transfer Speeds', 'Bestoss', '999.99', '65', 'https://m.media-amazon.com/images/I/71iGEGAOS4L._AC_SL1500_.jpg', '', ''),
    ('8', 'Seagate Expansion External Hard Drive', 'Seagate Expansion 2TB External Hard Drive offers a convenient and compact solution for expanding your storage on the go', 'Seagate', '2499.99', '35', 'https://m.media-amazon.com/images/I/814SDu24dnL._AC_SL1500_.jpg', 'https://m.media-amazon.com/images/I/51yOd1Lz-mL._AC_SL1500_.jpg', ''),
    ('9', 'TP-LINK ARCHER AX55 | AX3000 DUAL-BAND GIGABIT WI-FI 6 ROUTER', 'Achieves combined speeds up to 5400 Mbps—4804 Mbps on the 5 GHz band and 574 Mbps on the 2.4 GHz band—ideal for 8K streaming, gaming, and rapid downloads.', 'TP-Link', '1249.99', '44', 'https://m.media-amazon.com/images/I/51+Z5SWSFOL._AC_SL1000_.jpg', 'https://m.media-amazon.com/images/I/513jaSQpfeL._AC_SL1000_.jpg', 'https://m.media-amazon.com/images/I/61bbN1La4RL._AC_SL1000_.jpg'),
    ('9', 'TP-LINK OMADA SG2005P-PD | 5-PORT GIGABIT SMART SWITCH WITH 1-PORT POE++ IN AND 4-PORT POE+ OUT', 'Standard PoE Passthrough to double PoE source-to-device transmission distance from 100m to 200m without losing gigabit speeds, perfect for long-range surveillance cameras and access points.', 'TP-Link', '1799.99', '75', 'https://m.media-amazon.com/images/I/312OMr+CFFL._AC_SL1000_.jpg', 'https://m.media-amazon.com/images/I/41eUB75STgL._AC_SL1000_.jpg', 'https://m.media-amazon.com/images/I/411Jz8dNbSL._AC_SL1000_.jpg'),
    ('10', '25W PD Fast Charging USB-C Adapter', 'Stay powered up and ready to go with this 25W PD Fast Charging USB-C Adapter in sleek black', 'Generic', '99.99', '150', 'https://m.media-amazon.com/images/I/51nylcQG9OL._AC_SL1024_.jpg', 'https://m.media-amazon.com/images/I/411h2+X24VL._AC_.jpg', ''),
    ('10', 'Gizzu 1080P HDMI to VGA Adapter Poly', 'The Gizzu 1080P HDMI to VGA Adapter will enhance your viewing experience.', 'GIZZU', '49.99', '150', 'https://m.media-amazon.com/images/I/61oVg0LVmVL._AC_SL1500_.jpg', 'https://m.media-amazon.com/images/I/61ela8GtCPL._AC_SL1500_.jpg', 'https://m.media-amazon.com/images/I/614WTBDuD6L._AC_SL1500_.jpg'),
    ('11', 'Antec Gen5.0 ATX3.0 1000W Gold Fully Modular Power Supply', 'Antec Gen5.0 ATX3.0 1000W Gold Fully Modular Power Supply is designed with the ultimate performance and stability in mind for the gaming and enthusiast market.', 'Antec', '2999.99', '15', 'https://m.media-amazon.com/images/I/712OKn8XXyL._AC_SL1500_.jpg', '', '');
    
    
    
    
    
    
    
    
    
    
    
    
    