using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class payment : System.Web.UI.Page
    {
        private const string CART_API_URL =
            "http://localhost:8080/api/cart";

        private const string PAYMENT_API_URL =
            "http://localhost:8080/api/payment/process";

        private const string CHECKOUT_API_URL =
            "http://localhost:8080/api/checkout";


        private decimal _subtotal;
        private decimal _vat;
        private decimal _shipping;
        private decimal _total;


        
        // PAGE LOAD
       
        protected async void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                string token =
                    Session["Token"] as string;


                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect(
                        "/login",
                        false
                    );

                    Context.ApplicationInstance
                        .CompleteRequest();

                    return;
                }


                // Make sure a shipping address exists
                string address =
                    BuildShippingAddress();

                if (string.IsNullOrEmpty(address))
                {
                    Response.Redirect(
                        "/cart/checkout",
                        false
                    );

                    Context.ApplicationInstance
                        .CompleteRequest();

                    return;
                }


                await LoadCartTotals(token);
            }
        }


       
        // LOAD CART TOTALS
      
        private async Task LoadCartTotals(
            string token)
        {
            try
            {
                using (HttpClient client =
                       new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token
                        );


                    HttpResponseMessage response =
                        await client.GetAsync(
                            CART_API_URL
                        );


                    if (response.StatusCode ==
                        System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Clear();

                        Response.Redirect(
                            "/login",
                            false
                        );

                        Context.ApplicationInstance
                            .CompleteRequest();

                        return;
                    }


                    if (!response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Could not load cart. Status: "
                            + response.StatusCode;

                        return;
                    }


                    string json =
                        await response.Content
                            .ReadAsStringAsync();


                    CartResponse cart =
                        JsonConvert.DeserializeObject<CartResponse>(
                            json
                        );


                    var items =
                        cart?.items ??
                        new List<CartItemDto>();


                    // Calculate totals
                    _subtotal =
                        items.Sum(i => i.Total);

                    _vat =
                        _subtotal * 0.15m;

                    _shipping =
                        _subtotal < 1600
                            ? 300m
                            : 0m;

                    _total =
                        _subtotal +
                        _shipping;


                    // Display totals
                    lblSubtotal.Text =
                        _subtotal.ToString("F2");

                    lblVat.Text =
                        _vat.ToString("F2");

                    lblShipping.Text =
                        _shipping.ToString("F2");

                    lblTotal.Text =
                        _total.ToString("F2");


                    // Store totals
                    Session["CartSubtotal"] =
                        _subtotal;

                    Session["CartVat"] =
                        _vat;

                    Session["CartShipping"] =
                        _shipping;

                    Session["CartTotal"] =
                        _total;


                    if (_subtotal <= 0)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Your cart is empty. Add products before paying.";

                        btnPay.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error loading cart: "
                    + ex.Message;
            }
        }

        // PAY NOW
        protected async void btnPay_Click(
            object sender,
            EventArgs e)
        {
            string token =
                Session["Token"] as string;


            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect(
                    "/login",
                    false
                );

                Context.ApplicationInstance
                    .CompleteRequest();

                return;
            }


         
            // READ PAYMENT DETAILS
            
            string cardNumber =
                NormalizeCardNumber(
                    txtCardNumber.Text
                );

            string cardHolderName =
                txtName.Text.Trim();

            string expiryDate =
                txtExpiryDate.Text.Trim();

            string cvv =
                txtCVV.Text.Trim();


            
            // RESET BORDERS
           
            txtCardNumber.BorderColor =
                System.Drawing.Color.Empty;

            txtName.BorderColor =
                System.Drawing.Color.Empty;

            txtExpiryDate.BorderColor =
                System.Drawing.Color.Empty;

            txtCVV.BorderColor =
                System.Drawing.Color.Empty;

            lblMessage.Text = "";


            
            // REQUIRED FIELD VALIDATION
           
            bool missing = false;


            if (string.IsNullOrEmpty(cardNumber))
            {
                txtCardNumber.BorderColor =
                    System.Drawing.Color.Red;

                missing = true;
            }


            if (string.IsNullOrEmpty(cardHolderName))
            {
                txtName.BorderColor =
                    System.Drawing.Color.Red;

                missing = true;
            }


            if (string.IsNullOrEmpty(expiryDate))
            {
                txtExpiryDate.BorderColor =
                    System.Drawing.Color.Red;

                missing = true;
            }


            if (string.IsNullOrEmpty(cvv))
            {
                txtCVV.BorderColor =
                    System.Drawing.Color.Red;

                missing = true;
            }


            if (missing)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please complete all fields.";

                return;
            }


            
            // CARD NUMBER VALIDATION
            
            if (cardNumber.Length != 16 ||
                !cardNumber.All(char.IsDigit))
            {
                txtCardNumber.BorderColor =
                    System.Drawing.Color.Red;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please enter a valid 16-digit card number.";

                return;
            }


           
            // CVV VALIDATION
            
            if (cvv.Length != 3 ||
                !cvv.All(char.IsDigit))
            {
                txtCVV.BorderColor =
                    System.Drawing.Color.Red;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Please enter a valid 3-digit CVV.";

                return;
            }


          
            // EXPIRY VALIDATION
           
            if (!IsValidExpiry(expiryDate))
            {
                txtExpiryDate.BorderColor =
                    System.Drawing.Color.Red;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Expiry date must be in MM/YY format and not in the past.";

                return;
            }


        
            // GET TOTAL
            
            decimal amount = 0m;


            if (Session["CartTotal"] != null)
            {
                amount =
                    Convert.ToDecimal(
                        Session["CartTotal"],
                        CultureInfo.InvariantCulture
                    );
            }


            if (amount <= 0m)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Your cart total is invalid. Please refresh.";

                return;
            }


            
            //  PROCESS PAYMENT
           
            try
            {
                var paymentPayload =
                    new PaymentPayload
                    {
                        cardNumber = cardNumber,

                        cardHolderName =
                            cardHolderName,

                        expiryDate =
                            expiryDate,

                        cvv = cvv
                    };


                string paymentJson =
                    JsonConvert.SerializeObject(
                        paymentPayload
                    );


                string paymentUrl =
                    PAYMENT_API_URL +
                    "?amount=" +
                    amount.ToString(
                        CultureInfo.InvariantCulture
                    );


                using (HttpClient client =
                       new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token
                        );


                    var paymentContent =
                        new StringContent(
                            paymentJson,
                            Encoding.UTF8,
                            "application/json"
                        );


                    HttpResponseMessage paymentResponse =
                        await client.PostAsync(
                            paymentUrl,
                            paymentContent
                        );


                    string paymentResponseText =
                        await paymentResponse.Content
                            .ReadAsStringAsync();


                    // PAYMENT FAILED
                   
                    if (!paymentResponse.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Payment failed: "
                            + paymentResponseText;

                        return;
                    }


                   
                    // CREATE ORDER
                 
                    bool orderCreated =
                        await CreateOrder(
                            token,
                            paymentResponseText
                        );


                    if (!orderCreated)
                    {
                        return;
                    }


                   
                    // SUCCESS
                   

                    lblMessage.ForeColor =
                        System.Drawing.Color.Green;

                    lblMessage.Text =
                        "Payment successful! Your order has been placed.";


                    // Clear checkout session
                    Session.Remove(
                        "CheckoutAddress1"
                    );

                    Session.Remove(
                        "CheckoutAddress2"
                    );

                    Session.Remove(
                        "CheckoutSuburb"
                    );

                    Session.Remove(
                        "CheckoutCity"
                    );

                    Session.Remove(
                        "CheckoutZip"
                    );


                    // Clear cart totals
                    Session.Remove(
                        "CartSubtotal"
                    );

                    Session.Remove(
                        "CartVat"
                    );

                    Session.Remove(
                        "CartShipping"
                    );

                    Session.Remove(
                        "CartTotal"
                    );


                    // Redirect to order history
                    Response.Redirect(
                        "/account/history",
                        false
                    );

                    Context.ApplicationInstance
                        .CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error processing payment: "
                    + ex.Message;
            }
        }


       
        // CREATE ORDER AFTER SUCCESSFUL PAYMENT
     
        private async Task<bool> CreateOrder(
            string token,
            string paymentResponseText)
        {
            try
            {
                // Build shipping address
                string shippingAddress =
                    BuildShippingAddress();


                if (string.IsNullOrWhiteSpace(
                    shippingAddress))
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text =
                        "Shipping address is missing.";

                    return false;
                }


               
                // CREATE CHECKOUT REQUEST
               
                var checkoutPayload =
                    new CheckoutRequestPayload
                    {
                        shippingAddress =
                            shippingAddress,

                        paymentMethod =
                            "CARD"
                    };


                string checkoutJson =
                    JsonConvert.SerializeObject(
                        checkoutPayload
                    );


                using (HttpClient client =
                       new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(
                            "Bearer",
                            token
                        );


                    var content =
                        new StringContent(
                            checkoutJson,
                            Encoding.UTF8,
                            "application/json"
                        );


                    HttpResponseMessage response =
                        await client.PostAsync(
                            CHECKOUT_API_URL,
                            content
                        );


                    string responseText =
                        await response.Content
                            .ReadAsStringAsync();


                    if (!response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        lblMessage.Text =
                            "Order creation failed: "
                            + responseText;

                        return false;
                    }


                    return true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                lblMessage.Text =
                    "Error creating order: "
                    + ex.Message;

                return false;
            }
        }


       
        // BUILD SHIPPING ADDRESS
       

        private string BuildShippingAddress()
        {
            string address1 =
                Session["CheckoutAddress1"]
                as string;

            string address2 =
                Session["CheckoutAddress2"]
                as string;

            string suburb =
                Session["CheckoutSuburb"]
                as string;

            string city =
                Session["CheckoutCity"]
                as string;

            string zip =
                Session["CheckoutZip"]
                as string;


            return string.Join(
                ", ",
                new[]
                {
                    address1,
                    address2,
                    suburb,
                    city,
                    zip
                }
                .Where(x =>
                    !string.IsNullOrWhiteSpace(x))
            );
        }


        
        // NORMALIZE CARD NUMBER
       
        private static string NormalizeCardNumber(
            string raw)
        {
            if (string.IsNullOrEmpty(raw))
            {
                return string.Empty;
            }


            return new string(
                raw.Where(char.IsDigit).ToArray()
            );
        }


        // EXPIRY VALIDATION
       
        private static bool IsValidExpiry(
            string expiry)
        {
            if (string.IsNullOrEmpty(expiry))
            {
                return false;
            }


            var match =
                Regex.Match(
                    expiry,
                    @"^(0[1-9]|1[0-2])\s*\/\s*(\d{2})$"
                );


            if (!match.Success)
            {
                return false;
            }


            int month =
                int.Parse(
                    match.Groups[1].Value
                );


            int year =
                2000 +
                int.Parse(
                    match.Groups[2].Value
                );


            DateTime expiryEnd =
                new DateTime(
                    year,
                    month,
                    1
                )
                .AddMonths(1)
                .AddDays(-1);


            return expiryEnd >= DateTime.Today;
        }
    }


   
    // PAYMENT PAYLOAD
    
    public class PaymentPayload
    {
        public string cardNumber { get; set; }

        public string cardHolderName { get; set; }

        public string expiryDate { get; set; }

        public string cvv { get; set; }
    }


    // CHECKOUT PAYLOAD
    

    public class CheckoutRequestPayload
    {
        public string shippingAddress { get; set; }

        public string paymentMethod { get; set; }
    }
}