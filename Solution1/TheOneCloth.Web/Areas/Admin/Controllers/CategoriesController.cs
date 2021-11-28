using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Entities;
using TheOneCloth.Services;
using TheOneCloth.Web.Areas.Admin.AdminViewModels;
using Newtonsoft.Json;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/Categories
        public ActionResult main_category()
        {
            //List_main_categoryViewModel model = new List_main_categoryViewModel();
            //model.Categories = CategoryServices.Instance.GetAllCategory();
            //return PartialView("_List_main_category", model);
            return View();
        }

        [HttpGet]
        public ActionResult Add_main_category()
        {
            Add_main_CategoryViewModel model = new Add_main_CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add_main_category(Add_main_CategoryViewModel model)
        {
            var newcategory = new Categories();
            if (ModelState.IsValid)
            {
                newcategory.Name = model.Name;
                newcategory.Description = model.Description;
                newcategory.Status = model.Status;
                newcategory.IsFeatured = model.IsFeatured;
                newcategory.ImageURL = model.ImageURL;

                //CategoryServices.Instance.SaveCategory(newcategory);

                //List_main_categoryViewModel model1 = new List_main_categoryViewModel();
                //model1.Categories = CategoryServices.Instance.GetAllCategory();
                //return PartialView("_List_main_category", model1);
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
            return View();
        }

        [HttpGet]
        public JsonResult View_main_category(int Id)
        {
            Add_main_CategoryViewModel model = new Add_main_CategoryViewModel();
            //model.category = CategoryServices.Instance.Details(Id);

            var json = JsonConvert.SerializeObject(model);
            return Json(json, JsonRequestBehavior.AllowGet);

            // return View(model);

        }

        [HttpGet]
        public ActionResult Edit_main_category(int Id)
        {
            Add_main_CategoryViewModel model = new Add_main_CategoryViewModel();
            //model.category = CategoryServices.Instance.Details(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit_main_category(Add_main_CategoryViewModel model)
        {
        //    if (ModelState.IsValid)
        //    {
        //        var newcategory = CategoryServices.Instance.Details(model.ID);

        //        newcategory.Name = model.Name;
        //        newcategory.Description = model.Description;
        //        newcategory.Status = model.Status;
        //        newcategory.IsFeatured = model.IsFeatured;
        //        newcategory.ImageURL = model.ImageURL;

        //        CategoryServices.Instance.UpdateCategory(newcategory);
        //    }
        //    return RedirectToAction("main_category");
           return View();
    }
        [HttpPost]
        public ActionResult Delete_main_category(int Id)
        {
          //  CategoryServices.Instance.Delete(Id);
            return RedirectToAction("main_category");
        }
        public ActionResult sub_category()
        {
            return View();
        }
        public ActionResult Add_sub_category()
        {
            return View();
        }
        public ActionResult View_sub_category()
        {
            return View();
        }
        public ActionResult Edit_sub_category()
        {
            return View();
        }
    }
}