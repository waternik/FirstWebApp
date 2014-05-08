using FirstWebApp.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestRegistrateCurrentUserOnGameView()
        {
            var controller = new HomeController();
            var result = controller.RegistrateCurrentUserOnGame() as ViewResult;
        }
    }
}
