using System.Web;
using System.Web.Mvc;

namespace jQuery_Ajax_In_CRUD_Operations
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
