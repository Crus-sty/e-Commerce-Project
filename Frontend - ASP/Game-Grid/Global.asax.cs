using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Game_Grid
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Navigation System URL - Youtube Tutorial
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            // Let static files (css, js, images) bypass routing
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("imagery/{*pathInfo}");
            routes.Ignore("images/{*pathInfo}");
            routes.Ignore("css/{*pathInfo}");
            routes.Ignore("css-amado/{*pathInfo}");
            routes.Ignore("js/{*pathInfo}");
            routes.Ignore("js-amado/{*pathInfo}");
            routes.Ignore("vendor/{*pathInfo}");
            routes.Ignore("fonts/{*pathInfo}");

            // ----  category ---------  /shop/monitors
            routes.MapPageRoute(
                "ShopByCategory",           // route name
                "shop/{category}",          // URL pattern
                "~/product.aspx"            // physical page
            );

            // ---- Shop (no category) --------- /shop
            routes.MapPageRoute(
                "Shop",
                "shop",
                "~/shop.aspx"
            );

            // ---- Simple pages ---------------
            routes.MapPageRoute("About", "about", "~/about.aspx");
            routes.MapPageRoute("Contact", "contact", "~/contact.aspx");
            routes.MapPageRoute("Home", "home", "~/home.aspx");
            routes.MapPageRoute("Sign Up", "sign-up", "~/sign-up.aspx");
            routes.MapPageRoute("Login", "login", "~/login.aspx");
            routes.MapPageRoute("Account", "account", "~/account-info.aspx");
            routes.MapPageRoute("Cart", "cart", "~/shopping-cart.aspx");
            routes.MapPageRoute("Wishlist", "wishlist", "~/wishlist.aspx");


            routes.MapPageRoute("Admin Home", "admin-home", "~/admin-home.aspx");
            routes.MapPageRoute("Order Management", "admin/orders", "~/orders.aspx");
            routes.MapPageRoute("Product Management", "admin/product-mod", "~/product-mod.aspx");
            routes.MapPageRoute("Stats", "admin/reports-and-stats", "~/reports-and-stats.aspx");
            routes.MapPageRoute("Discounts", "admin/discounts", "~/discounts.aspx");


            routes.MapPageRoute(
                "Payment", 
                "cart/checkout/payment", 
                "~/payment.aspx");

            routes.MapPageRoute(
                "Checkout",
                "cart/checkout",
                "~/checkout.aspx");


            routes.MapPageRoute(
                "History", 
                "account/history", 
                "~/history.aspx");

            // Product detail (if you have it)
            routes.MapPageRoute(
                "ProductDetail",
                "shop/product/{id}",
                "~/product-detail.aspx"
            );
        }
    }
}