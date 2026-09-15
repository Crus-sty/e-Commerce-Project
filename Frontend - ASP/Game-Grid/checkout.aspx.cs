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
            /*if(Session["email"].ToString() != "" && Session["name"].ToString() != "" && Session["surname"].ToString() != "")
            {
                txtName.Text = Session["name"].ToString();
                txtSurname.Text = Session["surname"].ToString();
                txtEmail.Text = Session["email"].ToString();
                txtName.Enabled = false;
                txtSurname.Enabled = false;
                txtEmail.Enabled = false;
            }*/

            txtAddress1.BorderColor = System.Drawing.Color.Empty;
            txtCity.BorderColor = System.Drawing.Color.Empty;
            txtSuburb.BorderColor = System.Drawing.Color.Empty;
            txtZip.BorderColor = System.Drawing.Color.Empty;

            if (txtAddress1.Text != "" && txtCity.Text != "" && txtSuburb.Text != "" && txtZip.Text != "")
            {
                Response.Redirect("/cart/checkout/payment");
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Please fill in all required fields.";

                if(txtAddress1.Text == "")
                {
                    txtAddress1.BorderColor = System.Drawing.Color.Red;
                }
                if(txtCity.Text == "")
                {
                    txtCity.BorderColor = System.Drawing.Color.Red;
                }
                if(txtSuburb.Text == "")
                {
                    txtSuburb.BorderColor = System.Drawing.Color.Red;
                }
                if(txtZip.Text == "")
                {
                    txtZip.BorderColor = System.Drawing.Color.Red;
                }
            }
        }



    }
}