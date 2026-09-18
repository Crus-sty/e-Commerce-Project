<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="shopping-cart.aspx.cs"
    Inherits="Game_Grid.shopping_cart" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ========================================================= -->
    <!-- SHOPPING CART -->
    <!-- ========================================================= -->

    <!-- breadcrumb -->
    <div class="container">
        <div class="bread-crumb flex-w p-l-25 p-r-15 p-t-30 p-lr-0-lg">
            <a href="/home" class="stext-109 cl8 hov-cl1 trans-04">Home
			<i class="fa fa-angle-right m-l-9 m-r-10" aria-hidden="true"></i>
            </a>

            <span class="stext-109 cl4">Cart
            </span>
        </div>
    </div>


    <div class="bg0 p-t-75 p-b-85">
        <div class="container">
            <div class="row">
                <!-- ================================================= -->
                <!-- CART ITEMS -->

                <div class="col-lg-10 col-xl-7 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">
                        <div class="wrap-table-shopping-cart">
                            <table class="table-shopping-cart">
                                <!-- TABLE HEADER -->
                                <tr class="table_head">
                                    <th class="column-1">Product </th>
                                    <th class="column-2"></th>
                                    <th class="column-3">Price </th>
                                    <th class="column-4">Quantity </th>
                                    <th class="column-5">Total </th>

                                </tr>
                                <!-- ================================================= -->
                                <!-- CART REPEATER -->
                                <!-- ================================================= -->
                                <asp:Repeater ID="rptCart" runat="server">
                                    <ItemTemplate>
                                        <tr class="table_row">
                                            <!-- PRODUCT IMAGE -->
                                            <td class="column-1">
                                                <div class="how-itemcart1">
                                                    <img src='<%# Eval("ProductImage") %>' alt="Product Image" style="max-width: 80px; max-height: 80px;" />

                                                </div>

                                            </td>
                                            <!-- PRODUCT NAME -->
                                            <td class="column-2"><%# Eval("ProductName") %> </td>
                                            <!-- PRODUCT PRICE -->
                                            <td class="column-3">R <%# Eval("ProductPrice", "{0:F2}") %> </td>
                                            <!-- QUANTITY -->
                                            <td class="column-4">
                                                <div class="wrap-num-product flex-w m-l-auto m-r-0">
                                                    <!-- QUANTITY INPUT -->
                                                    <input class="mtext-104 cl3 txt-center num-product" type="number" min="0" name='quantity_<%# Eval("ProductID") %>' value='<%# Eval("Quantity") %>' />

                                                </div>
                                                <br />
                                                <!-- UPDATE BUTTON -->
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-sm btn-primary" CommandArgument='<%# Eval("ProductID") %>' OnClick="btnUpdate_Click" />
                                                <br />
                                                <br />
                                                <!-- REMOVE BUTTON -->
                                                <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-sm btn-danger" CommandArgument='<%# Eval("ProductID") %>' OnClick="btnRemove_Click" />
                                            </td>
                                            <!-- PRODUCT TOTAL -->
                                            <td class="column-5">R <%# Eval("Total", "{0:F2}") %> </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <!-- ================================================= -->
                        <!-- COUPON / UPDATE CART AREA -->
                        <!-- ================================================= -->
                        <div class="flex-w flex-sb-m bor15 p-t-18 p-b-15 p-lr-40 p-lr-15-sm">
                            <!-- COUPON -->
                            <div class="flex-w flex-m m-r-20 m-tb-5">
                                <asp:TextBox runat="server" CssClass="stext-104 cl2 plh4 size-117 bor13 p-lr-20 m-r-10 m-tb-5" type="text" name="coupon" placeholder="Coupon Code" ID="txtCouponCode" />
                                <div class="flex-c-m stext-101 cl2 size-118 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-5" onclick="btnApplyCoupon_Click">Apply coupon </div>
                                <asp:Label ID="lblCouponMessage" runat="server" />
                            </div>

                        </div>

                    </div>

                </div>

                <!-- CART TOTALS -->
                <div class="col-sm-10 col-lg-7 col-xl-5 m-lr-auto m-b-50">
                    <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-30 m-r-15 m-lr-0-xl p-lr-15-sm">
                        <!-- CART TOTALS TITLE -->
                        <h4 class="mtext-109 cl2 p-b-30">Cart Totals </h4>
                        <!-- SUBTOTAL -->

                        <div class="flex-w flex-t bor12 p-b-13">
                            <div class="size-208">
                                <span class="stext-110 cl2">Subtotal: </span>

                            </div>
                            <div class="size-209">
                                <span class="mtext-110 cl2">
                                    <asp:Label ID="lblSubtotal" runat="server" Text="R 0.00">

                                    </asp:Label>
                                </span>

                            </div>

                            <!-- VAT -->
                            <div class="size-208">
                                <span class="stext-110 cl2">VAT Included: (15%) 

                                </span>

                            </div>
                            <div class="size-209">
                                <span class="mtext-110 cl2">
                                    <asp:Label ID="lblVat" runat="server" Text="R 0.00">

                                    </asp:Label>

                                </span>

                            </div>
                            <!-- SHIPPING -->
                            <div class="size-208">
                                <span class="stext-110 cl2">Shipping: </span>

                            </div>
                            <div class="size-209">
                                <span class="mtext-110 cl2">
                                    <asp:Label ID="lblShipping" runat="server" Text="R 300.00"> 

                                    </asp:Label>

                                </span>

                            </div>

                        </div>
                        <!-- FINAL TOTAL -->
                        <div class="flex-w flex-t p-t-27 p-b-33">
                            <div class="size-208">
                                <span class="mtext-101 cl2">Total: </span>

                            </div>
                            <div class="size-209 p-t-1">
                                <span class="mtext-110 cl2">
                                    <asp:Label ID="lblTotal" runat="server" Text="R 0.00">

                                    </asp:Label>

                                </span>

                            </div>

                        </div>
                        <!-- CHECKOUT BUTTON -->
                        <asp:Button ID="btnCheckout" runat="server" Text="Proceed to Checkout" CssClass="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" OnClick="btnCheckout_Click"></asp:Button>

                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>
