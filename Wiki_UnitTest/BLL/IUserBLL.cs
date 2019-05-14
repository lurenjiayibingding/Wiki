using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiki_UnitTest.BLL
{
    public interface IUserBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool AddUser(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserName(Guid userId);
    }
}
