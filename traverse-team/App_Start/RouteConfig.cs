namespace Traverse.Team.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Improve SEO by stopping duplicate URL's due to case differences or trailing slashes.
            // See http://googlewebmastercentral.blogspot.co.uk/2010/04/to-slash-or-not-to-slash.html
            routes.AppendTrailingSlash = true;
            routes.LowercaseUrls = true;

            // IgnoreRoute - Tell the routing system to ignore certain routes for better performance.
            // Ignore .axd files.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Ignore everything in the Content folder.
            routes.IgnoreRoute("Content/{*pathInfo}");
            // Ignore everything in the Scripts folder.
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            // Ignore the Forbidden.html file.
            routes.IgnoreRoute("Error/Forbidden.html");
            // Ignore the GatewayTimeout.html file.
            routes.IgnoreRoute("Error/GatewayTimeout.html");
            // Ignore the ServiceUnavailable.html file.
            routes.IgnoreRoute("Error/ServiceUnavailable.html");
            // Ignore the humans.txt file.
            routes.IgnoreRoute("humans.txt");

            // Enable attribute routing.
            //routes.MapMvcAttributeRoutes();

            //
            routes.MapRoute(
               name: "DefaultLocalized",
               url: "{lang}/{controller}/{action}/{id}",
               defaults: new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional,
                   lang = "en"
               },
               constraints: new { lang = "[a-z]{2}" },
               namespaces: new[] { "Traverse.Team.Web.Controllers" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "en" },
                namespaces: new[] { "Traverse.Team.Web.Controllers" }
            );

            // TODO: remove this later
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetIndex,
                url: "{lang}/home/index",
                defaults: new { lang = "en" }
                );
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetAbout,
                url: "{lang}/home/about",
                defaults: new { lang = "en" }
                );
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetContact,
                url: "{lang}/home/contact",
                defaults: new { lang = "en" }
                );
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetBrowse,
                url: "{lang}/home/browse",
                defaults: new { lang = "en" }
                );
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetPrices,
                url: "{lang}/home/prices",
                defaults: new { lang = "en" }
                );
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetFeed,
                url: "");
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetSearch,
                url: "");
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetBrowserConfigXml,
                url: "");
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetManifestJson,
                url: "");
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetOpenSearchXml,
                url: "");
            routes.MapRoute(
                name: Constants.HomeControllerRoute.GetRobotsText,
                url: "");

            // Normal routes are not required because we are using attribute routing. So we don't need this MapRoute 
            // statement. Unfortunately, Elmah.MVC has a bug in which some 404 and 500 errors are not logged without 
            // this route in place. So we include this but look out on these pages for a fix:
            // https://github.com/alexbeletsky/elmah-mvc/issues/60
            // https://github.com/ASP-NET-MVC-Boilerplate/Templates/issues/8

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
