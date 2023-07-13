using System.Web;
using System.Web.Mvc;

namespace Integrando_Apis_con_ADO.NET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
