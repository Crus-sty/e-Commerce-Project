package com.eccomerce_store.dto;

public class LoginResponse {
    private final String message;
    private final String token;
    private final Long id;
    private final String email;
    private final String role;

    public LoginResponse(
            String message,
            String token,
            Long id,
            String email,
            String role) {

        this.message = message;
        this.token = token;
        this.id = id;
        this.email = email;
        this.role = role;
    }

    public String getMessage() {
        return message;
    }

    public String getToken() {
        return token;
    }

    public Long getId() {
        return id;
    }

    public String getEmail() {
        return email;
    }

    public String getRole() {
        return role;
    }
}
