<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Game_Grid.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings">
                <h1 align="center" class="mtext-111 cl2 p-b-16">Payment</h1>
            </div>

            <div class="col-12 col-md-5 col-lg-7 m-lr-auto">

                <div class="row p-b-30">

                    <div class="col-md-3">
                        <img src="/Payments/visa-blue-logo-19529.svg" alt="Visa" class="img-fluid">
                    </div>

                    <div class="col-md-3">
                        <img src="/Payments/paypal-blue-logo-19528.svg" alt="PayPal" class="img-fluid">
                    </div>

                    <div class="col-md-3">
                        <img src="/Payments/google-pay-logo-19558.svg" alt="Google Pay" class="img-fluid">
                    </div>

                    <div class="col-md-3">
                        <img src="/Payments/apple-pay-logo-19557.svg" alt="Apple Pay" class="img-fluid">
                    </div>

                </div>

                <div class="row">

                    <div class="col-sm-12 col-lg-7 col-xl-5 m-lr-auto m-b-50">

                        <div class="form-group">
                            <asp:Label ID="lblCardNumber" runat="server" Text="Card Number" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-control" placeholder="Enter Card Number"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblName" runat="server" Text="Name on Card" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name on Card"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" placeholder="Enter Expiry Date"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="lblCVV" runat="server" Text="CVV" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtCVV" runat="server" CssClass="form-control" placeholder="Enter CVV"></asp:TextBox>
                        </div>

                    </div>

                    <div class="col-sm-12 col-lg-6 col-xl-7 m-lr-auto m-b-50">

                        <div class="bor10 p-lr-10 p-t-30 p-b-30 m-l-10 m-r-15 m-lr-0-xl">

                            <h4 class="mtext-109 cl2 p-b-30">Cart Totals
                            </h4>

                            <div class="flex-w flex-t bor12 p-b-13">

                                <div class="size-208">
                                    <span class="stext-110 cl2">Subtotal:
                                    </span>
                                </div>

                                <div class="size-209">
                                    <span class="mtext-110 cl2">[R SUBTOTAL PRICE]
                                    </span>
                                </div>

                                <div class="size-208">
                                    <span class="stext-110 cl2">VAT Included: (15%)
                                    </span>
                                </div>

                                <div class="size-209">
                                    <span class="mtext-110 cl2">[R VAT AMOUNT]
                                    </span>
                                </div>

                                <div class="size-208">
                                    <span class="stext-110 cl2">Shipping:
                                    </span>
                                </div>

                                <div class="size-209">
                                    <span class="mtext-110 cl2">R 300.00
                                    </span>
                                </div>

                            </div>

                            <div class="flex-w flex-t p-t-27 p-b-33">

                                <div class="size-208">
                                    <span class="mtext-101 cl2">Total:
                                    </span>
                                </div>

                                <div class="size-209 p-t-1">
                                    <span class="mtext-110 cl2">[R TOTAL PRICE]
                                    </span>
                                </div>

                            </div>

                        </div>
                    </div>

                    <div class="row">
                    <div class="m-t-20">
                        <asp:Button runat="server" Text="Pay Now" class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04 pointer" OnClick="btnPay_Click">
                            
                        </asp:Button>
                    </div>
                        </div>
                </div>



                <div class="row">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="" Text=""></asp:Label>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
