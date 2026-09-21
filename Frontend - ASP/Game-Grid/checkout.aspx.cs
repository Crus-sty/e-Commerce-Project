using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class checkout : System.Web.UI.Page
    {
        private const string CART_API_URL = "http://localhost:8080/api/cart";
        private const string CHECKOUT_API_URL = "http://localhost:8080/api/checkout";

        private decimal _subtotal;
        private decimal _vat;
        private decimal _shipping;
        private decimal _total;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = Session["Token"] as string;
                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("/login");
                    return;
                }

                // Pre-fill user details if we have them cached from login
                PrefillUserInfo();

                await LoadCart(token);
            }
        }

        // Pre-fill name/surname/email if the login page stored them
        
        private void PrefillUserInfo()
        {
            string name = Session["FirstName"] as string;
            string surname = Session["LastName"] as string;
            string email = Session["Email"] as string;

            if (!string.IsNullOrEmpty(name)) txtName.Text = name;
            if (!string.IsNullOrEmpty(surname)) txtSurname.Text = surname;
            if (!string.IsNullOrEmpty(email)) txtEmail.Text = email;
        }

        // LOAD CART from /api/cart and compute totals
    
        private async Task LoadCart(string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.GetAsync(CART_API_URL);

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Clear();
                        Response.Redirect("/login");
                        return;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Could not load cart. Status: " + response.StatusCode;
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    CartResponse cart = JsonConvert.DeserializeObject<CartResponse>(json);

                    var items = cart?.items ?? new List<CartItemDto>();

                    rptCart.DataSource = items;
                    rptCart.DataBind();

                    _subtotal = items.Sum(i => i.Total);
                    _vat = _subtotal * 0.15m;
                    _shipping = _subtotal < 1600 && _subtotal > 0 ? 300m : 0m;
                    _total = _subtotal + _shipping;

                    lblSubtotal.Text = _subtotal.ToString("F2");
                    lblVat.Text = _vat.ToString("F2");
                    lblShipping.Text = _shipping.ToString("F2");
                    lblTotal.Text = _total.ToString("F2");

                    // Cache for the payment page
                    Session["CartSubtotal"] = _subtotal;
                    Session["CartVat"] = _vat;
                    Session["CartShipping"] = _shipping;
                    Session["CartTotal"] = _total;

                    if (_subtotal <= 0)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Your cart is empty. Add products before checking out.";
                        btnPayment.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error loading cart: " + ex.Message;
            }
        }

        // PROCEED TO PAYMENT
       
        protected async void btnPayment_Click(object sender, EventArgs e)
        {
            string token = Session["Token"] as string;
            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("/login");
                return;
            }

            // Reset borders
            txtAddress1.BorderColor = System.Drawing.Color.Empty;
            txtCity.BorderColor = System.Drawing.Color.Empty;
            txtSuburb.BorderColor = System.Drawing.Color.Empty;
            txtZip.BorderColor = System.Drawing.Color.Empty;
            lblError.Text = "";

            // Validate required fields 
            bool missing = false;
            if (string.IsNullOrWhiteSpace(txtAddress1.Text)) { txtAddress1.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrWhiteSpace(txtCity.Text)) { txtCity.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrWhiteSpace(txtSuburb.Text)) { txtSuburb.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrWhiteSpace(txtZip.Text)) { txtZip.BorderColor = System.Drawing.Color.Red; missing = true; }

            if (missing)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Please fill in all required fields.";
                return;
            }

            // Cache the address for the payment page 
            Session["CheckoutAddress1"] = txtAddress1.Text.Trim();
            Session["CheckoutAddress2"] = txtAddress2.Text.Trim();
            Session["CheckoutSuburb"] = txtSuburb.Text.Trim();
            Session["CheckoutCity"] = txtCity.Text.Trim();
            Session["CheckoutZip"] = txtZip.Text.Trim();

            // Send checkout request to Spring 
            try
            {
                var payload = new CheckoutPayload
                {
                    addressLine1 = txtAddress1.Text.Trim(),
                    addressLine2 = txtAddress2.Text.Trim(),
                    suburb = txtSuburb.Text.Trim(),
                    city = txtCity.Text.Trim(),
                    zipCode = txtZip.Text.Trim()
                };

                string json = JsonConvert.SerializeObject(payload);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(CHECKOUT_API_URL, content);
                    string responseText = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Checkout failed: " + responseText;
                        return;
                    }

                    // Backend created the order — go to payment
                    Response.Redirect("/cart/checkout/payment");
                }
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error during checkout: " + ex.Message;
            }
        }
    }


    // CHECKOUT PAYLOAD — must match your CheckoutRequest.java field names
    
    public class CheckoutPayload
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
    }
}