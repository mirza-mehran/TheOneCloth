using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Database;
using System.Data.Entity.ModelConfiguration;
namespace TheOneCloth.Entities
{
  public  class CategoryConfig : EntityTypeConfiguration<Categories>
    {
        public CategoryConfig()
        {
            Property(p => p.Description)
                .IsOptional()
                .HasColumnName("Description");
        }
    }
}
