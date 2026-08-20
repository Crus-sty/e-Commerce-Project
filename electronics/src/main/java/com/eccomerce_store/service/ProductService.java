package com.eccomerce_store.service;
import com.eccomerce_store.dto.ProductRequest;
import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.repository.ProductRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductService {
    private final ProductRepository productRepository;


    public ProductService(
            ProductRepository productRepository) {

        this.productRepository = productRepository;
    }



    // CREATE PRODUCT


    public Product createProduct(
            ProductRequest request) {

        Product product = new Product();

        product.setName(
                request.getName()
        );

        product.setDescription(
                request.getDescription()
        );

        product.setPrice(
                request.getPrice()
        );

        product.setStockQuantity(
                request.getStockQuantity()
        );

        product.setCategory(
                request.getCategory()
        );

        product.setImageUrl(
                request.getImageUrl()
        );

        return productRepository.save(product);
    }



    // GET ALL PRODUCTS


    public List<Product> getAllProducts() {

        return productRepository.findAll();
    }


    // GET PRODUCT BY ID


    public Product getProductById(Long id) {

        return productRepository
                .findById(id)
                .orElseThrow(() ->
                        new RuntimeException(
                                "Product not found"
                        )
                );
    }


    // UPDATE PRODUCT

    public Product updateProduct(
            Long id,
            ProductRequest request) {

        Product product =
                productRepository
                        .findById(id)
                        .orElseThrow(() ->
                                new RuntimeException(
                                        "Product not found"
                                )
                        );


        product.setName(
                request.getName()
        );

        product.setDescription(
                request.getDescription()
        );

        product.setPrice(
                request.getPrice()
        );

        product.setStockQuantity(
                request.getStockQuantity()
        );

        product.setCategory(
                request.getCategory()
        );

        product.setImageUrl(
                request.getImageUrl()
        );


        return productRepository.save(product);
    }



    // DELETE PRODUCT


    public void deleteProduct(Long id) {

        Product product =
                productRepository
                        .findById(id)
                        .orElseThrow(() ->
                                new RuntimeException(
                                        "Product not found"
                                )
                        );

        productRepository.delete(product);
    }



    // PRODUCTS BY CATEGORY


    public List<Product> getProductsByCategory(
            String category) {

        return productRepository
                .findByCategoryIgnoreCase(category);
    }


    // SEARCH PRODUCTS


    public List<Product> searchProducts(
            String name) {

        return productRepository
                .findByNameContainingIgnoreCase(name);
    }


    // CATEGORY + SEARCH

    public List<Product> searchByCategory(
            String category,
            String name) {

        return productRepository
                .findByCategoryIgnoreCaseAndNameContainingIgnoreCase(
                        category,
                        name
                );
    }


    // ALPHABETICAL ORDER


    public List<Product> getProductsAlphabetically() {

        return productRepository
                .findAllByOrderByNameAsc();
    }

    // LOWEST PRICE


    public List<Product> getProductsByLowestPrice() {

        return productRepository
                .findAllByOrderByPriceAsc();
    }



    // HIGHEST PRICE


    public List<Product> getProductsByHighestPrice() {

        return productRepository
                .findAllByOrderByPriceDesc();
    }

}
