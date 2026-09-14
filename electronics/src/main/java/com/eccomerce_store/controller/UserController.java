package com.eccomerce_store.controller;

import com.eccomerce_store.dto.UserProfileResponse;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.repository.UserRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/user")
@CrossOrigin
public class UserController 
{
    private final UserRepository userRepository;

    public UserController(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    @GetMapping("/profile")
    public ResponseEntity<?> profile(Authentication authentication)
    {
        // Gets the username of the currently logged-in user
        String username = authentication.getName();

        // finds that user in the database
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        // returns the user's information 
        UserProfileResponse response = new UserProfileResponse(user.getId(), user.getUsername(), user.getEmail(), user.getFirstName(), user.getLastName(), user.getRole(), user.getGender(), user.getDob());

        return ResponseEntity.ok(response);
    }
}
