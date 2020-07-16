using System.Web;
using System.Web.Mvc;

namespace Is_This_Vegan__Net_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
