package com.eccomerce_store.controller;

import com.eccomerce_store.dto.AddToCartRequest;
import com.eccomerce_store.electronics.Cart;
import com.eccomerce_store.electronics.CartItem;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.CartItemRepository;
import com.eccomerce_store.repository.CartRepository;
import com.eccomerce_store.repository.ProductRepository;
import com.eccomerce_store.repository.UserRepository;
import com.eccomerce_store.service.CartItemService;

import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.Map;

@RestController
@RequestMapping("/api/cart")
@CrossOrigin
public class CartController {

    private final CartRepository cartRepository;
    private final CartItemRepository cartItemRepository;
    private final ProductRepository productRepository;
    private final UserRepository userRepository;
    private final CartItemService cartItemService;

    public CartController(
            CartRepository cartRepository,
            CartItemRepository cartItemRepository,
            ProductRepository productRepository,
            UserRepository userRepository,
            CartItemService cartItemService) {

        this.cartRepository = cartRepository;
        this.cartItemRepository = cartItemRepository;
        this.productRepository = productRepository;
        this.userRepository = userRepository;
        this.cartItemService = cartItemService;
    }

    // ADD PRODUCT TO CART
    // POST /api/cart/add
    @PostMapping("/add")
    public ResponseEntity<?> addToCart(
            @RequestBody AddToCartRequest request,
            Authentication authentication) {

        // Validate quantity
        if (request.getQuantity() <= 0) {
            return ResponseEntity
                    .badRequest()
                    .body("Quantity must be greater than 0.");
        }

        // Get logged-in user
        String username = authentication.getName();
        User user = userRepository
                .findByUsername(username)
                .orElse(null);

        if (user == null) {
            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }

        // Find product
        Product product = productRepository
                .findById(request.getProductId())
                .orElse(null);

        if (product == null) {
            return ResponseEntity.notFound().build();
        }

        // Check stock
        if (product.getStockQuantity() < request.getQuantity()) {
            return ResponseEntity
                    .badRequest()
                    .body("Not enough stock available.");
        }

        // Find user's cart
        Cart cart = cartRepository
                .findByUserId(user.getId())
                .orElse(null);

        // Create cart if it doesn't exist
        if (cart == null) {
            cart = new Cart();
            cart.setUser(user);
            cart = cartRepository.save(cart);
        }

        // Check if product already exists in cart
        CartItem cartItem = cartItemRepository
                .findByCartIdAndProductId(
                        cart.getId(),
                        product.getId())
                .orElse(null);

        if (cartItem != null) {

            // Product already in cart — increase quantity
            int newQuantity = cartItem.getQuantity() + request.getQuantity();

            // Check stock again
            if (newQuantity > product.getStockQuantity()) {
                return ResponseEntity
                        .badRequest()
                        .body("Not enough stock available.");
            }

            cartItem.setQuantity(newQuantity);

        } else {

            // Create new cart item
            cartItem = new CartItem();
            cartItem.setCart(cart);
            cartItem.setProduct(product);
            cartItem.setQuantity(request.getQuantity());
        }

        cartItemRepository.save(cartItem);

        return ResponseEntity.ok("Product added to cart.");
    }

    // VIEW CART
    // GET /api/cart
    @GetMapping
    public ResponseEntity<?> getCart(Authentication authentication) {

        String username = authentication.getName();
        User user = userRepository
                .findByUsername(username)
                .orElse(null);

        if (user == null) {
            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }

        Cart cart = cartRepository
                .findByUserId(user.getId())
                .orElse(null);

        // Empty cart response
        if (cart == null) {
            Map<String, Object> emptyCart = new HashMap<>();
            emptyCart.put("items", new Object[0]);
            emptyCart.put("total", 0);
            return ResponseEntity.ok(emptyCart);
        }

        // Build cart response
        var items = cart.getCartItems()
                .stream()
                .map(item -> {

                    Map<String, Object> data = new HashMap<>();

                    data.put("cartItemId", item.getId());
                    data.put("productId", item.getProduct().getId());
                    data.put("productName", item.getProduct().getName());
                    data.put("productImage", item.getProduct().getImageUrl());
                    data.put("price", item.getProduct().getPrice());
                    data.put("quantity", item.getQuantity());

                    double subtotal =
                            item.getProduct().getPrice() * item.getQuantity();

                    data.put("subtotal", subtotal);

                    return data;
                })
                .toList();

        // Calculate total
        double total = cart.getCartItems()
                .stream()
                .mapToDouble(item ->
                        item.getProduct().getPrice() * item.getQuantity())
                .sum();

        Map<String, Object> response = new HashMap<>();
        response.put("items", items);
        response.put("total", total);

        return ResponseEntity.ok(response);
    }

    // UPDATE QUANTITY
    // PUT /api/cart/update/{productId}
    @PutMapping("/update/{productId}")
    public ResponseEntity<?> updateQuantity(
            @PathVariable Long productId,
            @RequestBody AddToCartRequest request,
            Authentication authentication) {

        String username = authentication.getName();
        User user = userRepository
                .findByUsername(username)
                .orElse(null);

        if (user == null) {
            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }

        Cart cart = cartRepository
                .findByUserId(user.getId())
                .orElse(null);

        if (cart == null) {
            return ResponseEntity.notFound().build();
        }

        // Check product exists and validate stock
        Product product = productRepository
                .findById(productId)
                .orElse(null);

        if (product == null) {
            return ResponseEntity.notFound().build();
        }

        // make sure stock is sufficient
        if (request.getQuantity() > 0 &&
                request.getQuantity() > product.getStockQuantity()) {

            return ResponseEntity
                    .badRequest()
                    .body("Not enough stock available.");
        }

        try {
            cartItemService.updateQuantity(
                    cart.getId(),
                    productId,
                    request.getQuantity());

            return ResponseEntity.ok("Quantity updated.");

        } catch (RuntimeException ex) {
            return ResponseEntity
                    .badRequest()
                    .body(ex.getMessage());
        }
    }

    // REMOVE PRODUCT
    // DELETE /api/cart/remove/{productId}
   @DeleteMapping("/remove/{productId}")
    public ResponseEntity<?> removeFromCart(
            @PathVariable Long productId,
            Authentication authentication) {

        String username = authentication.getName();
        User user = userRepository
                .findByUsername(username)
                .orElse(null);

        if (user == null) {
            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }

        Cart cart = cartRepository
                .findByUserId(user.getId())
                .orElse(null);

        if (cart == null) {
            return ResponseEntity.notFound().build();
        }

        CartItem cartItem = cartItemRepository
                .findByCartIdAndProductId(
                        cart.getId(),
                        productId)
                .orElse(null);

        if (cartItem == null) {
            return ResponseEntity.notFound().build();
        }

        cartItemRepository.delete(cartItem);

        return ResponseEntity.ok("Product removed from cart.");
    }

}