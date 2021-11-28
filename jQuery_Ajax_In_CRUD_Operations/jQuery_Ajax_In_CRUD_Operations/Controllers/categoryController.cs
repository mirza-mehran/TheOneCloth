using jQuery_Ajax_In_CRUD_Operations.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQuery_Ajax_In_CRUD_Operations.Controllers
{
    public class categoryController : Controller
    {
        // GET: category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View( GetAll_main_Category());
        }
         IEnumerable<Category> GetAll_main_Category()
        {
            using (var db = new ClothBazar_DatabaseEntities())
            {
                return db.Categories.ToList<Category>();
            }
        }

        [HttpGet]
        public ActionResult Main_Cat_Edit(int id = 0)
        {
            Category cate = new Category();
            return View(cate);
        }
        [HttpPost]
        public ActionResult Main_Cat_Edit(Category cate)
        {
            using (var db = new ClothBazar_DatabaseEntities())
            {
                db.Categories.Add(cate);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}