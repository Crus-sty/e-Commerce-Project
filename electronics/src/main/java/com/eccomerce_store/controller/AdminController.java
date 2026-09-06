package com.eccomerce_store.controller;

import com.eccomerce_store.electronics.Admin;
import com.eccomerce_store.service.AdminService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/admin")
@CrossOrigin
public class AdminController {
    private final AdminService adminService;


    public AdminController(
            AdminService adminService) {

        this.adminService = adminService;
    }

    // CREATE ADMIN
    @PostMapping("/create")
    public ResponseEntity<?> createAdmin(
            @RequestBody Admin admin) {

        try {

            Admin newAdmin = adminService.createAdmin(admin);


            return ResponseEntity.ok(newAdmin);

        } catch (RuntimeException e) {

            return ResponseEntity
                    .badRequest()
                    .body(e.getMessage());
        }
    }

    // GET ALL ADMINS
    @GetMapping
    public ResponseEntity<List<Admin>>
    getAllAdmins() {

        return ResponseEntity.ok(
                adminService.getAllAdmins()
        );
    }

    // GET ADMIN BY ID
    @GetMapping("/{id}")
    public ResponseEntity<?> getAdmin(
            @PathVariable Long id) {
        try {

            return ResponseEntity.ok(
                    adminService.getAdminById(id)
            );

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }

    // GET ADMIN BY USERNAME
    @GetMapping("/username/{username}")
    public ResponseEntity<?> getAdminByUsername(
            @PathVariable String username) {

        try {

            return ResponseEntity.ok(
                    adminService.getAdminByUsername(username)
            );

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }

    // DELETE ADMIN
    @DeleteMapping("/{id}")
    public ResponseEntity<?> deleteAdmin(
            @PathVariable Long id) {

        try {

            adminService.deleteAdmin(id);

            return ResponseEntity.ok(
                    "Admin deleted successfully"
            );

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }
}
