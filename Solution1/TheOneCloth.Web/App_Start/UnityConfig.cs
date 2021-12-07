using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using TheOneCloth.Database;
using TheOneCloth.Services;
using TheOneCloth.Web.Models;
using Unity;
using Unity.Mvc5;

namespace TheOneCloth.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
          
            container.RegisterSingleton<ICategoryServices, CategoryServices>();
            container.RegisterSingleton<ISub_CategoryServices, Sub_CategoryServices>();
            container.RegisterType<ICountry, Country>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}