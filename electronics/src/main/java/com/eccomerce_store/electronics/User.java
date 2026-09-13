package com.eccomerce_store.electronics;
import jakarta.persistence.*;
import java.time.LocalDate;
//user model
@Entity
@Table(name ="User")
public class User {
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

    private String firstName;

    private String lastName;

    @Column(nullable = false)
    private String role;

    @Column(nullable = false)
    private String gender;

    @Column(nullable = false)
    private LocalDate dob;


    // Constructor
    public User() {
        this.role = "CUSTOMER";
    }


    // ID
    public Long getId() {
        return id;
    }


    // Username
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }


    // Email
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }


    // Password
    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }


    // First name
    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }


    // Last name
    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }


    // Role
    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }


    // Gender
    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }


    // Date of birth
    public LocalDate getDob() {
        return dob;
    }

    public void setDob(LocalDate dob) {
        this.dob = dob;
    };

}

