using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using Newtonsoft.Json;
namespace Game_Grid {
    public partial class sign_up : System.Web.UI.Page 
    { 
        protected void Page_Load(object sender, EventArgs e) { } 
        protected async void btnCreateAccount_Click(object sender, EventArgs e) 
        { // GET VALUES FROM THE FORM
          string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim(); 
            string dob = txtDOB.Text.Trim();
            string gender = ddlGender.SelectedValue;
            string email = txtEmail.Text.Trim(); 
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text; 

            //  CHECK REQUIRED FIELDS
             if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(dob) || 
                string.IsNullOrEmpty(gender) ||
                string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(password)) 
            { lblMessage.ForeColor = System.Drawing.Color.Red; 
                lblMessage.Text = "Please complete all fields."; 
                return; 
            } 
          // CHECK PASSWORDS
          if (password != confirmPassword) 
            { lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Passwords do not match.";
                return; 
            } 
          // CHECK EMAIL
          if (!email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) && 
                !email.EndsWith("@yahoo.com", StringComparison.OrdinalIgnoreCase) &&
                !email.EndsWith("@outlook.com", StringComparison.OrdinalIgnoreCase) && 
                !email.EndsWith("@hotmail.com", StringComparison.OrdinalIgnoreCase) &&
                !email.EndsWith("@game-grid.com", StringComparison.OrdinalIgnoreCase))
            { lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a valid email address.";
                return; 
            }
            // CHECK IF EMAIL IS AN ADMIN EMAIL
            bool isAdmin = email.EndsWith( "@game-grid.com",StringComparison.OrdinalIgnoreCase);

            // CREATE HTTP CLIENT
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri( "http://localhost:8080" );
                try { 
                    // IF USER IS AN ADMIN
                  if (isAdmin) {
                        string username = name + "." + surname;

                        var adminData = new
                        {
                            username = username,
                            email = email,
                            password = password,
                            firstName = name,
                            lastName = surname,
                            gender = gender,
                            dob = dob
                        };
                        string adminJson = JsonConvert.SerializeObject(adminData); 
                        StringContent adminContent = new StringContent( adminJson, Encoding.UTF8, "application/json" ); 
                        // Call Admin API
                        HttpResponseMessage adminResponse = await client.PostAsync( "/api/admin/create", adminContent ); 
                        string adminResult = await adminResponse.Content .ReadAsStringAsync();
                       // ADMIN CREATED SUCCESSFULLY
                       if (adminResponse.IsSuccessStatusCode) {
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Admin account created successfully!";
                            // Store session information
                            Session["name"] = name; 
                            Session["surname"] = surname;
                            Session["email"] = email;
                            Session["role"] = "ADMIN";
                            // Redirect to admin page
                            Response.Redirect("admin-home.aspx"); 
                        } else
                        { 
                            lblMessage.ForeColor = System.Drawing.Color.Red; 
                            lblMessage.Text = "Admin registration failed: " + adminResult; 
                        }
                    } 
                  // IF USER IS A NORMAL CUSTOMER
                  else {
                        string username = email;
                        var registerData = new 
                        { name = name,
                            surname = surname,
                            email = email,
                            password = password,
                            username = username,
                            gender = gender,
                            dob = dob
                        }; 
                        string json = JsonConvert.SerializeObject(registerData);
                        StringContent content = new StringContent( json, Encoding.UTF8, "application/json" ); 
                        // Call registration API
                       HttpResponseMessage response = await client.PostAsync( "/api/auth/register", content ); 
                        string result = await response.Content .ReadAsStringAsync();
                         // CUSTOMER CREATED SUCCESSFULLY
                         if (response.IsSuccessStatusCode) {
                            lblMessage.ForeColor = System.Drawing.Color.Green; 
                            lblMessage.Text = "Account created successfully!";
                            // Store session information
                            Session["name"] = name; 
                            Session["surname"] = surname;
                            Session["email"] = email;
                            Session["role"] = "CUSTOMER";
                            // Redirect to home page
                           Response.Redirect("home.aspx"); 
                        } else 
                        { 
                            lblMessage.ForeColor = System.Drawing.Color.Red; 
                            lblMessage.Text = "Registration failed: " + result;
                        }
                    }
                } catch (Exception ex)
                { // CONNECTION ERROR
                  lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Could not connect to the backend: " + ex.Message; 
                }
            }
        }
    }
}