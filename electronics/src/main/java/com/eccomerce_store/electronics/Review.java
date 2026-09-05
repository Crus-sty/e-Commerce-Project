package com.eccomerce_store.electronics;

import jakarta.persistence.*;

 //@Entity tells JPA that Review represents a database table
@Entity

@Table(name = "reviews", uniqueConstraints = {@UniqueConstraint(columnNames = {"user_id", "product_id"})})
public class Review
 {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne


    @JoinColumn(name = "user_id", nullable = false)
    private User user;

    @ManyToOne

    @JoinColumn(name = "product_id", nullable = false)
    private Product product;

    @Column(nullable = false)
    private int rating;

    @Column(nullable = false)
    private String comment;

    public Review()
    {
    }


    // Getters and Setters
    public Long getId()
    {
        return id;
    }

    public User getUser()
    {
        return user;
    }

    public void setUser(User user)
    {
        this.user = user;
    }

    public Product getProduct()
    {
        return product;
    }

    public void setProduct(Product product)
    {
        this.product = product;
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
