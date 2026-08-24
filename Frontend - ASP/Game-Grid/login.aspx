<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Game_Grid.login" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 align="center">Login </h1>
            </div>

            <div class="col-12 col-md-8 col-lg-6 m-lr-auto">

                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter your Email here..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your Password here..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-9">
                        <asp:Button runat="server" class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04 pointer" type="button" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-9">
                    <p class="stext-113 cl6">
                        Don't have an account?
                                <a href="sign-up.aspx" class="mtext-106 cl2">Sign Up</a>
                    </p>
                        </div>
                </div>

                <div class="text-center p-t-25">

                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

                </div>
            </div>

        </div>
    </div>

</asp:Content>
