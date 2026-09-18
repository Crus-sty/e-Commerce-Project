<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="discounts.aspx.cs" Inherits="Game_Grid.promo_codes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 align="center">Discounts / Promotions Codes
                </h1>
            </div>

            <div class="flex-w flex-sb-m bor0 p-t-18 p-b-15 p-lr-10 p-lr-10-sm">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Discount No."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search Discount" CssClass="btn btn-primary mt-3" OnClick="btnSearchDiscounts_Click"></asp:Button>
                <asp:Button ID="btnAddDiscount" runat="server" Text="Add Discount" CssClass="btn btn-primary mt-3" OnClick="btnAddDiscount_Click"></asp:Button>
                <asp:Button ID="btnDeleteDiscount" runat="server" Text="Delete Discount" CssClass="btn btn-primary mt-3" OnClick="btnDeleteDiscount_Click"></asp:Button>
            </div>

            <div class="row">

                <div class="col-lg-10 col-xl-8 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">
                        <div class="wrap-table-shopping-cart">
                            <table class="table-shopping-cart">
                                <tr class="table_head">
                                    <th class="column-1">Discount No.</th>
                                    <th class="column-1">Description</th>
                                    <th class="column-3">Start Date</th>
                                    <th class="column-3">End Date</th>
                                    <th class="column-3">Manage / Modify</th>
                                </tr>

                                <tr class="table_row">
                                    <td class="column-1">[Discount No.]</td>
                                    <td class="column-1">[Description]</td>
                                    <td class="column-3">[Start Date]</td>
                                    <td class="column-3">[End Date]</td>

                                    <td class="column-3">
                                        <!-- Remove button -->
                                        <div class="block2-txt-child2 flex-r p-t-3">
                                            <a href="#" class="btn-addwish-b2 dis-block pos-relative js-addwish-b2" onclick="btnRemove_Click">
                                                <img class="icon-heart1 dis-block trans-04" src="images/icons/icon-heart-01.png" alt="ICON">
                                                <img class="icon-heart2 dis-block trans-04 ab-t-l" src="/images/icons/icon-heart-02.png" alt="ICON">
                                            </a>
                                        </div>
                                    </td>
                                </tr>

                                <!-- Repeater -->

                                <asp:Repeater ID="rptWishlist" runat="server">
                                    <ItemTemplate>
                                        <tr class="table_row">
                                            <td class="column-1">
                                                <div class="how-itemcart1">
                                                    <img src='<%# Eval("DiscountNo") %>' alt="IMG">
                                                </div>
                                            </td>
                                            <td class="column-2"><%# Eval("Description") %></td>
                                            <td class="column-3"><%# Eval("StartDate") %></td>
                                            <td class="column-4"><%# Eval("EndDate") %></td>

                                            <td class="column-5">
                                                <div class="block2-txt-child2 flex-r p-t-3">
                                                    <a href="#" class="btn-addwish-b2 dis-block pos-relative js-addwish-b2">
                                                        <img class="icon-heart1 dis-block trans-04" src="images/icons/icon-heart-01.png" alt="ICON">
                                                        <img class="icon-heart2 dis-block trans-04 ab-t-l" src="/images/icons/icon-heart-02.png" alt="ICON">
                                                    </a>
                                                </div>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </table>
                        </div>
                    </div>
                </div>



            </div>


        </div>
    </div>

</asp:Content>
