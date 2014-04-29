using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FirstWebApp.Models.DBModels
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RegistratedMember> RegistratedMembers { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }

    //public sealed class ConfigurationForMyDBContext : DbMigrationsConfiguration<UsersContext>
    //{
//        protected override void Seed(UsersContext context)
//        {
//            base.Seed(context);
//            context.Database.ExecuteSqlCommand(
//                @"
//    insert into webpages_Roles (RoleName)
//    values ('Admin'),('User')
//    ");
//        }
    //}
}