using Microsoft.VisualStudio.TestTools.UnitTesting;
using job.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace job.Controllers.Tests
{
    [TestClass()]
    public class RolesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            RolesController controller = new RolesController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest()
        {
            RolesController controller = new RolesController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.AreEqual("تم انشاء بنجاح",result.ViewBag.Messagecreate);
        }
    }
}