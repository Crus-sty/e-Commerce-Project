using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class product_mod : System.Web.UI.Page
    {
        private const string API_URL = "http://localhost:8080/api/products";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                await LoadProducts();
            }
        }

        // LOAD ALL PRODUCTS
        private async Task LoadProducts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    string response = await client.GetStringAsync(API_URL);

                    List<ProductDto> products =
                        JsonConvert.DeserializeObject<List<ProductDto>>(response);

                    rptCart.DataSource = products;
                    rptCart.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Could not load products: " + ex.Message;
            }
        }


        // SEARCH PRODUCT
        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txt_id.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a Product ID.";
                return;
            }

            if (!long.TryParse(txt_id.Text.Trim(), out long productId))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Product ID must be a number.";
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    HttpResponseMessage response =
                        await client.GetAsync(API_URL + "/" + productId);

                    if (!response.IsSuccessStatusCode)
                    {
                        ClearFields();

                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text =
                            "Product not found. Status: " +
                            response.StatusCode;

                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();

                    ProductDto product =
                        JsonConvert.DeserializeObject<ProductDto>(json);

                    if (product == null)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Product was not found.";
                        return;
                    }

                    // Fill the form
                    txt_id.Text = product.id.ToString();
                    txt_name.Text = product.name;
                    txt_brand.Text = product.brand; 
                    txt_price.Text = product.price.ToString("F2");
                    txt_qty.Text = product.stockQuantity.ToString();
                    txt_desc.Text = product.description;

                    txt_image1.Text = product.imageUrl;
                    txt_image2.Text = product.imageUrl2;
                    txt_image3.Text = product.imageUrl3;

                    // Select category
                    if (!string.IsNullOrEmpty(product.category))
                    {
                        ListItem item =
                            ddlCategory.Items.FindByValue(product.category);

                        if (item != null)
                        {
                            ddlCategory.SelectedValue = product.category;
                        }
                    }

                    DisableFields();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text =
                        "Product " + product.id + " loaded successfully.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text =
                    "Error searching for product: " + ex.Message;
            }
        }

        // EDIT PRODUCT

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_id.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Search for a product first.";
                return;
            }

            EnableFields();

            // Product ID should never be edited
            txt_id.Enabled = false;

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text =
                "You can now edit the product details.";
        }

      
        // SAVE CHANGES
 
        protected async void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!long.TryParse(txt_id.Text.Trim(), out long productId))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid Product ID.";
                return;
            }

            if (!ValidateProductFields())
            {
                return;
            }

            ProductRequestDto product = CreateProductRequest();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    string json =
                        JsonConvert.SerializeObject(product);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            API_URL + "/" + productId,
                            content
                        );

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Green;

                        lblMessage.Text =
                            "Product updated successfully.";

                        DisableFields();

                        LoadProducts();
                    }
                    else
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Could not update product. Status: " +
                            response.StatusCode +
                            " " +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error updating product: " +
                    ex.Message;
            }
        }

        // ADD PRODUCT
        protected async void btnaddproduct_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            // Clear the form before adding
            txt_id.Text = "";

            if (!ValidateProductFields())
            {
                return;
            }

            ProductRequestDto product = CreateProductRequest();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    string json =
                        JsonConvert.SerializeObject(product);

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PostAsync(
                            API_URL,
                            content
                        );

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ProductDto createdProduct =
                            JsonConvert.DeserializeObject<ProductDto>(
                                responseText
                            );

                        lblMessage.ForeColor =
                            System.Drawing.Color.Green;

                        lblMessage.Text =
                            "Product added successfully. Product ID: " +
                            createdProduct.id;

                        // Put generated ID into the form
                        txt_id.Text =
                            createdProduct.id.ToString();

                        DisableFields();

                        LoadProducts();
                    }
                    else
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Could not add product. Status: " +
                            response.StatusCode +
                            " " +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error adding product: " +
                    ex.Message;
            }
        }

       
        // DELETE PRODUCT
        
        protected async void btndeleteproduct_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!long.TryParse(txt_id.Text.Trim(), out long productId))
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Enter a valid Product ID to delete.";

                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            API_URL + "/" + productId
                        );

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Green;

                        lblMessage.Text =
                            "Product deleted successfully.";

                        ClearFields();
                        DisableFields();

                        LoadProducts();
                    }
                    else
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Could not delete product. Status: " +
                            response.StatusCode +
                            " " +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error deleting product: " +
                    ex.Message;
            }
        }

      
        // CREATE REQUEST OBJECT
      
        private ProductRequestDto CreateProductRequest()
        {
            double price;
            int quantity;

            double.TryParse(
                txt_price.Text.Trim(),
                out price
            );

            int.TryParse(
                txt_qty.Text.Trim(),
                out quantity
            );

            return new ProductRequestDto
            {
                name = txt_name.Text.Trim(),
                brand = txt_brand.Text.Trim(),
                description = txt_desc.Text.Trim(),
                price = price,
                stockQuantity = quantity,
                category = ddlCategory.SelectedValue,
                imageUrl = txt_image1.Text.Trim(),
                imageUrl2 = txt_image2.Text.Trim(),
                imageUrl3 = txt_image3.Text.Trim()
            };
        }

        // VALIDATE FORM
       
        private bool ValidateProductFields()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                ShowError("Please enter a product name.");
                return false;
            }

            if (!double.TryParse(
                    txt_price.Text.Trim(),
                    out double price))
            {
                ShowError("Please enter a valid price.");
                return false;
            }

            if (price < 0)
            {
                ShowError("Price cannot be negative.");
                return false;
            }

            if (!int.TryParse(
                    txt_qty.Text.Trim(),
                    out int quantity))
            {
                ShowError("Please enter a valid quantity.");
                return false;
            }

            if (quantity < 0)
            {
                ShowError("Quantity cannot be negative.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_desc.Text))
            {
                ShowError("Please enter a product description.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                    ddlCategory.SelectedValue))
            {
                ShowError("Please select a product category.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_image1.Text))
            {
                ShowError("Please enter Product Image 1.");
                return false;
            }

            return true;
        }


        // ENABLE / DISABLE FIELDS
    
        private void EnableFields()
        {
            txt_name.Enabled = true;
            txt_brand.Enabled = true;
            txt_price.Enabled = true;
            txt_qty.Enabled = true;
            txt_desc.Enabled = true;

            ddlCategory.Enabled = true;

            txt_image1.Enabled = true;
            txt_image2.Enabled = true;
            txt_image3.Enabled = true;
        }

        private void DisableFields()
        {
            txt_name.Enabled = false;
            txt_brand.Enabled = false;
            txt_price.Enabled = false;
            txt_qty.Enabled = false;
            txt_desc.Enabled = false;

            ddlCategory.Enabled = false;

            txt_image1.Enabled = false;
            txt_image2.Enabled = false;
            txt_image3.Enabled = false;
        }

        // CLEAR FORM
     
        private void ClearFields()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_brand.Text = "";
            txt_price.Text = "";
            txt_qty.Text = "";
            txt_desc.Text = "";

            txt_image1.Text = "";
            txt_image2.Text = "";
            txt_image3.Text = "";

            ddlCategory.SelectedIndex = 0;
        }

      
        // ERROR MESSAGE
      
        private void ShowError(string message)
        {
            lblMessage.ForeColor =
                System.Drawing.Color.Red;

            lblMessage.Text = message;
        }

       
        // PRODUCT RESPONSE DTO
      
        public class ProductDto
        {
            public long id { get; set; }

            public string name { get; set; }

            public string brand { get; set; }

            public string description { get; set; }

            public double price { get; set; }

            public int stockQuantity { get; set; }

            public string category { get; set; }

            public string imageUrl { get; set; }

            public string imageUrl2 { get; set; }

            public string imageUrl3 { get; set; }
        }

        // PRODUCT REQUEST DTO
    
        public class ProductRequestDto
        {
            public string name { get; set; }

            public string brand { get; set; }

            public string description { get; set; }

            public double price { get; set; }

            public int stockQuantity { get; set; }

            public string category { get; set; }

            public string imageUrl { get; set; }

            public string imageUrl2 { get; set; }

            public string imageUrl3 { get; set; }
        }
    }
}