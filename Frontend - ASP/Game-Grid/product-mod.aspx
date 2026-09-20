<%@ Page Title="Product Modification" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="product-mod.aspx.cs" Inherits="Game_Grid.product_mod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="row">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Text=""></asp:Label>
            </div>

            <div class="row">


                <div class="col-lg-5 col-xl-5 m-lr-auto m-b-50">
                    <div class="m-l-5 m-r--8 m-lr-0-xl">

                        <h3 class="mtext-111 cl2 p-b-16">Modify Product</h3>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">

                                    <label id="p-id">Product ID</label>
                                    <asp:TextBox ID="txt_id" runat="server" CssClass="form-control" placeholder="[Product ID]"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search Product" CssClass="btn btn-primary mt-3" OnClick="btnSearch_Click" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label id="p-name">Product Name</label>
                            <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Name]"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label id="p-price">Product Price</label>
                            <asp:TextBox ID="txt_price" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Price]"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label id="p-qty">Product Quantity</label>
                            <asp:TextBox ID="txt_qty" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Quantity]"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label id="p-desc">Product Description</label>
                            <asp:TextBox ID="txt_desc" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Description]"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label id="p-features">Product Category</label>
                            <!-- <asp:TextBox ID="txt_features" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Features]"></asp:TextBox> -->
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Category]">

                                <asp:ListItem Text="Choose Product Category" Value="" />
                                <asp:ListItem Text="Monitors & Displays" Value="Monitors & Displays" />
                                <asp:ListItem Text="PC Components" Value="PC Components" />
                                <asp:ListItem Text="Console Gaming" Value="Console Gaming" />
                                <asp:ListItem Text="PC Gaming" Value="PC Gaming" />
                                <asp:ListItem Text="Gaming Laptops" Value="Gaming Laptops" />
                                <asp:ListItem Text="Speakers" Value="Speakers" />
                                <asp:ListItem Text="Headphones" Value="Headphones" />
                                <asp:ListItem Text="Cables & Adapters" Value="Cables & Adapters" />
                                <asp:ListItem Text="Extras" Value="Extras" />

                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label id="p-image1">Product Image 1</label>
                        <asp:TextBox ID="txt_image1" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Image 1]"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label id="p-image2">Product Image 2</label>
                        <asp:TextBox ID="txt_image2" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Image 2]"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label id="p-image3">Product Image 3</label>
                        <asp:TextBox ID="txt_image3" runat="server" CssClass="form-control" Enabled="false" placeholder="[Product Image 3]"></asp:TextBox>
                    </div>




                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-primary mt-3" OnClick="btnEdit_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />

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
                                    <th class="column-5"></th>
                                </tr>

                                <!-- Repeater control to display cart items dynamically from the data source. 
                            Each item in the cart will be displayed in a table row with product image, name, price, quantity input, and total price. -->

                                <asp:Repeater ID="rptCart" runat="server">
                                    <ItemTemplate>
                                        <tr class="table_row">
                                            <td class="column-1">
                                                <div class="how-itemcart1">
                                                    <img src='<%# Eval("ProductImage") %>' alt="IMG">
                                                    <p class="column-1"><%# Eval("ProductName") %></p>
                                                </div>
                                            </td>
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
                                    </ItemTemplate>
                                </asp:Repeater>


                            </table>
                        </div>


                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="btn_addproduct" runat="server" Text="Add Product" CssClass="btn btn-primary mt-3" OnClick="btnaddproduct_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btn_deleteproduct" runat="server" Text="Delete Product" CssClass="btn btn-primary mt-3" OnClick="btndeleteproduct_Click" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
