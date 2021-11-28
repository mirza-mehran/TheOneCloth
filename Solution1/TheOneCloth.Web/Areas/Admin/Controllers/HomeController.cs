using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Web.EnumCode;
using TheOneCloth.Web.Models;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
       // [AuthorizeRole(Role.Admin)]
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}