package com.eccomerce_store.dto;

//Contains all information required when checking out
public class CheckoutRequest
{
    // Customer delivery address
    private String shippingAddress;

    private String paymentMethod;

    // Card information used for payment processing
    private String cardNumber;
    private String expiryMonth;
    private String expiryYear;
    private String cvv;

    public CheckoutRequest()
    {

    }

    //Getters and Setters
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

    public String getCardNumber() {
        return cardNumber;
    }

    public void setCardNumber(String cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public String getExpiryMonth()
    {
        return expiryMonth;
    }

    public void setExpiryMonth(String expiryMonth)
    {
        this.expiryMonth = expiryMonth;
    }

    public String getExpiryYear()
    {
        return expiryYear;
    }

    public void setExpiryYear(String expiryYear)
    {
        this.expiryYear = expiryYear;
    }

    public String getCvv()
    {
        return cvv;
    }

    public void setCvv(String cvv)
    {
        this.cvv = cvv;
    }
}
