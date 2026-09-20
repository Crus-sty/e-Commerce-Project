using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class shopping_cart : System.Web.UI.Page
    {
        // Cart API
        private const string API_URL = "http://localhost:8080/api/cart";


        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load the cart
                //await LoadCart();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/cart/checkout");
        }

        protected void btnApplyCoupon_Click(object sender, EventArgs e)
        {
            string newtottal = null;
            string couponCode = txtCouponCode.Text.Trim();
            Session["couponcode"] = couponCode;
            Session["discount"] = 0.0; //Percentage discount, 10% discount would be 0.1


            if (string.IsNullOrEmpty(couponCode))
            {
                lblCouponMessage.ForeColor = System.Drawing.Color.Red;
                lblCouponMessage.Text = "Please enter a coupon code.";
                return;
            }
            else
            {
                txtCouponCode.Enabled = false;
                lblDiscount.Visible = true;
                lblCouponMessage.Visible = true;
                lblDiscount.Text = "";
                newtottal = "";
                lblTotal.Text = newtottal;
            }
        }
        /*
        // LOAD CART
        private async Task LoadCart()
        {
            try
            {
                // Get JWT token from session
                string token = Session["Token"] as string;

                // If user is nott logged in
                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("login.aspx");
                    return;
                }


                using (HttpClient client = new HttpClient())
                {
                    // Send JWT token 
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);


                    // Call Spring Boot
                    HttpResponseMessage response =
                        await client.GetAsync(API_URL);


                    // Check response
                    if (!response.IsSuccessStatusCode)
                    {
                        Response.Write(
                            "<script>alert('Could not load cart. Status: "
                            + response.StatusCode
                            + "');</script>");

                        return;
                    }


                    // Read JSON response
                    string json =
                        await response.Content.ReadAsStringAsync();


                    // Convert JSON into CartResponse object
                    CartResponse cart = JsonConvert.DeserializeObject<CartResponse>(json);



                    if (cart != null)
                    {
                        // Display cart items
                        rptCart.DataSource = cart.items;
                        rptCart.DataBind();


                        // Subtotal
                        lblSubtotal.Text = "R " + cart.total.ToString("F2");



                        // VAT
                        double vat = cart.total * 0.15;

                        lblVat.Text = "R " + vat.ToString("F2");



                        // Shipping
                        double shipping = 300.00;

                        lblShipping.Text = "R " + shipping.ToString("F2");



                        // Final total
                        double finalTotal = cart.total + shipping;


                        lblTotal.Text = "R " + finalTotal.ToString("F2");

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "<script>alert('Error loading cart: "
                    + ex.Message.Replace("'", "")
                    + "');</script>");
            }
        }*/
        protected async void btnRemove_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Get JWT token
                string token = Session["Token"] as string;

                // Check if user is logged in
                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                // Get the Product ID from the Remove button
                string productId =
                    ((System.Web.UI.WebControls.Button)sender).CommandArgument;

                using (HttpClient client = new HttpClient())
                {
                    // Send JWT token
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    // Call Spring Boot DELETE endpoint
                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            API_URL + "/remove/" + productId);

                    // If successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Reload cart
                        await LoadCart();
                    }
                    else
                    {
                        string message =
                            await response.Content.ReadAsStringAsync();

                        Response.Write(
                            "<script>alert('"
                            + message.Replace("'", "")
                            + "');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "<script>alert('Error removing product: "
                    + ex.Message.Replace("'", "")
                    + "');</script>");
            }*/
        }

        // UPDATE QUANTITY
        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Get JWT token
                string token = Session["Token"] as string;


                // Check login
                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("login.aspx");
                    return;
                }


                // Get product ID from button
                string productId =
                    ((System.Web.UI.WebControls.Button)sender)
                    .CommandArgument;


                // Get quantity from the input box
                string quantityText = Request.Form["quantity_" + productId];



                int quantity;


                // Check quantity
                if (!int.TryParse(quantityText, out quantity))
                {
                    Response.Write(
                        "<script>alert('Invalid quantity.');</script>");

                    return;
                }


                using (HttpClient client = new HttpClient())
                {
                    // Send JWT
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);


                    // Create request body
                    var requestObject = new
                    {
                        quantity = quantity
                    };


                    // Convert request to JSON
                    string json = JsonConvert.SerializeObject(requestObject);



                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json");


                    // Call Spring Boot
                    HttpResponseMessage response = await client.PutAsync(API_URL + "/update/" + productId, content
                       );




                    // Check result
                    if (response.IsSuccessStatusCode)
                    {
                        // Reload cart
                        await LoadCart();
                    }
                    else
                    {
                        string message =
                            await response.Content.ReadAsStringAsync();


                        Response.Write(
                            "<script>alert('"
                            + message.Replace("'", "")
                            + "');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "<script>alert('Error updating cart: "
                    + ex.Message.Replace("'", "")
                    + "');</script>");
            }
        }*/
    }

    // CART RESPONSE

    /*public class CartResponse
    {
        public List<CartItemDto> items { get; set; }

        public double total { get; set; }
    }

    // CART ITEM
 

    public class CartItemDto
    {
        public long cartItemId { get; set; }

        public long productId { get; set; }

        public string productName { get; set; }

        public string productImage { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public double subtotal { get; set; }

        // Properties used by the ASPX Repeater

        public long ProductID
        {
            get
            {
                return productId;
            }
        }


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


        public int Quantity
        {
            get
            {
                return quantity;
            }
        }


        public double Total
        {
            get
            {
                return subtotal;
            }
        }*/
    }
}


        

    