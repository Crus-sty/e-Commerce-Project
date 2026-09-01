using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Game_Grid
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Button Working";

        //    string name = txtName.Text.Trim();
        //    string surname = txtSurname.Text.Trim();
        //    string dob = txtDOB.Text.Trim();
        //    string gender = txtGender.Text.Trim();
        //    string email = txtEmail.Text.Trim();
        //    string password = txtPassword.Text;
        //    string confirmPassword = txtConfirmPassword.Text;

        //    // Check required fields
        //    if (string.IsNullOrEmpty(name) ||
        //        string.IsNullOrEmpty(surname) ||
        //        string.IsNullOrEmpty(dob) ||
        //        string.IsNullOrEmpty(gender) ||
        //        string.IsNullOrEmpty(email) ||
        //        string.IsNullOrEmpty(password))
        //    {
        //        lblMessage.Text = "Please complete all fields.";
        //        return;
        //    }

        //    // Check passwords
        //    if (password != confirmPassword)
        //    {
        //        lblMessage.Text = "Passwords do not match.";
        //        return;
        //    }

        //    // Check email
        //    if (!email.EndsWith("@gmail.com",
        //            StringComparison.OrdinalIgnoreCase) &&
        //        !email.EndsWith("@yahoo.com",
        //            StringComparison.OrdinalIgnoreCase) &&
        //        !email.EndsWith("@outlook.com",
        //            StringComparison.OrdinalIgnoreCase) &&
        //        !email.EndsWith("@hotmail.com",
        //            StringComparison.OrdinalIgnoreCase))
        //    {
        //        lblMessage.Text = "Please enter a valid email address.";
        //        return;
        //    }

        //    // Create username
        //    string username = email;

           
        //    var registerData = new
        //    {
        //        username = username,
        //        email = email,
        //        password = password,
        //        firstName = name,
        //        lastName = surname,
        //        gender = gender,
        //        dob = dob
        //    };

        //    string json = JsonConvert.SerializeObject(registerData);

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(
        //            "http://localhost:8080"
        //        );

        //        StringContent content = new StringContent(
        //            json,
        //            Encoding.UTF8,
        //            "application/json"
        //        );

        //        try
        //        {
        //            HttpResponseMessage response = await client.PostAsync("/api/auth/register", content);

        //            string result = await response.Content.ReadAsStringAsync();


        //            if (response.IsSuccessStatusCode)
        //            {
        //                lblMessage.ForeColor = System.Drawing.Color.Green;


        //                lblMessage.Text = "Account created successfully!";


        //                Response.Redirect("login.aspx");
        //            }
        //            else
        //            {
        //                lblMessage.ForeColor = System.Drawing.Color.Red;


        //                lblMessage.Text = "Registration failed: " + result;

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            lblMessage.ForeColor = System.Drawing.Color.Red;


        //            lblMessage.Text = "Could not connect to the backend: " + ex.Message;


        //        }
        //    }
        }
    }
}