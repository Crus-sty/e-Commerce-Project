package com.eccomerce_store.dto;

public class ReviewResponse
{
    private Long ID;
    private Long userID;
    private String username;
    private Long productID;
    private String productName;
    private int rating;
    private String comment;

    public ReviewResponse()
    {

    }

    public ReviewResponse(Long ID, Long userID, String username, Long productID, String productName, int rating, String comment)
    {

        this.ID = ID;
        this.userID = userID;
        this.username = username;
        this.productID = productID;
        this.productName = productName;
        this.rating = rating;
        this.comment = comment;
    }

    // Getters and setters
    public Long getID()
    {
        return ID;
    }

    public Long getUserID()
    {
        return userID;
    }

    public String getUsername()
    {
        return username;
    }

    public Long getProductID()
    {
        return productID;
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
