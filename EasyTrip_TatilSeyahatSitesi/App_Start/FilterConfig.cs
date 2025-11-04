using System.Web;
using System.Web.Mvc;

namespace EasyTrip_TatilSeyahatSitesi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
