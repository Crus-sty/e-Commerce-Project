package com.eccomerce_store.service;

import com.eccomerce_store.dto.*;
import com.eccomerce_store.electronics.User;

import com.eccomerce_store.repository.UserRepository;
import com.eccomerce_store.security.JwtService;
import com.eccomerce_store.dto.RegisterRequest;


import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class AuthService {
    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final JwtService jwtService;

    public AuthService(
            UserRepository userRepository,
            PasswordEncoder passwordEncoder,
            JwtService jwtService) {

        this.userRepository = userRepository;
        this.passwordEncoder = passwordEncoder;
        this.jwtService = jwtService;
    }

    // REGISTER
    public String register(RegisterRequest request) {

        // Check if email already exists
        if (userRepository.existsByEmail(request.getEmail())) {
            return "Email already exists";
        }

        // Create new user
        User user = new User();

        // Use email as username
        user.setUsername(request.getEmail());

        // Personal information
        user.setFirstName(request.getName());
        user.setLastName(request.getSurname());

        // Email
        user.setEmail(request.getEmail());

        // Other information
        user.setDob(request.getDob());
        user.setGender(request.getGender());

        // Encrypt password
        user.setPassword(
                passwordEncoder.encode(
                        request.getPassword()
                )
        );

        // Normal registration = customer
        user.setRole("CUSTOMER");

        // Save user to database
        userRepository.save(user);

        return "Registration successful";
    }

    // LOGIN
    public LoginResponse login(LoginRequest request) {

        // Find user using email
        User user = userRepository
                .findByEmail(request.getEmail())
                .orElse(null);

        // User doesn't exist
        if (user == null) {
            throw new RuntimeException(
                    "Invalid email or password"
            );
        }

        // Check password
        boolean passwordCorrect =
                passwordEncoder.matches(
                        request.getPassword(),
                        user.getPassword()
                );

        if (!passwordCorrect) {
            throw new RuntimeException(
                    "Invalid email or password"
            );
        }

        // Generate JWT
        String token = jwtService.generateToken(
                user.getId(),
                user.getEmail(),
                user.getRole()
        );

        // Return login response
        return new LoginResponse(
                "Login successful",
                token,
                user.getId(),
                user.getEmail(),
                user.getRole()
        );
     }
    }
