<%@ Page Title="Products" Language="C#" MasterPageFile="~/Main-2.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Game_Grid.product" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Product Section -->
    <div class="bg0 m-t-23 p-b-140">

        <div class="container">

            <!-- Product Categories -->
            <div class="flex-w flex-sb-m p-b-52">

                <div class="flex-w flex-l-m filter-tope-group m-tb-10">

                    <asp:LinkButton href="/shop/monitors-and-displays" runat="server" ID="btn_monitors" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Monitors">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/console-gaming" runat="server" ID="btn_console" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Gaming">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/pc-components" ID="btn_pcgaming" runat="server" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="PC Components">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/laptops" ID="btn_laptops" runat="server" type="button" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Laptops">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/headphones" ID="btn_headphones" runat="server" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Headphones">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/speakers" ID="btn_speakers" runat="server" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Speakers">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/cables-and-adapters" ID="btn_cables" runat="server" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Cable &amp; Adapters">
                    </asp:LinkButton>

                    <asp:LinkButton href="/shop/extras" ID="btn_extras" runat="server" class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5"
                        data-filter="*" Text="Extras">
                    </asp:LinkButton>

                </div>


                <!-- Filter and Search Buttons -->
                <div class="flex-w flex-c-m m-tb-10">

                    <div class="flex-c-m stext-106 cl6 size-104 bor4 pointer hov-btn3 trans-04 m-r-8 m-tb-4 js-show-filter">

                        <i class="icon-filter cl2 m-r-6 fs-15 trans-04 zmdi zmdi-filter-list"></i>

                        <i class="icon-close-filter cl2 m-r-6 fs-15 trans-04 zmdi zmdi-close dis-none"></i>

                        Filter

                    </div>


                    <div class="flex-c-m stext-106 cl6 size-105 bor4 pointer hov-btn3 trans-04 m-tb-4 js-show-search">

                        <i class="icon-search cl2 m-r-6 fs-15 trans-04 zmdi zmdi-search"></i>

                        <i class="icon-close-search cl2 m-r-6 fs-15 trans-04 zmdi zmdi-close dis-none"></i>

                        Search

                    </div>

                </div>


                <!-- Search Product -->
                <div class="dis-none panel-search w-full p-t-10 p-b-15">

                    <div class="bor8 dis-flex p-l-15">

                        <button class="size-113 flex-c-m fs-16 cl2 hov-cl1 trans-04"
                            type="button">

                            <i class="zmdi zmdi-search"></i>

                        </button>


                        <input class="mtext-107 cl2 size-114 plh2 p-r-15"
                            type="text"
                            id="searchProduct"
                            name="search-product"
                            placeholder="Search Products">
                    </div>

                </div>


                <!-- Filter Panel -->
                <div class="dis-none panel-filter w-full p-t-10">

                    <div class="wrap-filter flex-w bg6 w-full p-lr-40 p-t-27 p-lr-15-sm">


                        <!-- Sort -->
                        <div class="filter-col1 p-r-15 p-b-27">

                            <div class="mtext-102 cl2 p-b-15">
                                Sort By
                            </div>

                            <ul>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04 filter-link-active">Default
                                    </a>
                                </li>


                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">Popularity
                                    </a>
                                </li>


                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">Average Rating
                                    </a>
                                </li>


                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">Newness
                                    </a>
                                </li>


                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">Price: Low to High
                                    </a>
                                </li>


                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">Price: High to Low
                                    </a>
                                </li>

                            </ul>

                        </div>


                        <!-- Price Filter -->
                        <div class="filter-col2 p-r-15 p-b-27">

                            <div class="mtext-102 cl2 p-b-15">
                                Price
                            </div>

                            <ul>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04 filter-link-active">All
                                    </a>
                                </li>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">R0.00 - R499.99
                                    </a>
                                </li>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">R500.00 - R1,999.99
                                    </a>
                                </li>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">R2,000.00 - R3,999.99
                                    </a>
                                </li>

                                <li class="p-b-6">
                                    <a href="#"
                                        class="filter-link stext-106 trans-04">R4,000.00 +
                                    </a>
                                </li>

                            </ul>

                        </div>


                        <!-- Color Filter -->
                        <div class="filter-col3 p-r-15 p-b-27">

                            <div class="mtext-102 cl2 p-b-15">
                                Color
                            </div>

                            <ul>

                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #222;">
                                        <i class="zmdi zmdi-circle"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">Black
                                    </a>

                                </li>


                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #4272d7;">
                                        <i class="zmdi zmdi-circle"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">Blue
                                    </a>

                                </li>


                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #b3b3b3;">
                                        <i class="zmdi zmdi-circle"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">Grey
                                    </a>

                                </li>


                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #00ad5f;">
                                        <i class="zmdi zmdi-circle"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">Green
                                    </a>

                                </li>


                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #fa4251;">
                                        <i class="zmdi zmdi-circle"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">Red
                                    </a>

                                </li>


                                <li class="p-b-6">

                                    <span class="fs-15 lh-12 m-r-6"
                                        style="color: #aaa;">
                                        <i class="zmdi zmdi-circle-o"></i>
                                    </span>

                                    <a href="#" class="filter-link stext-106 trans-04">White
                                    </a>

                                </li>

                            </ul>

                        </div>


                        <!-- Tags -->
                        <div class="filter-col4 p-b-27">

                            <div class="mtext-102 cl2 p-b-15">
                                Tags
                            </div>

                            <div class="flex-w p-t-4 m-r--5">

                                <a href="#"
                                    class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Monitors
                                </a>

                                <a href="#"
                                    class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Gaming
                                </a>

                                <a href="#"
                                    class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Audio
                                </a>

                                <a href="#"
                                    class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Cable &amp; Adapters
                                </a>

                                <a href="#"
                                    class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">PC Components
                                </a>

                            </div>

                        </div>

                    </div>

                </div>

            </div>


            <!-- PRODUCTS FROM DATABASE -->
            <div class="row isotope-grid">

                <asp:Repeater ID="rptProducts" runat="server">

                    <ItemTemplate>

                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item">

                            <!-- Product Block -->
                            <div class="block2">

                                <!-- Product Image -->
                                <div class="block2-pic hov-img0">

                                    <img src='<%# Eval("imageUrl") %>'
                                        alt='<%# Eval("name") %>'>

                                    <!-- Quick View "/shop/product/" + Eval("id") -->
                                    <a href="#"
                                        class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04 js-show-modal1"
                                        data-id='<%# Eval("id") %>'
                                        data-name='<%# Eval("name") %>'
                                        data-price='<%# Eval("price", "{0:N2}") %>'
                                        data-imageurl1='<%# Eval("imageUrl") %>'
                                        data-imageurl2='<%# Eval("imageUrl") %>'
                                        data-imageurl3='<%# Eval("imageUrl") %>'
                                        <!-- 
                                        data-imageurl2='< Eval("imageUrl2") %>'
                                        data-imageurl3='< Eval("imageUrl3") %>' -->
                                        data-description='<%# Eval("description") %>'>Quick View

                                    </a>

                                </div>

                                <!-- Product Information -->
                                <div class="block2-txt flex-w flex-t p-t-14">

                                    <div class="block2-txt-child1 flex-col-l">

                                        <!-- Product Name -->
                                        <a href='<%# "/shop/product/" + Eval("id") %>'
                                            class="stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6">

                                            <%# Eval("name") %>

                                        </a>

                                        <!-- Product Price -->
                                        <span class="stext-105 cl3">R <%# Eval("price", "{0:N2}") %>
                                        </span>

                                    </div>

                                    <!-- Wishlist Button -->
                                    <div class="block2-txt-child2 flex-r p-t-3">

                                        <a href="#"
                                            class="btn-addwish-b2 dis-block pos-relative js-addwish-b2">
                                            <!-- Add to Wishlist Button -->
                                            <img class="icon-heart1 dis-block trans-04"
                                                src="/images/icons/icon-heart-01.png"
                                                alt="Wishlist">
                                            <!-- Remove from Wishlist Button -->
                                            <img class="icon-heart2 dis-block trans-04 ab-t-l"
                                                src="/images/icons/icon-heart-02.png"
                                                alt="Wishlist">
                                        </a>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>


                <!-- No Products Message -->
                <asp:Label ID="lblMessage"
                    runat="server"
                    CssClass="text-center w-full"
                    ForeColor="Red">
                </asp:Label>


            </div>

        </div>


    </div>

    

</asp:Content>
