using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Wiki_UnitTest.BLL;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Controllers;
using Wiki_UnitTest.Mold.Request;

namespace WikiUnitTest_Test
{
    [TestClass]
    public class UserControllerTest
    {
        /*
         * Mock对象中的方法只能测试虚拟方法或者接口方法
         */

        [TestMethod]
        public void AddUserTest()
        {
            Mock<MariaDbContext> mockDbContext = new Mock<MariaDbContext>(new object[] { "" });
            Mock<UserBLL> bllMock = new Mock<UserBLL>(mockDbContext.Object);
            bllMock.Setup(n => n.AddUser(It.IsAny<string>())).Returns(true);

            UserController controller = new UserController(bllMock.Object);
            JsonResult result = controller.AddUser(new AddUserRequest { UserName = "老天师" });
            var jsonResult = JsonConvert.SerializeObject(result);
            Assert.IsTrue(string.Equals(jsonResult, "{\"ContentType\":null,\"SerializerSettings\":null,\"StatusCode\":null,\"Value\":{\"Status\":1,\"Message\":\"\",\"Date\":true}}"));
        }

        [TestMethod]
        public void AddUserTest2()
        {
            Mock<IUserBLL> bllMock = new Mock<IUserBLL>();
            bllMock.Setup(n => n.AddUser(It.IsAny<string>())).Returns(true);

            UserController controller = new UserController(bllMock.Object);
            JsonResult result = controller.AddUser(new AddUserRequest { UserName = "老天师" });
            var jsonResult = JsonConvert.SerializeObject(result);
            Assert.IsTrue(string.Equals(jsonResult, "{\"ContentType\":null,\"SerializerSettings\":null,\"StatusCode\":null,\"Value\":{\"Status\":1,\"Message\":\"\",\"Date\":true}}"));
        }
    }
}
