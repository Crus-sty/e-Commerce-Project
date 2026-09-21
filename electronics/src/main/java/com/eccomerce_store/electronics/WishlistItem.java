package com.eccomerce_store.electronics;

import jakarta.persistence.*;

@Entity
@Table(name = "wishlistitem", uniqueConstraints = @UniqueConstraint(name = "uk_wishlistitem_wishlist_product",
                columnNames = { "WishlistID", "ProductID" }
        )
)
public class WishlistItem {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "WishlistItemID")
    private Long id;

    /**
     * The wishlist this item belongs to.
     * Column in DB is WishlistID (FK → wishlist.WishlistID).
     */
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "WishlistID", nullable = false)
    private Wishlist wishlist;

    /**
     * The product being wishlisted.
     * Column in DB is ProductID (FK → product.ProductID).
     */
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "ProductID", nullable = false)
    private Product product;

    // ---------------------------------------------------------------
    // Constructors
    // ---------------------------------------------------------------
    public WishlistItem() { }

    public WishlistItem(Wishlist wishlist, Product product) {
        this.wishlist = wishlist;
        this.product = product;
    }

    // Getters and setters

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Wishlist getWishlist() {
        return wishlist;
    }

    public void setWishlist(Wishlist wishlist) {
        this.wishlist = wishlist;
    }

    public Product getProduct() {
        return product;
    }

    public void setProduct(Product product) {
        this.product = product;
    }
}