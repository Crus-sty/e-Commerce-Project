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
            string cardHolderName = txtName.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            txtCardNumber.BorderColor = System.Drawing.Color.Empty;
            txtName.BorderColor = System.Drawing.Color.Empty;
            txtExpiryDate.BorderColor = System.Drawing.Color.Empty;
            txtCVV.BorderColor = System.Drawing.Color.Empty;

            if (string.IsNullOrEmpty(cardNumber) ||
                string.IsNullOrEmpty(expiryDate) ||
                string.IsNullOrEmpty(cardHolderName) ||
                string.IsNullOrEmpty(cvv))
            {

                if(string.IsNullOrEmpty(cardNumber))
                {
                    txtCardNumber.BorderColor = System.Drawing.Color.Red;
                }
                if(string.IsNullOrEmpty(cardHolderName))
                {
                    txtName.BorderColor = System.Drawing.Color.Red;
                }
                if(string.IsNullOrEmpty(expiryDate))
                {
                    txtExpiryDate.BorderColor = System.Drawing.Color.Red;
                }
                if(string.IsNullOrEmpty(cvv))
                {
                    txtCVV.BorderColor = System.Drawing.Color.Red;
                }

                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please complete all fields.";
                return;
            }

            if(cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                txtCardNumber.BorderColor = System.Drawing.Color.Red;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a valid 16-digit card number.";
                return;
            }

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Payment successful!";
        }
    }
}