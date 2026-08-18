<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Game_Grid.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 120px;"></div>

    <div class="login">

        <div class="acc-headings">
        <h1 align ="center"> Login </h1>
        </div>

        <div class="input-div">
        <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
        <input type="email" id="login-email" placeholder="Enter your Email here...">
        </div>

        <div class="input-div">
        <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
        <input type="password" id="login-password" placeholder="Enter your Password here...">
        </div>

        <button class="login-btn" type="button" onclick="#">Login</button>

        <p>Don't have an account?
            <a href="sign-up.aspx">Sign Up</a>
        </p>

    </div>

</asp:Content>
