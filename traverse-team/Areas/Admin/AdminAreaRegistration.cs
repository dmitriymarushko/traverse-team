using System.Web.Mvc;

namespace Traverse.Team.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin",
                url: "admin/",
                defaults: new { controller = "Home", action = "Index", lang = "en" },
                constraints: new { lang = "[a-z]{2}" },
                namespaces: new[] { "Traverse.Team.Web.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                name: "Admin_",
                url: "{lang}/admin/",
                defaults: new { controller = "Home", action = "Index", lang = "en" },
                namespaces: new[] { "Traverse.Team.Web.Areas.Admin.Controllers" }
            );
            context.MapRoute(
                "Admin_Default_Localized",
                "{lang}/Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", lang = "en", id = UrlParameter.Optional },
                constraints: new { lang = "[a-z]{2}" },
                namespaces: new[] { "Traverse.Team.Web.Areas.Admin.Controllers" }
            );
        }
    }
}