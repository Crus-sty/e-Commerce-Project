package com.eccomerce_store.service;

import com.eccomerce_store.dto.CheckoutRequest;
import com.eccomerce_store.dto.CheckoutResponse;
import com.eccomerce_store.dto.PaymentRequest;
import com.eccomerce_store.dto.PaymentResponse;
import com.eccomerce_store.electronics.Cart;
import com.eccomerce_store.electronics.CartItem;
import com.eccomerce_store.electronics.Order;
import com.eccomerce_store.electronics.OrderItem;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.CartItemRepository;
import com.eccomerce_store.repository.CartRepository;
import com.eccomerce_store.repository.OrderRepository;
import com.eccomerce_store.repository.ProductRepository;
import com.eccomerce_store.repository.UserRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class CheckoutService
{
    private final PaymentService paymentService;

    private final UserRepository userRepository;

    private final CartRepository cartRepository;

    private final CartItemRepository cartItemRepository;

    private final ProductRepository productRepository;

    private final OrderRepository orderRepository;

    public CheckoutService(UserRepository userRepository, CartRepository cartRepository, CartItemRepository cartItemRepository, ProductRepository productRepository, OrderRepository orderRepository, PaymentService paymentService)
    {
        this.userRepository = userRepository;
        this.cartRepository = cartRepository;
        this.cartItemRepository = cartItemRepository;
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
        this.paymentService = paymentService;
    }

    @Transactional
    public CheckoutResponse checkout(String username, CheckoutRequest request)
    {
        //Finds the logged-in user
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        if (request.getShippingAddress() == null || request.getShippingAddress().trim().isEmpty())
        {
            throw new RuntimeException("Shipping address is required");
        }

        if (request.getPaymentMethod() == null || request.getPaymentMethod().trim().isEmpty())
        {
            throw new RuntimeException("Payment method is required");
        }

        //Finds the user's cart
        Cart cart = cartRepository.findByUserId(user.getId()).orElseThrow(() -> new RuntimeException("Cart not found"));

        //Gets cart items
        var cartItems = cartItemRepository.findByCartId(cart.getId());

        if (cartItems.isEmpty())
        {
            throw new RuntimeException("Your cart is empty");
        }

        //Calculates the order total
        double total = 0;

        for (CartItem cartItem : cartItems)
        {
            Product product = cartItem.getProduct();

            int quantity = cartItem.getQuantity();

            // Checks stock before payment
            if (product.getStockQuantity() < quantity)
            {
                throw new RuntimeException("Not enough stock for product: " + product.getName());
            }

            double subtotal = product.getPrice() * quantity;

            total += subtotal;
        }

        //Creates PaymentRequest
        PaymentRequest paymentRequest = new PaymentRequest();

        paymentRequest.setCardNumber(request.getCardNumber());

        paymentRequest.setExpiryMonth(request.getExpiryMonth());

        paymentRequest.setExpiryYear(request.getExpiryYear());

        paymentRequest.setCvv(request.getCvv());

        PaymentResponse paymentResponse = paymentService.processPayment(paymentRequest, total);

        //Checks whether payment succeeded
        if (!paymentResponse.isSuccess())
        {
            throw new RuntimeException("Payment failed: " + paymentResponse.getMessage());
        }

        //Creates the order
        Order order = new Order();

        order.setUser(user);

        order.setShippingAddress(request.getShippingAddress());

        order.setPaymentMethod(request.getPaymentMethod());

        order.setStatus("PLACED");

        order.setTotalAmount(total);

        // Creates OrderItems
        for (CartItem cartItem : cartItems)
        {
            Product product = cartItem.getProduct();

            int quantity = cartItem.getQuantity();


            OrderItem orderItem = new OrderItem();

            orderItem.setOrder(order);

            orderItem.setProduct(product);

            orderItem.setQuantity(quantity);

            orderItem.setPrice(product.getPrice());


            order.getOrderItems().add(orderItem);

            // Reduce product stock
            product.setStockQuantity(product.getStockQuantity() - quantity);

            productRepository.save(product);
        }

        Order savedOrder = orderRepository.save(order);

        cartItemRepository.deleteAll(cartItems);

        return new CheckoutResponse(savedOrder.getId(), user.getId(), savedOrder.getTotalAmount(), savedOrder.getStatus(), savedOrder.getShippingAddress(), savedOrder.getPaymentMethod());
    }
}