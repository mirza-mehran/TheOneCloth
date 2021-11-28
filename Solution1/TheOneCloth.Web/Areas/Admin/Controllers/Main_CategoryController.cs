﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using TheOneCloth.Services;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class Main_CategoryController : Controller
    {
        // GET: Admin/Main_Category_
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(CategoryServices.Instance.GetAll_main_Category());
        }

        [HttpGet]
        public ActionResult Main_Cat_Edit(int id=0)
        {
            var cate= CategoryServices.Instance.Main_Cat_Edit_Get_Cat(id);           
            return View(cate);
        }

        [HttpPost]
        public ActionResult Main_Cat_Edit(Categories cate)
        {
            try
            {
                if (cate.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(cate.ImageUpload.FileName);
                    string extension = Path.GetExtension(cate.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    cate.ImageURL = "~/images/category/" + fileName;
                    cate.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/category/"), fileName));
                }
                CategoryServices.Instance.Main_Cat_Edit_POST_Cat(cate);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", CategoryServices.Instance.GetAll_main_Category()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                CategoryServices.Instance.Main_Cat_Delete_POST_Cat(id);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", CategoryServices.Instance.GetAll_main_Category()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}