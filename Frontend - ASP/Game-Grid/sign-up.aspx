<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="Game_Grid.sign_up" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="bg0 p-t-75 p-b-85">
        <div class="container">

            <div class="acc-headings p-b-40">
                <h1 class="text-center">Sign Up / Create Account</h1>
            </div>


            <div class="row">

                <div class="col-11 col-md-8 col-lg-6 m-lr-auto">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
                            </div>
                        </div>


                        <div class="col-md-6">
                            <div class="form-group">

                                <asp:Label ID="lblSurname" runat="server" Text="Surname" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="Enter your surname"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblDOB" runat="server" Text="Date of Birth" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="Enter your date of birth"></asp:TextBox>
                            </div>
                        </div>


                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblGender" runat="server" Text="Gender" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Enter your gender"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">

                                <asp:Label ID="lblPassword" runat="server" Text="Password" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" ForeColor="Gray"></asp:Label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm your password"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="text-center p-t-20">
                        <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" CssClass="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04"OnClick="btnCreateAccount_Click"></asp:Button>
                    </div>


                    <div class="text-center p-t-25">

                        <p class="stext-113 cl6">
                            Already have an account?
                        <a href="login.aspx" class="mtext-106 cl2">Login</a>
                        </p>

                    </div>

                    <div class="text-center p-t-25">

                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

                    </div>

                </div>

            </div>

        </div>

    </div>



</asp:Content>
