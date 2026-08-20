package com.eccomerce_store.dto;

public class LoginResponse {
    private final String message;
    private final String token;
    private final String username;
    private final String role;

    public LoginResponse(
            String message,
            String token,
            Long id, String username,
            String role) {

        this.message = message;
        this.token = token;
        this.username = username;
        this.role = role;
    }

    public String getMessage() {
        return message;
    }

    public String getToken() {
        return token;
    }

    public String getUsername() {
        return username;
    }

    public String getRole() {
        return role;
    }
}
