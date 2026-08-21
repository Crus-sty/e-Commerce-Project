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
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Enter your Email here..."></asp:TextBox><--changed input to textbox-->
        </div>
       
        <div class="input-div">
        <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter your Password here..."></asp:TextBox>
        </div>

        <asp:Button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="btnLogin_Click">Login</asp:Button>
		
        <p>Don't have an account?
            <a href="sign-up.aspx">Sign Up</a>
        </p>
        </div>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Placeholder=""></asp:Label>
    </div>

</asp:Content>
