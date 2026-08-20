package com.eccomerce_store.controller;


import com.eccomerce_store.dto.ProductRequest;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.repository.ProductRepository;
import com.eccomerce_store.service.ProductService;
import org.springframework.http.ResponseEntity;

import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/products")
@CrossOrigin
public class ProductController {
    private final ProductRepository productRepository;


    private final ProductService productService;


    public ProductController(
            ProductRepository productRepository, ProductService productService) {
        this.productRepository = productRepository;

        this.productService = productService;
    }



    // CREATE PRODUCT


    @PostMapping
    public ResponseEntity<Product> createProduct(
            @RequestBody ProductRequest request) {

        Product product =
                productService.createProduct(request);

        return ResponseEntity.ok(product);
    }



    // GET ALL PRODUCTS

    @GetMapping
    public ResponseEntity<List<Product>> getProducts() {

        return ResponseEntity.ok(
                productService.getAllProducts()
        );
    }



    // GET PRODUCT BY ID


    @GetMapping("/{id}")
    public ResponseEntity<Product> getProduct(
            @PathVariable Long id) {

        try {

            Product product =
                    productService.getProductById(id);

            return ResponseEntity.ok(product);

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }



    // UPDATE PRODUCT


    @PutMapping("/{id}")
    public ResponseEntity<Product> updateProduct(
            @PathVariable Long id,
            @RequestBody ProductRequest request) {

        try {

            Product product =
                    productService.updateProduct(
                            id,
                            request
                    );

            return ResponseEntity.ok(product);

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }


    // DELETE PRODUCT

    @DeleteMapping("/{id}")
    public ResponseEntity<String> deleteProduct(
            @PathVariable Long id) {

        try {

            productService.deleteProduct(id);

            return ResponseEntity.ok(
                    "Product deleted successfully"
            );

        } catch (RuntimeException e) {

            return ResponseEntity
                    .notFound()
                    .build();
        }
    }



    // PRODUCTS BY CATEGORY
    @GetMapping("/category/{category}")
    public ResponseEntity<List<Product>>
    getProductsByCategory(
            @PathVariable String category) {

        return ResponseEntity.ok(
                productService
                        .getProductsByCategory(category)
        );
    }


    // SEARCH

    @GetMapping("/search")
    public ResponseEntity<List<Product>>
    searchProducts(
            @RequestParam String name) {

        return ResponseEntity.ok(
                productService
                        .searchProducts(name)
        );
    }



    // CATEGORY + SEARCH

    @GetMapping("/category/{category}/search")
    public ResponseEntity<List<Product>>
    searchCategory(
            @PathVariable String category,
            @RequestParam String name) {

        return ResponseEntity.ok(
                productService.searchByCategory(
                        category,
                        name
                )
        );
    }


    // ALPHABETICAL

    @GetMapping("/sort/name")
    public ResponseEntity<List<Product>>
    sortAlphabetically() {

        return ResponseEntity.ok(
                productService
                        .getProductsAlphabetically()
        );
    }


    // LOWEST PRICE

    @GetMapping("/sort/price-low")
    public ResponseEntity<List<Product>>
    sortLowestPrice() {

        return ResponseEntity.ok(
                productService
                        .getProductsByLowestPrice()
        );
    }


    // HIGHEST PRICE

    @GetMapping("/sort/price-high")
    public ResponseEntity<List<Product>>
    sortHighestPrice() {

        return ResponseEntity.ok(
                productService
                        .getProductsByHighestPrice()
        );
    }
}
