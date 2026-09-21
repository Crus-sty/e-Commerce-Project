package com.eccomerce_store.controller;

import com.eccomerce_store.electronics.Order;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.OrderRepository;
import com.eccomerce_store.repository.UserRepository;

import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/orders")
@CrossOrigin
public class OrderController
{
    private final OrderRepository orderRepository;
    private final UserRepository userRepository;

    public OrderController(
            OrderRepository orderRepository,
            UserRepository userRepository)
    {
        this.orderRepository = orderRepository;
        this.userRepository = userRepository;
    }

    // Get all orders for the currently logged-in user
    @GetMapping("/my-orders")
    public ResponseEntity<?> getMyOrders(Authentication authentication)
    {
        try
        {
            String username = authentication.getName();

            User user = userRepository.findByUsername(username)
                    .orElseThrow(() -> new RuntimeException("User not found"));

            List<Order> orders = orderRepository.findByUserId(user.getId());

            return ResponseEntity.ok(orders);
        }
        catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }

    // Get one specific order
    @GetMapping("/{orderId}")
    public ResponseEntity<?> getOrder(
            @PathVariable Long orderId,
            Authentication authentication)
    {
        try
        {
            String username = authentication.getName();

            User user = userRepository.findByUsername(username)
                    .orElseThrow(() -> new RuntimeException("User not found"));

            Order order = orderRepository.findById(orderId)
                    .orElseThrow(() -> new RuntimeException("Order not found"));

            // Make sure the user can only view their own orders
            if (!order.getUser().getId().equals(user.getId()))
            {
                return ResponseEntity.status(403)
                        .body("You are not allowed to view this order.");
            }

            return ResponseEntity.ok(order);
        }
        catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }
}