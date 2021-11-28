using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheOneCloth.Entities;

namespace TheOneCloth.Web.Areas.Admin.AdminViewModels
{
    public class Add_main_CategoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This field is required.!")]
        [Display(Name = "Name")]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageURL { get; set; }

        public Categories category { get; set; }
    }
    public class List_main_categoryViewModel
    {
        public List<Categories> Categories { get; set; }
    }
}