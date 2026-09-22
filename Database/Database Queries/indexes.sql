-- USER INDEXES
CREATE INDEX idx_user_role
ON User(Role);

-- CATEGORY INDEXES
CREATE INDEX idx_category_name
ON Category(CategoryName);

-- PRODUCT INDEXES
CREATE INDEX idx_product_category
ON Product(CategoryID);

CREATE INDEX idx_product_brand
ON Product(Brand); -- For filtering

CREATE INDEX idx_product_price
ON Product(Price); -- For filtering and sorting

CREATE INDEX idx_product_stock
ON Product(StockQuantity);

-- CART INDEXES
CREATE INDEX idx_cart_user
ON Cart(UserID);

-- CART ITEM INDEXES
CREATE INDEX idx_cartitem_cart
ON CartItem(CartID);

CREATE INDEX idx_cartitem_product
ON CartItem(ProductID);

-- ORDER INDEXES
CREATE INDEX idx_order_user
ON User_Order(UserID);

CREATE INDEX idx_order_date
ON User_Order(Order_Date);

CREATE INDEX idx_order_status
ON User_Order(Status);

-- ORDER ITEM INDEXES
CREATE INDEX idx_orderitem_order
ON OrderItem(OrderID);

CREATE INDEX idx_orderitem_product
ON OrderItem(ProductID);

-- WISHLIST INDEXES
CREATE INDEX idx_wishlist_user
ON Wishlist(UserID);

-- WISHLIST ITEM INDEXES
CREATE INDEX idx_wishlistitem_product
ON WishlistItem(ProductID);

CREATE INDEX idx_wishlistitem_wishlist
ON WishlistItem(WishlistID);

-- CUSTOMIZATION SERVICE INDEXES
CREATE INDEX idx_service_category
ON CustomizationService(CategoryID);

-- PAYMENT INDEXES
CREATE INDEX idx_payment_order
ON Payment(OrderID);

CREATE INDEX idx_payment_status
ON Payment(PaymentStatus);

-- SPECIFICATION INDEXES
CREATE INDEX idx_specification_product
ON Specification(ProductID);

-- REVIEW INDEXES
CREATE INDEX idx_review_product
ON Review(ProductID);

CREATE INDEX idx_review_user
ON Review(UserID);

CREATE INDEX idx_review_rating
ON Review(Rating);