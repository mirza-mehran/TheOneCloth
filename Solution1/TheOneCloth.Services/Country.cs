using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using System.Data.Entity;

namespace TheOneCloth.Services
{
    public class Country : ICountry
    {
        public async Task DeleteCountry(int id)
        {
            using (var db = new TOContext())
            {
                var data = db.Countries.Where(x => x.ID == id).FirstOrDefault();
                db.Entry(data).State = EntityState.Deleted;
               await db.SaveChangesAsync();
            }
        }

        public async Task GetCountry(Countries model)
        {
            using (var db = new TOContext())
            {
                db.Entry(model).State = EntityState.Modified;
               await db.SaveChangesAsync();
            }
        }

        public async Task<Countries> GetCountry(int id)
        {
            using (var db = new TOContext())
            {
               return await db.Countries.FindAsync(id);
            }
        }

        public async Task SaveCountry(Countries model)
        {
            using (var db = new TOContext())
            {
                db.Countries.Add(model);
                await db.SaveChangesAsync();
            }
        }

        public List<Countries> ViewAll()
        {
            using (var db = new TOContext())
            {
                return  db.Countries.OrderBy(x => x.Title).ToList();
            }
        }
    }
}
