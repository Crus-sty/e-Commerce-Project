package com.eccomerce_store.service;

import com.eccomerce_store.electronics.Cart;
import com.eccomerce_store.electronics.CartItem;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.repository.CartItemRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class CartItemService {
    private final CartItemRepository cartItemRepository;

    public CartItemService(
            CartItemRepository cartItemRepository) {

        this.cartItemRepository =
                cartItemRepository;
    }

    // FIND CART ITEM
    public Optional<CartItem> findCartItem(
            Long cartId,
            Long productId) {

        return cartItemRepository
                .findByCartIdAndProductId(
                        cartId,
                        productId
                );
    }



    // ADD PRODUCT TO CART
    public CartItem addProduct(
            Cart cart,
            Product product,
            int quantity) {

        Optional<CartItem> existingItem =
                findCartItem(
                        cart.getId(),
                        product.getId()
                );


        // Product already exists
        if (existingItem.isPresent()) {

            CartItem cartItem =
                    existingItem.get();

            int newQuantity =
                    cartItem.getQuantity()
                            + quantity;

            cartItem.setQuantity(
                    newQuantity
            );

            return cartItemRepository.save(
                    cartItem
            );
        }


        // Product doesn't exist
        CartItem newItem =
                new CartItem();

        newItem.setCart(cart);

        newItem.setProduct(product);

        newItem.setQuantity(quantity);

        return cartItemRepository.save(
                newItem
        );
    }

    // UPDATE QUANTITY
    //(don't change)
    public CartItem updateQuantity(
            Long cartId,
            Long productId,
            int quantity) {

        CartItem cartItem = cartItemRepository.findByCartIdAndProductId(cartId, productId)
                .orElseThrow(() ->
                                new RuntimeException(
                                        "Product not found in cart"
                                )
                        );


        if (quantity <= 0) {

            cartItemRepository.delete(
                    cartItem
            );

            return null;
        }


        cartItem.setQuantity(quantity);

        return cartItemRepository.save(
                cartItem
        );
    }

    // REMOVE PRODUCT
    public void removeProduct(
            Long cartId,
            Long productId) {

        CartItem cartItem =
                cartItemRepository
                        .findByCartIdAndProductId(
                                cartId,
                                productId
                        )
                        .orElseThrow(() ->
                                new RuntimeException(
                                        "Product not found in cart"
                                )
                        );

        cartItemRepository.delete(
                cartItem
        );
    }

    // GET ALL ITEMS
    public List<CartItem> getCartItems(
            Long cartId) {

        return cartItemRepository
                .findByCartId(cartId);
    }



    // DELETE ALL ITEMS
    public void clearCart(Long cartId) {

        List<CartItem> items =
                cartItemRepository
                        .findByCartId(cartId);

        cartItemRepository.deleteAll(items);
    }
}
