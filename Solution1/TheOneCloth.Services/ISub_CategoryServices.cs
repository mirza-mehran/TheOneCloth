using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Entities;

namespace TheOneCloth.Services
{
  public interface ISub_CategoryServices
    {
        IEnumerable<Sub_Category> GetAllCategory();
        List<Categories> GetMainCategoryName();
        void SaveSubCategory(Sub_Category model);
        Sub_Category GetCategory(int id);
        void UpdateSubCategory(Sub_Category model);
        void DeleteCategory(int id);
    }
}
