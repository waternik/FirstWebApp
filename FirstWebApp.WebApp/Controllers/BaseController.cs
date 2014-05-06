using FirstWebApp.WebApp.Filters;
using System.Web.Mvc;
using log4net;
using log4net.Config;

namespace FirstWebApp.WebApp.Controllers
{
    using log4net.Util;

    [Culture]
    public class BaseController : Controller
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));

        protected override void OnException(ExceptionContext exceptionContext)
        {
            log.ErrorExt(exceptionContext.Exception.Message);
            var e = exceptionContext.Exception;
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = new ViewResult { ViewName = MVC.Shared.Views.ErrorView };
        }
    }
}