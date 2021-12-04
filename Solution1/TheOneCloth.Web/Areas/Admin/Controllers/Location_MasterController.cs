using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Entities;
using TheOneCloth.Services;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class Location_MasterController : Controller
    {
        // GET: Admin/Location_Master

        private ICountry _Country = null;

        public Location_MasterController(ICountry Country)
        {
            _Country = Country;
        }

        [OutputCache (Duration = 10, Location = System.Web.UI.OutputCacheLocation.Client)]
      
        public ActionResult Countries()
        {
            return View();
        }

        //[HttpGet]
        //public async Task< ActionResult> ViewAll()
        //{
        //    var syncContext = SynchronizationContext.Current;
        //    SynchronizationContext.SetSynchronizationContext(null);

        //    var model = await _Country.ViewAll();
        //    SynchronizationContext.SetSynchronizationContext(syncContext);

        //    return View(model);
        //}

        [HttpGet]
        public ActionResult ViewAll()
        {
            return View(_Country.ViewAll());
        }

        [HttpGet]
        public ActionResult Add_Countries()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add_Countries(Countries model)
        {
            try
            {
                if (model != null)
                {
                   await _Country.SaveCountry(model);
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Country.ViewAll()), message = "Added Successfully " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false , message = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult View_Countries()
        {
            return View();
        }

        [HttpGet]
        [AsyncTimeout(1)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "_TimeOut")]
        public async Task<ActionResult> Edit_Countries(int id)
        {
            Countries country = new Countries();
            country = await _Country.GetCountry(id);
            return View(country);
        }

        [HttpPost]
        public async Task <JsonResult> Edit_Countries(Countries country)
        {
            try
            {
                await _Country.GetCountry(country);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Country.ViewAll()), message = "Update Successfully " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete_Countries(int id)
        {
            try
            {
               await _Country.DeleteCountry(id);
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _Country.ViewAll()), message = "Delete Successfully " }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
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