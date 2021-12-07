using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Results;
using TheOneCloth.Database;
using TheOneCloth.Entities;
using System.Web.Http;
using Newtonsoft.Json;

namespace TheOneCloth.Web.Areas.Admin.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        public IEnumerable<Categories> GetCategory()
        {
            using (var db = new TOContext())
            {
                return( db.Categoriess.ToList());
            }
        }
        public  async Task<IHttpActionResult> GetID([FromUri]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid ID");
            Categories cate = new Categories();
            using (var db=new TOContext())
            {
                cate = await db.Categoriess.Where(x => x.ID == id).FirstOrDefaultAsync();
                return Ok(cate);
            }
        }
        public async Task<IHttpActionResult> POST([FromBody] Categories cate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            using (var db=new TOContext())
            {
                db.Categoriess.Add(new Categories() {
                    Name = cate.Name,
                    Description = cate.Description,
                    Status = cate.Status,
                    IsFeatured = cate.IsFeatured,
                    ImageURL = cate.ImageURL
                });
                await  db.SaveChangesAsync();
                return Ok();
            }
        }
        public async Task<IHttpActionResult> Put([FromUri]int id,[FromBody] Categories cate)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Update");
            using (var db=new TOContext())
            {
                var data = await db.Categoriess.FirstOrDefaultAsync(x => x.ID == id);
                if (data !=null)
                {
                    data.Name = cate.Name;
                    data.Description = cate.Description;
                    data.Status = cate.Status;
                    data.IsFeatured = cate.IsFeatured;
                    data.ImageURL = cate.ImageURL;
                     
                    db.Entry(data).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                return Ok(); 
            }
        }
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid ID");
            using (var db=new TOContext())
            {
                var data = await db.Categoriess.FirstOrDefaultAsync(x => x.ID == id);
                db.Entry(data).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
