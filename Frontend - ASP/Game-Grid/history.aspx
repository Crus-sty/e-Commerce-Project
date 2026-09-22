<%@ Page Title="Order History" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" Async="true" CodeBehind="history.aspx.cs" Inherits="Game_Grid.history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 align="center">Orders</h1>
            </div>

            <div class="row">

                <div class="col-lg-10 col-xl-8 m-lr-auto m-b-50">
                    <div class="m-l-25 m-r--38 m-lr-0-xl">

                        <asp:Label ID="lblMessage" runat="server"
                            CssClass="text-danger">
                        </asp:Label>

                        <div class="wrap-table-shopping-cart">

                            <table class="table-shopping-cart">

                                <tr class="table_head">
                                    <th class="column-1">Order No.</th>
                                    <th class="column-2">Number of Items</th>
                                    <th class="column-3">Total Price</th>
                                    <th class="column-4">Status</th>
                                    <th class="column-5">View Order</th>
                                </tr>

                                <asp:Repeater ID="rptOrders" runat="server"
                                    OnItemCommand="rptOrders_ItemCommand">

                                    <ItemTemplate>

                                        <tr class="table_row">

                                            <td class="column-1">
                                                <%# Eval("OrderNo") %>
                                            </td>

                                            <td class="column-2">
                                                <%# Eval("NumberOfItems") %>
                                            </td>

                                            <td class="column-3">R <%# Eval("TotalPrice", "{0:F2}") %>
                                            </td>

                                            <td class="column-4">
                                                <%# Eval("Status") %>
                                            </td>

                                            <td class="column-5">

                                                <asp:HyperLink
                                                    ID="btnViewOrder"
                                                    runat="server"
                                                    Text="View Order"
                                                    CssClass="btn btn-primary mt-3"
                                                    NavigateUrl='<%# "/account/history/" + Eval("Id") %>'>
                                                </asp:HyperLink>
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
