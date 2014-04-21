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
        public ActionResult RegistratedMembers()
        {

            ViewBag.Message = "Registrated members";
            var registratedMembersList = new List<RegistratedMember>();
            using (var uc = new UsersContext())
            {
                foreach (var rm in uc.RegistratedMembers)
                {
                    var user = new UserProfile() { UserId = rm.UserProfile.UserId, UserName = rm.UserProfile.UserName };
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
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm=>rm.UserId==userId));
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

    }
}