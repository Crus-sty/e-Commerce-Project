package com.eccomerce_store.service;

import com.eccomerce_store.dto.WishlistItemDto;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.electronics.Wishlist;
import com.eccomerce_store.electronics.WishlistItem;
import com.eccomerce_store.repository.ProductRepository;
import com.eccomerce_store.repository.UserRepository;
import com.eccomerce_store.repository.WishlistItemRepository;
import com.eccomerce_store.repository.WishlistRepository;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.ArrayList;
import java.util.List;

@Service
public class WishlistService {

    private final WishlistRepository wishlistRepository;
    private final WishlistItemRepository wishlistItemRepository;
    private final ProductRepository productRepository;
    private final UserRepository userRepository;

    public WishlistService(
            WishlistRepository wishlistRepository,
            WishlistItemRepository wishlistItemRepository,
            ProductRepository productRepository,
            UserRepository userRepository
    ) {
        this.wishlistRepository = wishlistRepository;
        this.wishlistItemRepository = wishlistItemRepository;
        this.productRepository = productRepository;
        this.userRepository = userRepository;
    }

    // -----------------------------------------------------------------
    // GET — list all wishlist items for the currently-logged-in user
    // -----------------------------------------------------------------
    @Transactional(readOnly = true)
    public List<WishlistItemDto> getWishlistForUser(String username) {

        User user = userRepository.findByUsername(username)
                .orElseThrow(() -> new RuntimeException("User not found."));

        Wishlist wishlist = wishlistRepository.findByUserId(user.getId())
                .orElse(null);

        if (wishlist == null) {
            return new ArrayList<>();
        }

        List<WishlistItemDto> result = new ArrayList<>();

        for (WishlistItem item : wishlist.getItems()) {
            Product p = item.getProduct();
            if (p == null) continue;    // orphaned row — skip

            result.add(new WishlistItemDto(
                    p.getId(),
                    p.getName(),
                    p.getImageUrl(),
                    p.getPrice(),
                    p.getStockQuantity()
            ));
        }

        return result;
    }

    // -----------------------------------------------------------------
    // ADD — add a product to the user's wishlist
    // -----------------------------------------------------------------
    @Transactional
    public void addToWishlist(String username, Long productId) {

        User user = userRepository.findByUsername(username)
                .orElseThrow(() -> new RuntimeException("User not found."));

        Product product = productRepository.findById(productId)
                .orElseThrow(() -> new RuntimeException("Product not found."));

        // Find the user's wishlist, or create one
        Wishlist wishlist = wishlistRepository.findByUserId(user.getId())
                .orElseGet(() -> {
                    Wishlist w = new Wishlist(user);
                    return wishlistRepository.save(w);
                });

        // Skip if it's already there
        if (wishlistItemRepository.existsByWishlistIdAndProductId(
                wishlist.getId(), product.getId())) {
            return;
        }

        WishlistItem item = new WishlistItem(wishlist, product);
        wishlistItemRepository.save(item);
    }

    // -----------------------------------------------------------------
    // REMOVE — remove a product from the user's wishlist
    // -----------------------------------------------------------------
    @Transactional
    public void removeFromWishlist(String username, Long productId) {

        User user = userRepository.findByUsername(username)
                .orElseThrow(() -> new RuntimeException("User not found."));

        Wishlist wishlist = wishlistRepository.findByUserId(user.getId())
                .orElseThrow(() -> new RuntimeException("Wishlist not found."));

        WishlistItem item = wishlistItemRepository
                .findByWishlistIdAndProductId(wishlist.getId(), productId)
                .orElseThrow(() -> new RuntimeException("Product not in wishlist."));

        wishlistItemRepository.delete(item);
    }
}