package com.eccomerce_store.dto;

import java.math.BigDecimal;
public class AdminOrderDto {

    private Long orderId;
    private String customerName;
    private int numberOfItems;
    private double totalAmount;
    private String status;

    public AdminOrderDto() {
    }

    public AdminOrderDto(
            Long orderId,
            String customerName,
            int numberOfItems,
            double totalAmount,
            String status) {

        this.orderId = orderId;
        this.customerName = customerName;
        this.numberOfItems = numberOfItems;
        this.totalAmount = totalAmount;
        this.status = status;
    }

    public Long getOrderId() {
        return orderId;
    }

    public void setOrderId(Long orderId) {
        this.orderId = orderId;
    }

    public String getCustomerName() {
        return customerName;
    }

    public void setCustomerName(String customerName) {
        this.customerName = customerName;
    }

    public int getNumberOfItems() {
        return numberOfItems;
    }

    public void setNumberOfItems(int numberOfItems) {
        this.numberOfItems = numberOfItems;
    }

    public double getTotalAmount() {
        return totalAmount;
    }

    public void setTotalAmount(double totalAmount) {
        this.totalAmount = totalAmount;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}