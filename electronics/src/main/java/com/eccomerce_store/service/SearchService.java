package com.eccomerce_store.service;

import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.repository.ProductRepository;
import org.springframework.stereotype.Service;
import java.util.List;

//Handles product searching
@Service
public class SearchService
{
    private final ProductRepository productRepository;

    public SearchService(ProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

     //Searches products using a keyword and sorting option
    public List<Product> search(String keyword, String sort)
    {
        //Prevents null or empty searches
        if (keyword == null || keyword.trim().isEmpty())
        {
            return productRepository.findAll();
        }

        keyword = keyword.trim();

         //Sorts by price from lowest to highest
        if ("price_asc".equalsIgnoreCase(sort))
        {
            return productRepository.searchProductsPriceAsc(keyword);
        }

         //Sorts by price from highest to lowest
        if ("price_desc".equalsIgnoreCase(sort))
        {
            return productRepository.searchProductsPriceDesc(keyword);
        }
         //Sorts alphabetically
        if ("name".equalsIgnoreCase(sort))
        {
            return productRepository.searchProductsNameAsc(keyword);
        }

        //Default search without sorting
        return productRepository.searchProducts(keyword);
    }
}
