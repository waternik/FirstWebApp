using FirstWebApp.WebApp.Filters;
using System.Web.Mvc;

namespace FirstWebApp.WebApp.Controllers
{
    [Culture]
    public class BaseController : Controller
    {
        [Culture]
        protected override void OnException(ExceptionContext exceptionContext)
        {
            var e = exceptionContext.Exception;
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = new ViewResult { ViewName = MVC.Shared.Views.ErrorView };
        }
    }
}