<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Main-2.Master"
    AutoEventWireup="true" Async="true"
    CodeBehind="payment.aspx.cs" Inherits="Game_Grid.payment" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">
</asp:Content>


<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <!-- Breadcrumb -->
    <div class="container">

        <div class="bread-crumb flex-w p-l-25 p-r-15 p-t-30 p-lr-0-lg">

            <a href="/home"
                class="stext-109 cl8 hov-cl1 trans-04">

                Home

                <i class="fa fa-angle-right m-l-9 m-r-10"
                    aria-hidden="true">
                </i>

            </a>


            <a href="/cart"
                class="stext-109 cl8 hov-cl1 trans-04">

                Cart

                <i class="fa fa-angle-right m-l-9 m-r-10"
                    aria-hidden="true">
                </i>

            </a>


            <a href="/cart/checkout"
                class="stext-109 cl8 hov-cl1 trans-04">

                Checkout

                <i class="fa fa-angle-right m-l-9 m-r-10"
                    aria-hidden="true">
                </i>

            </a>


            <span class="stext-109 cl4">
                Payment
            </span>

        </div>

    </div>



    <div class="bg0 p-t-75 p-b-85">

        <div class="container">


            <div class="acc-headings">

                <h1 align="center"
                    class="mtext-111 cl2 p-b-16">

                    Payment

                </h1>

            </div>


            <div class="col-12 col-md-5 col-lg-7 m-lr-auto">


                <!-- ================================================= -->
                <!-- PAYMENT LOGOS -->
                <!-- ================================================= -->

                <div class="row p-b-30">

                    <div class="col-md-3">

                        <img
                            src="/Payments/visa-blue-logo-19529.svg"
                            alt="Visa"
                            class="img-fluid">

                    </div>


                    <div class="col-md-3">

                        <img
                            src="/Payments/paypal-blue-logo-19528.svg"
                            alt="PayPal"
                            class="img-fluid">

                    </div>


                    <div class="col-md-3">

                        <img
                            src="/Payments/google-pay-logo-19558.svg"
                            alt="Google Pay"
                            class="img-fluid">

                    </div>


                    <div class="col-md-3">

                        <img
                            src="/Payments/apple-pay-logo-19557.svg"
                            alt="Apple Pay"
                            class="img-fluid">

                    </div>

                </div>



                <div class="row">


                    <!-- ================================================= -->
                    <!-- CARD DETAILS -->
                    <!-- ================================================= -->

                    <div class="col-sm-12 col-lg-7 col-xl-5 m-lr-auto m-b-50">


                        <!-- Card number -->
                        <div class="form-group">

                            <asp:Label
                                ID="lblCardNumber"
                                runat="server"
                                Text="Card Number"
                                ForeColor="Gray">
                            </asp:Label>


                            <asp:TextBox
                                ID="txtCardNumber"
                                runat="server"
                                CssClass="form-control"
                                MaxLength="19"
                                placeholder="Enter Card Number">
                            </asp:TextBox>

                        </div>


                        <!-- Card holder -->
                        <div class="form-group">

                            <asp:Label
                                ID="lblName"
                                runat="server"
                                Text="Name on Card"
                                ForeColor="Gray">
                            </asp:Label>


                            <asp:TextBox
                                ID="txtName"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter Name on Card">
                            </asp:TextBox>

                        </div>


                        <!-- Expiry -->
                        <div class="form-group">

                            <asp:Label
                                ID="lblExpiryDate"
                                runat="server"
                                Text="Expiry Date (MM/YY)"
                                ForeColor="Gray">
                            </asp:Label>


                            <asp:TextBox
                                ID="txtExpiryDate"
                                runat="server"
                                CssClass="form-control"
                                MaxLength="5"
                                placeholder="MM/YY">
                            </asp:TextBox>

                        </div>


                        <!-- CVV -->
                        <div class="form-group">

                            <asp:Label
                                ID="lblCVV"
                                runat="server"
                                Text="CVV"
                                ForeColor="Gray">
                            </asp:Label>


                            <asp:TextBox
                                ID="txtCVV"
                                runat="server"
                                MaxLength="4"
                                TextMode="Password"
                                CssClass="form-control"
                                placeholder="Enter CVV">
                            </asp:TextBox>

                        </div>

                    </div>



                    <!-- ================================================= -->
                    <!-- CART TOTALS -->
                    <!-- ================================================= -->

                    <div class="col-sm-12 col-lg-6 col-xl-7 m-lr-auto m-b-50">

                        <div class="bor10 p-lr-10 p-t-30 p-b-30 m-l-10 m-r-15 m-lr-0-xl">


                            <h4 class="mtext-109 cl2 p-b-30">
                                Cart Totals
                            </h4>


                            <div class="flex-w flex-t bor12 p-b-13">


                                <!-- Subtotal -->
                                <div class="size-208">

                                    <span class="stext-110 cl2">
                                        Subtotal:
                                    </span>

                                </div>


                                <div class="size-209">

                                    <span class="mtext-110 cl2">

                                        R
                                        <asp:Label
                                            ID="lblSubtotal"
                                            runat="server"
                                            Text="0.00">
                                        </asp:Label>

                                    </span>

                                </div>


                                <!-- VAT -->
                                <div class="size-208">

                                    <span class="stext-110 cl2">
                                        VAT Included(15%):
                                    </span>

                                </div>


                                <div class="size-209">

                                    <span class="mtext-110 cl2">

                                        R
                                        <asp:Label
                                            ID="lblVat"
                                            runat="server"
                                            Text="0.00">
                                        </asp:Label>

                                    </span>

                                </div>


                                <!-- Shipping -->
                                <div class="size-208">

                                    <span class="stext-110 cl2">
                                        Shipping:
                                    </span>

                                </div>


                                <div class="size-209">

                                    <span class="mtext-110 cl2">

                                        R
                                        <asp:Label
                                            ID="lblShipping"
                                            runat="server"
                                            Text="0.00">
                                        </asp:Label>

                                    </span>

                                </div>

                            </div>



                            <!-- Total -->
                            <div class="flex-w flex-t p-t-27 p-b-33">

                                <div class="size-208">

                                    <span class="mtext-101 cl2">
                                        Total:
                                    </span>

                                </div>


                                <div class="size-209 p-t-1">

                                    <span class="mtext-110 cl2">

                                        R
                                        <asp:Label
                                            ID="lblTotal"
                                            runat="server"
                                            Text="0.00">
                                        </asp:Label>

                                    </span>

                                </div>

                            </div>

                        </div>

                    </div>



                    <!-- ================================================= -->
                    <!-- PAY BUTTON -->
                    <!-- ================================================= -->

                    <div class="col-12 m-t-20">

                        <asp:Button
                            ID="btnPay"
                            runat="server"
                            Text="Pay Now"
                            CssClass="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04 pointer"
                            OnClick="btnPay_Click" />

                    </div>



                    <!-- ================================================= -->
                    <!-- MESSAGE -->
                    <!-- ================================================= -->

                    <div class="col-12 m-t-15">

                        <asp:Label
                            ID="lblMessage"
                            runat="server"
                            Text="">
                        </asp:Label>

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>