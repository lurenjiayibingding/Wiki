using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Mold.DBModel;

namespace Wiki_UnitTest.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBLL : IUserBLL
    {
        MariaDbContext dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserBLL(MariaDbContext context)
        {
            dbContext = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual bool AddUser(string userName)
        {
            var userModel = new WUserInfoModel
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
            };

            dbContext.UserInfoModels.Add(userModel);
            if (dbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetUserName(Guid userId)
        {
            var user = dbContext.UserInfoModels.Where(n => n.Id == userId.ToString()).FirstOrDefault();
            if (user != null)
            {
                return user.UserName;
            }
            throw new Exception("数据不存在");
        }
    }
}
