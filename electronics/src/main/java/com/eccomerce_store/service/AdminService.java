package com.eccomerce_store.service;

import com.eccomerce_store.dto.AdminRequest;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.UserRepository;

import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AdminService {

    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;


    public AdminService(UserRepository userRepository,
                        PasswordEncoder passwordEncoder) {

        this.userRepository = userRepository;
        this.passwordEncoder = passwordEncoder;
    }

    // CREATE ADMIN
    public User createAdmin(AdminRequest request) {

        // Check email
        if (userRepository.existsByEmail(request.getEmail())) {
            throw new RuntimeException("Email already exists");
        }


        // Check username
        if (userRepository.existsByUsername(request.getUsername())) {
            throw new RuntimeException("Username already exists");
        }


        // Create User object
        User user = new User();


        // Username
        user.setUsername(request.getUsername());


        // Email
        user.setEmail(request.getEmail());


        // First name
        user.setFirstName(request.getFirstName());


        // Last name
        user.setLastName(request.getLastName());


        // Encrypt password
        user.setPasswordHash(
                passwordEncoder.encode(request.getPassword())
        );


        // IMPORTANT
        // This makes the account an ADMIN
        user.setRole("ADMIN");


        // Optional information
        user.setGender(request.getGender());
        user.setDob(request.getDob());


        // Save into the SAME User table
        return userRepository.save(user);
    }

    // GET ALL ADMINS
    public List<User> getAllAdmins() {

        return userRepository.findByRole("ADMIN");
    }

    // GET ADMIN BY ID
    public User getAdminById(Long id) {

        User user = userRepository.findById(id)
                .orElseThrow(() ->
                        new RuntimeException("Admin not found")
                );


        if (!"ADMIN".equals(user.getRole())) {
            throw new RuntimeException("User is not an admin");
        }


        return user;
    }

    // GET ADMIN BY USERNAME
    public User getAdminByUsername(String username) {

        User user = userRepository.findByUsername(username)
                .orElseThrow(() ->
                        new RuntimeException("Admin not found")
                );


        if (!"ADMIN".equals(user.getRole())) {
            throw new RuntimeException("User is not an admin");
        }


        return user;
    }


    // DELETE ADMIN
    public void deleteAdmin(Long id) {

        User user = getAdminById(id);

        userRepository.delete(user);
    }
}