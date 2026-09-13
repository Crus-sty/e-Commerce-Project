using System;
using System.Collections.Generic;
using System.Linq;
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

                int cartTotal = GetCartItemCount();
                int wishlistTotal = GetWishlistItemCount();

                cartIcon.Attributes["data-notify"] = cartTotal.ToString();
                wishlistIcon.Attributes["data-notify"] = wishlistTotal.ToString();

                SetActiveMenu();
            }


        }

        protected void accountLink_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {

                Response.Redirect("account-info.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Add code to handle newsletter subscription

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("sign-up.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("history.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("home.aspx");
        }
        protected void btn_Orderhistory_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("history.aspx");
            }
            else
            {
                Response.Redirect("login.aspx");
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
            string current = Session["Page"].ToString();

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