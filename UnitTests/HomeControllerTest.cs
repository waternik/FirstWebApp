using FirstWebApp.Repository.Interfaces;
using FirstWebApp.Repository.Models;
using FirstWebApp.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
            var registratedMembersList = new List<IRegistratedMember>();
            registratedMembersList.Add( new RegistratedMember()
                                            {
                                                DateRegistration = DateTime.Now,
                                                Id= 1,
                                                UserId = 3,
                                                UserProfile = new UserProfile()
                                                                  {
                                                                      FullUserName  = "Петькин",
                                                                      UserId = 3,
                                                                      UserName = "user1"
                                                                  }
                                            });
            var mock = new Mock<IRepositoryRegistratedMembers>();
            mock.Setup(m => m.GetRegistratedMembers()).Returns(registratedMembersList);
            var controller = new HomeController(mock.Object);
            var result = controller.AllRegistratedOnGameUsers() as ViewResult;
        }
    }
}
