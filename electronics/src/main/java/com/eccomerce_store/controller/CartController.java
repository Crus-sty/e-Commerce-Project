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


    public CartController(
            CartRepository cartRepository,
            CartItemRepository cartItemRepository,
            ProductRepository productRepository,
            UserRepository userRepository) {

        this.cartRepository = cartRepository;

        this.cartItemRepository =cartItemRepository;


        this.productRepository = productRepository;


        this.userRepository = userRepository;

    }



    // ADD PRODUCT TO CART

    @PostMapping("/add")
    public ResponseEntity<?> addToCart(
            @RequestBody AddToCartRequest request,
            Authentication authentication) {

        // Check quantity

        if (request.getQuantity() <= 0) {

            return ResponseEntity
                    .badRequest()
                    .body("Quantity must be greater than 0.");
        }



        // GET LOGGED-IN USER


        String username =
                authentication.getName();

        User user =
                userRepository
                        .findByUsername(username)
                        .orElse(null);

        if (user == null) {

            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }



        // FIND PRODUCT


        Product product =
                productRepository
                        .findById(
                                request.getProductId()
                        )
                        .orElse(null);

        if (product == null) {

            return ResponseEntity
                    .notFound()
                    .build();
        }



        // CHECK STOCK


        if (product.getStockQuantity()
                < request.getQuantity()) {

            return ResponseEntity
                    .badRequest()
                    .body(
                            "Not enough stock available."
                    );
        }



        // FIND USER'S CART


        Cart cart =
                cartRepository
                        .findByUserId(
                                user.getId()
                        )
                        .orElse(null);



        // CREATE CART IF IT DOESN'T EXIST


        if (cart == null) {

            cart = new Cart();

            cart.setUser(user);

            cart =
                    cartRepository.save(cart);
        }


        // CHECK IF PRODUCT ALREADY EXISTS


        CartItem cartItem =
                cartItemRepository
                        .findByCartIdAndProductId(
                                cart.getId(),
                                product.getId()
                        )
                        .orElse(null);


        if (cartItem != null) {

            // Product already exists
            // Increase quantity

            int newQuantity =
                    cartItem.getQuantity()
                            + request.getQuantity();

            // Check stock again

            if (newQuantity >
                    product.getStockQuantity()) {

                return ResponseEntity
                        .badRequest()
                        .body(
                                "Not enough stock available."
                        );
            }

            cartItem.setQuantity(
                    newQuantity
            );

        } else {

            // CREATE NEW CART ITEM


            cartItem = new CartItem();

            cartItem.setCart(cart);

            cartItem.setProduct(product);

            cartItem.setQuantity(
                    request.getQuantity()
            );
        }


        // SAVE


        cartItemRepository.save(cartItem);


        return ResponseEntity.ok(
                "Product added to cart."
        );
    }


    // VIEW CART


    @GetMapping
    public ResponseEntity<?> getCart(
            Authentication authentication) {

        String username =
                authentication.getName();

        User user =
                userRepository
                        .findByUsername(username)
                        .orElse(null);

        if (user == null) {

            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }


        Cart cart =
                cartRepository
                        .findByUserId(
                                user.getId()
                        )
                        .orElse(null);


        if (cart == null) {

            Map<String, Object> emptyCart =
                    new HashMap<>();

            emptyCart.put(
                    "items",
                    new Object[0]
            );

            emptyCart.put(
                    "total",
                    0
            );

            return ResponseEntity.ok(
                    emptyCart
            );
        }


        // BUILD CART RESPONSE


        var items =
                cart.getCartItems()
                        .stream()
                        .map(item -> {

                            Map<String, Object> data =
                                    new HashMap<>();

                            data.put(
                                    "cartItemId",
                                    item.getId()
                            );

                            data.put(
                                    "productId",
                                    item.getProduct().getId()
                            );

                            data.put(
                                    "productName",
                                    item.getProduct().getName()
                            );

                            data.put(
                                    "price",
                                    item.getProduct().getPrice()
                            );

                            data.put(
                                    "quantity",
                                    item.getQuantity()
                            );

                            double subtotal =
                                    item.getProduct()
                                            .getPrice()
                                            *
                                            item.getQuantity();

                            data.put(
                                    "subtotal",
                                    subtotal
                            );

                            return data;
                        })
                        .toList();


        // Calculate total

        double total =
                cart.getCartItems()
                        .stream()
                        .mapToDouble(item ->
                                item.getProduct()
                                        .getPrice()
                                        *
                                        item.getQuantity()
                        )
                        .sum();


        Map<String, Object> response =
                new HashMap<>();

        response.put(
                "items",
                items
        );

        response.put(
                "total",
                total
        );


        return ResponseEntity.ok(
                response
        );
    }

    // REMOVE PRODUCT


    @DeleteMapping(
            "/remove/{productId}"
    )
    public ResponseEntity<?> removeFromCart(
            @PathVariable Long productId,
            Authentication authentication) {

        String username =
                authentication.getName();

        User user =
                userRepository
                        .findByUsername(username)
                        .orElse(null);

        if (user == null) {

            return ResponseEntity
                    .status(401)
                    .body("User not found.");
        }


        Cart cart =
                cartRepository
                        .findByUserId(
                                user.getId()
                        )
                        .orElse(null);

        if (cart == null) {

            return ResponseEntity
                    .notFound()
                    .build();
        }


        CartItem cartItem =
                cartItemRepository
                        .findByCartIdAndProductId(
                                cart.getId(),
                                productId
                        )
                        .orElse(null);


        if (cartItem == null) {

            return ResponseEntity
                    .notFound()
                    .build();
        }


        cartItemRepository.delete(
                cartItem
        );


        return ResponseEntity.ok(
                "Product removed from cart."
        );
    }
}
