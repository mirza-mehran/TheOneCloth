using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class Location_MasterController : Controller
    {
        // GET: Admin/Location_Master
        public ActionResult Countries()
        {
            return View();
        }
        public ActionResult Add_Countries()
        {
            return View();
        }
        public ActionResult View_Countries()
        {
            return View();
        }
        public ActionResult Edit_Countries()
        {
            return View();
        }



        public ActionResult Cities()
        {
            return View();
        }
        public ActionResult Add_Cities()
        {
            return View();
        }
        public ActionResult View_Cities()
        {
            return View();
        }
        public ActionResult Edit_Cities()
        {
            return View();
        }



        public ActionResult States()
        {
            return View();
        }
        public ActionResult Add_States()
        {
            return View();
        }
        public ActionResult View_States()
        {
            return View();
        }
        public ActionResult Edit_States()
        {
            return View();
        }
    }
}