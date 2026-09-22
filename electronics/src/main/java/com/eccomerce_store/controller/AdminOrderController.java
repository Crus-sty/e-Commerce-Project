package com.eccomerce_store.controller;

import com.eccomerce_store.dto.AdminOrderDto;
import com.eccomerce_store.electronics.Order;
import com.eccomerce_store.repository.OrderRepository;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/admin/orders")
public class AdminOrderController {

    private final OrderRepository orderRepository;

    public AdminOrderController(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }

    // GET ALL ORDERS
    @GetMapping
    public List<AdminOrderDto> getAllOrders() {

        List<Order> orders =
                orderRepository.findAllWithUserAndItems();

        return orders.stream()
                .map(order -> {

                    String customerName = "Unknown Customer";

                    if (order.getUser() != null) {

                        String firstName =
                                order.getUser().getFirstName();

                        String lastName =
                                order.getUser().getLastName();

                        customerName =
                                (firstName == null ? "" : firstName)
                                        + " "
                                        + (lastName == null ? "" : lastName);

                        customerName = customerName.trim();
                    }

                    int numberOfItems = 0;

                    if (order.getOrderItems() != null) {
                        numberOfItems =
                                order.getOrderItems().size();
                    }

                    return new AdminOrderDto(
                            order.getId(),
                            customerName,
                            numberOfItems,
                            order.getTotalAmount(),
                            order.getStatus()
                    );
                })
                .toList();
    }

    // GET ONE ORDER
    @GetMapping("/{orderId}")
    public ResponseEntity<AdminOrderDto> getOrderById(
            @PathVariable Long orderId) {

        Optional<Order> optionalOrder =
                orderRepository.findById(orderId);

        if (optionalOrder.isEmpty()) {
            return ResponseEntity.notFound().build();
        }

        Order order = optionalOrder.get();

        String customerName = "Unknown Customer";

        if (order.getUser() != null) {

            String firstName =
                    order.getUser().getFirstName();

            String lastName =
                    order.getUser().getLastName();

            customerName =
                    (firstName == null ? "" : firstName)
                            + " "
                            + (lastName == null ? "" : lastName);

            customerName = customerName.trim();
        }

        int numberOfItems = 0;

        if (order.getOrderItems() != null) {
            numberOfItems =
                    order.getOrderItems().size();
        }

        AdminOrderDto dto =
                new AdminOrderDto(
                        order.getId(),
                        customerName,
                        numberOfItems,
                        order.getTotalAmount(),
                        order.getStatus()
                );

        return ResponseEntity.ok(dto);
    }
}