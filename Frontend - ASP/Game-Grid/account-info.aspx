<%@ Page Title="Account Information" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="account-info.aspx.cs" Inherits="Game_Grid.account_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings">
                <h1 align="center">Welcome, [NAME] [SURNAME] </h1>
                <h5 align="center">Account Information </h5>
            </div>

            <div class="row">

                <div class="col-11 col-md-8 col-lg-6 m-lr-auto">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="[USER NAME]"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblSurname" runat="server" Text="Surname" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="[USER SURNAME]"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblDOB" runat="server" Text="Date of Birth" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="[USER Date Of Birth]"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblGender" runat="server" Text="Gender" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="[USER GENDER]"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="[USER EMAIL]"></asp:TextBox>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#">Edit Information</button>
                        </div>

                        <div class="col-md-6">
                            <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#">Save</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
