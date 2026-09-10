using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadProducts();
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "http://localhost:8080/api/products";

                    HttpResponseMessage response =
                        await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json =
                            await response.Content.ReadAsStringAsync();

                        List<ProductModel> products =
                            JsonConvert.DeserializeObject<List<ProductModel>>(json);

                        // Only show the first 10 products
                        products = products.Take(10).ToList();

                        rptProducts.DataSource = products;
                        rptProducts.DataBind();
                    }
                    else
                    {
                        Response.Write(
                            "<script>alert('Could not load products. Status: "
                            + response.StatusCode +
                            "');</script>"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "<script>alert('" +
                    ex.Message.Replace("'", "") +
                    "');</script>"
                );
            }
        }
    }
}