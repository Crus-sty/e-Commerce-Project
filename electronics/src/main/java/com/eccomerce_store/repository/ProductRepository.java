package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface ProductRepository extends JpaRepository<Product, Long> {
    // Find products by category

    List<Product> findByCategoryIgnoreCase(String category);

    // Search products by name
    List<Product> findByNameContainingIgnoreCase(String name);

    // Search products by category and name
    List<Product> findByCategoryIgnoreCaseAndNameContainingIgnoreCase(
            String category,
            String name
    );

    // Products sorted alphabetically
    List<Product> findAllByOrderByNameAsc();

    // Products sorted by price
    List<Product> findAllByOrderByPriceAsc();

    List<Product> findAllByOrderByPriceDesc();
}
