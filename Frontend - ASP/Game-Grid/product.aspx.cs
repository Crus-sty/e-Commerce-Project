using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Game_Grid
{
    public partial class product : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Page"] = "shop.aspx";
                await LoadProducts();

                updatecategory();
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

                        // SEARCH

                        string search = Request.QueryString["search"];

                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            search = search.Trim();

                            products = products
                                .Where(p =>
                                    (!string.IsNullOrEmpty(p.Name) &&
                                     p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)

                                    ||

                                    (!string.IsNullOrEmpty(p.Description) &&
                                     p.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)

                                    ||

                                    (!string.IsNullOrEmpty(p.Category) &&
                                     p.Category.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                                )
                                .ToList();
                        }

                        // CATEGORY FILTER
                        string category =
                            Request.QueryString["category"];

                        if (!string.IsNullOrWhiteSpace(category))
                        {
                            category = category.Trim();

                            products = products
                                .Where(p =>
                                    !string.IsNullOrEmpty(p.Category) &&
                                    p.Category.IndexOf(
                                        category,
                                        StringComparison.OrdinalIgnoreCase
                                    ) >= 0
                                )
                                .ToList();
                        }

                        // DISPLAY PRODUCTS

                        rptProducts.DataSource = products;
                        rptProducts.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Could not load products. Status: " + response.StatusCode + "');</script>"

                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.Replace("'", "") + "');</script>"



                );
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
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

        protected void updatecategory()
        {
            string category = Page.RouteData.Values["category"] as string;

            btn_monitors.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_pcgaming.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_laptops.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_speakers.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_headphones.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_cables.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";
            btn_extras.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5";

            switch (category)
            {
                case "monitors-and-displays":
                    btn_monitors.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "pc-components":
                    btn_pcgaming.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "laptops":
                    btn_laptops.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "speakers":
                    btn_speakers.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "headphones":
                    btn_headphones.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;  
                case "cables-and-adapters":
                    btn_cables.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "extras":
                    btn_extras.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
            }

        }
    }
}