using System.Web.Mvc;
using System.Web.Routing;

namespace Arvato.PortalCandidato.UI.App_Start
{
    public class HandleAntiforgeryTokenErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Candidate", action = "Create", AreaReference = string.Empty }));
        }
    }
}