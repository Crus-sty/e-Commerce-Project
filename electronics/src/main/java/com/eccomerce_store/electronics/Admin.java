package com.eccomerce_store.electronics;


import jakarta.persistence.*;

@Entity
@Table(name = "User")//subject to change based on database
public class Admin {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name ="UserID")
    private Long id;

    @Column(name="UserName",unique = true, nullable = false)
    private String username;

    @Column(name="Email",unique = true, nullable = false)
    private String email;

    @Column(name="PasswordHash",nullable = false)
    private String password;


    // Empty constructor required by JPA
    public Admin() {
    }


    // Getters and Setters

    public Long getId() {
        return id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail (String email){return this.email = email;}
    public void setEmail(String email) {
        this.email = email;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }
}
