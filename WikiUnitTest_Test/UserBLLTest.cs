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
        public void AddUserTest()
        {
            var mockUserInfoModel = new Mock<DbSet<WUserInfoModel>>();
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockUserInfoModel.Object);
            mockDbContext.Setup(n => n.SaveChanges()).Returns(1);
            var result = userBll.AddUser("武当王也");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetUserNameTest()
        {
            var id = Guid.NewGuid();
            var name = Guid.NewGuid().ToString();
            var userInfoModel = new WUserInfoModel
            {
                Id = id.ToString(),
                UserName = "name",
            };
            var list = new List<WUserInfoModel> { userInfoModel };

            var mockUserInfoModel = new Mock<DbSet<WUserInfoModel>>();
            mockUserInfoModel.Object.Add(new WUserInfoModel
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "111",
            });
            //mockUserInfoModel.Setup(n => n.Where(It.IsAny<Expression<Func<WUserInfoModel, bool>>>())).Returns(null);

            //mockDbContext.Setup(n => n.UserInfoModels.Where(It.IsAny<Expression<Func<WUserInfoModel, bool>>>())).Returns(mockUserInfoModel.Object);
            mockDbContext.Setup(n => n.UserInfoModels).Returns(mockUserInfoModel.Object);
            Assert.IsTrue(userBll.GetUserName(id) == name);
        }
    }
}
