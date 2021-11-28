using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: Admin/UserManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add_User()
        {
            return View();
        }
        public ActionResult View_User()
        {
            return View();
        }
        public ActionResult Edit_User()
        {
            return View();
        }
    }
}