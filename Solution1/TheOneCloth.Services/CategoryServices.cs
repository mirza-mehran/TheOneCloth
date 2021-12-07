using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using System.Data.Entity;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TheOneCloth.Services
{
  public class CategoryServices : ICategoryServices
    {
        #region Singleton Pattern
        //public static CategoryServices Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new CategoryServices();
        //        return instance;
        //    }
        //}
        //private static CategoryServices instance { get; set; }

        //private CategoryServices()
        //{

        //}
        #endregion
            
        public async Task<Categories> Main_Cat_Edit_Get_Cat(int id)
        {
            Categories cate = new Categories();
            if (id != 0)
            {
                using (var db = new TOContext())
                {
                    cate =await db.Categoriess.FindAsync(id);
                }
            }
            return cate;

        }
        
        public async Task<List<Categories>> GetAll_main_Category()
        {

            string Baseurl = "http://localhost:49562/api/categories";
            List<Categories> cate = new List<Categories>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("/api/categories");
                if (Res.IsSuccessStatusCode)
                {
                    var CateResponse = Res.Content.ReadAsStringAsync().Result;
                    cate = JsonConvert.DeserializeObject<List<Categories>>(CateResponse);
                }
                return cate;
            }

            //using (var db = new TOContext())
            //{
            //    return db.Categoriess.ToList<Categories>();
            //}
        }
       
        public void Main_Cat_Edit_POST_Cat(Categories cate)
        {
            using (var db = new TOContext())
            {
                if (cate.ID == 0)
                {
                    db.Categoriess.Add(cate);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(cate).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        
        public void Main_Cat_Delete_POST_Cat(int id)
        {
            using (TOContext db = new TOContext())
            {
                Categories cate = db.Categoriess.Where(x => x.ID == id).FirstOrDefault<Categories>();
                db.Categoriess.Remove(cate);
                db.SaveChanges();
            }
        }
    }
}
