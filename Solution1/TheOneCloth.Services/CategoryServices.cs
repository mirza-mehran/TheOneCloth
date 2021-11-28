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

namespace TheOneCloth.Services
{
  public   class CategoryServices
    {
        #region Singleton Pattern
        public static CategoryServices Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryServices();
                return instance;
            }
        }
        private static CategoryServices instance { get; set; }

        private CategoryServices()
        {

        }
        #endregion

        public Categories Main_Cat_Edit_Get_Cat(int id)
        {
            Categories cate = new Categories();
            if (id != 0)
            {
                using (var db = new TOContext())
                {
                   cate = db.Categoriess.Find(id);
                }
            }
            return cate;
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
        public void SaveCategory(Categories category)
        {
            using (var db=new TOContext())
            {
                db.Categoriess.Add(category);
                db.SaveChanges();
            }
        }
      public   IEnumerable<Categories> GetAll_main_Category()
        {
            using (var db = new TOContext())
            {
                return db.Categoriess.ToList<Categories>();
            }
        }
        public List<Categories> GetAllCategory()
        {
            using (var db=new TOContext())
            {
                //var a = CountCategory();
                //if (a > 0)
                //{
                    return db.Categoriess.ToList();
             //   }
                   
              //  return new List<Categories>();
            }
        }
        public int CountCategory()
        {
            using (var db = new TOContext())
            {
                return db.Categoriess.Count();
            }
        }
        public Categories Details(int id)
        {
            using (var db=new TOContext())
            {
               return  db.Categoriess.Find(id);
            }
        }

        public void UpdateCategory(Categories category)
        {
            using (var db=new TOContext())
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void  Delete(int Id)
        {
            using (var db = new TOContext())
            {
               var cate= db.Categoriess.Where(x => x.ID == Id).FirstOrDefault();
                db.Categoriess.Remove(cate);
                db.SaveChanges();
            }
        }
    }
}
