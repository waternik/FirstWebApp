using FirstWebApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using FirstWebApp.WebApp.Filters;
using FirstWebApp.Repository;
using FirstWebApp.Repository.Models;
using System.Web;

namespace FirstWebApp.WebApp.Controllers
{

    [Culture]
    public partial class HomeController : Controller
    {
        readonly Repository.Repository myRepository = new Repository.Repository();

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
            return View(myRepository.GetRegistratedMembers());
        }

        [Authorize()]
        public virtual ActionResult RegistrateCurrentUserOnGame()
        {

            using (var db = new MyDBContext())
            {
                var userId = db.UserProfiles.First(user => user.UserName == myRepository.CurrentUserName).UserId;
                if (db.RegistratedMembers.Any(regMember => regMember.UserId == userId))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.UserId == userId));
                else
                {
                    var nr = new RegistratedMember() { UserId = userId, DateRegistration = DateTime.Now };
                    //db.RegistratedMembers.Add(nr);
                }
                db.SaveChanges();
            }
            return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult EditInfoAboutRegistratedUser(int id)
        {
            var AllMembers = myRepository.GetRegistratedMembers();
            if (!AllMembers.Any(rm => rm.Id == id))
                    return this.RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());

                var regMember = AllMembers.First(rm => rm.Id == id);

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
            //if (ModelState.IsValid)
            //{
                //using (var db = new MyDBContext())
                //{
                //    db.Entry(model).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
            //}

            return RedirectToAction(MVC.Home.AllRegistratedOnGameUsers());
        }

        [Authorize(Roles = "Admin")]
        public virtual ActionResult RemoveRegistratedUser(int id)
        {
            //using (var db = new MyDBContext())
            //{
            //    if (db.RegistratedMembers.Any(regMember => regMember.Id == id))
            //        db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.Id == id));
            //    db.SaveChanges();
            //}
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