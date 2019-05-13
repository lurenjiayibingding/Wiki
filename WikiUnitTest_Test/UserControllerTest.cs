using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Wiki_UnitTest.BLL;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Controllers;
using Wiki_UnitTest.Mold.Request;

namespace WikiUnitTest_Test
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            Mock<MariaDbContext> mockDbContext = new Mock<MariaDbContext>(new object[] { "" });
            Mock<UserBLL> bllMock = new Mock<UserBLL>(mockDbContext.Object);
            UserController controller = new UserController(bllMock.Object);

            bllMock.Setup(n => n.AddUser("")).Returns(true);
            JsonResult result = controller.AddUser(new AddUserRequest { UserName = "老天师" });
            Assert.IsTrue(true);
        }
    }
}
