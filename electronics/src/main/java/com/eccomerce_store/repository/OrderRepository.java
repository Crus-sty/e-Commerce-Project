package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.Order;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

//@Repository tells Spring that this interface is used to communicate with the database
@Repository

 //JpaRepository gives us built-in database operations
public interface OrderRepository extends JpaRepository<Order, Long>
{
    List<Order> findByUserId(Long userId);

    @Query("""
        SELECT DISTINCT o
        FROM Order o
        LEFT JOIN FETCH o.user
        LEFT JOIN FETCH o.orderItems
        """)
    List<Order> findAllWithUserAndItems();
}
