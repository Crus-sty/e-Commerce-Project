using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class Main_2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] != null)
                {
                    btnSignUp.Visible = false;
                    btnLogin.Visible = false;
                    btnAccount.Visible = true;
                    btnHistory.Visible = true;
                    btnLogout.Visible = true;
                }
                else
                {
                    btnSignUp.Visible = true;
                    btnLogin.Visible = true;
                    btnAccount.Visible = false;
                    btnHistory.Visible = false;
                    btnLogout.Visible = false;
                }
            }

                int cartTotal = GetCartItemCount();
                int wishlistTotal = GetWishlistItemCount();

                cartIcon.Attributes["data-notify"] = cartTotal.ToString();
                wishlistIcon.Attributes["data-notify"] = wishlistTotal.ToString();

                SetActiveMenu();


        }

        protected void accountLink_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {

                Response.Redirect("/account");
            }
            else
            {
                Response.Redirect("/login");
            }
        }

        protected async void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Product ID from the hidden field
                int productId;
                if (!int.TryParse(hfProductId.Value, out productId) || productId <= 0)
                {
                    ShowAlert("No product selected. Please try again.");
                    return;
                }

                // 2. Quantity
                int quantity;
                if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 1)
                {
                    quantity = 1;
                }

                // 3. Logged-in user's email
                string email = Session["email"] as string;
                if (string.IsNullOrEmpty(email))
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                // 4. Build JSON payload
                var cartData = new
                {
                    productId = productId,
                    quantity = quantity,
                    email = email
                };

                string json = JsonConvert.SerializeObject(cartData);

                // 5. POST to Spring Boot
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8080/");

                    var content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    HttpResponseMessage response =
                        await client.PostAsync("api/cart/add", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Update cart badge in session
                        int current = 0;
                        int.TryParse(Session["CartCount"]?.ToString(), out current);
                        Session["CartCount"] = current + quantity;

                        Response.Redirect("cart.aspx");
                    }
                    else
                    {
                        string errorBody = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(
                            $"=== Cart API error {response.StatusCode}: {errorBody}");
                        ShowAlert("Could not add to cart. Status: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("=== EXCEPTION: " + ex.ToString());
                ShowAlert("Error: " + ex.Message);
            }
        }
        private void ShowAlert(string message)
        {
            string safe = message
                .Replace("\\", "\\\\")
                .Replace("'", "\\'")
                .Replace("\r", "")
                .Replace("\n", "\\n");

            Page.ClientScript.RegisterStartupScript(
                this.GetType(),
                "alert_" + Guid.NewGuid().ToString("N"),
                "alert('" + safe + "');",
                true
            );
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Add code to handle newsletter subscription

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("/sign-up");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/login");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("/account/history");
            }
            else
            {
                Response.Redirect("/login");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/home");
        }
        protected void btn_Orderhistory_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("/account/history");
            }
            else
            {
                Response.Redirect("/login");
            }
        }

        //Helper Functions No Parameters
        private int GetCartItemCount()
        {
            if (Session["CartCount"] != null)
                return Convert.ToInt32(Session["CartCount"]);
            return 0;
        }

        private int GetWishlistItemCount()
        {
            if (Session["WishlistCount"] != null)
                return Convert.ToInt32(Session["WishlistCount"]);
            return 0;
        }

        private void SetActiveMenu()
        {
            string current = Session["Page"] as string ?? "";

            homeMenu.Attributes["class"] = "";
            shopMenu.Attributes["class"] = "";
            aboutMenu.Attributes["class"] = "";
            contactMenu.Attributes["class"] = "";

            // Apply to the right one
            switch (current)
            {
                case "home.aspx":
                    homeMenu.Attributes["class"] = "active-menu";
                    break;

                case "shop.aspx":
                    shopMenu.Attributes["class"] = "active-menu";
                    break;

                case "about.aspx":
                    aboutMenu.Attributes["class"] = "active-menu";
                    break;

                case "contact.aspx":
                    contactMenu.Attributes["class"] = "active-menu";
                    break;
            }
        }
    }
}