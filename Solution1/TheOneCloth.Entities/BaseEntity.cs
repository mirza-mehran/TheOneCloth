using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneCloth.Entities
{
   public  class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="This field is required.!")]
        [Display(Name ="Category")]
        [MinLength(2),MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
