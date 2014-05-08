using FirstWebApp.WebApp.Filters;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using FirstWebApp.Repository.Interfaces;
using log4net.Util;
using Ninject;
using Ninject.Modules;
using FirstWebApp.Repository;

namespace FirstWebApp.WebApp.Controllers
{
    [Culture]
    public class BaseController : Controller
    {
        [Inject]
        public IRepositoryRegistratedMembers MyRepository;
        
        public static readonly ILog log = LogManager.GetLogger(typeof(MvcApplication));

        protected override void OnException(ExceptionContext exceptionContext)
        {
            log.ErrorExt(exceptionContext.Exception.Message);
            var e = exceptionContext.Exception;
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = new ViewResult { ViewName = MVC.Shared.Views.ErrorView };
        }
    }

    public class WeaponNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRepositoryRegistratedMembers>().To<RepositoryRegistratedMembers>();
        }
    }
}