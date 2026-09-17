package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface ProductRepository extends JpaRepository<Product, Long>
    {
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

         @Query("""
        SELECT p
        FROM Product p
        WHERE LOWER(p.name) LIKE LOWER(CONCAT('%', :keyword, '%'))
           OR LOWER(p.description) LIKE LOWER(CONCAT('%', :keyword, '%'))
    """)
    List<Product> searchProducts(@Param("keyword") String keyword);

    // Search products and sort from cheapest to most expensive
    @Query("""
        SELECT p
        FROM Product p
        WHERE LOWER(p.name) LIKE LOWER(CONCAT('%', :keyword, '%'))
           OR LOWER(p.description) LIKE LOWER(CONCAT('%', :keyword, '%'))
        ORDER BY p.price ASC
    """)
    List<Product> searchProductsPriceAsc(@Param("keyword") String keyword);

    // Search products and sort from most expensive to cheapest
    @Query("""
        SELECT p
        FROM Product p
        WHERE LOWER(p.name) LIKE LOWER(CONCAT('%', :keyword, '%'))
           OR LOWER(p.description) LIKE LOWER(CONCAT('%', :keyword, '%'))
        ORDER BY p.price DESC
    """)
    List<Product> searchProductsPriceDesc(@Param("keyword") String keyword);


    // Search products and sort alphabetically by name
    @Query("""
        SELECT p
        FROM Product p
        WHERE LOWER(p.name) LIKE LOWER(CONCAT('%', :keyword, '%'))
           OR LOWER(p.description) LIKE LOWER(CONCAT('%', :keyword, '%'))
        ORDER BY p.name ASC
    """)
    List<Product> searchProductsNameAsc(@Param("keyword") String keyword);
}
