using Newtonsoft.Json;

namespace Game_Grid
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("stockQuantity")]
        public int StockQuantity { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}