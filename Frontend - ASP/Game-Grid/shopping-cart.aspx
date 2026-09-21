<%@ Page Title="Shopping Cart"
    Language="C#"
    MasterPageFile="~/Main-2.Master"
    AutoEventWireup="true"
    CodeBehind="shopping-cart.aspx.cs"
    Inherits="Game_Grid.shopping_cart"
    Async="true" %>

<asp:Content ID="HeadContent"
    ContentPlaceHolderID="head"
    runat="server">

    <style>
        .cart-product-image {
            width: 100px;
            height: 100px;
            object-fit: contain;
        }

        .cart-quantity-input {
            width: 70px;
            height: 40px;
            border: 1px solid #e6e6e6;
            text-align: center;
            padding: 5px;
        }

        .cart-action-button {
            border: none;
            cursor: pointer;
            padding: 8px 12px;
            margin: 3px;
            color: white;
        }

        .cart-update-button {
            background-color: #717fe0;
        }

        .cart-remove-button {
            background-color: #e65540;
        }

        .cart-summary-box {
            border: 1px solid #e6e6e6;
            padding: 30px;
        }

        .cart-summary-row {
            display: flex;
            justify-content: space-between;
            padding: 12px 0;
            border-bottom: 1px solid #eeeeee;
        }

        .cart-summary-total {
            font-size: 18px;
            font-weight: bold;
        }

        .cart-coupon-input {
            width: 100%;
            height: 45px;
            border: 1px solid #e6e6e6;
            padding: 10px;
        }

        .cart-coupon-button {
            height: 45px;
            background-color: #222222;
            color: white;
            border: none;
            padding: 0 20px;
            cursor: pointer;
        }

        .cart-message {
            display: block;
            margin-bottom: 20px;
        }

        .empty-cart-message {
            text-align: center;
            padding: 40px;
        }

        @media (max-width: 768px) {
            .cart-table-wrapper {
                overflow-x: auto;
            }

            .cart-table {
                min-width: 800px;
            }
        }
    </style>

</asp:Content>


<asp:Content ID="MainContent"
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


        <span class="stext-109 cl4">
            Cart
        </span>

    </div>

