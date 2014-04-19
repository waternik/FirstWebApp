using FirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    using WebMatrix.WebData;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistratedMembers()
        {
            ViewBag.Message = "Registrated members";
            var uc = new UsersContext();
            IEnumerable<RegistratedMember> registratedMembers = uc.RegistratedMembers;
            ViewBag.UC = uc;
            ViewBag.RegMember = registratedMembers;
            return View();
        }

        [Authorize()]
        public ActionResult RegistrateOnEvent()
        {
            using (var db = new UsersContext())
            {
                var userId = db.UserProfiles.First(user => user.UserName == WebSecurity.CurrentUserName).UserId;
                if (db.RegistratedMembers.Any(regMember => regMember.UserId == userId))
                    return this.RedirectToAction("RegistratedMembers");

                var nr = new RegistratedMember() { UserId = userId, DateRegistration = DateTime.Now };
                db.RegistratedMembers.Add(nr);
                db.SaveChanges();
            }
            return this.RedirectToAction("RegistratedMembers");
        }

    }
}