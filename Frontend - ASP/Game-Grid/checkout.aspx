<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Game_Grid.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- breadcrumb -->
    <div class="container">
        <div class="bread-crumb flex-w p-l-25 p-r-15 p-t-30 p-lr-0-lg">
            <a href="/home" class="stext-109 cl8 hov-cl1 trans-04">Home
			<i class="fa fa-angle-right m-l-9 m-r-10" aria-hidden="true"></i>
            </a>

            <a href="/cart" class="stext-109 cl8 hov-cl1 trans-04">Cart
            <i class="fa fa-angle-right m-l-9 m-r-10" aria-hidden="true"></i>
            </a>

            <span class="stext-109 cl4">Checkout
            </span>
        </div>
    </div>

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">
            <div class="row">


                <div class="col-lg-5 col-xl-5 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">

                        <h3 class="mtext-111 cl2 p-b-16">Checkout / Complete Purchase</h3>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <label id="Name">Name</label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your full name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label id="surName">Surname</label>
                                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="Enter your surname name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label id="email">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="address">Address Line 1</label>
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" placeholder="Enter your address"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="address2">Address Line 2</label>
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" placeholder="Enter your additional address information (optional)"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label id="suburb">Suburb</label>
                            <asp:TextBox ID="txtSuburb" runat="server" CssClass="form-control" placeholder="Enter your suburb"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="city">City</label>
                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter your city"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="zip">ZIP Code</label>
                            <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter your ZIP code"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" Text="Proceed to Payment" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" OnClick="btnPayment_Click"></asp:Button>

                    </div>
                </div>

                <!-- shopping Cart -->

                <div class="col-lg-7 col-xl-7 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">
                        <div class="wrap-table-shopping-cart">
                            <table class="table-shopping-cart">
                                <tr class="table_head">
                                    <th class="column-1">Product</th>
                                    <th class="column-2"></th>
                                    <th class="column-3">Price</th>
                                    <th class="column-4">Quantity</th>
                                    <th class="column-5">Total</th>
                                </tr>

                                <!-- Repeater control to display cart items dynamically from the data source. 
                                    Each item in the cart will be displayed in a table row with product image, name, price, quantity input, and total price. -->

                                <asp:Repeater ID="rptCart" runat="server">
                                    <ItemTemplate>
                                        <tr class="table_row">
                                            <td class="column-1">
                                                <div class="how-itemcart1">
                                                    <img src='<%# Eval("ProductImage") %>' alt="IMG">
                                                </div>
                                            </td>
                                            <td class="column-2"><%# Eval("ProductName") %></td>
                                            <td class="column-3"><%# Eval("ProductPrice", "{0:F2}") %></td>
                                            <td class="column-4">
                                                <div class="wrap-num-product flex-w m-l-auto m-r-0">
                                                    <div class="btn-num-product-down cl8 hov-btn3 trans-04 flex-c-m">
                                                        <i class="fs-16 zmdi zmdi-minus"></i>
                                                    </div>

                                                    <input class="mtext-104 cl3 txt-center num-product" type="number" name="num-product<%# Eval("ProductID") %>" value="<%# Eval("Quantity") %>" />

                                                    <div class="btn-num-product-up cl8 hov-btn3 trans-04 flex-c-m">
                                                        <i class="fs-16 zmdi zmdi-plus"></i>
                                                    </div>
                                                </div>
                                            </td>
                                            <td class="column-5"><%# Eval("Total", "{0:F2}") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </table>
                        </div>


                    </div>
                </div>
            </div>

            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>

        </div>
    </div>

</asp:Content>
