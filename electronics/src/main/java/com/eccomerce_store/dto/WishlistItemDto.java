package com.eccomerce_store.dto;


public class WishlistItemDto {

    private Long productId;
    private String productName;
    private String productImage;
    private Double price;
    private Integer stockQuantity;

    public WishlistItemDto() { }

    public WishlistItemDto(
            Long productId,
            String productName,
            String productImage,
            Double price,
            Integer stockQuantity
    ) {
        this.productId = productId;
        this.productName = productName;
        this.productImage = productImage;
        this.price = price;
        this.stockQuantity = stockQuantity;
    }

    public Long getProductId() {
        return productId;
    }

    public void setProductId(Long productId) {
        this.productId = productId;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public String getProductImage() {
        return productImage;
    }

    public void setProductImage(String productImage) {
        this.productImage = productImage;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public Integer getStockQuantity() {
        return stockQuantity;
    }

    public void setStockQuantity(Integer stockQuantity) {
        this.stockQuantity = stockQuantity;
    }
}