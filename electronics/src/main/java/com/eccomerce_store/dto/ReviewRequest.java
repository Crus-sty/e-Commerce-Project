package com.eccomerce_store.dto;

public class ReviewRequest
{
    private Long productId;
    private int rating;
    private String comment;

    public ReviewRequest()
    {

    }

    // Getters and setters
    public Long getProductId()
    {
        return productId;
    }

    public void setProductId(Long productId)
    {
        this.productId = productId;
    }

    public int getRating()
    {
        return rating;
    }

    public void setRating(int rating)
    {
        this.rating = rating;
    }

    public String getComment()
    {
        return comment;
    }

    public void setComment(String comment)
    {
        this.comment = comment;
    }
}
