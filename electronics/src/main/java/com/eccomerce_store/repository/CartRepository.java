package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Cart;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;
@Repository
public interface CartRepository extends JpaRepository<Cart, Long> {
    //allows us to find the cart belonging to the logged in customer.
    Optional<Cart> findByUserId(Long userId);
}
