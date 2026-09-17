<%@ Page Title="Home" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" Async="true" CodeBehind="home.aspx.cs" Inherits="Game_Grid.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Slider -->
    <section class="section-slide">
        <div class="wrap-slick1">
            <div class="slick1">
                <div class="item-slick1" style="background-image: url(imagery/OLED-G9.jpg);">
                    <div class="container h-full">
                        <div class="flex-col-l-m h-full p-t-100 p-b-30 respon5">
                            <div class="layer-slick1 animated visible-false" data-appear="fadeInDown" data-delay="0">
                                <span class="ltext-101 cl2 respon2">Odyssey G9
                                </span>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="fadeInUp" data-delay="800">
                                <h2 class="ltext-201 cl2 p-t-19 p-b-43 respon1">Samsung
                                </h2>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="zoomIn" data-delay="1600">
                                <a href="shop.aspx" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04">Shop Now
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="item-slick1" style="background-image: url(imagery/Playstation-5-crop.jpg);">
                    <div class="container h-full">
                        <div class="flex-col-l-m h-full p-t-100 p-b-30 respon5">
                            <div class="layer-slick1 animated visible-false" data-appear="rollIn" data-delay="0">
                                <span class="ltext-101 cl2 respon2">Playstation 5 
                                </span>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="lightSpeedIn" data-delay="800">
                                <h2 class="ltext-201 cl2 p-t-19 p-b-43 respon1">Sony
                                </h2>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="slideInUp" data-delay="1600">
                                <a href="shop.aspx" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04">Shop Now
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="item-slick1" style="background-image: url(imagery/XBOX-Controller.jpg);">
                    <div class="container h-full">
                        <div class="flex-col-l-m h-full p-t-100 p-b-30 respon5">
                            <div class="layer-slick1 animated visible-false" data-appear="rotateInDownLeft" data-delay="0">
                                <span class="ltext-101 cl2 respon2">Controller
                                </span>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="rotateInUpRight" data-delay="800">
                                <h2 class="ltext-201 cl2 p-t-19 p-b-43 respon1">XBOX
                                </h2>
                            </div>

                            <div class="layer-slick1 animated visible-false" data-appear="rotateIn" data-delay="1600">
                                <a href="shop.aspx" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04">Shop Now
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!-- Banner -->
    <div class="sec-banner bg0 p-t-80 p-b-50">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-xl-4 p-b-30 m-lr-auto">
                    <!-- Block1 -->
                    <div class="block1 wrap-pic-w">
                        <img src="https://images.pexels.com/photos/245032/pexels-photo-245032.jpeg" alt="IMG-BANNER">

                        <a href="shop.aspx?category=displays" class="block1-txt ab-t-l s-full flex-col-l-sb p-lr-38 p-tb-34 trans-03 respon3">
                            <div class="block1-txt-child1 flex-col-l">
                                <span class="block1-name ltext-102 trans-04 p-b-8">Displays
                                </span>

                                <span class="block1-info stext-102 trans-04"></span>
                            </div>

                            <div class="block1-txt-child2 p-b-4 trans-05">
                                <div class="block1-link stext-101 cl0 trans-09">
                                    Shop Now
                                </div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-md-6 col-xl-4 p-b-30 m-lr-auto">
                    <!-- Block1 -->
                    <div class="block1 wrap-pic-w">
                        <img src="https://images.pexels.com/photos/4523021/pexels-photo-4523021.jpeg" alt="IMG-BANNER">

                        <a href="shop.aspx?category=gaming" class="block1-txt ab-t-l s-full flex-col-l-sb p-lr-38 p-tb-34 trans-03 respon3">
                            <div class="block1-txt-child1 flex-col-l">
                                <span class="block1-name ltext-102 trans-04 p-b-8">Gaming
                                </span>

                                <span class="block1-info stext-102 trans-04"></span>
                            </div>

                            <div class="block1-txt-child2 p-b-4 trans-05">
                                <div class="block1-link stext-101 cl0 trans-09">
                                    Shop Now
                                </div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-md-6 col-xl-4 p-b-30 m-lr-auto">
                    <!-- Block1 -->
                    <div class="block1 wrap-pic-w">
                        <img src="https://media.pangoly.com/img/2/8/e/9/28e9ac79-ddd9-47d2-8c12-5e80f0968e5e.jpg" alt="IMG-BANNER">

                        <a href="shop.aspx?category=pc-accessories" class="block1-txt ab-t-l s-full flex-col-l-sb p-lr-38 p-tb-34 trans-03 respon3">
                            <div class="block1-txt-child1 flex-col-l">
                                <span class="block1-name ltext-102 trans-04 p-b-8">PC Accessories
                                </span>

                                <span class="block1-info stext-102 trans-04"></span>
                            </div>

                            <div class="block1-txt-child2 p-b-4 trans-05">
                                <div class="block1-link stext-101 cl0 trans-09">
                                    Shop Now
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Product -->
    <section class="bg0 p-t-23 p-b-140">
        <div class="container">

            <div class="p-b-10">
                <h3 class="ltext-103 cl5">Trending Products
                </h3>
            </div>



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

                                    <!-- Quick View -->
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

                                            <img class="icon-heart1 dis-block trans-04"
                                                src="/images/icons/icon-heart-01.png"
                                                alt="Wishlist">

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
            </div>

            <!-- Load more -->
            <div class="flex-c-m flex-w w-full p-t-45">
                <a href="/shop" class="flex-c-m stext-101 cl5 size-103 bg2 bor1 hov-btn1 p-lr-15 trans-04 pointer">Load More
                </a>
            </div>
        </div>
    </section>
</asp:Content>
