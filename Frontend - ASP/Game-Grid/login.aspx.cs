using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

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

            // CHECK FIELDS
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtEmail.BorderColor = System.Drawing.Color.Empty;
                txtPassword.BorderColor = System.Drawing.Color.Empty;

                if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    txtEmail.BorderColor = System.Drawing.Color.Red;
                    txtPassword.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please enter your Email and Password";
                    return;
                }
                else if (string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    txtEmail.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please enter your Email";
                    return;
                }
                else if (!string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                {
                    txtPassword.BorderColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Please enter your Password";
                    return;
                }

            }

            // CREATE LOGIN REQUEST
            var loginData = new
            {
                email = email,
                password = password
            };

            // CONVERT TO JSON
            string json = JsonConvert.SerializeObject(loginData);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("http://localhost:8080/");

                StringContent content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                try
                {
                    // SEND LOGIN REQUEST TO SPRING BOOT
                    HttpResponseMessage response =
                        await client.PostAsync(
                            "api/auth/login",
                            content
                        );

                    // READ BACKEND RESPONSE
                    string result = await response.Content.ReadAsStringAsync();


                    // LOGIN SUCCESSFUL

                    if (response.IsSuccessStatusCode)
                    {
                        LoginResponse loginResponse =
                            JsonConvert.DeserializeObject<LoginResponse>(
                                result
                            );

                        // CHECK RESPONSE
                        if (loginResponse == null)
                        {
                            lblMessage.ForeColor =
                                System.Drawing.Color.Red;

                            lblMessage.Text =
                                "Could not read the login response.";

                            return;
                        }

                        // CHECK TOKEN
                        if (string.IsNullOrEmpty(loginResponse.token))
                        {
                            lblMessage.ForeColor = System.Drawing.Color.Red;


                            lblMessage.Text = "Login succeeded, but no token was received.";


                            return;
                        }

                        // STORE USER INFORMATION IN SESSION


                        Session["Token"] = loginResponse.token;


                        Session["UserID"] = loginResponse.id;


                        Session["email"] = loginResponse.email;


                        Session["Username"] = loginResponse.username;


                        Session["role"] = loginResponse.role;


                        // CHECK ROLE


                        if (loginResponse.role != null &&
                            loginResponse.role.Equals(
                                "ADMIN",
                                StringComparison.OrdinalIgnoreCase))
                        {
                            // ADMIN
                            Response.Redirect(
                                 "admin-home.aspx",
                                 false
                            );

                            Context.ApplicationInstance
                               .CompleteRequest();
                        }
                        else
                        {
                            // CUSTOMER
                            Response.Redirect(
                                "home.aspx",
                                false
                            );

                            Context.ApplicationInstance
                                .CompleteRequest();
                        }
                    }

                    // LOGIN FAILED
                    else
                    {
                        lblMessage.ForeColor =
                            System.Drawing.Color.Red;

                        // SHOW THE ACTUAL BACKEND ERROR
                        lblMessage.Text =
                            "Login failed.<br/>" +
                            "Status: " +
                            response.StatusCode +
                            "<br/>" +
                            "Response: " +
                            result;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor =
                        System.Drawing.Color.Red;

                    lblMessage.Text = "Could not connect to the backend:<br/>" + ex.Message;


                }
            }

        }

        // LOGIN RESPONSE
        public class LoginResponse
        {
            public string message { get; set; }

            public string token { get; set; }

            public long id { get; set; }

            public string username { get; set; }

            public string email { get; set; }

            public string role { get; set; }
        }
    }
}