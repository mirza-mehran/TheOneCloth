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
          
            container.RegisterType<ICategoryServices, CategoryServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}