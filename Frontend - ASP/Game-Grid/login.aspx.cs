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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Check fields
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter your email and password.";
                return;
            }

            // Create login request
            var loginData = new
            {
                email = email,
                password = password
            };

            // Convert request to JSON
            string json = JsonConvert.SerializeObject(loginData);


            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");


                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                try
                {
                    // Send login request to Spring Boot
                    HttpResponseMessage response = await client.PostAsync("/api/auth/login", content);





                    // Read response from Spring Boot
                    string result = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        // Convert JSON response into LoginResponse
                        LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);


                        // Make sure we received a token
                        if (loginResponse != null &&
                            !string.IsNullOrEmpty(loginResponse.token))
                        {
                            // Store login information in Session
                            Session["Token"] = loginResponse.token;
                            Session["email"] = email;
                            Session["Username"] = loginResponse.username;
                            Session["Role"] = loginResponse.role;

                            // Go to the correct page
                            if (loginResponse.role != null &&
                                loginResponse.role.Equals(
                                    "ADMIN",
                                    StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect(
                                    "admin-home.aspx",
                                    false);

                                Context.ApplicationInstance
                                    .CompleteRequest();
                            }
                            else
                            {
                                Response.Redirect(
                                    "home.aspx",
                                    false);

                                Context.ApplicationInstance
                                    .CompleteRequest();
                            }
                        }
                        else
                        {
                            lblMessage.Text =
                                "Login succeeded, but no token was received.";
                        }
                    }
                    else
                    {
                        lblMessage.Text =
                            "Invalid email or password.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text =
                        "Could not connect to the backend: "
                        + ex.Message;
                }
            }
        }
        // LOGIN RESPONSE FROM SPRING BOOT

        public class LoginResponse
        {
            public string message { get; set; }

            public string token { get; set; }

            public string username { get; set; }

            public string role { get; set; }
        }
    }
}