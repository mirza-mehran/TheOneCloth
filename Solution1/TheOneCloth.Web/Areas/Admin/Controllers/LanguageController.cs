using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Admin/Language
        public ActionResult Language()
        {
            return View();
        }
        public ActionResult Add_Language()
        {
            return View();
        }
        public ActionResult Update_Strings_Language()
        {
            return View();
        }
        public ActionResult Edit_Language()
        {
            return View();
        }
    }
}