<%@ Page Title="Account Information" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="account-info.aspx.cs" Inherits="Game_Grid.account_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 120px;"></div>

    <div class="acc-info-box">

        <div class="acc-headings">
        <h1 align ="center"> Welcome, [NAME] [SURNAME] </h1>
        <h5 align ="center"> Account Information </h5>
        </div>

        <div class="input-div">
        <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Gray"></asp:Label>
        <input type="text" id="signup-name" placeholder="Name">
        </div>

        <div class="input-div">
        <asp:Label ID="lblsurname" runat="server" Text="Surname" ForeColor="Gray"></asp:Label>
        <input type="text" id="signup-surname" placeholder="Surname">
        </div>

        <div class="input-div">
        <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
        <input type="email" id="signup-email" placeholder="Email">
        </div>

        <div class="input-div">
        <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
        <input type="password" id="signup-password" placeholder="Password">
        </div>

        <button class="edit-info-btn" type="button" onclick="#"> Edit Information</button>
        <button class="save-info-btn" type="button" onclick="#"> Save</button>

    </div>

</asp:Content>
