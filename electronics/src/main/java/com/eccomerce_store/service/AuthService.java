package com.eccomerce_store.service;

import com.eccomerce_store.dto.LoginRequest;
import com.eccomerce_store.dto.LoginResponse;
import com.eccomerce_store.dto.RegisterRequest;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.UserRepository;
import com.eccomerce_store.security.JwtService;
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
    public User register(RegisterRequest request) {

        if (userRepository.existsByEmail(request.getEmail())) {
            throw new RuntimeException("Email already exists");
        }

        if (userRepository.existsByUsername(request.getName())) {
            throw new RuntimeException("Username already exists");
        }

        User user = new User();

        user.setUsername(request.getName());
        user.setEmail(request.getEmail());

        // Encrypt password
        user.setPasswordHash(
                passwordEncoder.encode(request.getPassword())
        );

        user.setFirstName(request.getName());
        user.setLastName(request.getSurname());
        user.setGender(request.getGender());
        user.setDob(request.getDob());

        // Determine role
        if (request.getEmail()
                .toLowerCase()
                .endsWith("@game-grid.com")) {

            user.setRole("ADMIN");

        } else {

            user.setRole("CUSTOMER");
        }

        return userRepository.save(user);
    }


    // LOGIN
    public LoginResponse login(LoginRequest request) {

        User user = userRepository
                .findByEmail(request.getEmail())
                .orElseThrow(() ->
                        new RuntimeException("Invalid email or password")
                );

        // Check password
        if (!passwordEncoder.matches(
                request.getPassword(),
                user.getPasswordHash())) {

            throw new RuntimeException("Invalid email or password");
        }

        // Generate JWT
        String token = jwtService.generateToken(
                user.getId(),
                user.getUsername(),
                user.getRole()
        );

        // Return login response
        return new LoginResponse(
                "Login successful",
                token,
                user.getId(),
                user.getUsername(),
                user.getEmail(),
                user.getRole()
        );
    }
}