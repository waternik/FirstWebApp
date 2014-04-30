// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace FirstWebApp.WebApp.Controllers
{
    public partial class HomeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HomeController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ChangeCulture()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeCulture);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditInfoAboutRegistratedUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditInfoAboutRegistratedUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult RemoveRegistratedUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveRegistratedUser);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController Actions { get { return MVC.Home; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Home";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Home";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ChangeCulture = "ChangeCulture";
            public readonly string AllRegistratedOnGameUsers = "AllRegistratedOnGameUsers";
            public readonly string RegistrateCurrentUserOnGame = "RegistrateCurrentUserOnGame";
            public readonly string EditInfoAboutRegistratedUser = "EditInfoAboutRegistratedUser";
            public readonly string RemoveRegistratedUser = "RemoveRegistratedUser";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ChangeCulture = "ChangeCulture";
            public const string AllRegistratedOnGameUsers = "AllRegistratedOnGameUsers";
            public const string RegistrateCurrentUserOnGame = "RegistrateCurrentUserOnGame";
            public const string EditInfoAboutRegistratedUser = "EditInfoAboutRegistratedUser";
            public const string RemoveRegistratedUser = "RemoveRegistratedUser";
        }


        static readonly ActionParamsClass_ChangeCulture s_params_ChangeCulture = new ActionParamsClass_ChangeCulture();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangeCulture ChangeCultureParams { get { return s_params_ChangeCulture; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangeCulture
        {
            public readonly string lang = "lang";
        }
        static readonly ActionParamsClass_EditInfoAboutRegistratedUser s_params_EditInfoAboutRegistratedUser = new ActionParamsClass_EditInfoAboutRegistratedUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditInfoAboutRegistratedUser EditInfoAboutRegistratedUserParams { get { return s_params_EditInfoAboutRegistratedUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditInfoAboutRegistratedUser
        {
            public readonly string id = "id";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_RemoveRegistratedUser s_params_RemoveRegistratedUser = new ActionParamsClass_RemoveRegistratedUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RemoveRegistratedUser RemoveRegistratedUserParams { get { return s_params_RemoveRegistratedUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RemoveRegistratedUser
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string AllRegistratedOnGameUsers = "AllRegistratedOnGameUsers";
                public readonly string EditInfoAboutRegistratedUser = "EditInfoAboutRegistratedUser";
            }
            public readonly string AllRegistratedOnGameUsers = "~/Views/Home/AllRegistratedOnGameUsers.cshtml";
            public readonly string EditInfoAboutRegistratedUser = "~/Views/Home/EditInfoAboutRegistratedUser.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_HomeController : FirstWebApp.WebApp.Controllers.HomeController
    {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ChangeCultureOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string lang);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChangeCulture(string lang)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeCulture);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lang", lang);
            ChangeCultureOverride(callInfo, lang);
            return callInfo;
        }

        [NonAction]
        partial void AllRegistratedOnGameUsersOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult AllRegistratedOnGameUsers()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AllRegistratedOnGameUsers);
            AllRegistratedOnGameUsersOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RegistrateCurrentUserOnGameOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult RegistrateCurrentUserOnGame()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RegistrateCurrentUserOnGame);
            RegistrateCurrentUserOnGameOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditInfoAboutRegistratedUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult EditInfoAboutRegistratedUser(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditInfoAboutRegistratedUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditInfoAboutRegistratedUserOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void RemoveRegistratedUserOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult RemoveRegistratedUser(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveRegistratedUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RemoveRegistratedUserOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591