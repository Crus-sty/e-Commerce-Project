package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.CartItem;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface CartItemRepository extends JpaRepository<CartItem, Long> {
    Optional<CartItem> findByCartIdAndProductId(
            Long cartId,
            Long productId
    );
    List<CartItem> findByCartId(
            Long cartId
    );
}
