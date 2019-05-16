using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Wiki_UnitTest.BLL;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Mold.DBModel;
using System.Linq;

namespace WikiUnitTest_Test
{
    [TestClass]
    public class UserBLLTest
    {
        private UserBLL userBll;

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void AddUserTest()
        {
            Mock<MariaDbContext> mockDbContext = new Mock<MariaDbContext>(new object[] { "Data Source=118.24.80.186;Port=3306;Database=WeChat; User ID=root; Password=1qazXSW@;Charset=utf8" });
            var mockUserInfoModel = new Mock<DbSet<WUserInfoModel>>();
            mockUserInfoModel.Object.Add(new WUserInfoModel
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "111",
            });



            //var aaa = mockUserInfoModel.Count();

            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockUserInfoModel.Object);
            userBll = new UserBLL(mockDbContext.Object);

            mockDbContext.Setup(n => n.SaveChanges()).Returns(1);

            //Assert.IsTrue(mockUserInfoModel.Count() == 0);
            var result = userBll.AddUser("武当王也");
            Assert.IsTrue(result);
            //Assert.IsTrue(mockUserInfoModel.Count() == 1);

        }

    }
}