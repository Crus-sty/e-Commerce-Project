<%@ Page Title="Invoice" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="order-detail.aspx.cs" Inherits="Game_Grid.order_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <section class="bg-img1 txt-center p-lr-15 p-tb-92" style="background-image: url('/images/bg-69.jpg');">
            <h2 class="ltext-105 cl0 txt-center">Invoice</h2>
        </section>

    <div class="bg0 p-t-40 p-b-85">
        <div class="container">

            <div class="flex-w flex-sb-m p-b-25">

                <a href="/account/orders" class="stext-107 cl5 hov-cl1 trans-04">
                    ← Back to my orders
                </a>

            </div>


            <div class="bg6 p-t-40 p-b-40 p-lr-40">
                <div class="flex-w flex-sb-m p-b-30">

                    <div>
                        <img src="/imagery/Futuristic_GAMEGRID_Tech_Gaming_Logo_-_black.png"
                             alt="Game Grid" style="max-width:180px;">

                        <p class="stext-107 cl6 p-t-15">
                            Game Grid Inc.<br />
                            8th Floor, 379 Hudson St<br />
                            Johannesburg, Gauteng, South Africa<br />
                            (+27) 11 555 3434
                        </p>
                    </div>

                    <div>

                        <p class="stext-102 cl2 p-b-3">
                            <strong><asp:Label ID="lblInvoiceNumber" runat="server" /></strong>
                        </p>

                        <p class="stext-107 cl6">
                            Issued: <asp:Label ID="lblInvoiceDate" runat="server" />
                        </p>

                        <p class="stext-107 cl6">
                            Order: <asp:Label ID="lblOrderNumber" runat="server" />
                        </p>

                        <p class="stext-107 cl6 p-t-10">
                            Status:
                            <span class="stext-102 cl2">
                                <strong><asp:Label ID="lblStatus" runat="server" /></strong>
                            </span>
                        </p>
                    </div>

                </div>


                <!-- Billing -->
                <div class="flex-w flex-sb-m p-t-30 p-b-30">

                    <div class="p-r-25 p-b-20">
                        <div class="stext-107 cl6 p-b-8">
                            <strong>BILLED TO</strong>
                        </div>

                        <p class="stext-102 cl2">
                            <strong><asp:Label ID="lblCustomerName" runat="server" /></strong><br />
                            <asp:Label ID="lblCustomerEmail" runat="server" /><br />
                            <asp:Label ID="lblCustomerPhone" runat="server" />
                        </p>
                    </div>

                    <div class="p-r-25 p-b-20">
                        <div class="stext-107 cl6 p-b-8">
                            <strong>SHIPPING ADDRESS</strong>
                        </div>

                        <p class="stext-102 cl2">
                            <asp:Label ID="lblShippingAddress1" runat="server" />
                            <asp:Label ID="lblShippingAddress2" runat="server" />
                            <asp:Label ID="lblShippingCity" runat="server" />
                            <asp:Label ID="lblShippingProvince" runat="server" />
                            <asp:Label ID="lblShippingPostalCode" runat="server" />
                        </p>
                    </div>

                </div>


                <!-- Payment -->
                <div class="p-t-30 p-b-30">

                    <div class="stext-107 cl6 p-b-15">
                        <strong>PAYMENT DETAILS</strong>
                    </div>

                    <div class="flex-w flex-sb-m">

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Payment method</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblPaymentMethod" runat="server" />
                            </p>
                        </div>

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Payment status</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblPaymentStatus" runat="server" />
                            </p>
                        </div>

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Transaction ID</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblTransactionId" runat="server" />
                            </p>
                        </div>

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Card / reference</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblCardInfo" runat="server" />
                                <asp:Label ID="lblCardName" runat="server" />
                            </p>
                        </div>

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Paid on</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblPaidOn" runat="server" />
                            </p>
                        </div>

                        <div class="p-r-25 p-b-10">
                            <p class="stext-107 cl6 p-b-5">Order status</p>
                            <p class="stext-102 cl2">
                                <asp:Label ID="lblOrderStatus" runat="server" />
                            </p>
                        </div>

                    </div>

                </div>


                <!-- Products-->
                <div class="p-t-30">

                    <div class="stext-107 cl6 p-b-15">
                        <strong>ITEMS ORDERED</strong>
                    </div>

                    <div class="wrap-table-shopping-cart">
                        <table class="table-shopping-cart">

                            <tr class="table_head">
                                <th class="column-1">Product</th>
                                <th class="column-3">Unit price</th>
                                <th class="column-4">Qty</th>
                                <th class="column-5">Line total</th>
                            </tr>

                            <asp:Repeater ID="rptItems" runat="server">
                                <ItemTemplate>
                                    <tr class="table_row">

                                        <td class="column-1">
                                            <div class="how-itemcart1">
                                                <img src='<%# Eval("ProductImage") %>'
                                                     alt='<%# Eval("ProductName") %>'>
                                                <span class="stext-102 cl2 m-l-15">
                                                    <%# Eval("ProductName") %>
                                                </span>
                                            </div>
                                        </td>

                                        <td class="column-3">
                                            R <%# Eval("UnitPrice", "{0:N2}") %>
                                        </td>

                                        <td class="column-4">
                                            <%# Eval("Quantity") %>
                                        </td>

                                        <td class="column-5">
                                            R <%# Eval("LineTotal", "{0:N2}") %>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </table>
                    </div>

                </div>


                <!-- Total -->
                <div class="flex-w flex-r-m p-t-30">

                    <div>

                        <div class="flex-w flex-sb-m p-tb-8">
                            <span class="stext-107 cl6 p-r-40">Subtotal</span>
                            <span class="stext-102 cl2">
                                <asp:Label ID="lblSubtotal" runat="server" />
                            </span>
                        </div>

                        <div class="flex-w flex-sb-m p-tb-8">
                            <span class="stext-107 cl6 p-r-40">Shipping</span>
                            <span class="stext-102 cl2">
                                <asp:Label ID="lblShipping" runat="server" />
                            </span>
                        </div>

                        <div class="flex-w flex-sb-m p-tb-8" id="divDiscount" runat="server">
                            <span class="stext-107 cl6 p-r-40">Discount</span>
                            <span class="stext-102 cl2">
                                - <asp:Label ID="lblDiscount" runat="server" />
                            </span>
                        </div>

                        <div class="flex-w flex-sb-m p-tb-8">
                            <span class="stext-107 cl6 p-r-40">VAT Included (15%)</span>
                            <span class="stext-102 cl2">
                                <asp:Label ID="lblVat" runat="server" />
                            </span>
                        </div>

                        <div class="flex-w flex-sb-m p-t-15">
                            <span class="mtext-110 cl2 p-r-40">Total</span>
                            <span class="mtext-110 cl2">
                                <asp:Label ID="lblTotal" runat="server" />
                            </span>
                        </div>

                    </div>

                </div>


                <!-- NOTES -->
                <div class="p-t-40">

                    <div class="stext-107 cl6 p-b-8">
                        <strong>NOTES</strong>
                    </div>

                    <p class="stext-107 cl6">
                        Thank you for shopping with Game Grid. Payment is due within 30 days
                        of the invoice date. For any queries about this order, contact
                        <strong>support@Game-Grid.com</strong> or call (+27) 11 555 3434,
                        quoting invoice number.
                    </p>

                </div>

            </div>

        </div>
    </div>

</asp:Content>
