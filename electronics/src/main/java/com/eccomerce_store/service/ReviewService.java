package com.eccomerce_store.service;

import com.eccomerce_store.dto.ReviewRequest;
import com.eccomerce_store.dto.ReviewResponse;

import com.eccomerce_store.electronics.Product;
import com.eccomerce_store.electronics.Review;
import com.eccomerce_store.electronics.User;

import com.eccomerce_store.repository.ProductRepository;
import com.eccomerce_store.repository.ReviewRepository;
import com.eccomerce_store.repository.UserRepository;

import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ReviewService
{
     //Used to save, find and delete reviews
    private final ReviewRepository reviewRepository;

     //Used to find products
    private final ProductRepository productRepository;

     //Used to find users
    private final UserRepository userRepository;

    public ReviewService(ReviewRepository reviewRepository, ProductRepository productRepository, UserRepository userRepository)
    {
        this.reviewRepository = reviewRepository;
        this.productRepository = productRepository;
        this.userRepository = userRepository;
    }

     //Creates a new review for a product
    public ReviewResponse createReview(String username, ReviewRequest request)
    {
         //To find the logged in user
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

         //To find the product being reviewed
        Product product = productRepository.findById(request.getProductId()).orElseThrow(() -> new RuntimeException("Product not found"));

         //Exception handling to ensure that we always get a rating between 1 and 5
        if (request.getRating() < 1 || request.getRating() > 5)
        {
            throw new RuntimeException("Rating must be between 1 and 5");
        }

         //ensures that a comment is put in
        if (request.getComment() == null || request.getComment().trim().isEmpty())
        {
            throw new RuntimeException("Comment is required");
        }

         //Checks whether a user has already reviewed a certain product
        if (reviewRepository.existsByUserIdAndProductId(user.getId(), product.getId()))
        {
            throw new RuntimeException("You have already reviewed this product");
        }

        Review review = new Review();
         //Connecting review to the user
        review.setUser(user);
         //Connecting review to the product
        review.setProduct(product);

        review.setRating(request.getRating());

        review.setComment(request.getComment());

        Review savedReview = reviewRepository.save(review);

        return convertToResponse(savedReview);
    }

    //To get reviews for a product
    public List<ReviewResponse> getProductReviews(Long productId)
    {
        if (!productRepository.existsById(productId))
        {
            throw new RuntimeException("Product not found");
        }

        return reviewRepository.findByProductId(productId).stream().map(this::convertToResponse).toList();
    }

    //To get reviews for a particular user
    public List<ReviewResponse> getUserReviews(String username)
    {
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        return reviewRepository.findByUserId(user.getId()).stream().map(this::convertToResponse).toList();
    }

    // Updates review
    public ReviewResponse updateReview(Long reviewId, String username, ReviewRequest request)
    {
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        Review review = reviewRepository.findById(reviewId).orElseThrow(() -> new RuntimeException("Review not found"));

        //To avoid another user from changing another's review
        if (!review.getUser().getId().equals(user.getId()))
        {
            throw new RuntimeException("You can only update your own review");
        }

        if (request.getRating() < 1 || request.getRating() > 5)
        {
            throw new RuntimeException("Rating must be between 1 and 5");
        }

        review.setRating(request.getRating());

        review.setComment(request.getComment());

        Review updatedReview = reviewRepository.save(review);

        return convertToResponse(updatedReview);
    }

    //Deletes review
    public void deleteReview(Long reviewId, String username)
    {
        User user = userRepository.findByUsername(username).orElseThrow(() -> new RuntimeException("User not found"));

        Review review = reviewRepository.findById(reviewId).orElseThrow(() -> new RuntimeException("Review not found"));

        if (!review.getUser().getId().equals(user.getId()))
        {
            throw new RuntimeException("You can only delete your own review");
        }

        reviewRepository.delete(review);
    }

    private ReviewResponse convertToResponse(Review review)
    {
        return new ReviewResponse(review.getId(), review.getUser().getId(), review.getUser().getUsername(), review.getProduct().getId(), review.getProduct().getName(), review.getRating(), review.getComment());
    }
}
