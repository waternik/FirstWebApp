using FirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using FirstWebApp.Filters;
using FirstWebApp.Models.DBModels;
using WebMatrix.WebData;
using System.Web;

namespace FirstWebApp.Controllers
{
    [Culture]
    public partial class HomeController : Controller
    {
        public virtual ActionResult ChangeCulture(string lang)
        {
            var cultures = new List<string>() { "ru", "en"};
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }

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
            if(Request.UrlReferrer == null)
                return RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());

            return Redirect(this.Request.UrlReferrer.AbsolutePath);
        }

        public virtual ActionResult AllRegistratedOnGameUsers()
        {

            ViewBag.Message = "Registrated members";
            var registratedMembersList = new List<RegistratedMember>();
            using (var uc = new UsersContext())
            {
                foreach (var rm in uc.RegistratedMembers)
                {
                    var user = new UserProfile() { UserId = rm.UserProfile.UserId, UserName = rm.UserProfile.UserName, FullUserName = rm.UserProfile.FullUserName};
                    var regUser = new RegistratedMember()
                    {
                        DateRegistration = rm.DateRegistration,
                        Id = rm.Id,
                        UserId = user.UserId,
                        UserProfile = user
                    };
                    registratedMembersList.Add(regUser);
                }
            }
            return View(registratedMembersList);
        }

        [Authorize()]
        public virtual ActionResult RegistrateCurrentUserOnGame()
        {
            
            using (var db = new UsersContext())
            {
                var userId = db.UserProfiles.First(user => user.UserName == WebSecurity.CurrentUserName).UserId;
                if (db.RegistratedMembers.Any(regMember => regMember.UserId == userId))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.UserId == userId));
                else
                {
                    var nr = new RegistratedMember() { UserId = userId, DateRegistration = DateTime.Now };
                    db.RegistratedMembers.Add(nr);
                }
                db.SaveChanges();
            }
            return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult EditInfoAboutRegistratedUser(int id)
        {
            using (var db = new UsersContext())
            {
                if (!db.RegistratedMembers.Any(rm => rm.Id == id))
                    return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());


                var regMember = db.RegistratedMembers.First(rm => rm.Id == id);
                var model = new RegistratedMember()
                                {
                                    UserId = regMember.UserId,
                                    UserProfile = regMember.UserProfile,
                                    DateRegistration = regMember.DateRegistration,
                                    Id = regMember.Id
                                };
                return this.View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public virtual ActionResult EditInfoAboutRegistratedUser(RegistratedMember model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new UsersContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult RemoveRegistratedUser(int id)
        {
            using (var db = new UsersContext())
            {
                if (db.RegistratedMembers.Any(regMember => regMember.Id == id))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.Id == id));
                db.SaveChanges();
            }
            return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            var e = exceptionContext.Exception;
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = new ViewResult { ViewName = MVC.Shared.Views.ErrorView };
        }

    }
}