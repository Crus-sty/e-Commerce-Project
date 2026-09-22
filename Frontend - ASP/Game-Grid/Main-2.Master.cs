using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.UI;

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

            SetActiveMenu();
        }


        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


        protected void btn_Orderhistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/history.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


        protected void accountLink_Click(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                Response.Redirect("~/account.aspx", false);
            }
            else
            {
                Response.Redirect("~/login.aspx", false);
            }

            Context.ApplicationInstance.CompleteRequest();
        }


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sign-up.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/home.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }


        protected async void btnAddToCart_Click(object sender, EventArgs e)
        {
            string token = Session["Token"] as string;

            if (string.IsNullOrEmpty(token))
            {
                Response.Redirect("~/login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }

            try
            {
                int productId;

                if (!int.TryParse(hfProductId.Value, out productId))
                {
                    ShowAlert("Invalid product.");
                    return;
                }

                int quantity;

                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    quantity = 1;
                }

                if (quantity <= 0)
                {
                    quantity = 1;
                }

                var cartItem = new
                {
                    productId = productId,
                    quantity = quantity
                };

                string json =
                    JsonConvert.SerializeObject(cartItem);

                using (HttpClient client = new HttpClient())
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
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        Response.Redirect(
                            "~/shopping-cart.aspx",
                            false);

                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else if (response.StatusCode ==
                             System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Remove("Token");
                        Session.Remove("email");

                        Response.Redirect(
                            "~/login.aspx",
                            false);

                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Response.Write(
                            "Could not add to cart. Status: " +
                            response.StatusCode +
                            "<br/>" +
                            responseText);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "Error adding to cart: " +
                    ex.Message);
            }
        }


        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Newsletter subscription code can be added here.
        }


        private int GetCartItemCount()
        {
            if (Session["CartCount"] != null)
            {
                return Convert.ToInt32(
                    Session["CartCount"]);
            }

            return 0;
        }


        private int GetWishlistItemCount()
        {
            if (Session["WishlistCount"] != null)
            {
                return Convert.ToInt32(
                    Session["WishlistCount"]);
            }

            return 0;
        }


        private void SetActiveMenu()
        {
            string current =
                Session["Page"] as string ?? "";

            homeMenu.Attributes["class"] = "";
            shopMenu.Attributes["class"] = "";
            aboutMenu.Attributes["class"] = "";
            contactMenu.Attributes["class"] = "";

            switch (current)
            {
                case "home.aspx":
                    homeMenu.Attributes["class"] =
                        "active-menu";
                    break;

                case "product.aspx":
                    shopMenu.Attributes["class"] =
                        "active-menu";
                    break;

                case "about.aspx":
                    aboutMenu.Attributes["class"] =
                        "active-menu";
                    break;

                case "contact.aspx":
                    contactMenu.Attributes["class"] =
                        "active-menu";
                    break;
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
                "alert_" +
                Guid.NewGuid().ToString("N"),
                "alert('" +
                safe +
                "');",
                true);
        }
    }
}