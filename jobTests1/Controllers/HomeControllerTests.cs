using Microsoft.VisualStudio.TestTools.UnitTesting;
using job.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace job.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {

        [TestMethod()]
        public void AboutTest()
        {
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("وصف عام حول الموقع ", result.ViewBag.Message);
        }

        [TestMethod()]
        public void ContactTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }


        [TestMethod()]
        public void ContactTest1()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.AreEqual("تم عملية الاتصال بنجاح", result.ViewBag.Messagecontact);
        }

        [TestMethod()]
        public void ApplyTest()
        {
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Apply() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void SearchTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Search() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void Call_usTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Call_us() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}