package com.eccomerce_store.service;

import com.eccomerce_store.electronics.Admin;
import com.eccomerce_store.repository.AdminRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AdminService {
    private final AdminRepository adminRepository;


    public AdminService(AdminRepository adminRepository) {

        this.adminRepository = adminRepository;
    }

    // CREATE ADMIN
    public Admin createAdmin(Admin admin) {

        if (adminRepository.existsByUsername(
                admin.getUsername())) {

            throw new RuntimeException(
                    "Username already exists"
            );
        }

        return adminRepository.save(admin);
    }

    // GET ADMIN BY ID
    public Admin getAdminById(Long id) {

        return adminRepository
                .findById(id)
                .orElseThrow(() ->
                        new RuntimeException(
                                "Admin not found"
                        )
                );
    }

    // GET ALL ADMINS
    public List<Admin> getAllAdmins() {

        return adminRepository.findAll();
    }


    // FIND ADMIN BY USERNAME
    public Admin getAdminByUsername(
            String username) {

        return adminRepository
                .findByUsername(username)
                .orElseThrow(() ->
                        new RuntimeException(
                                "Admin not found"
                        )
                );
    }

    // DELETE ADMIN
    public void deleteAdmin(Long id) {

        if (!adminRepository.existsById(id)) {

            throw new RuntimeException(
                    "Admin not found"
            );
        }

        adminRepository.deleteById(id);
    }
}
