<%@ Page Title="Account Information" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="account-info.aspx.cs" Inherits="Game_Grid.account_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="acc-headings">
        <h1 align ="center"> Welcome, [NAME] [SURNAME] </h1>
        <h5 align ="center"> Account Information </h5>
        </div>

        <div class="order-md-1 col-11 col-md-5 col-lg-4 m-lr-auto p-b-30">

        <div class="input-div">
        <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Gray"></asp:Label>
        <input type="text" id="signup-name" placeholder="[User Name]">
        </div>

        <div class="input-div">
        <asp:Label ID="lblsurname" runat="server" Text="Surname" ForeColor="Gray"></asp:Label>
        <input type="text" id="signup-surname" placeholder="[User Surname]">
        </div>

        <div class="input-div">
        <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
        <input type="email" id="signup-email" placeholder="[User Email]">
        </div>

        <div class="input-div">
        <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
        <input type="password" id="signup-password" placeholder="[User Password]">
        </div>

        <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#"> Edit Information</button>
        <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#"> Save</button>

        </div>
    </div>

</asp:Content>
