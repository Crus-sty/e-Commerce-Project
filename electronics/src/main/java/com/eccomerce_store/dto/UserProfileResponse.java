package com.eccomerce_store.dto;

import java.time.LocalDate;

public class UserProfileResponse
{
    private Long id;
    private String username;
    private String email;
    private String firstName;
    private String lastName;
    private String role;
    private String gender;
    private LocalDate dob;

    public UserProfileResponse()
    {

    }

    public UserProfileResponse(Long id, String username, String email, String firstName, String lastName, String role, String gender, LocalDate dob)
    {
        this.id = id;
        this.username = username;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.role = role;
        this.gender = gender;
        this.dob = dob;
    }

    public Long getId()
    {
        return id;
    }

    public String getUsername()
    {
        return username;
    }

    public String getEmail()
    {
        return email;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public String getRole()
    {
        return role;
    }

    public String getGender()
    {
        return gender;
    }

    public LocalDate getDob()
    {
        return dob;
    }
}
