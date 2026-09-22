using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class orders : System.Web.UI.Page
    {
        private const string API_URL =
            "http://localhost:8080/api/admin/orders";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadOrders();
            }
        }

        private async Task LoadOrders()
        {
            try
            {
                string token = Session["Token"] as string;

                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response =
                        await client.GetAsync(API_URL);

                    string responseContent =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        List<OrderDto> orders =
                            JsonConvert.DeserializeObject<List<OrderDto>>(
                                responseContent);

                        if (orders == null)
                        {
                            orders = new List<OrderDto>();
                        }

                        rptOrders.DataSource = orders;
                        rptOrders.DataBind();

                        if (lblMessage != null) lblMessage.Text = "";
                    }
                    else
                    {
                        if (lblMessage != null)
                        {
                            lblMessage.Text =
                                "Could not load orders. Status: "
                                + (int)response.StatusCode
                                + " "
                                + response.StatusCode
                                + "<br/>"
                                + responseContent;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (lblMessage != null)
                {
                    lblMessage.Text = "An error occurred while loading orders: " + ex.Message;

                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(
                        "LoadOrders error (lblMessage null): " + ex);
                }
            }
        }
        protected async void btnSearchOrders_Click(
            object sender,
            EventArgs e)
        {
            string orderIdText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(orderIdText))
            {
                lblMessage.Text =
                    "Please enter an order ID.";
                return;
            }

            long orderId;

            if (!long.TryParse(orderIdText, out orderId))
            {
                lblMessage.Text =
                    "Please enter a valid numeric order ID.";
                return;
            }

            await SearchOrder(orderId);
        }

        private async Task SearchOrder(long orderId)
        {
            try
            {
                string token = Session["Token"] as string;

                if (string.IsNullOrEmpty(token))
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    string url = API_URL + "/" + orderId;

                    HttpResponseMessage response =
                        await client.GetAsync(url);

                    string responseContent =
                        await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        OrderDto order =
                            JsonConvert.DeserializeObject<OrderDto>(
                                responseContent);

                        if (order == null)
                        {
                            lblMessage.Text =
                                "The server returned an empty order.";
                            return;
                        }

                        List<OrderDto> orders =
                            new List<OrderDto>();

                        orders.Add(order);

                        rptOrders.DataSource = orders;
                        rptOrders.DataBind();

                        lblMessage.Text = "";
                    }
                    else if (response.StatusCode ==
                             HttpStatusCode.NotFound)
                    {
                        rptOrders.DataSource = null;
                        rptOrders.DataBind();

                        lblMessage.Text =
                            "Order was not found.";
                    }
                    else
                    {
                        lblMessage.Text =
                            "Could not search for the order. Status: "
                            + (int)response.StatusCode
                            + " "
                            + response.StatusCode
                            + "<br/>"
                            + responseContent;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "An error occurred while searching: "
                    + ex.Message;
            }
        }

        protected async void btnViewAll_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text = "";

            await LoadOrders();
        }

        protected void btnViewOrder_Command(
            object sender,
            System.Web.UI.WebControls.CommandEventArgs e)
        {
            string orderId =
                e.CommandArgument.ToString();

            Response.Redirect(
                "admin-order-details.aspx?orderId="
                + orderId);
        }

        public class OrderDto
        {
            public long orderId { get; set; }

            public string customerName { get; set; }

            public int numberOfItems { get; set; }

            public decimal totalAmount { get; set; }

            public string status { get; set; }
        }
    }
}