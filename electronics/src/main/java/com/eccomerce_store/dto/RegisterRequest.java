package com.eccomerce_store.dto;

public class RegisterRequest {
    private String firstname;
    private String surname;
    private String dob;
    private String gender;
    private String email;
    private String password;


    public RegisterRequest() {
    }


    public String getName() {
        return firstname;
    }

    public void setName(String name) {
        this.firstname = name;
    }


    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }


    public String getDob() {
        return dob;
    }

    public void setDob(String dob) {
        this.dob = dob;
    }


    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }


    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }


    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
