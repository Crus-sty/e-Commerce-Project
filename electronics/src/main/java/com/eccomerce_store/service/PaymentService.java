package com.eccomerce_store.service;

import com.eccomerce_store.dto.PaymentRequest;
import com.eccomerce_store.dto.PaymentResponse;

import org.springframework.stereotype.Service;

import java.util.UUID;

// Service responsible for processing payments
@Service
public class PaymentService
{
    public PaymentResponse processPayment(
            PaymentRequest request,
            double amount)
    {
        // Check payment request
        if (request == null)
        {
            return new PaymentResponse(
                    false,
                    "Payment information is required.",
                    null,
                    null,
                    amount
            );
        }

        String cardNumber = request.getCardNumber();

        if (cardNumber == null)
        {
            return new PaymentResponse(
                    false,
                    "Card number is required.",
                    null,
                    null,
                    amount
            );
        }

        cardNumber = cardNumber.replaceAll("\\s+", "");


        // Basic card number validation
        if (!cardNumber.matches("\\d{13,19}"))
        {
            return new PaymentResponse(
                    false,
                    "Invalid card number.",
                    null,
                    null,
                    amount
            );
        }


        // Luhn validation
        if (!isValidLuhn(cardNumber))
        {
            return new PaymentResponse(
                    false,
                    "Invalid card number.",
                    null,
                    null,
                    amount
            );
        }


        // Validate amount
        if (amount <= 0)
        {
            return new PaymentResponse(
                    false,
                    "Payment amount must be greater than zero.",
                    null,
                    null,
                    amount
            );
        }


        // Last four digits
        String lastFourDigits =
                cardNumber.substring(cardNumber.length() - 4);


        // Simulated transaction ID
        String transactionId =
                "TXN-" +
                        UUID.randomUUID()
                                .toString()
                                .substring(0, 8)
                                .toUpperCase();


        return new PaymentResponse(
                true,
                "Payment successful.",
                transactionId,
                lastFourDigits,
                amount
        );
    }


    // Luhn algorithm
    private boolean isValidLuhn(String cardNumber)
    {
        int sum = 0;
        boolean doubleDigit = false;

        for (int i = cardNumber.length() - 1;
             i >= 0;
             i--)
        {
            int digit =
                    Character.getNumericValue(
                            cardNumber.charAt(i));

            if (doubleDigit)
            {
                digit *= 2;

                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;

            doubleDigit = !doubleDigit;
        }

        return sum % 10 == 0;
    }
}