using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        protected async void btnAddToCart_Click(object sender, EventArgs e)

        {
            string token = Session["Token"] as string;

            if (string.IsNullOrEmpty(token))
            {
                Response.Write("<h2>TOKEN IS EMPTY</h2>");
                return;
            }

          
              try
              {
                  // Get product ID from the hidden field
                  int productId;

                  if (!int.TryParse(hfProductId.Value, out productId))
                  {
                      return;
                  }

                  // Get quantity from the quantity textbox
                  int quantity;

                  if (!int.TryParse(txtQuantity.Text, out quantity))
                  {
                      quantity = 1;
                  }

                  if (quantity <= 0)
                  {
                      quantity = 1;
                  }

                // Create cart object
                var cartItem = new
                {
                    productId = productId,
                    quantity = quantity,
                   
                };

                string json = JsonConvert.SerializeObject(cartItem);

                  using (HttpClient client = new HttpClient())
                  {
                      // IMPORTANT:
                      // Send the JWT token to Spring Boot
                      client.DefaultRequestHeaders.Authorization =
                          new AuthenticationHeaderValue("Bearer", token);

                      StringContent content = new StringContent(
                          json,
                          Encoding.UTF8,
                          "application/json"
                      );

                      HttpResponseMessage response =
                          await client.PostAsync(
                              "http://localhost:8080/api/cart/add",
                              content
                          );

                      string responseText =
                          await response.Content.ReadAsStringAsync();

                      if (response.IsSuccessStatusCode)
                      {
                          // Product successfully added
                          Response.Redirect("shopping-cart.aspx");
                      }
                      else if (response.StatusCode ==
                               System.Net.HttpStatusCode.Unauthorized)
                      {
                          // Token was rejected by Spring Boot
                          Session.Remove("Token");

                          Response.Redirect("login.aspx");
                      }
                      else
                      {
                          // Show the actual backend error
                          Response.Write(
                              "Could not add to cart. Status: " +
                              response.StatusCode +
                              "<br/>" +
                              responseText
                          );
                      }
                  }
              }
              catch (Exception ex)
              {
                  Response.Write(
                      "Error adding to cart: " +
                      ex.Message
                  );
              }
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