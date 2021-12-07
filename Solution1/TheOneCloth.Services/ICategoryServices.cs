using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Entities;

namespace TheOneCloth.Services
{
    public  interface ICategoryServices
    {
         Task <List<Categories>> GetAll_main_Category();
         Task< Categories> Main_Cat_Edit_Get_Cat(int id);
         void Main_Cat_Edit_POST_Cat(Categories cate);
         void Main_Cat_Delete_POST_Cat(int id);
    }
}
