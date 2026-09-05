package com.eccomerce_store.controller;
import com.eccomerce_store.dto.CheckoutRequest;
import com.eccomerce_store.dto.CheckoutResponse;
import com.eccomerce_store.service.CheckoutService;

import org.springframework.http.ResponseEntity;

import org.springframework.security.core.Authentication;

import org.springframework.web.bind.annotation.*;

 //@RestController tells Spring that this class handles REST API requests
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
    // Checkout
    @PostMapping
    public ResponseEntity<?> checkout(@RequestBody CheckoutRequest request, Authentication authentication)
    {
        try {

            String username = authentication.getName();

            CheckoutResponse response = checkoutService.checkout(username, request);

            return ResponseEntity.ok(response);

        } catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }
}
