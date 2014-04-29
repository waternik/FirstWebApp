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
    public class HomeController : Controller
    {
        public ActionResult ChangeCulture(string lang)
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
                return RedirectToAction("RegistratedMembers");

            return Redirect(this.Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult RegistratedMembers()
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
        public ActionResult RegistrateOnEvent()
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
            return this.RedirectToAction("RegistratedMembers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            using (var db = new UsersContext())
            {
                RegistratedMember regMember = db.RegistratedMembers.First(rm => rm.Id == id);
                if (regMember != null)
                {
                    var model = new RegistratedMember()
                    {
                        UserId = regMember.UserId,
                        UserProfile = regMember.UserProfile,
                        DateRegistration = regMember.DateRegistration,
                        Id = regMember.Id
                    };
                    return View(model);
                }

                return RedirectToAction("RegistratedMembers");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(RegistratedMember model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new UsersContext())
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("RegistratedMembers");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Remove(int id)
        {
            using (var db = new UsersContext())
            {
                if (db.RegistratedMembers.Any(regMember => regMember.Id == id))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.Id == id));
                db.SaveChanges();
            }
            return this.RedirectToAction("RegistratedMembers");
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            var e = exceptionContext.Exception;
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = new ViewResult { ViewName = "Error" };
        }

    }
}