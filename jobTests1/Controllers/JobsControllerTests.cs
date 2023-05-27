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
    public class JobsControllerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            JobsController controller = new JobsController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
                
        }
    }
}