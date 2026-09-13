<%@ Page Title="Wishlist" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="Game_Grid.wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mtext-105 cl2 txt-center p-b-30">Wishlist</h2>

    <div class="bg0 p-t-75 p-b-85">

        <div class="container">
            <div class="row">

                <div class="col-lg-10 col-xl-8 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">
                        <div class="wrap-table-shopping-cart">
                            <table class="table-shopping-cart">
                                <tr class="table_head">
                                    <th class="column-1">Product</th>
                                    <th class="column-2"></th>
                                    <th class="column-3">Price</th>
                                    <th class="column-4">Availability</th>
                                    <th class="column-5">Remove</th>
                                </tr>

                                <!-- Repeater: one row per wishlist item from GET /api/wishlist -->
                                <asp:Repeater ID="rptWishlist" runat="server">
                                    <ItemTemplate>
                                        <tr class="table_row">
                                            <td class="column-1">
                                                <div class="how-itemcart1">
                                                    <img src='<%# Eval("ProductImage") %>' alt="IMG">
                                                </div>
                                            </td>

                                            <td class="column-2"><%# Eval("ProductName") %></td>

                                            <td class="column-3"><%# Eval("Price", "{0:F2}") %></td>

                                            <td class="column-4">
                                                <span class="stext-110 cl2">
                                                    <%# (bool)Eval("InStock") ? "In Stock" : "Out of Stock" %>
                                                </span>
                                            </td>

                                            <td class="column-5">
                                                <div class="block2-txt-child2 flex-r p-t-3">
                                                    <asp:LinkButton runat="server"
                                                        CommandArgument='<%# Eval("ProductId") %>'
                                                        OnClick="btnRemove_Click"
                                                        CssClass="btn-addwish-b2 dis-block pos-relative js-addwish-b2">
                                                        <img class="icon-heart1 dis-block trans-04"
                                                             src="images/icons/icon-heart-01.png" alt="ICON">
                                                        <img class="icon-heart2 dis-block trans-04 ab-t-l"
                                                             src="images/icons/icon-heart-02.png" alt="ICON">
                                                    </asp:LinkButton>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </table>
                        </div>

                        <div class="flex-w flex-sb-m bor15 p-t-18 p-b-15 p-lr-40 p-lr-15-sm">
                            <div class="flex-c-m stext-101 cl2 size-119 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-10">
                                Update Wishlist
                            </div>
                        </div>

                        <!-- Error / info messages surface here -->
                        <asp:Literal ID="litMessage" runat="server" />
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>