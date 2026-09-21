package com.eccomerce_store.electronics;

import jakarta.persistence.*;

 // This class represents one product inside an order
@Entity

@Table(name = "orderitem")
public class OrderItem
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne

    @JoinColumn(name = "OrderID", nullable = false)
    private Order order;

    @ManyToOne

    @JoinColumn(name = "productID", nullable = false)
    private Product product;

    @Column(name="Quantity",nullable = false)
    private int quantity;

    @Column(name="UnitPrice",nullable = false)
    private double price;

    public OrderItem()
    {
    }

    // Getters and Setters
    public Long getId()
    {
        return id;
    }

    public Order getOrder()
    {
        return order;
    }

    public void setOrder(Order order)
    {
        this.order = order;
    }

    public Product getProduct()
    {
        return product;
    }

    public void setProduct(Product product)
    {
        this.product = product;
    }

    public int getQuantity()
    {
        return quantity;
    }

    public void setQuantity(int quantity)
    {
        this.quantity = quantity;
    }

    public double getPrice()
    {
        return price;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }
}
