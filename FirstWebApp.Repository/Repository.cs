using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstWebApp.Repository.Interfaces;

namespace FirstWebApp.Repository
{
    using WebMatrix.WebData;
    using FirstWebApp.Repository.Models;

    public class Repository
    {
        public void CreateUsers(string UserName, string Password)
        {
            WebSecurity.CreateUserAndAccount(UserName, Password);
            WebSecurity.Login(UserName, Password);
        }

        public bool ChangePassword(string UserName, string OldPassword, string NewPassword)
        {
            return WebSecurity.ChangePassword(UserName, OldPassword, NewPassword);
        }

        public void LogOut()
        {
            WebSecurity.Logout();
        }

        public bool LogIn(string UserName, string Password, bool persistCookie = false)
        {
            return WebSecurity.Login(UserName, Password, persistCookie);
        }

        public string CurrentUserName
        {
            get
            {
                return WebSecurity.CurrentUserName;
            }
        }
        
        public List<IRegistratedMember> GetRegistratedMembers()
        {
            var registratedMembersList = new List<IRegistratedMember>();
            using (var db = new MyDBContext())
            {
                 registratedMembersList.AddRange(
                    (from rm in db.RegistratedMembers 
                     let user = new UserProfile(){
                                        UserId = rm.UserProfile.UserId
                                        , UserName = rm.UserProfile.UserName
                                        , FullUserName = rm.UserProfile.FullUserName
                                    } 
                     select new RegistratedMember()
                                {
                                    DateRegistration = rm.DateRegistration
                                    , Id = rm.Id
                                    , UserId = user.UserId
                                    , UserProfile = user
                                }));
                 
            }
            return registratedMembersList;
        }


    }
}
