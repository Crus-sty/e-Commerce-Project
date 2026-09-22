using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace Game_Grid
{
    public partial class history : Page
    {
        private const string API_URL = "http://localhost:8080/api/orders/my-orders";


        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadOrderHistory();
            }
        }

        private async Task LoadOrderHistory()
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

                    HttpResponseMessage response = await client.GetAsync(API_URL);


                    string json = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        List<OrderHistoryDto> orders = JsonConvert.DeserializeObject<List<OrderHistoryDto>>(json);


                        if (orders == null || orders.Count == 0)
                        {
                            lblMessage.Text = "You have no orders yet.";

                            rptOrders.DataSource = null;
                            rptOrders.DataBind();

                            return;
                        }

                        rptOrders.DataSource = orders;
                        rptOrders.DataBind();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        Session.Clear();

                        Response.Redirect("login.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        lblMessage.Text = "Could not load orders. Status: " + response.StatusCode +
                            "<br/>" +
                            json;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading order history: " +
                    ex.Message;
            }
        }

        protected void rptOrders_ItemCommand(
            object source,
            System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrder")
            {
                string orderId = e.CommandArgument.ToString();

                Response.Redirect("order-details.aspx?id=" + orderId, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }

    public class OrderHistoryDto
    {
        public long Id { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public string ShippingAddress { get; set; }

        public string PaymentMethod { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public int NumberOfItems
        {
            get
            {
                if (OrderItems == null)
                    return 0;

                int total = 0;

                foreach (OrderItemDto item in OrderItems)
                {
                    total += item.Quantity;
                }

                return total;
            }
        }

        public string OrderNo
        {
            get
            {
                return Id.ToString();
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return (decimal)TotalAmount;
            }
        }
    }

    public class OrderItemDto
    {
        public long Id { get; set; }

        public int Quantity { get; set; }
    }
}