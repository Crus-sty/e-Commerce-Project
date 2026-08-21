using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
//using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Game_Grid
{
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
		protected async void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string dob = txtDOB.Text.Trim();
            string gender = txtGender.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check required fields
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(dob) ||
                string.IsNullOrEmpty(gender) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please complete all fields.";
                return;
            }

            // Check passwords
            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            // Create object to send to Spring Boot
            var registerData = new
            {
				//will cahge varibles to match the database
                name = name,
                surname = surname,
                dob = dob,
                gender = gender,
                email = email,
                password = password
            };

            // Convert object to JSON
            string json = JsonConvert.SerializeObject(registerData);

            /*using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("http://localhost:8080");//will  change later

                StringContent content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

                try
                {
                    // Send pOST request to Spring Boot
                    HttpResponseMessage response =
                        await client.PostAsync(
                            "/api/auth/register",
                            content
                        );

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Green;

                        lblMessage.Text ="Account created successfully!";
                            

                        // Go to login page
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        string result =
                            await response.Content.ReadAsStringAsync();

                        lblMessage.Text ="Registration failed: " + result;
                            
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Could not connect to the backend.";
                       
                }
            }*/
        }
    }
}