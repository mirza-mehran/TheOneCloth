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
   public  class GlobalListAllClass : IEquatable<GlobalListAllClass>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsFeatured { get; set; }
 
        public bool Equals(GlobalListAllClass other)
        {
            if (object.ReferenceEquals(other,null))
            {
                return false;
            }
            if (object.ReferenceEquals(this,other))
            {
                return true;
            }
            return ID.Equals(other.ID) && Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int idHashCode = ID.GetHashCode();
            int nameHashCode = Name.GetHashCode();

            return idHashCode ^ nameHashCode;
        }
    }
}
