using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class shopping_cart : System.Web.UI.Page
    {
        private const string API_URL = "http://localhost:8080/api/cart";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadCart();
            }
        }

        // LOAD CART
  
        private async Task LoadCart()
        {
            string token = Session["Token"] as string;

            // User is not logged in
            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response =
                        await client.GetAsync(API_URL);

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        CartResponse cart =
                            JsonConvert.DeserializeObject<CartResponse>(
                                responseText
                            );

                        if (cart != null && cart.items != null)
                        {
                            rptCart.DataSource = cart.items;
                            rptCart.DataBind();

                            CalculateTotals(cart.items);
                        }
                        else
                        {
                            List<CartItemDto> emptyCart =
                                new List<CartItemDto>();

                            rptCart.DataSource = emptyCart;
                            rptCart.DataBind();

                            CalculateTotals(emptyCart);
                        }
                    }
                    else if (response.StatusCode ==
                             System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Clear();

                        Response.Redirect("login.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                        return;
                    }
                    else
                    {
                        lblMessage.Text =
                            "Could not load cart. Status: " +
                            response.StatusCode +
                            "<br/>" +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error loading cart: " + ex.Message;
            }
        }

        // CALCULATE TOTALS
 

        private void CalculateTotals(List<CartItemDto> items)
        {
            decimal subtotal = 0;

            foreach (CartItemDto item in items)
            {
                subtotal += item.Total;
            }

            // VAT = 15%
            decimal vat = subtotal * 0.15m;

            // Shipping
            decimal shipping = 0;

            if (subtotal < 1600 && subtotal > 0)
            {
                shipping = 300;
            }

            decimal total = subtotal + shipping;

            lblSubtotal.Text = subtotal.ToString("F2");
            lblVat.Text = vat.ToString("F2");
            lblShipping.Text = shipping.ToString("F2");
            lblTotal.Text = total.ToString("F2");
        }


        // UPDATE CART ITEM


        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            string token = Session["Token"] as string;

            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                System.Web.UI.WebControls.Button button =
                    (System.Web.UI.WebControls.Button)sender;

                int productId;

                if (!int.TryParse(
                    button.CommandArgument,
                    out productId))
                {
                    lblMessage.Text = "Invalid product ID.";
                    return;
                }

                string quantityValue =
                    Request.Form["quantity_" + productId];

                int quantity;

                if (!int.TryParse(
                    quantityValue,
                    out quantity))
                {
                    lblMessage.Text =
                        "Please enter a valid quantity.";
                    return;
                }

                if (quantity <= 0)
                {
                    lblMessage.Text =
                        "Quantity must be greater than 0.";
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token
                        );

                    StringContent content =
                        new StringContent(
                            quantity.ToString(),
                            Encoding.UTF8,
                            "application/json"
                        );

                    HttpResponseMessage response =
                        await client.PutAsync(
                            API_URL +
                            "/update/" +
                            productId,
                            content
                        );

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text =
                            "Cart updated successfully.";

                        await LoadCart();
                    }
                    else
                    {
                        lblMessage.Text =
                            "Could not update cart. " +
                            "Status: " +
                            response.StatusCode +
                            "<br/>" +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error updating cart: " +
                    ex.Message;
            }
        }

        // REMOVE CART ITEM


        protected async void btnRemove_Click(object sender, EventArgs e)
        {
            string token = Session["Token"] as string;

            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                System.Web.UI.WebControls.Button button =
                    (System.Web.UI.WebControls.Button)sender;

                int productId;

                if (!int.TryParse(
                    button.CommandArgument,
                    out productId))
                {
                    lblMessage.Text =
                        "Invalid product ID.";

                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token
                        );

                    string url =
                        API_URL +
                        "/remove/" +
                        productId;

                    HttpResponseMessage response =
                        await client.DeleteAsync(url);

                    string responseText =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text =
                            "Item removed successfully.";

                        await LoadCart();
                    }
                    else
                    {
                        lblMessage.Text =
                            "Remove failed. " +
                            "Status: " +
                            response.StatusCode +
                            "<br/>Response: " +
                            responseText;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "Error removing item: " +
                    ex.Message;
            }
        }


        // APPLY COUPON
   

        protected void btnApplyCoupon_Click(
            object sender,
            EventArgs e)
        {
            string coupon = txtCoupon.Text.Trim();

            if (string.IsNullOrEmpty(coupon))
            {
                lblMessage.Text =
                    "Please enter a coupon code.";

                return;
            }

            lblMessage.Text =
                "Coupon functionality is not available yet.";
        }

        // CHECKOUT


        protected void btnCheckout_Click(
            object sender,
            EventArgs e)
        {
            string token = Session["Token"] as string;

            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            Response.Redirect("checkout.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    // CART RESPONSE
 

    public class CartResponse
    {
        public List<CartItemDto> items { get; set; }
    }

    
    // CART ITEM

    public class CartItemDto
    {
        public int productId { get; set; }

        public string productName { get; set; }

        public string productImage { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public decimal subtotal { get; set; }


        // PROPERTIES USED BY ASPX
     
        public int ProductID
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

        public decimal ProductPrice
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

        public decimal Total
        {
            get
            {
                return subtotal;
            }
        }
    }
}