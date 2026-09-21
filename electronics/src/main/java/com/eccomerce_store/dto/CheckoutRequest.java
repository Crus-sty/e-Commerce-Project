package com.eccomerce_store.dto;

// Contains the information required to create an order
public class CheckoutRequest
{
    private String shippingAddress;
    private String paymentMethod;

    public CheckoutRequest()
    {
    }

    public String getShippingAddress()
    {
        return shippingAddress;
    }

    public void setShippingAddress(String shippingAddress)
    {
        this.shippingAddress = shippingAddress;
    }

    public String getPaymentMethod()
    {
        return paymentMethod;
    }

    public void setPaymentMethod(String paymentMethod)
    {
        this.paymentMethod = paymentMethod;
    }
}