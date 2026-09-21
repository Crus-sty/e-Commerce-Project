package com.eccomerce_store.controller;

import com.eccomerce_store.dto.WishlistItemDto;
import com.eccomerce_store.service.WishlistService;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/wishlist")
@CrossOrigin
public class WishlistController {

    private final WishlistService wishlistService;

    public WishlistController(WishlistService wishlistService) {
        this.wishlistService = wishlistService;
    }
    // GET -list the current user's wishlist
    @GetMapping
    public ResponseEntity<?> getWishlist(Authentication authentication) {
        try {
            String username = authentication.getName();
            List<WishlistItemDto> items =
                    wishlistService.getWishlistForUser(username);
            return ResponseEntity.ok(items);
        } catch (RuntimeException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }
    // POST add a product
    @PostMapping("/add/{productId}")
    public ResponseEntity<?> add(
            @PathVariable Long productId,
            Authentication authentication) {
        try {
            String username = authentication.getName();
            wishlistService.addToWishlist(username, productId);
            return ResponseEntity.ok("Product added to wishlist.");
        } catch (RuntimeException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }

    // DELETE /api/wishlist/remove/{productId} — remove a produc
    @DeleteMapping("/remove/{productId}")
    public ResponseEntity<?> remove(
            @PathVariable Long productId,
            Authentication authentication) {
        try {
            String username = authentication.getName();
            wishlistService.removeFromWishlist(username, productId);
            return ResponseEntity.ok("Product removed from wishlist.");
        } catch (RuntimeException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }
}