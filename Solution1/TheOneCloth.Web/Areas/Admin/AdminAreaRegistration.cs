using System.Web.Mvc;

namespace TheOneCloth.Web.Areas.Admin
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
                name:"sub_category",
                url:"sub-category",
                defaults: new {Controller= "Sub_Categories", action= "Index" }
                );

            context.MapRoute(
                name: "allcategory",
                url: "categories",
                defaults: new { controller = "Main_Category", action = "Index", id = UrlParameter.Optional }
                //constraints: @"^[A-Z]([-.\w]*[A-Z])*$"
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}