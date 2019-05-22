using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Wiki_UnitTest.BLL;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Mold.DBModel;
using System.Linq;
using System.Linq.Expressions;
using WikiUnitTest_Test.Class;

namespace WikiUnitTest_Test
{
    [TestClass]
    public class UserBLLTest
    {
        private Mock<MariaDbContext> mockDbContext;
        private UserBLL userBll;

        [TestInitialize]
        public void TestInitialize()
        {
            mockDbContext = new Mock<MariaDbContext>(new object[] { "" });
            userBll = new UserBLL(mockDbContext.Object);
        }

        [TestMethod]
        public void AddUserTest1()
        {
            var mockUserInfoModel = new Mock<DbSet<WUserInfoModel>>();
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockUserInfoModel.Object);
            mockDbContext.Setup(n => n.SaveChanges()).Returns(1);
            var result = userBll.AddUser("曾小贤");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddUserTest2()
        {
            var mockUserInfoModel = new Mock<DbSet<WUserInfoModel>>();
            mockUserInfoModel.SetupArray(new WUserInfoModel[0]);
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockUserInfoModel.Object);
            mockDbContext.Setup(n => n.SaveChanges()).Returns(1);
            var result = userBll.AddUser("曾小贤");
            Assert.IsTrue(mockUserInfoModel.Object.Count() == 1);
        }

        /// <summary>
        /// 错误的单元测试用例
        /// </summary>
        [TestMethod]
        public void GetUserNameTest1()
        {
            var id = Guid.NewGuid();
            var name = Guid.NewGuid().ToString();
            var userInfoModel = new WUserInfoModel
            {
                Id = id.ToString(),
                UserName = "name",
            };

            //DbSet<T>是抽象类不能直接实例化
            //mockDbContext.Setup(n => n.UserInfoModels).Returns(new DbSet<WUserInfoModel>());

            //报错::“The method or operation is not implemented.”
            Mock<DbSet<WUserInfoModel>> mockDbSet = new Mock<DbSet<WUserInfoModel>>();
            mockDbSet.Object.Add(userInfoModel);
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockDbSet.Object);

            Assert.IsTrue(userBll.GetUserName(id) == name);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetUserNameTest2()
        {
            var id = Guid.NewGuid();
            var name = Guid.NewGuid().ToString();
            var userInfoModel = new WUserInfoModel
            {
                Id = id.ToString(),
                UserName = name,
            };

            Mock<DbSet<WUserInfoModel>> mockDbSet = new Mock<DbSet<WUserInfoModel>>();
            mockDbSet.SetupArray(new WUserInfoModel[] { userInfoModel });
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockDbSet.Object);

            Assert.IsTrue(userBll.GetUserName(id) == name);
        }
    }
}
