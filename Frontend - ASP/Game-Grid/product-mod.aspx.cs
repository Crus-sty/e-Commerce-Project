using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Grid
{
    public partial class product_mod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text.Trim();
            String name = txt_name.Text.Trim();
            Double price = Convert.ToDouble(txt_price.Text.Trim());
            int qty = Convert.ToInt32(txt_qty.Text.Trim());
            String desc = txt_desc.Text.Trim();
            String category = ddlCategory.SelectedValue;
            String image_1 = txt_image1.Text.Trim();
            String image_2 = txt_image2.Text.Trim();
            String image_3 = txt_image3.Text.Trim();


        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            txt_name.Enabled = true;
            txt_price.Enabled = true;
            txt_qty.Enabled = true;
            txt_desc.Enabled = true;
            ddlCategory.Enabled = true;
            txt_image1.Enabled = true;
            txt_image2.Enabled = true;
            txt_image3.Enabled = true;
        }

        protected void btndeleteproduct_Click(object sender, EventArgs e)
        {

        }
        protected void btnaddproduct_Click(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            btnSearch.Visible = false;
            txt_id.Text = "Auto Generated";
            txt_name.Enabled = true;
            txt_name.Text = "";
            txt_price.Enabled = true;
            txt_price.Text = "";
            txt_qty.Enabled = true;
            txt_qty.Text = "";
            txt_desc.Enabled = true;
            txt_desc.Text = "";
            ddlCategory.Enabled = true;
            ddlCategory.ClearSelection();
            txt_image1.Enabled = true;
            txt_image1.Text = "";
            txt_image2.Enabled = true;
            txt_image2.Text = "";
            txt_image3.Enabled = true;
            txt_image3.Text = "";
            btn_addproduct.Visible = false;
            btnEdit.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String id = txt_id.Text.Trim();
            if (id == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter a product ID.";
                return;
            }/*
            // Call the API to get the product details
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                HttpResponseMessage response = client.GetAsync($"/api/products/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var product = response.Content.ReadAsAsync<Product>().Result;
                    txt_name.Text = product.Name;
                    txt_price.Text = product.Price.ToString();
                    txt_qty.Text = product.Quantity.ToString();
                    txt_desc.Text = product.Description;
                    txt_features.Text = product.Features;
                    txt_image1.Text = product.Image1;
                    txt_image2.Text = product.Image2;
                    txt_image3.Text = product.Image3;
                    btnEdit.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Product not found.";
                }*/
            }

        
    }
}