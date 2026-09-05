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

    public CheckoutService(UserRepository userRepository, CartRepository cartRepository, CartItemRepository cartItemRepository, ProductRepository productRepository, OrderRepository orderRepository)
    {
        this.userRepository = userRepository;
        this.cartRepository = cartRepository;
        this.cartItemRepository = cartItemRepository;
        this.productRepository = productRepository;
        this.orderRepository = orderRepository;
    }

    @Transactional
    public CheckoutResponse checkout(String username, CheckoutRequest request)
    {
        // To find logged-in user
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        //Checks shipping address
        if (request.getShippingAddress() == null || request.getShippingAddress().trim().isEmpty())
        {
            throw new RuntimeException("Shipping address is required");
        }

        //Checks payment method
        if (request.getPaymentMethod() == null || request.getPaymentMethod().trim().isEmpty())
        {
            throw new RuntimeException("Payment method is required");
        }

        //Finds User's cart
        Cart cart = cartRepository.findByUserId(user.getId()).orElseThrow(() -> new RuntimeException("Cart not found"));

        //Gets cart item
        var cartItems = cartItemRepository.findByCartId(cart.getId());

        if (cartItems.isEmpty())
        {
            throw new RuntimeException("Your cart is empty");
        }

        Order order = new Order();

        order.setUser(user);

        order.setShippingAddress(request.getShippingAddress());

         //Stores the selected payment method
        order.setPaymentMethod(request.getPaymentMethod());

         //Set the initial order status
        order.setStatus("PLACED");

        double total = 0;

        for (CartItem cartItem : cartItems)
        {
            // Gets the Product associated with this CartItem
            Product product = cartItem.getProduct();

            int quantity = cartItem.getQuantity();

            if (product.getStockQuantity() < quantity)
            {
                throw new RuntimeException("Not enough stock for product: " + product.getName());
            }

            double subtotal = product.getPrice() * quantity;

            total += subtotal;

            OrderItem orderItem = new OrderItem();

             //Connects OrderItem to Order
            orderItem.setOrder(order);

             //Connects OrderItem to Product
            orderItem.setProduct(product);

             //Stores the quantity purchased
            orderItem.setQuantity(quantity);

            orderItem.setPrice(product.getPrice());

            order.getOrderItems().add(orderItem);

            product.setStockQuantity(product.getStockQuantity() - quantity);

            productRepository.save(product);
        }

         //Stores the calculated total in the Order
        order.setTotalAmount(total);

        Order savedOrder = orderRepository.save(order);

        //Clears the cart
        cartItemRepository.deleteAll(cartItems);

        return new CheckoutResponse(savedOrder.getId(), user.getId(), savedOrder.getTotalAmount(), savedOrder.getStatus(), savedOrder.getShippingAddress(), savedOrder.getPaymentMethod());
    }
}