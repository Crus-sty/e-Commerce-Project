<%@ Page Title="Product Modification" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="product-mod.aspx.cs" Inherits="Game_Grid.product_mod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">
            <div class="row">


                <div class="col-lg-5 col-xl-5 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">

                        <h3 class="mtext-111 cl2 p-b-16">Checkout / Complete Purchase</h3>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <label id="p-id">Product ID</label>
                                    <asp:TextBox ID="txt_id" runat="server" CssClass="form-control" placeholder="[Product ID]"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search Product" CssClass="btn btn-primary mt-3" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label id="p-name">Product Name</label>
                            <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" placeholder="[Product Name]"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label id="p-price">Product Price</label>
                            <asp:TextBox ID="txt_price" runat="server" CssClass="form-control" placeholder="[Product Price]"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="p-desc">Product Description</label>
                            <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" placeholder="[Product Description]"></asp:TextBox>
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

                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-primary mt-3" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary mt-3" />

                                </div>
                            </div>
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
                                        </ItemTemplate>
                                    </asp:Repeater>


                                </table>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
