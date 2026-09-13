using Game_Grid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
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
            try
            {
                var items = ApiClient.Get<List<WishlistItemDto>>("/api/wishlist");
                rptWishlist.DataSource = items ?? new List<WishlistItemDto>();
                rptWishlist.DataBind();
            }
            catch (Exception ex)
            {
                litMessage.Text = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var link = (LinkButton)sender;
            long productId = long.Parse(link.CommandArgument.ToString());

            try
            {
                ApiClient.Delete<string>($"/api/wishlist/remove/{productId}");
                BindWishlist();
            }
            catch (Exception ex)
            {
                litMessage.Text = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
        }
    }


}