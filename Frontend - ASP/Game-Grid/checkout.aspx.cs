using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            if( txtAddress1 != null && txtCity != null && txtSuburb != null && txtZip != null)
            {
                Response.Redirect("/cart/checkout/payment");
            }
            else
            {
                lblError.Text = "Please fill in all required fields.";
            }
        }



    }
}