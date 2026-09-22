<%@ Page Title="Discounts" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="discounts.aspx.cs" Inherits="Game_Grid.promo_codes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 align="center">
                    Discounts / Promotion Codes
                </h1>
            </div>

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="text-danger">
            </asp:Label>

            <!-- SEARCH -->

            <div class="flex-w flex-sb-m bor0 p-t-18 p-b-15">

                <asp:TextBox
                    ID="txtSearch"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Discount No.">
                </asp:TextBox>

                <asp:Button
                    ID="btnSearch"
                    runat="server"
                    Text="Search Discount"
                    CssClass="btn btn-primary mt-3"
                    OnClick="btnSearchDiscounts_Click" />

            </div>


            <!-- ADD DISCOUNT -->

            <div class="bor10 p-lr-30 p-t-30 p-b-30 m-t-30">

                <h3 class="mtext-105 cl2 p-b-20">
                    Add Discount
                </h3>

                <div class="p-b-15">

                    <label>Discount Number</label>

                    <asp:TextBox
                        ID="txtDiscountNo"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter discount number">
                    </asp:TextBox>

                </div>

                <div class="p-b-15">

                    <label>Description</label>

                    <asp:TextBox
                        ID="txtDescription"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Discount description">
                    </asp:TextBox>

                </div>

                <div class="p-b-15">

                    <label>Discount Percentage</label>

                    <asp:TextBox
                        ID="txtDiscountPercentage"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter percentage">
                    </asp:TextBox>

                </div>

                <div class="p-b-15">

                    <label>Start Date</label>

                    <asp:TextBox
                        ID="txtStartDate"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Date">
                    </asp:TextBox>

                </div>

                <div class="p-b-15">

                    <label>End Date</label>

                    <asp:TextBox
                        ID="txtEndDate"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Date">
                    </asp:TextBox>

                </div>

                <asp:Button
                    ID="btnAddDiscount"
                    runat="server"
                    Text="Add Discount"
                    CssClass="btn btn-primary"
                    OnClick="btnAddDiscount_Click" />

            </div>


            <!-- DISCOUNT TABLE -->

            <div class="row m-t-50">

                <div class="col-lg-10 col-xl-8 m-lr-auto m-b-50">

                    <div class="wrap-table-shopping-cart">

                        <table class="table-shopping-cart">

                            <tr class="table_head">

                                <th class="column-1">
                                    Discount No.
                                </th>

                                <th class="column-2">
                                    Description
                                </th>

                                <th class="column-3">
                                    Start Date
                                </th>

                                <th class="column-4">
                                    End Date
                                </th>

                                <th class="column-5">
                                    Manage
                                </th>

                            </tr>


                            <asp:Repeater
                                ID="rptDiscounts"
                                runat="server">

                                <ItemTemplate>

                                    <tr class="table_row">

                                        <td class="column-1">
                                            <%# Eval("DiscountNo") %>
                                        </td>

                                        <td class="column-2">
                                            <%# Eval("Description") %>
                                        </td>

                                        <td class="column-3">
                                            <%# Eval("StartDate") %>
                                        </td>

                                        <td class="column-4">
                                            <%# Eval("EndDate") %>
                                        </td>

                                        <td class="column-5">

                                            <asp:Button
                                                ID="btnDeleteDiscount"
                                                runat="server"
                                                Text="Delete"
                                                CssClass="btn btn-danger"
                                                CommandArgument='<%# Eval("DiscountNo") %>'
                                                OnClick="btnDeleteDiscount_Click" />

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