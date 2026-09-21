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

      
        private string GetCategoryIdFromSlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug)) return null;

            switch (slug.ToLowerInvariant())
            {
                case "monitors-and-displays": return "4";
                case "pc-components": return "2";
                case "laptops": return "5";
                case "speakers": return "7";
                case "headphones": return "7";
                case "cables-and-adapters": return "10";
                case "extras": return "8";
                case "console-gaming":
                case "gaming": return "3";
                default: return null;
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

                    if (!response.IsSuccessStatusCode)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "API ERROR: " + response.StatusCode;
                        return;
                    }

                    string json = await response.Content.ReadAsStringAsync();

                    List<ProductModel> products =
                        JsonConvert.DeserializeObject<List<ProductModel>>(json);

                    if (products == null) products = new List<ProductModel>();

                    // SEARCH
                    string search = Request.QueryString["search"];
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        search = search.Trim();
                        products = products.Where(p =>
                            (!string.IsNullOrEmpty(p.Name) &&
                             p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                            ||
                            (!string.IsNullOrEmpty(p.Description) &&
                             p.Description.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                            ||
                            (!string.IsNullOrEmpty(p.Category) &&
                             p.Category.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        ).ToList();
                    }

                    // CATEGORY FILTER (slug → numeric ID)
                    string categorySlug = Page.RouteData.Values["category"] as string;
                    if (!string.IsNullOrWhiteSpace(categorySlug))
                    {
                        string categoryId = GetCategoryIdFromSlug(categorySlug);
                        if (!string.IsNullOrEmpty(categoryId))
                        {
                            products = products.Where(p =>
                                !string.IsNullOrEmpty(p.Category) &&
                                p.Category == categoryId
                            ).ToList();
                        }
                    }

                    // BIND
                    rptProducts.DataSource = products;
                    rptProducts.DataBind();

                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Loaded " + products.Count + " products.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "EXCEPTION: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("=== EXCEPTION: " + ex.ToString());
            }
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
                case "console-gaming":
                    btn_console.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
                case "pc-gaming":
                    btn_console.Attributes["class"] = "stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1";
                    break;
            }
        }
    }
}