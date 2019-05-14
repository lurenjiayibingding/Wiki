using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wiki_UnitTest.BLL;
using Wiki_UnitTest.Common;
using Wiki_UnitTest.Mold.Request;
using Wiki_UnitTest.Mold.Response;

namespace Wiki_UnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBLL userBll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public UserController(IUserBLL bll)
        {
            userBll = bll;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public JsonResult AddUser([FromBody]AddUserRequest request)
        {
            var result = userBll.AddUser(request.UserName);
            if (result)
            {
                return new JsonResult(new ApiResponse(1, "", true));
            }
            else
            {
                return new JsonResult(new ApiResponse(2, "", false));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetUserName")]
        public JsonResult GetUserName(Guid userId)
        {
            try
            {
                var userName = userBll.GetUserName(userId);
                return new JsonResult(new ApiResponse(1, "", userName));
            }
            catch (Exception ex)
            {
                return new JsonResult(new ApiResponse(2, $"{ex.Message}"));
            }
        }
    }
}