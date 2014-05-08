using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FirstWebApp.WebApp.Filters;
using FirstWebApp.Repository;
using FirstWebApp.Repository.Models;
using System.Web;

namespace FirstWebApp.WebApp.Controllers
{
    using WebMatrix.WebData;

    public partial class HomeController : BaseController
    {
        public virtual ActionResult AllRegistratedOnGameUsers()
        {
            ViewBag.Message = "Registrated members";
            return View(MyRepository.GetRegistratedMembers());
        }

        public virtual ActionResult ChangeCulture(string lang)
        {
            var cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang))
                lang = "ru";

            var cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
                cookie = new HttpCookie("lang")
                {
                    HttpOnly = false,
                    Value = lang,
                    Expires = DateTime.Now.AddMonths(1)
                };
            Response.Cookies.Add(cookie);
            if (Request.UrlReferrer == null)
                return RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());

            return Redirect(this.Request.UrlReferrer.AbsolutePath);
        }

        [Authorize()]
        public virtual ActionResult RegistrateCurrentUserOnGame()
        {

            MyRepository.AddRegMember(WebSecurity.CurrentUserName);

            return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult EditInfoAboutRegistratedUser(int id)
        {
            var AllMembers = MyRepository.GetRegistratedMembers();
            var regMember = AllMembers.FirstOrDefault(rm => rm.Id == id);

            if (regMember == null)
                return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());

            var model = new RegistratedMember()
                            {
                                UserId = regMember.UserId,
                                UserProfile = regMember.UserProfile,
                                DateRegistration = regMember.DateRegistration,
                                Id = regMember.Id
                            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public virtual ActionResult EditInfoAboutRegistratedUser(RegistratedMember model)
        {
            MyRepository.SaveChangeRegMember(model);

            return RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult RemoveRegistratedUser(int id)
        {
            MyRepository.RemoveRegMember(id);

            return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }
    }
}