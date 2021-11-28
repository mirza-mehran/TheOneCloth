using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneCloth.Entities
{
   public  class Users
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "User Name")]
        [MinLength(1)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Display(Name = "Roles")]
        [MinLength(1)]
        public string  Roles { get; set; }
    }
}
