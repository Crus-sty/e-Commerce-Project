<%@ Page Title="Order Management"
    Language="C#"
    MasterPageFile="~/Admin.Master"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="orders.aspx.cs"
    Inherits="Game_Grid.orders" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 align="center">
                    Order&nbsp; Management
                </h1>
            </div>

            <div class="row mb-4">
                <div class="col-md-8 mx-auto">

                    <div class="form-group">
                        <asp:TextBox
                            ID="txtSearch"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Enter Order ID">
                        </asp:TextBox>
                    </div>

                    <div class="text-center mt-3">

                        <asp:Button
                            ID="btnSearchOrder"
                            runat="server"
                            Text="Search Order"
                            CssClass="btn btn-primary"
                            OnClick="btnSearchOrders_Click" />

                        <asp:Button
                            ID="btnViewAll"
                            runat="server"
                            Text="View All Orders"
                            CssClass="btn btn-secondary ml-2"
                            OnClick="btnViewAll_Click" />

                    </div>

                    <div class="text-center mt-3">
                        <asp:Label
                            ID="lblMessage"
                            runat="server"
                            CssClass="text-danger">
                        </asp:Label>
                    </div>

                </div>
            </div>

            <div class="row">

                <div class="col-lg-12 m-lr-auto m-b-50">

                    <div class="wrap-table-shopping-cart">

                        <table class="table-shopping-cart">

                            <tr class="table_head">

                                <th class="column-1">
                                    Order No.
                                </th>

                                <th class="column-2">
                                    Customer
                                </th>

                                <th class="column-2">
                                    Number of Items
                                </th>

                                <th class="column-2">
                                    Total Price
                                </th>

                                <th class="column-3">
                                    Status
                                </th>

                                <th class="column-3">
                                    Manage
                                </th>

                            </tr>

                            <asp:Repeater
                                ID="rptOrders"
                                runat="server">

                                <ItemTemplate>

                                    <tr class="table_row">

                                        <td class="column-1">
                                            <%# Eval("orderId") %>
                                        </td>

                                        <td class="column-2">
                                            <%# Eval("customerName") %>
                                        </td>

                                        <td class="column-2">
                                            <%# Eval("numberOfItems") %>
                                        </td>

                                        <td class="column-2">
                                            R <%# Eval("totalAmount", "{0:F2}") %>
                                        </td>

                                        <td class="column-3">
                                            <%# Eval("status") %>
                                        </td>

                                        <td class="column-3">

                                            <asp:Button
                                                ID="btnViewOrder"
                                                runat="server"
                                                Text="View"
                                                CssClass="btn btn-primary btn-sm"
                                                CommandArgument='<%# Eval("orderId") %>'
                                                OnCommand="btnViewOrder_Command" />

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

</asp:Content>