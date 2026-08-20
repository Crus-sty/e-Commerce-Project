package com.eccomerce_store.service;

import com.eccomerce_store.dto.*;
import com.eccomerce_store.electronics.User;

import com.eccomerce_store.security.SecurityConfig;
import com.eccomerce_store.security.JwtAuthenticationFilter;

import com.eccomerce_store.repository.userRepository;
import com.eccomerce_store.security.JwtService;
import com.eccomerce_store.repository.userRepository;
import com.eccomerce_store.dto.RegisterRequest;
import com.eccomerce_store.dto.RegisterRequest;



import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class AuthService {
    private final userRepository.UserRepository userRepository;

    private final PasswordEncoder passwordEncoder;

    private final JwtService jwtService;

    public AuthService(
            userRepository.UserRepository userRepository,
            PasswordEncoder passwordEncoder,
            JwtService jwtService) {

        this.userRepository = userRepository;

        this.passwordEncoder = passwordEncoder;

        this.jwtService = jwtService;
    }

    // REGISTER
    public String register(
            RegisterRequest request) {

        // Check username
        if (userRepository.existsByUsername(
                request.getUsername())) {

            return "Username already exists";
        }

        // Check email
        if (userRepository.existsByEmail(
                request.getEmail())) {

            return "Email already exists";
        }

        // Create user
        User user = new User();

        user.setUsername(
                request.getUsername()
        );

        user.setEmail(
                request.getEmail()
        );

        user.setFirstName(
                request.getFirstName()
        );

        user.setLastName(
                request.getLastName()
        );

        // Encrypt password
        user.setPassword(
                passwordEncoder.encode(
                        request.getPassword()
                )
        );

        // Normal registration = customer
        user.setRole("CUSTOMER");

        // Save user
        userRepository.save(user);

        return "Registration successful";
    }

    // LOGIN
    public LoginResponse login(
            LoginRequest request) {

        User user =
                userRepository
                        .findByUsername(
                                request.getUsername()
                        )
                        .orElse(null);

        if (user == null) {

            throw new RuntimeException(
                    "Invalid username or password"
            );
        }

        // Compare entered password
        // against encrypted password
        boolean passwordCorrect =
                passwordEncoder.matches(
                        request.getPassword(),
                        user.getPassword()
                );

        if (!passwordCorrect) {

            throw new RuntimeException(
                    "Invalid username or password"
            );
        }

        // Generate JWT
        String token =
                jwtService.generateToken(
                        user.getId(),
                        user.getUsername(),
                        user.getRole()
                );

        return new LoginResponse(
                "Login successful",
                token,
                user.getId(),
                user.getUsername(),
                user.getRole()
        );
    }}
