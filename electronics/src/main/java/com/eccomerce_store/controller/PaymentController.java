package com.eccomerce_store.controller;

import com.eccomerce_store.dto.PaymentRequest;
import com.eccomerce_store.dto.PaymentResponse;
import com.eccomerce_store.service.PaymentService;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/payment")
@CrossOrigin
public class PaymentController
{
    private final PaymentService paymentService;

    public PaymentController(PaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    @PostMapping("/process")
    public ResponseEntity<PaymentResponse> processPayment(
            @RequestBody PaymentRequest request,
            @RequestParam double amount)
    {
        PaymentResponse response =
                paymentService.processPayment(request, amount);

        if (!response.isSuccess())
        {
            return ResponseEntity
                    .badRequest()
                    .body(response);
        }

        return ResponseEntity.ok(response);
    }
}