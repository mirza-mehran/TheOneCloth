using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TheOneCloth.Entities
{
    public partial class Categories : BaseEntity
    {
        public string  Status { get; set; }
        public bool IsFeatured { get; set; }
        [DisplayName("Image")]
        public string  ImageURL { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public Categories()
        {
            ImageURL = "~/images/default.png";
        }
    }
}
