package com.eccomerce_store.controller;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/user")
public class UserController {
    @GetMapping("/profile")//may change
    public String profile(
            Authentication authentication) {

        return "Welcome "
                + authentication.getName()
                + "! You are logged in.";
    }
}
