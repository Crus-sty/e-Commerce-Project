using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class payment : System.Web.UI.Page
    {
        private const string CART_API_URL = "http://localhost:8080/api/cart";
        private const string PAYMENT_API_URL = "http://localhost:8080/api/payment/process";

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

                await LoadCartTotals(token);
            }
        }

        // LOAD TOTALS FROM SPRING /api/cart
        private async Task LoadCartTotals(string token)
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
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Could not load cart. Status: " + response.StatusCode;
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    CartResponse cart = JsonConvert.DeserializeObject<CartResponse>(json);

                    var items = cart?.items ?? new List<CartItemDto>();

                    _subtotal = items.Sum(i => i.Total);
                    _vat = _subtotal * 0.15m;
                    _shipping = _subtotal > 0 ? 300m : 0m;
                    _total = _subtotal + _vat + _shipping;

                    lblSubtotal.Text = _subtotal.ToString("F2");
                    lblVat.Text = _vat.ToString("F2");
                    lblShipping.Text = _shipping.ToString("F2");
                    lblTotal.Text = _total.ToString("F2");

                    // Cache for later (in case of postback)
                    Session["CartSubtotal"] = _subtotal;
                    Session["CartVat"] = _vat;
                    Session["CartShipping"] = _shipping;
                    Session["CartTotal"] = _total;

                    if (_subtotal <= 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Your cart is empty. Add products before paying.";
                        btnPay.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error loading cart: " + ex.Message;
            }
        }

        // PAY NOW
       
        protected async void btnPay_Click(object sender, EventArgs e)
        {
            string token = Session["Token"] as string;
            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("/login");
                return;
            }

            //  read inputs 
            string cardNumber = NormalizeCardNumber(txtCardNumber.Text);
            string cardHolderName = txtName.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            // Reset border colors
            txtCardNumber.BorderColor = System.Drawing.Color.Empty;
            txtName.BorderColor = System.Drawing.Color.Empty;
            txtExpiryDate.BorderColor = System.Drawing.Color.Empty;
            txtCVV.BorderColor = System.Drawing.Color.Empty;

            // Required field check 
            bool missing = false;
            if (string.IsNullOrEmpty(cardNumber)) { txtCardNumber.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrEmpty(cardHolderName)) { txtName.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrEmpty(expiryDate)) { txtExpiryDate.BorderColor = System.Drawing.Color.Red; missing = true; }
            if (string.IsNullOrEmpty(cvv)) { txtCVV.BorderColor = System.Drawing.Color.Red; missing = true; }

            if (missing)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please complete all fields.";
                return;
            }

            
            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                txtCardNumber.BorderColor = System.Drawing.Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a valid 16-digit card number.";
                return;
            }

            //3 digits
            if (cvv.Length != 3 || !cvv.All(char.IsDigit))
            {
                txtCVV.BorderColor = System.Drawing.Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a valid 3-digit CVV.";
                return;
            }

          
            if (!IsValidExpiry(expiryDate))
            {
                txtExpiryDate.BorderColor = System.Drawing.Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Expiry date must be in MM/YY format and not in the past.";
                return;
            }

            // Amount from cached session 
            decimal amount = 0m;
            if (Session["CartTotal"] != null)
                amount = Convert.ToDecimal(Session["CartTotal"], CultureInfo.InvariantCulture);

            if (amount <= 0m)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Your cart total is invalid. Please refresh.";
                return;
            }

            // Call  payment API 
            try
            {
                var payload = new PaymentPayload
                {
                    cardNumber = cardNumber,
                    cardHolderName = cardHolderName,
                    expiryDate = expiryDate,
                    cvv = cvv
                };

                string json = JsonConvert.SerializeObject(payload);

                string url = PAYMENT_API_URL + "?amount=" +
                    amount.ToString(CultureInfo.InvariantCulture);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseText = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Payment failed: " + responseText;
                        return;
                    }

                    
                    // await ClearCartOnServer(token);

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Payment successful! Redirecting...";

                    // Clear the local cart cache
                    Session.Remove("CartSubtotal");
                    Session.Remove("CartVat");
                    Session.Remove("CartShipping");
                    Session.Remove("CartTotal");

                    // Give the browser a moment to show the message
                    Response.AddHeader("Refresh", "2;url=/account/history");
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error processing payment: " + ex.Message;
            }
        }

        // HELPERS
     
        private static string NormalizeCardNumber(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return string.Empty;
            return new string(raw.Where(char.IsDigit).ToArray());
        }

       
        private static bool IsValidExpiry(string expiry)
        {
            if (string.IsNullOrEmpty(expiry)) return false;

            var match = Regex.Match(expiry, @"^(0[1-9]|1[0-2])\s*\/\s*(\d{2})$");
            if (!match.Success) return false;

            int month = int.Parse(match.Groups[1].Value);
            int year = 2000 + int.Parse(match.Groups[2].Value);

            // Last moment of the expiry month
            var expiryEnd = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);

            return expiryEnd >= DateTime.Today;
        }
    }

  
    public class PaymentPayload
    {
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }
        public string expiryDate { get; set; }
        public string cvv { get; set; }
    }
}