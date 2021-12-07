using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Web.EnumCode;
using TheOneCloth.Web.Models;

namespace TheOneCloth.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        //[AuthorizeRole(Role.User)]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HandleError(View = "Error")]
        public ActionResult errorpage()
        {
            int u = Convert.ToInt32("");
            return View();
        }

        [AuthorizeRole(Role.Administrator)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [AuthorizeRole(Role.Admin)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}