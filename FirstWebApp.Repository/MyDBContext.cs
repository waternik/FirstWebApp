using System.Data.Entity;
using FirstWebApp.Repository.Models;

namespace FirstWebApp.Repository
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfileDO> UserProfiles { get; set; }
        public DbSet<RegistratedMemberDO> RegistratedMembers { get; set; }
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