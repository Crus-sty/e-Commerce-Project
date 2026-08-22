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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
		protected async void btnLogin_Click(object sender, EventArgs e)
        {
            /*string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                //lblMessage.Text = "Please enter your email and password.";
                return;
            }

            var loginData = new
            {
                email = email,
                password = password
            };

            string json = JsonConvert.SerializeObject(loginData);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri("http://localhost:8080");//we can change this  i used my localhost

                StringContent content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

                try
                {
					//Making Requst
                    HttpResponseMessage response =
                        await client.PostAsync(
                            "/api/auth/login",
                            content
                        );

                    if (response.IsSuccessStatusCode)
                    {
                        // Login successful

                        Session["email"] = email;

                        Response.Redirect("admin-home.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid email or password.";
                           
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text ="Could not connect to the backend.";
                        
                }
            }*/
        }
    }
}