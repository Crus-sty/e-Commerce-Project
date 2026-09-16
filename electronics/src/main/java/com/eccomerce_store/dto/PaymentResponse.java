package com.eccomerce_store.dto;

//Response returned after payment processing
public class PaymentResponse
{
    private boolean success;
    private String message;
    private String transactionId;
    private String CardNo;
    private double amount;

    public PaymentResponse()
    {

    }

    public PaymentResponse(boolean success, String message, String transactionId, String CardNo, double amount)
    {
        this.success = success;
        this.message = message;
        this.transactionId = transactionId;
        this.CardNo = CardNo;
        this.amount = amount;
    }

    //Getters and Setters
    public boolean isSuccess()
    {
        return success;
    }

    public void setSuccess(boolean success)
    {
        this.success = success;
    }

    public String getMessage()
    {
        return message;
    }

    public void setMessage(String message)
    {
        this.message = message;
    }

    public String getTransactionId()
    {
        return transactionId;
    }

    public void setTransactionId(String transactionId)
    {
        this.transactionId = transactionId;
    }

    public String getCardNo()
    {
        return CardNo;
    }

    public void setCardNo(String cardno)
    {
        this.CardNo = cardno;
    }

    public double getAmount()
    {
        return amount;
    }

    public void setAmount(double amount)
    {
        this.amount = amount;
    }
}
