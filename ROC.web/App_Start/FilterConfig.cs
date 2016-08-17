using System.Web;
using System.Web.Mvc;

namespace ROC.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JsonAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
