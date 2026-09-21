using Game_Grid.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class wishlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Token"] == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                BindWishlist();
            }
        }

        private void BindWishlist()
        {
            // --- DEBUG ---
            var token = Session["Token"] as string;
            litMessage.Text = "<div style='color:orange'>DEBUG Token=" +
                (string.IsNullOrEmpty(token) ? "(null or empty)" : "[" + token.Substring(0, Math.Min(20, token.Length)) + "...]") +
                "</div>";
            // --- END DEBUG ---
            try
            {
                var items = ApiClient.Get<List<WishlistItemDto>>("/api/wishlist");

                rptWishlist.DataSource = items ?? new List<WishlistItemDto>();
                rptWishlist.DataBind();
            }
            catch (Exception ex)
            {
                litMessage.Text =
                    "<div class='alert alert-danger'>Could not load wishlist: "
                    + Server.HtmlEncode(ex.Message) + "</div>";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var link = (LinkButton)sender;

            if (!long.TryParse(link.CommandArgument, out long productId))
            {
                litMessage.Text =
                    "<div class='alert alert-danger'>Invalid product id.</div>";
                return;
            }

            try
            {
                ApiClient.Delete<string>($"/api/wishlist/remove/{productId}");
                BindWishlist();

                litMessage.Text =
                    "<div class='alert alert-success'>Item removed from wishlist.</div>";
            }
            catch (Exception ex)
            {
                litMessage.Text =
                    "<div class='alert alert-danger'>Could not remove item: "
                    + Server.HtmlEncode(ex.Message) + "</div>";
            }
        }
    }
}