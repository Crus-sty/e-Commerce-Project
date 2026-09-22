using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                string productId =
                    Page.RouteData.Values["id"] as string;

                if (string.IsNullOrEmpty(productId))
                {
                    productId =
                        Request.QueryString["id"];
                }

                if (string.IsNullOrEmpty(productId))
                {
                    lblMessage.Text =
                        "Product ID is missing.";

                    return;
                }

                int id;

                if (!int.TryParse(
                    productId,
                    out id))
                {
                    lblMessage.Text =
                        "Invalid product ID.";

                    return;
                }

                using (HttpClient client =
                       new HttpClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            API_URL + id);

                    string json =
                        await response.Content
                            .ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ProductDto product =
                            JsonConvert
                                .DeserializeObject<ProductDto>(
                                    json);

                        if (product == null)
                        {
                            lblMessage.Text =
                                "Product could not be found.";

                            return;
                        }

                        Page.Title = product.Name;

                        BindProduct(product);

                        await LoadRelatedProducts(product);
                    }
                    else
                    {
                        lblMessage.Text =
                            "Could not load product. Status: "
                            + response.StatusCode
                            + "<br/>"
                            + Server.HtmlEncode(json);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error loading product: "
                    + Server.HtmlEncode(ex.Message);
            }
        }


        private void BindProduct(ProductDto product)
        {
            List<ProductDto> products =
                new List<ProductDto>();

            products.Add(product);

            rptProduct.DataSource =
                products;

            rptProduct.DataBind();

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


        private async Task LoadRelatedProducts(
            ProductDto currentProduct)
        {
            try
            {
                using (HttpClient client =
                       new HttpClient())
                {
                    HttpResponseMessage response =
                        await client.GetAsync(
                            "http://localhost:8080/api/products");

                    if (!response.IsSuccessStatusCode)
                    {
                        return;
                    }

                    string json =
                        await response.Content
                            .ReadAsStringAsync();

                    List<ProductDto> products =
                        JsonConvert
                            .DeserializeObject<
                                List<ProductDto>>(json);

                    if (products == null)
                    {
                        return;
                    }

                    // Remove current product
                    products.RemoveAll(
                        p => p.Id ==
                             currentProduct.Id);

                    // Only products in same category
                    if (!string.IsNullOrEmpty(
                        currentProduct.Category))
                    {
                        products =
                            products.FindAll(
                                p =>
                                    p.Category != null &&
                                    p.Category.Equals(
                                        currentProduct.Category,
                                        StringComparison
                                            .OrdinalIgnoreCase));
                    }

                    // Maximum 4 related products
                    if (products.Count > 4)
                    {
                        products =
                            products.GetRange(0, 4);
                    }

                    rptRelatedProducts.DataSource =
                        products;

                    rptRelatedProducts.DataBind();
                }
            }
            catch
            {
                // Related products are optional.
            }
        }


        protected async void btnAddToCart_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // Check if the customer is logged in
     
                string token =
                    Session["Token"] as string;

                if (string.IsNullOrEmpty(token))
                {
                    lblMessage.Text =
                        "Please log in before adding a product to your cart.";

                    return;
                }
                //  Get the clicked button

                Button btn =
                    (Button)sender;


                // Get the Repeater item
     
                RepeaterItem item =
                    (RepeaterItem)btn.NamingContainer;

                // Get quantity
           
                TextBox txtQuantity =
                    (TextBox)item.FindControl(
                        "txtQuantity");

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
    
                string productIdText =
                    Page.RouteData.Values["id"] as string;

                if (string.IsNullOrEmpty(productIdText))
                {
                    productIdText =
                        Request.QueryString["id"];
                }


                int productId;

                if (!int.TryParse(
                    productIdText,
                    out productId))
                {
                    lblMessage.Text =
                        "Invalid product ID.";

                    return;
                }

                //  Create cart request
          
                var cartItem = new
                {
                    productId = productId,
                    quantity = quantity
                };


                //  Convert to JSON
       
                string json =
                    JsonConvert.SerializeObject(
                        cartItem);

                //  Send request to Spring Boot
    
                using (HttpClient client =
                       new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token);


                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json");


                    HttpResponseMessage response =
                        await client.PostAsync(
                            "http://localhost:8080/api/cart/add",
                            content);


                    string responseText =
                        await response.Content
                            .ReadAsStringAsync();


                   
                    //  Successful
         
                    if (response.IsSuccessStatusCode)
                    {
                        Response.Redirect(
                            "~/shopping-cart.aspx",
                            false);

                        Context.ApplicationInstance
                            .CompleteRequest();

                        return;
                    }

                    //  Unauthorized

                    if (response.StatusCode ==
                        System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Remove("Token");
                        Session.Remove("email");

                        lblMessage.Text =
                            "Your session has expired. Please log in again.";

                        return;
                    }
                    //Other backend errors
                    
                    lblMessage.Text =
                        "Could not add product to cart."
                        + "<br/>Status: "
                        + response.StatusCode
                        + "<br/>"
                        + Server.HtmlEncode(
                            responseText);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error adding product to cart:"
                    + "<br/>"
                    + Server.HtmlEncode(
                        ex.Message);
            }
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