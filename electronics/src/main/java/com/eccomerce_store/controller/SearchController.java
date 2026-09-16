package com.eccomerce_store.controller;

import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.service.SearchService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

//REST Controller for product searching
@RestController
@RequestMapping("/api/search")
@CrossOrigin
public class SearchController
{
    private final SearchService searchService;

    public SearchController(SearchService searchService)
    {
        this.searchService = searchService;
    }

    @GetMapping
    public ResponseEntity<List<Product>> searchProducts(@RequestParam String keyword, @RequestParam(required = false, defaultValue = "") String sort)
    {
        List<Product> products = searchService.search(keyword, sort);

        return ResponseEntity.ok(products);
    }
}
