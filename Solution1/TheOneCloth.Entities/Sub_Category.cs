using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneCloth.Entities
{
  public class Sub_Category
    {
        public int ID { get; set; }
        public string  Sub_category { get; set; }
        public string  Status { get; set; }

        [ForeignKey("Categories")]
        public int CategoriesID { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
