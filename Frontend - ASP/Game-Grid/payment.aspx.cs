using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            if (string.IsNullOrEmpty(cardNumber) ||
                string.IsNullOrEmpty(expiryDate) ||
                string.IsNullOrEmpty(cvv))
            {
                lblMessage.Text = "Please complete all fields.";
                return;
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Payment successful!";
        }
    }
}