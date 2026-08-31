using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void accountLink_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("Account.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            // Add code to handle newsletter subscription

        }
    }
}