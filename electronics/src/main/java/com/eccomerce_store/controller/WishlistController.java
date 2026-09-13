package com.eccomerce_store.controller;

import com.eccomerce_store.electronics.User;
import com.eccomerce_store.electronics.WishlistItem;
import com.eccomerce_store.repository.UserRepository;
import com.eccomerce_store.repository.WishlistItemRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/wishlist")
@CrossOrigin
public class WishlistController {

    private final WishlistItemRepository wishlistRepo;
    private final UserRepository userRepo;

    public WishlistController(WishlistItemRepository wishlistRepo,
                              UserRepository userRepo) {
        this.wishlistRepo = wishlistRepo;
        this.userRepo = userRepo;
    }

    @GetMapping
    public ResponseEntity<?> getWishlist(Authentication auth) {
        User user = userRepo.findByUsername(auth.getName()).orElse(null);
        if (user == null) return ResponseEntity.status(401).body("User not found.");

        List<Map<String, Object>> items = wishlistRepo.findByUserId(user.getId())
                .stream()
                .map(w -> {
                    Map<String, Object> m = new HashMap<>();
                    m.put("wishlistItemId", w.getId());
                    m.put("productId", w.getProduct().getId());
                    m.put("productName", w.getProduct().getName());
                    m.put("productImage", w.getProduct().getImageUrl());
                    m.put("price", w.getProduct().getPrice());
                    m.put("inStock", w.getProduct().getStockQuantity() > 0);
                    return m;
                })
                .collect(Collectors.toList());

        return ResponseEntity.ok(items);
    }

    @DeleteMapping("/remove/{productId}")
    public ResponseEntity<?> remove(Authentication auth, @PathVariable Long productId) {
        User user = userRepo.findByUsername(auth.getName()).orElse(null);
        if (user == null) return ResponseEntity.status(401).body("User not found.");

        return wishlistRepo.findByUserIdAndProductId(user.getId(), productId)
                .map(w -> {
                    wishlistRepo.delete(w);
                    return ResponseEntity.ok("Removed from wishlist.");
                })
                .orElse(ResponseEntity.notFound().build());
    }
}