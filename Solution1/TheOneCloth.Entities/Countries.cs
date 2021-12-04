using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneCloth.Entities
{
    public partial class Countries
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required.!")]
        [MinLength(1),MaxLength(10)]
        public string  ShortCode { get; set; }

        [Required(ErrorMessage = "This field is required.!")]
        [MaxLength(500)]
        public string  Title { get; set; }
    }
}
