using System.Collections.Generic;

namespace FirstWebApp.WebApp.Filters
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string curentCulture = null;
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            curentCulture = cultureCookie != null ? cultureCookie.Value : "ru";

            var cultures = new List<string>() { "ru", "en"};
            if (!cultures.Contains(curentCulture))
                curentCulture = "ru";

            filterContext.RouteData.Values["lang"] = curentCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(curentCulture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(curentCulture);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}