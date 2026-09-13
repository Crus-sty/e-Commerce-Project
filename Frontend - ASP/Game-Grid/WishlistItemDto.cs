using System;

namespace Game_Grid.Models
{
    public class WishlistItemDto
    {
        public long id { get; set; }

        public long productId { get; set; }

        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }

        public string ProductName
        {
            get
            {
                return productName;
            }
        }

        public string ProductImage
        {
            get
            {
                return productImage;
            }
        }

        public double ProductPrice
        {
            get
            {
                return price;
            }
        }

        public long ProductID
        {
            get
            {
                return productId;
            }
        }
    }
}