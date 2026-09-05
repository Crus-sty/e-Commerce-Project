package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.OrderItem;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
 //Repository used to communicate with the order_items table
@Repository
public interface OrderItemRepository extends JpaRepository<OrderItem, Long>
{
   //JpaRepository provides the methods needed
}
