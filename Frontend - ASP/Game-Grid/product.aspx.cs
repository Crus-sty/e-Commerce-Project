using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;

namespace Game_Grid
{
    public partial class product : System.Web.UI.Page
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

                    HttpResponseMessage response = await client.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();


                        List<ProductModel> products = JsonConvert.DeserializeObject<List<ProductModel>>(json);


                        rptProducts.DataSource = products;
                        rptProducts.DataBind();
                    }
                    else
                    {
                        Response.Write(
                            "<script>alert('Could not load products. Status: " + response.StatusCode + "');</script>"


                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(
                    "<script>alert('" + ex.Message.Replace("'", "") +"');</script>"
                );
            }
        }
    }
}