using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using TheOneCloth.Services;
using TheOneCloth.Web.Areas.Admin.AdminViewModels;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class Sub_CategoriesController : Controller
    {
        private ISub_CategoryServices _Sub_CategoryServices = null;
        public Sub_CategoriesController(ISub_CategoryServices Sub_CategoryServices)
        {
            _Sub_CategoryServices = Sub_CategoryServices;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(_Sub_CategoryServices.GetAllCategory());
        }

        [HttpGet]
        public ActionResult Add()
        {
            Sub_CategoryViewModel model = new Sub_CategoryViewModel();
            model.Categories = _Sub_CategoryServices.GetMainCategoryName();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddPOST(Sub_CategoryViewModel model)
        {
            try
            {
                Sub_Category cate = new Sub_Category();

                cate.Sub_category = model.Sub_category;
                cate.CategoriesID = model.CategoriesID;
                cate.Status = model.Status;

                _Sub_CategoryServices.SaveSubCategory(cate);
           
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Sub_CategoryServices.GetAllCategory()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new {success=false, message=ex.Message },JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            EditSub_CategoryViewModel model = new EditSub_CategoryViewModel();
            var sub_category = _Sub_CategoryServices.GetCategory(id);

            if (id != 0)
            {
                model.ID = sub_category.ID;
                model.Sub_category = sub_category.Sub_category;
                model.Status = sub_category.Status;
                model.CategoriesID = sub_category.Categories != null ? sub_category.Categories.ID : 0;
            }
            model.AvailableCategories = _Sub_CategoryServices.GetMainCategoryName();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPOST(EditSub_CategoryViewModel model)
        {
            try
            {
                Sub_Category cate = new Sub_Category();
                cate.ID = model.ID;
                cate.Sub_category = model.Sub_category;
                cate.Status = model.Status;
                cate.CategoriesID = model.CategoriesID;
                
                _Sub_CategoryServices.UpdateSubCategory(cate);

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Sub_CategoryServices.GetAllCategory()), message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success=false,message =ex.Message },JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    _Sub_CategoryServices.DeleteCategory(id);
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Sub_CategoryServices.GetAllCategory()), message = "Delete Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}