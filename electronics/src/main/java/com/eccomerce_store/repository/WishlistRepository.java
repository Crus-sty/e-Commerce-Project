package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Wishlist;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface WishlistRepository extends JpaRepository<Wishlist, Long> {

    // Look up the wishlist belonging to a specific user
    Optional<Wishlist> findByUserId(Long userId);
}