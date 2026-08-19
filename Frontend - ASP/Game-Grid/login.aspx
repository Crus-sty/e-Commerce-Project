<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Game_Grid.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="acc-headings">
        <h1 align ="center"> Login </h1>
        </div>

        <div class="order-md-1 col-11 col-md-5 col-lg-4 m-lr-auto p-b-30">

        <div class="input-div">
        <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
        <input type="email" id="login-email" placeholder="Enter your Email here...">
        </div>

        <div class="input-div">
        <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
        <input type="password" id="login-password" placeholder="Enter your Password here...">
        </div>

        <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#">Login</button>

        <p>Don't have an account?
            <a href="sign-up.aspx">Sign Up</a>
        </p>
        </div>
    </div>

</asp:Content>