</div>
    <!-- Page Header -->
        <h2 class="ltext-105 cl0 txt-center">
            Shopping Cart
        </h2>


    <!-- Shopping Cart -->
    <section class="bg0 p-t-75 p-b-85">

        <div class="container">

            <!-- Message -->
            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="cart-message">
            </asp:Label>


            <div class="row">

                <!-- Cart Items -->
                <div class="col-lg-8 m-lr-auto m-b-50">

                    <div class="cart-table-wrapper">

                        <table class="table-shopping-cart cart-table">

                            <thead>
                                <tr class="table_head">

                                    <th class="column-1">
                                        Product
                                    </th>

                                    <th class="column-2">
                                        Name
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

                                    <th class="column-6">
                                        Actions
                                    </th>

                                </tr>
                            </thead>


                            <tbody>

                                <asp:Repeater
                                    ID="rptCart"
                                    runat="server">

                                    <ItemTemplate>

                                        <tr class="table_row">

                                            <!-- Product Image -->
                                            <td class="column-1">

                                                <div class="how-itemcart1">

                                                    <img
                                                        src='<%# Eval("ProductImage") %>'
                                                        alt='<%# Eval("ProductName") %>'
                                                        class="cart-product-image"
                                                        onerror="this.src='/images/no-image.png';" />

                                                </div>

                                            </td>


                                            <!-- Product Name -->
                                            <td class="column-2">

                                                <span class="stext-105 cl2">

                                                    <%# Eval("ProductName") %>

                                                </span>

                                            </td>


                                            <!-- Product Price -->
                                            <td class="column-3">

                                                <span class="stext-105 cl2">

                                                    R <%# Eval("ProductPrice", "{0:N2}") %>

                                                </span>

                                            </td>


                                            <!-- Quantity -->
                                            <td class="column-4">

                                                <div class="wrap-num-product flex-w m-l-auto m-r-0">

                                                    <input
                                                        type="number"
                                                        name='<%# "quantity_" + Eval("ProductID") %>'
                                                        value='<%# Eval("Quantity") %>'
                                                        min="1"
                                                        class="mtext-104 cl3 txt-center num-product cart-quantity-input" />

                                                </div>

                                            </td>


                                            <!-- Item Total -->
                                            <td class="column-5">

                                                <span class="stext-105 cl2">

                                                    R <%# Eval("Total", "{0:N2}") %>

                                                </span>

                                            </td>


                                            <!-- Actions -->
                                            <td class="column-6">

                                                <asp:Button
                                                    ID="btnUpdate"
                                                    runat="server"
                                                    Text="Update"
                                                    CssClass="cart-action-button cart-update-button"
                                                    CommandArgument='<%# Eval("ProductID") %>'
                                                    OnClick="btnUpdate_Click" />

                                                <asp:Button
                                                    ID="btnRemove"
                                                    runat="server"
                                                    Text="Remove"
                                                    CssClass="cart-action-button cart-remove-button"
                                                    CommandArgument='<%# Eval("ProductID") %>'
                                                    OnClick="btnRemove_Click"
                                                    OnClientClick="return confirm('Remove this product from your cart?');" />

                                            </td>

                                        </tr>

                                    </ItemTemplate>

                                </asp:Repeater>

                            </tbody>

                        </table>

                    </div>


                    <!-- Empty Cart -->
                    <asp:Panel
                        ID="pnlEmptyCart"
                        runat="server"
                        Visible="false"
                        CssClass="empty-cart-message">

                        <h4 class="mtext-109 cl2 p-b-20">
                            Your cart is empty
                        </h4>

                        <a
                            href="/shop"
                            class="flex-c-m stext-101 cl0 size-118 bg3 bor2 hov-btn3 p-lr-15 trans-04">

                            Continue Shopping

                        </a>

                    </asp:Panel>


                    <!-- Continue Shopping -->
                    <div class="flex-w flex-sb-m p-t-18">

                        <a
                            href="/shop"
                            class="flex-c-m stext-101 cl2 size-118 bg8 bor13 hov-btn3 p-lr-15 trans-04">

                            Continue Shopping

                        </a>

                    </div>

                </div>


                <!-- Cart Summary -->
                <div class="col-lg-4 m-lr-auto m-b-50">

                    <div class="cart-summary-box">

                        <h4 class="mtext-109 cl2 p-b-30">
                            Cart Totals
                        </h4>


                        <!-- Coupon -->
                        <div class="p-b-30">

                            <h5 class="stext-110 cl2 p-b-10">
                                Coupon Code
                            </h5>

                            <asp:TextBox
                                ID="txtCoupon"
                                runat="server"
                                CssClass="cart-coupon-input"
                                placeholder="Enter coupon code">
                            </asp:TextBox>

                            <div class="p-t-10">

                                <asp:Button
                                    ID="btnApplyCoupon"
                                    runat="server"
                                    Text="Apply Coupon"
                                    CssClass="cart-coupon-button"
                                    OnClick="btnApplyCoupon_Click" />

                            </div>

                        </div>


                        <!-- Subtotal -->
                        <div class="cart-summary-row">

                            <span class="stext-110 cl2">
                                Subtotal
                            </span>

                            <span class="stext-110 cl2">

                                R
                                <asp:Label
                                    ID="lblSubtotal"
                                    runat="server"
                                    Text="0.00">
                                </asp:Label>

                            </span>

                        </div>


                        <!-- VAT -->
                        <div class="cart-summary-row">

                            <span class="stext-110 cl2">
                                VAT Included(15%)
                            </span>

                            <span class="stext-110 cl2">

                                R
                                <asp:Label
                                    ID="lblVat"
                                    runat="server"
                                    Text="0.00">
                                </asp:Label>

                            </span>

                        </div>


                        <!-- Shipping -->
                        <div class="cart-summary-row">

                            <span class="stext-110 cl2">
                                Shipping
                            </span>

                            <span class="stext-110 cl2">

                                R
                                <asp:Label
                                    ID="lblShipping"
                                    runat="server"
                                    Text="0.00">
                                </asp:Label>

                            </span>

                        </div>


                        <!-- Total -->
                        <div class="cart-summary-row cart-summary-total">

                            <span class="stext-110 cl2">
                                Total
                            </span>

                            <span class="stext-110 cl2">

                                R
                                <asp:Label
                                    ID="lblTotal"
                                    runat="server"
                                    Text="0.00">
                                </asp:Label>

                            </span>

                        </div>


                        <!-- Checkout -->
                        <div class="p-t-30">

                            <asp:Button
                                ID="btnCheckout"
                                runat="server"
                                Text="Proceed to Checkout"
                                CssClass="flex-c-m stext-101 cl0 size-101 bg3 bor1 hov-btn3 p-lr-15 trans-04 w-full"
                                OnClick="btnCheckout_Click" />

                        </div>

                    </div>
                    <!-- /cart-summary-box -->

                </div>
                <!-- /col-lg-4 -->

            </div>
            <!-- /row -->

        </div>
        <!-- /container -->

    </section>
    <!-- /Shopping Cart -->

</asp:Content>