package com.eccomerce_store.security;
import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.security.Keys;

import org.springframework.stereotype.Service;

import javax.crypto.SecretKey;
import java.nio.charset.StandardCharsets;
import java.util.Date;
@Service
public class JwtService {
    private final String SECRET_KEY =
            "ThisIsASecretKeyForMyEcommerceWebsite123456789";

    private final long EXPIRATION_TIME =
            1000 * 60 * 60;

    private SecretKey getSigningKey() {

        return Keys.hmacShaKeyFor(
                SECRET_KEY.getBytes(
                        StandardCharsets.UTF_8
                )
        );
    }

    public String generateToken(
            Long userId,
            String username,
            String role) {

        return Jwts.builder()

                // Store user ID inside JWT
                .claim("userId", userId)

                // Store role
                .claim("role", role)

                // Username
                .subject(username)

                // Created time
                .issuedAt(new Date())

                // Expiration
                .expiration(
                        new Date(
                                System.currentTimeMillis()
                                        + EXPIRATION_TIME
                        )
                )

                // Sign token
                .signWith(getSigningKey())

                .compact();
    }

    public String extractUsername(String token) {

        return getClaims(token)
                .getSubject();
    }

    public Long extractUserId(String token) {

        Number userId =
                getClaims(token)
                        .get("userId", Number.class);

        return userId.longValue();
    }

    public String extractRole(String token) {

        return getClaims(token)
                .get("role", String.class);
    }

    public boolean isTokenValid(String token) {

        try {

            Claims claims = getClaims(token);

            return claims
                    .getExpiration()
                    .after(new Date());

        } catch (Exception e) {

            return false;
        }
    }

    private Claims getClaims(String token) {

        return Jwts.parser()

                .verifyWith(getSigningKey())

                .build()

                .parseSignedClaims(token)

                .getPayload();
    }
}

