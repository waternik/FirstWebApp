using System.Collections.Generic;
using System.Linq;
using FirstWebApp.Repository.Interfaces;
using System.Data.Entity;
using FirstWebApp.Repository.Models;
using System;

namespace FirstWebApp.Repository
{
    public class RepositoryRegistratedMembers : IRepositoryRegistratedMembers
    {
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

        public void AddRegMember(string nameUser)
        {
            using (var db = new MyDBContext())
            {
                var idUser = db.UserProfiles.First(user => user.UserName == nameUser).UserId;
                if (db.RegistratedMembers.Any(regMember => regMember.UserId == idUser))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.UserId == idUser));
                else
                {
                    var nr = new RegistratedMemberDO() { UserId = idUser, DateRegistration = DateTime.Now };
                    db.RegistratedMembers.Add(nr);
                }
                db.SaveChanges();
            }
        }

        public void RemoveRegMember(int id)
        {
            using (var db = new MyDBContext())
            {
                if (db.RegistratedMembers.Any(regMember => regMember.Id == id))
                    db.RegistratedMembers.Remove(db.RegistratedMembers.First(rm => rm.Id == id));
                db.SaveChanges();
            }
        }

        public void SaveChangeRegMember(IRegistratedMember item)
        {
            using (var db = new MyDBContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}