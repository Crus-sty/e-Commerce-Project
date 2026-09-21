<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Main-2.Master"
    AutoEventWireup="true" Async="true"
    CodeBehind="checkout.aspx.cs" Inherits="Game_Grid.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    aria-hidden="true"></i>
            </a>


            <a href="/cart"
                class="stext-109 cl8 hov-cl1 trans-04">
                Cart

                <i class="fa fa-angle-right m-l-9 m-r-10"
                    aria-hidden="true"></i>
            </a>


            <span class="stext-109 cl4">
                Checkout
            </span>

        </div>

    </div>


    <div class="bg0 p-t-75 p-b-85">

        <div class="container">

            <div class="row">


                <!-- ================================================= -->
                <!-- ADDRESS FORM -->
                <!-- ================================================= -->

                <div class="col-lg-5 col-xl-5 m-lr-auto m-b-50">

                    <div class="m-l-25 m-r--38 m-lr-0-xl">

                        <h3 class="mtext-111 cl2 p-b-16">
                            Checkout / Complete Purchase
                        </h3>


                        <!-- Name -->
                        <div class="row">

                            <div class="col-md-6">

                                <div class="form-group">

                                    <label>Name</label>

                                    <asp:TextBox
                                        ID="txtName"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Enter your name">
                                    </asp:TextBox>

                                </div>

                            </div>


                            <!-- Surname -->
                            <div class="col-md-6">

                                <div class="form-group">

                                    <label>Surname</label>

                                    <asp:TextBox
                                        ID="txtSurname"
                                        runat="server"
                                        CssClass="form-control"
                                        placeholder="Enter your surname">
                                    </asp:TextBox>

                                </div>

                            </div>

                        </div>


                        <!-- Email -->
                        <div class="form-group">

                            <label>Email</label>

                            <asp:TextBox
                                ID="txtEmail"
                                runat="server"
                                CssClass="form-control"
                                TextMode="Email"
                                placeholder="Enter your email">
                            </asp:TextBox>

                        </div>


                        <!-- Address Line 1 -->
                        <div class="form-group">

                            <label>Address Line 1</label>

                            <asp:TextBox
                                ID="txtAddress1"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter your address">
                            </asp:TextBox>

                        </div>


                        <!-- Address Line 2 -->
                        <div class="form-group">

                            <label>
                                Address Line 2 (optional)
                            </label>

                            <asp:TextBox
                                ID="txtAddress2"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Additional address info">
                            </asp:TextBox>

                        </div>


                        <!-- Suburb -->
                        <div class="form-group">

                            <label>Suburb</label>

                            <asp:TextBox
                                ID="txtSuburb"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter your suburb">
                            </asp:TextBox>

                        </div>


                        <!-- City -->
                        <div class="form-group">

                            <label>City</label>

                            <asp:TextBox
                                ID="txtCity"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter your city">
                            </asp:TextBox>

                        </div>


                        <!-- ZIP -->
                        <div class="form-group">

                            <label>ZIP Code</label>

                            <asp:TextBox
                                ID="txtZip"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Enter your ZIP code">
                            </asp:TextBox>

                        </div>


                        <!-- Continue to payment -->
                        <asp:Button
                            ID="btnPayment"
                            runat="server"
                            Text="Proceed to Payment"
                            CssClass="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer"
                            OnClick="btnPayment_Click" />

                    </div>

                </div>



                <!-- ================================================= -->
                <!-- CART SUMMARY -->
                <!-- ================================================= -->

                <div class="col-lg-7 col-xl-7 m-lr-auto m-b-50">

                    <div class="m-l-25 m-r--38 m-lr-0-xl">

                        <div class="wrap-table-shopping-cart">

                            <table class="table-shopping-cart">

                                <thead>

                                    <tr class="table_head">

                                        <th class="column-1">
                                            Product
                                        </th>

                                        <th class="column-2">
                                        </th>

                                        <th class="column-3">
                                            Price
                                        </th>

                                        <th class="column-4">
                                            Quantity
                                        </th>

                                        <th class="column-5">
                                            Total
                                        </th>

                                    </tr>

                                </thead>


                                <tbody>

                                    <asp:Repeater
                                        ID="rptCart"
                                        runat="server">

                                        <ItemTemplate>

                                            <tr class="table_row">

                                                <td class="column-1">

                                                    <div class="how-itemcart1">

                                                        <img
                                                            src='<%# Eval("ProductImage") %>'
                                                            alt='<%# Eval("ProductName") %>'
                                                            onerror="this.src='/images/no-image.png';" />

                                                    </div>

                                                </td>


                                                <td class="column-2">

                                                    <%# Eval("ProductName") %>

                                                </td>


                                                <td class="column-3">

                                                    R
                                                    <%# Eval("ProductPrice", "{0:N2}") %>

                                                </td>


                                                <td class="column-4">

                                                    <%# Eval("Quantity") %>

                                                </td>


                                                <td class="column-5">

                                                    R
                                                    <%# Eval("Total", "{0:N2}") %>

                                                </td>

                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>

                                </tbody>

                            </table>

                        </div>



                        <!-- ================================================= -->
                        <!-- TOTALS -->
                        <!-- ================================================= -->

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
                                        VAT (15%):
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
                            <div class="flex-w flex-t p-t-27">

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

                </div>

            </div>


            <!-- Error -->
            <asp:Label
                ID="lblError"
                runat="server"
                Text="">
            </asp:Label>

        </div>

    </div>

</asp:Content>