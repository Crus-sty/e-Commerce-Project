package com.eccomerce_store.dto;

public class CheckoutResponse
{
    private Long orderId;
    private Long userId;
    private double totalAmount;
    private String status;
    private String shippingAddress;
    private String paymentMethod;

    public CheckoutResponse()
    {
    }

    public CheckoutResponse(Long orderId, Long userId, double totalAmount, String status, String shippingAddress, String paymentMethod)
    {
        this.orderId = orderId;
        this.userId = userId;
        this.totalAmount = totalAmount;
        this.status = status;
        this.shippingAddress = shippingAddress;
        this.paymentMethod = paymentMethod;
    }

    // Getters and setters
    public Long getOrderId()
    {
        return orderId;
    }

    public Long getUserId()
    {
        return userId;
    }

    public double getTotalAmount()
    {
        return totalAmount;
    }

    public String getStatus()
    {
        return status;
    }

    public String getShippingAddress()
    {
        return shippingAddress;
    }

    public String getPaymentMethod()
    {
        return paymentMethod;
    }
}