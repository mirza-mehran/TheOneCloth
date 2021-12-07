using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using TheOneCloth.Services;

namespace TheOneCloth.Web.Areas.Admin.Controllers
{
    public class Main_CategoryController : Controller
    {
        private ICategoryServices _CategoryServices = null;
        public Main_CategoryController(ICategoryServices CategoryServices)
        {
            _CategoryServices = CategoryServices;
        }
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult ViewAll()
        {

            IEnumerable<Categories> Category = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49562/api/");
                //HTTP GET
                var responseTask = client.GetAsync("categories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Categories>>();
                    readTask.Wait();

                    Category = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Category = Enumerable.Empty<Categories>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Category);

        }

        [HttpGet]
        public ActionResult Main_Cat_Edit(int id=0)
        {
            Categories Category = new Categories();
            if (id != 0)
            {
                using (var client= new HttpClient())
                {
                    client.BaseAddress =new Uri("http://localhost:49562/api/");
                    var responseTask = client.GetAsync("categories?id=" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Categories>();
                        readTask.Wait();
                        Category = readTask.Result;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                }
            }
            return View(Category);
          //  return View(_CategoryServices.Main_Cat_Edit_Get_Cat(id));
        }

        [HttpPost]
        public ActionResult Main_Cat_Edit(Categories cate)
        {
            try
            {
                IEnumerable<Categories> Category = null;
           
                if (cate.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(cate.ImageUpload.FileName);
                    string extension = Path.GetExtension(cate.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    cate.ImageURL = "~/images/category/" + fileName;
                    cate.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/images/category/"), fileName));
                }
                //_CategoryServices.Main_Cat_Edit_POST_Cat(cate);
                if (cate.ID !=0)
                {
                    #region Edit  
                    using (var client = new HttpClient())
                    {
                        cate.ImageUpload = null;
                        client.BaseAddress = new Uri("http://localhost:49562/api/");
                        var responseTask = client.PutAsJsonAsync<Categories>("categories?id=" + cate.ID.ToString(), cate);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            using (var clientA = new HttpClient())
                            {
                                clientA.BaseAddress = new Uri("http://localhost:49562/api/");
                                var responseTaskA = clientA.GetAsync("categories");
                                responseTaskA.Wait();
                                var resultA = responseTaskA.Result;
                                if (resultA.IsSuccessStatusCode)
                                {
                                    var readTaskA = resultA.Content.ReadAsAsync<IList<Categories>>();
                                    readTaskA.Wait();
                                    Category = readTaskA.Result;
                                }
                                else
                                {
                                    Category = Enumerable.Empty<Categories>();
                                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                                }
                            }

                            return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", Category), message = "Update Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }

                    #endregion
                }
                else
                {
                    #region  Add
                    using (var client=new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:49562/api/");
                        var ResponseTask = client.PostAsJsonAsync<Categories>("categories",cate);
                        ResponseTask.Wait();

                        var result = ResponseTask.Result;
                        if (result.IsSuccessStatusCode) 
                        {
                            using (var clientA = new HttpClient())
                            {
                                clientA.BaseAddress = new Uri("http://localhost:49562/api/");
                                var responseTaskA = clientA.GetAsync("categories");
                                responseTaskA.Wait();
                                var resultA = responseTaskA.Result;
                                if (resultA.IsSuccessStatusCode)
                                {
                                    var readTaskA = resultA.Content.ReadAsAsync<IList<Categories>>();
                                    readTaskA.Wait();
                                    Category = readTaskA.Result;
                                }
                                else
                                {
                                    Category = Enumerable.Empty<Categories>();
                                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                                }
                            }

                            return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", Category), message = "Added Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    #endregion
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", Category), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
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
                IEnumerable<Categories> Category = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49562/api/");
                    var responseTask = client.DeleteAsync("categories?id=" + id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        using (var clientA = new HttpClient())
                        {
                            clientA.BaseAddress = new Uri("http://localhost:49562/api/");
                            var responseTaskA = clientA.GetAsync("categories");
                            responseTaskA.Wait();
                            var resultA = responseTaskA.Result;
                            if (resultA.IsSuccessStatusCode)
                            {
                                var readTaskA = resultA.Content.ReadAsAsync<IList<Categories>>();
                                readTaskA.Wait();
                                Category = readTaskA.Result;
                            }
                            else
                            {
                                Category = Enumerable.Empty<Categories>();
                                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                            }
                        }

                        return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", Category), message = "Delete Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }


                //  _CategoryServices.Main_Cat_Delete_POST_Cat(id);

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", Category), message = "Delete Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}