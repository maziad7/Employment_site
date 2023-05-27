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
    public class CategoriesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            CategoriesController controller = new CategoriesController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void CreateTest()
        {
            CategoriesController controller = new CategoriesController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}