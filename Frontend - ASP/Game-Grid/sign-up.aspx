<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="Game_Grid.sign_up" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 120px;"></div>

        <div class="signup-box">

            <div class="acc-headings">
            <h1 align ="center"> Sign Up / Create Account </h1>
            </div>

            <div class="input-div">
            <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Gray"></asp:Label>
            <input type="text" id="signup-name" placeholder="Enter your Name here...">
            </div>

            <div class="input-div">
            <asp:Label ID="lblsurname" runat="server" Text="Surname" ForeColor="Gray"></asp:Label>
            <input type="text" id="signup-surname" placeholder="Enter your Surname here...">
            </div>

            <div class="input-div">
            <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
            <input type="email" id="signup-email" placeholder="Enter your Email here...">
            </div>

            <div class="input-div">
            <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
            <input type="password" id="signup-password" placeholder="Enter your Password here...">
            </div>

            <div class="input-div">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" ForeColor="Gray"></asp:Label>
            <input type="password" id="confirm-password" placeholder="Enter your Password again...">
            </div>

            <button class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04" type="button" onclick="#">Create Account</button>

            <p>Already have an account?
                <a href="login.aspx">Login</a>
            </p>

        </div>



</asp:Content>
