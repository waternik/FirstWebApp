using FirstWebApp.Repository.Interfaces;
using FirstWebApp.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestAllRegistratedOnGameUsersView()
        {
            IRepositoryRegistratedMembers rep;
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IRepositoryRegistratedMembers>().To<MyRep>();
            var myrep = ninjectKernel.TryGet<IRepositoryRegistratedMembers>();
            var controller = new HomeController(myrep);
            var result = controller.AllRegistratedOnGameUsers() as ViewResult;
        }

        public class MyRep : IRepositoryRegistratedMembers
        {
            public List<IRegistratedMember> GetRegistratedMembers()
            {
                var registratedMembersList = new List<IRegistratedMember>();
                
                return registratedMembersList;
            }

            public void AddRegMember(string nameUser)
            {
                
            }

            public void RemoveRegMember(int id)
            {
                
            }

            public void SaveChangeRegMember(IRegistratedMember item)
            {
                
            }
        }
    }
}
