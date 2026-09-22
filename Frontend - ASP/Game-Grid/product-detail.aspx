<%@ Page Title="Product Details"
    Language="C#"
    MasterPageFile="~/Main-2.Master"
    AutoEventWireup="true"
    Async="true"
    CodeBehind="product-detail.aspx.cs"
    Inherits="Game_Grid.product_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .product-detail-image {
            width: 100%;
            max-height: 500px;
            object-fit: contain;
        }

        .product-detail-container {
            padding: 40px 20px;
        }

        .quantity-box {
            display: flex;
            align-items: center;
            margin-top: 20px;
            margin-bottom: 20px;
        }

        .quantity-box .quantity-label {
            margin-right: 15px;
            font-weight: bold;
        }

        .quantity-input {
            width: 70px;
            text-align: center;
        }

        .product-price {
            font-size: 24px;
            font-weight: bold;
            margin-top: 15px;
        }

        .product-description {
            margin-top: 20px;
            line-height: 1.7;
        }

        .product-category {
            color: #888;
            text-transform: uppercase;
            margin-bottom: 10px;
        }

        .stock-text {
            margin-top: 15px;
            color: #555;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="container product-detail-container">

        <asp:Repeater ID="rptProduct" runat="server">

            <ItemTemplate>

                <div class="row">

                    <!-- PRODUCT IMAGE -->
                    <div class="col-md-6">

                        <div class="product-image-container">

                            <asp:Image
                                ID="imgProduct"
                                runat="server"
                                CssClass="product-detail-image"
                                ImageUrl='<%# Eval("ImageUrl") %>'
                                AlternateText='<%# Eval("Name") %>' />

                        </div>

                    </div>


                    <!-- PRODUCT INFORMATION -->
                    <div class="col-md-6">

                        <!-- CATEGORY -->
                        <div class="product-category">
                            <%# Eval("Category") %>
                        </div>


                        <!-- NAME -->
                        <h1>
                            <%# Eval("Name") %>
                        </h1>


                        <!-- PRICE -->
                        <div class="product-price">

                            R <%# Eval("Price", "{0:N2}") %>

                        </div>


                        <!-- DESCRIPTION -->
                        <div class="product-description">

                            <p>
                                <%# Eval("Description") %>
                            </p>

                        </div>


                        <!-- STOCK -->
                        <div class="stock-text">

                            Stock available:
                            <%# Eval("StockQuantity") %>

                        </div>


                        <!-- QUANTITY -->
                        <div class="quantity-box">

                            <span class="quantity-label">
                                Quantity:
                            </span>

                            <asp:TextBox
                                ID="txtQuantity"
                                runat="server"
                                CssClass="quantity-input"
                                Text="1"
                                TextMode="Number">
                            </asp:TextBox>

                        </div>


                        <!-- ADD TO CART -->
                        <asp:Button
                            ID="btnAddToCart"
                            runat="server"
                            CssClass="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04"
                            Text="Add to cart"
                            OnClick="btnAddToCart_Click" />

                    </div>

                </div>

            </ItemTemplate>

        </asp:Repeater>


        <!-- PRODUCT NOT FOUND MESSAGE -->

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="text-danger">
        </asp:Label>


        <!-- RELATED PRODUCTS -->

        <div class="row mt-5">

            <div class="col-12">

                <h3 class="mb-4">
                    Related Products
                </h3>

            </div>

            <asp:Repeater
                ID="rptRelatedProducts"
                runat="server">

                <ItemTemplate>

                    <div class="col-sm-6 col-md-4 col-lg-3 p-b-35">

                        <div class="block2">

                            <div class="block2-pic hov-img0">

                                <asp:Image
                                    ID="imgRelatedProduct"
                                    runat="server"
                                    CssClass="img-fluid"
                                    ImageUrl='<%# Eval("ImageUrl") %>'
                                    AlternateText='<%# Eval("Name") %>' />

                            </div>

                            <div class="block2-txt flex-w flex-t p-t-14">

                                <div class="block2-txt-child1 flex-col-l">

                                    <a
                                        href='<%# "product-detail.aspx?id=" + Eval("Id") %>'
                                        class="stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6">

                                        <%# Eval("Name") %>

                                    </a>

                                    <span class="stext-105 cl3">

                                        R <%# Eval("Price", "{0:N2}") %>

                                    </span>

                                </div>

                            </div>

                        </div>

                    </div>

                </ItemTemplate>

            </asp:Repeater>

        </div>

    </div>

</asp:Content>