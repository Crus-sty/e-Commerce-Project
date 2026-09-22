using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class product_detail : Page
    {
        private const string API_URL =
            "http://localhost:8080/api/products/";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadProduct();
            }
        }

        private async Task LoadProduct()
        {
            try
            {

                string productId = Page.RouteData.Values["id"] as string;
                if (string.IsNullOrEmpty(productId))
                {
                    productId = Request.QueryString["id"];
                }

                if (string.IsNullOrEmpty(productId))
                {
                    Response.Redirect("product.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                int id;

                if (!int.TryParse(productId, out id))
                {
                    Response.Redirect("product.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(API_URL + id);

                    string json =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ProductDto product =
                            JsonConvert.DeserializeObject<ProductDto>(json);

                        if (product == null)
                        {
                            lblMessage.Text =
                                "Product could not be found.";

                            return;
                        }

                        Page.Title = product.Name;

                        BindProduct(product);

                        // Wait for related products to finish loading
                        await LoadRelatedProducts(product);
                    }
                    else
                    {
                        lblMessage.Text =
                            "Could not load product. Status: "
                            + response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error loading product: " + ex.Message;
            }
        }

        private void BindProduct(ProductDto product)
        {
            List<ProductDto> products =
                new List<ProductDto>();

            products.Add(product);

            rptProduct.DataSource = products;
            rptProduct.DataBind();

            // Find txtQuantity INSIDE the Repeater
            if (rptProduct.Items.Count > 0)
            {
                TextBox txtQuantity =
                    (TextBox)rptProduct.Items[0]
                    .FindControl("txtQuantity");

                if (txtQuantity != null)
                {
                    txtQuantity.Text = "1";
                }
            }
        }

        private async Task LoadRelatedProducts(ProductDto currentProduct)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            "http://localhost:8080/api/products");

                    if (!response.IsSuccessStatusCode)
                    {
                        return;
                    }

                    string json =
                        await response.Content.ReadAsStringAsync();

                    List<ProductDto> products =
                        JsonConvert.DeserializeObject<List<ProductDto>>(json);

                    if (products == null)
                    {
                        return;
                    }

                    // Remove current product
                    products.RemoveAll(
                        p => p.Id == currentProduct.Id);

                    // Only show products from same category
                    if (!string.IsNullOrEmpty(currentProduct.Category))
                    {
                        products = products.FindAll(
                            p =>
                                p.Category != null &&
                                p.Category.Equals(
                                    currentProduct.Category,
                                    StringComparison.OrdinalIgnoreCase));
                    }

                    //  4 related products
                    if (products.Count > 4)
                    {
                        products = products.GetRange(0, 4);
                    }

                    rptRelatedProducts.DataSource = products;
                    rptRelatedProducts.DataBind();
                }
            }
            catch
            {
                // Related products are optional.
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button btn = (Button)sender;

            // Get the Repeater item
            RepeaterItem item =
                (RepeaterItem)btn.NamingContainer;

            // Find the quantity TextBox inside that Repeater item
            TextBox txtQuantity =
                (TextBox)item.FindControl("txtQuantity");

            int quantity = 1;

            if (txtQuantity != null)
            {
                if (!int.TryParse(
                    txtQuantity.Text,
                    out quantity))
                {
                    quantity = 1;
                }
            }

            if (quantity < 1)
            {
                quantity = 1;
            }

            // Get product ID
            string productId =
                Request.QueryString["id"];

            if (string.IsNullOrEmpty(productId))
            {
                lblMessage.Text =
                    "Product ID is missing.";

                return;
            }

            // For now, display the selected quantity
            lblMessage.Text =
                "Product ID: "
                + productId
                + " | Quantity: "
                + quantity;
        }
    }

    public class ProductDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int StockQuantity { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string ImageUrl2 { get; set; }

        public string ImageUrl3 { get; set; }
    }
}