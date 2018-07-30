using Arvato.PortalCandidato.UI.App_Start;
using System.Web.Mvc;

namespace Arvato.PortalCandidato.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleAntiforgeryTokenErrorAttribute()
            { ExceptionType = typeof(HttpAntiForgeryException) }
      );
        }
    }
}
