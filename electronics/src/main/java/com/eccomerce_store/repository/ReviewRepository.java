package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Review;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

 //Repository for accessing the reviews table
@Repository
public interface ReviewRepository extends JpaRepository<Review, Long>
{
    List<Review> findByProductId(Long productId);

    List<Review> findByUserId(Long userId);

    Optional<Review> findByUserIdAndProductId(Long userId, Long productId);

    boolean existsByUserIdAndProductId(Long userId, Long productId);
}
