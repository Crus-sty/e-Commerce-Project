package com.eccomerce_store.service;

import com.eccomerce_store.dto.CheckoutRequest;
import com.eccomerce_store.dto.CheckoutResponse;
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
    private final UserRepository userRepository;
    private final CartRepository cartRepository;
    private final CartItemRepository cartItemRepository;
    private final ProductRepository productRepository;
    private final OrderRepository orderRepository;

    public CheckoutService(
            UserRepository userRepository,
            CartRepository cartRepository,
            CartItemRepository cartItemRepository,
            ProductRepository productRepository,
            OrderRepository orderRepository)
    {
        this.userRepository = userRepository;
        this.cartRepository = cartRepository;
        this.cartItemRepository = cartItemRepository;
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
    }

    @Transactional
    public CheckoutResponse checkout(
            String username,
            CheckoutRequest request)
    {

        // FIND LOGGED-IN USER
        User user = userRepository
                .findByUsername(username)
                .orElseThrow(() ->
                        new RuntimeException("User not found"));



        //  VALIDATE SHIPPING ADDRESS


        if (request == null)
        {
            throw new RuntimeException("Checkout information is required");
        }

        if (request.getShippingAddress() == null ||
                request.getShippingAddress().trim().isEmpty())
        {
            throw new RuntimeException("Shipping address is required");
        }


        //  VALIDATE PAYMENT METHOD


        if (request.getPaymentMethod() == null ||
                request.getPaymentMethod().trim().isEmpty())
        {
            throw new RuntimeException("Payment method is required");
        }



        //  FIND USER CART


        Cart cart = cartRepository
                .findByUserId(user.getId())
                .orElseThrow(() ->
                        new RuntimeException("Cart not found"));



        // GET CART ITEMS


        var cartItems =
                cartItemRepository.findByCartId(cart.getId());

        if (cartItems.isEmpty())
        {
            throw new RuntimeException("Your cart is empty");
        }

        //  CALCULATE SUBTOTAL
        double subtotal = 0;

        for (CartItem cartItem : cartItems)
        {
            Product product = cartItem.getProduct();

            int quantity = cartItem.getQuantity();

            // Check stock
            if (product.getStockQuantity() < quantity)
            {
                throw new RuntimeException(
                        "Not enough stock for product: "
                                + product.getName());
            }

            double itemSubtotal =
                    product.getPrice() * quantity;

            subtotal += itemSubtotal;
        }

        // CALCULATE VAT

        double vat = subtotal * 0.15;

        // CALCULATE SHIPPING
        double shipping = subtotal > 0 ? 300.0 : 0.0;

        // CALCULATE FINAL TOTAL
        double total = subtotal + vat + shipping;



        //  CREATE ORDER


        Order order = new Order();

        order.setUser(user);

        order.setShippingAddress(
                request.getShippingAddress());

        order.setPaymentMethod(
                request.getPaymentMethod());

        order.setStatus("PLACED");

        order.setTotalAmount(total);



        // CREATE ORDER ITEMS


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


            // Reduce stock
            product.setStockQuantity(
                    product.getStockQuantity() - quantity);

            productRepository.save(product);
        }



        //  SAVE ORDER

        Order savedOrder =
                orderRepository.save(order);
        //  CLEAR CART

        cartItemRepository.deleteAll(cartItems);
        //  RETURN RESPONSE
        return new CheckoutResponse(
                savedOrder.getId(),
                user.getId(),
                savedOrder.getTotalAmount(),
                savedOrder.getStatus(),
                savedOrder.getShippingAddress(),
                savedOrder.getPaymentMethod()
        );
    }
}