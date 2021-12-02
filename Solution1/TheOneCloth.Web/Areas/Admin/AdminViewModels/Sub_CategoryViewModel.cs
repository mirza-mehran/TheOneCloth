using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheOneCloth.Entities;

namespace TheOneCloth.Web.Areas.Admin.AdminViewModels
{
    public class Sub_CategoryViewModel
    {
        public int ID { get; set; }
        public string Sub_category { get; set; }
        public string Status { get; set; }
        public int CategoriesID { get; set; }
        public List<Categories> Categories { get; set; }
    }

    public class EditSub_CategoryViewModel
    {
        public int  ID { get; set; }
        public string Sub_category { get; set; }
        public string Status { get; set; }
        public int CategoriesID { get; set; }

        public List<Categories> AvailableCategories { get; set; }

    }
}