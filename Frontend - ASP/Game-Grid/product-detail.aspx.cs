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
    public partial class product_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
		protected async void btnAddToCart_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Get product ID
                int productId;

                if (!int.TryParse(hfProductId.Value, out productId))
                {
                    return;
                }

                // Get quantity
                int quantity;

                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    quantity = 1;
                }

                if (quantity < 1)
                {
                    quantity = 1;
                }

                // Get logged-in user
                string email = Session["email"] as string;

                if (string.IsNullOrEmpty(email))
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                // Data that will be sent to Spring Boot
                var cartData = new
                {
                    productId = productId,
                    quantity = quantity,
                    email = email
                };

                // Convert to JSON
                string json = JsonConvert.SerializeObject(cartData);
                   

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress =
                        new Uri("http://localhost:8080");//we will change

                    StringContent content =
                        new StringContent(
                            json,
                            Encoding.UTF8,
                            "application/json"
                        );

                    // POST request
                    HttpResponseMessage response =
                        await client.PostAsync(
                            "/api/cart/add",
                            content
                        );

                    if (response.IsSuccessStatusCode)
                    {
                        Response.Redirect("cart.aspx");
                    }
                    else
                    {
                        //We Will Display error
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }*/

            Session["CartCount"] = (int)(Session["CartCount"]) + 1;
        }
    }
}