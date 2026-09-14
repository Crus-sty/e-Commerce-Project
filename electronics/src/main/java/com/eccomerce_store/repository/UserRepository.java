package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface UserRepository extends JpaRepository<User, Long> {

    Optional<User> findByEmail(String email);

    Optional<User> findByUsername(String username);

    List<User> findByRole(String role);

    boolean existsByEmail(String email);

    boolean existsByUsername(String username);
}