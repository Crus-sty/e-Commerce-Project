package com.eccomerce_store.controller;

import com.eccomerce_store.dto.CheckoutRequest;
import com.eccomerce_store.dto.CheckoutResponse;
import com.eccomerce_store.service.CheckoutService;

import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

// Controller responsible for creating an order after payment
@RestController
@RequestMapping("/api/checkout")
@CrossOrigin
public class CheckoutController
{
    private final CheckoutService checkoutService;

    public CheckoutController(CheckoutService checkoutService)
    {
        this.checkoutService = checkoutService;
    }

    // POST /api/checkout
    @PostMapping
    public ResponseEntity<?> checkout(
            @RequestBody CheckoutRequest request,
            Authentication authentication)
    {
        try
        {
            // Get the logged-in user's username from JWT
            String username = authentication.getName();

            // Create the order
            CheckoutResponse response =
                    checkoutService.checkout(username, request);

            return ResponseEntity.ok(response);
        }
        catch (RuntimeException e)
        {
            return ResponseEntity
                    .badRequest()
                    .body(e.getMessage());
        }
    }
}