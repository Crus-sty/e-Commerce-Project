package com.eccomerce_store.dto;

public class ReviewResponse
{
    private Long id;
    private Long userId;
    private String username;
    private Long productId;
    private String productName;
    private int rating;
    private String comment;

    public ReviewResponse()
    {

    }

    public ReviewResponse(Long id, Long userId, String username, Long productId, String productName, int rating, String comment)
    {

        this.id = id;
        this.userId = userId;
        this.username = username;
        this.productId = productId;
        this.productName = productName;
        this.rating = rating;
        this.comment = comment;
    }

    // Getters and setters
    public Long getId()
    {
        return id;
    }

    public Long getUserId()
    {
        return userId;
    }

    public String getUsername()
    {
        return username;
    }

    public Long getProductId()
    {
        return productId;
    }

    public String getProductName()
    {
        return productName;
    }

    public int getRating()
    {
        return rating;
    }

    public String getComment()
    {
        return comment;
    }
}
