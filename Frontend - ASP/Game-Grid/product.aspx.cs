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
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                        List<product> products =
                            JsonConvert.DeserializeObject<List<product>>(json);

                        rptProducts.DataSource = products;
                        rptProducts.DataBind();
                    }
                    else
                    {
                        Response.Write(
                            "<script>alert('Could not load products from the API');</script>"
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

