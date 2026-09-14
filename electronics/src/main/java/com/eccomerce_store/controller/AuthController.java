package com.eccomerce_store.controller;


import com.eccomerce_store.dto.LoginRequest;
import com.eccomerce_store.dto.LoginResponse;
import com.eccomerce_store.dto.RegisterRequest;
import com.eccomerce_store.electronics.User;
import com.eccomerce_store.service.AuthService;
import org.springframework.http.ResponseEntity;

import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/auth")
@CrossOrigin
public class AuthController {
    private final AuthService authService;

    public AuthController(
            AuthService authService) {

        this.authService = authService;
    }


    // REGISTER
    @PostMapping("/register")
    public ResponseEntity<?> register(
            @RequestBody RegisterRequest request) {

        try {

            User result = authService.register(request);


            return ResponseEntity.ok(result);

        } catch (Exception e) {

            return ResponseEntity
                    .badRequest()
                    .body(e.getMessage());
        }
    }


    // LOGIN
    @PostMapping("/login")
    public ResponseEntity<?> login(
            @RequestBody LoginRequest request) {

        try {

            LoginResponse response =authService.login(request);


            return ResponseEntity.ok(response);

        } catch (Exception e) {

            return ResponseEntity
                    .status(401)
                    .body(e.getMessage());
        }
    }
}
