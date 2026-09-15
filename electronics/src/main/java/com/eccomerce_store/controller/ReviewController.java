package com.eccomerce_store.controller;

import com.eccomerce_store.dto.ReviewRequest;
import com.eccomerce_store.dto.ReviewResponse;
import com.eccomerce_store.service.ReviewService;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.web.bind.annotation.*;
import java.util.List;

 // @RestController tells Spring that this class is a REST controller
@RestController

@RequestMapping("/api/reviews")

@CrossOrigin
public class ReviewController
{
    private final ReviewService reviewService;

    public ReviewController(ReviewService reviewService)
    {
        this.reviewService = reviewService;
    }

    // Creates review
    @PostMapping
    public ResponseEntity<?> createReview(@RequestBody ReviewRequest request, Authentication authentication)
    {
        try
        {
            String username = authentication.getName();

            ReviewResponse response = reviewService.createReview(username, request);

            return ResponseEntity.ok(response);

        } catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }

    // Gets all the reviews for the product
    @GetMapping("/product/{productId}")
    public ResponseEntity<?> getProductReviews(@PathVariable Long productId)
    {
        try
        {
            List<ReviewResponse> reviews = reviewService.getProductReviews(productId);

            return ResponseEntity.ok(reviews);

        } catch (RuntimeException e)
        {
            return ResponseEntity.notFound().build();
        }
    }

    //Returns reviews written by the logged-in user
    @GetMapping("/my")
    public ResponseEntity<?> getMyReviews(Authentication authentication)
    {
        try
        {
             // Gets the logged-in user's username
            String username = authentication.getName();

            return ResponseEntity.ok(reviewService.getUserReviews(username));

        } catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }

     //Updates an existing review
    @PutMapping("/{reviewId}")
    public ResponseEntity<?> updateReview(@PathVariable Long reviewId, @RequestBody ReviewRequest request, Authentication authentication)
    {
        try
        {
            String username = authentication.getName();

            ReviewResponse response = reviewService.updateReview(reviewId, username, request);

            return ResponseEntity.ok(response);

        } catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }

     // Deletes a review
    @DeleteMapping("/{reviewId}")
    public ResponseEntity<?> deleteReview(@PathVariable Long reviewId, Authentication authentication)
    {
        try
        {
            String username = authentication.getName();

            reviewService.deleteReview(reviewId, username);

            return ResponseEntity.ok("Review deleted successfully");

        } catch (RuntimeException e)
        {
            return ResponseEntity.badRequest().body(e.getMessage());
        }
    }
}
