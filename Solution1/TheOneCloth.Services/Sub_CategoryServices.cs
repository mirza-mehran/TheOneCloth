using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using System.Data.Entity;

namespace TheOneCloth.Services
{
    public class Sub_CategoryServices : ISub_CategoryServices
    {
        public IEnumerable<Sub_Category> GetAllCategory()
        {
            using (var db = new TOContext())
            {
                return db.Sub_Categorys.Include(x => x.Categories).ToList<Sub_Category>();
            }
        }

        public Sub_Category GetCategory(int id)
        {
            using (var db=new TOContext())
            {
                return db.Sub_Categorys.Where(x => x.ID == id).Include(x => x.Categories).FirstOrDefault();
                
            }
        }

        public List<Categories> GetMainCategoryName()
        {
            using (var db = new TOContext())
            {
                return db.Categoriess.ToList();
            }
        }
        public void SaveSubCategory(Sub_Category model)
        {
            using (var db = new TOContext())
            {
                db.Sub_Categorys.Add(model);
                db.SaveChanges();
            }
        }

        public void UpdateSubCategory(Sub_Category model)
        {
            using (var db = new TOContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public  void DeleteCategory(int id)
        {
            using (var db = new TOContext())
            {
                Sub_Category cate = db.Sub_Categorys.Where(x => x.ID == id).FirstOrDefault();
                //db.Sub_Categorys.Remove(cate);
                db.Entry(cate).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }


    }
}
