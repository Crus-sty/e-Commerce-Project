package com.eccomerce_store.controller;
import com.eccomerce_store.dto.CheckoutRequest;
import com.eccomerce_store.dto.CheckoutResponse;
import com.eccomerce_store.service.CheckoutService;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

//Controller responsible for handling checkout requests
@RestController
@RequestMapping("/api/checkout")
@CrossOrigin
public class CheckoutController
{
    private final CheckoutService checkoutService;

    //Constructor injection for CheckoutService
    public CheckoutController(CheckoutService checkoutService)
    {
        this.checkoutService = checkoutService;
    }

    // Processes a customer's checkout Endpoint: POST /api/checkout
    @PostMapping
    public ResponseEntity<?> checkout( @RequestBody CheckoutRequest request, Authentication authentication)
    {
        try
        {
            // Get the username of the currently logged-in user
            String username = authentication.getName();

            // Send the checkout request to the service
            CheckoutResponse response = checkoutService.checkout(username, request);

            // Return successful checkout response
            return ResponseEntity.ok(response);
        } catch (RuntimeException e)
        {
            // Return an error if checkout fails
            return ResponseEntity .badRequest() .body(e.getMessage());
        }
    }
}
