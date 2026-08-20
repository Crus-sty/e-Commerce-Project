package com.eccomerce_store.repository;

import com.eccomerce_store.electronics.User;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;
public class userRepository {



    public interface UserRepository
            extends JpaRepository<User, Long> {

        Optional<User> findByUsername(String username);

        Optional<User> findByEmail(String email);

        boolean existsByUsername(String username);

        boolean existsByEmail(String email);
    }
}
