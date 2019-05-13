using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiki_UnitTest.Mold.Response
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ApiResponse
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public object Date { get; set; }

        public ApiResponse(int status, string messag = "", object date = null)
        {
            Status = status;
            Message = messag;
            Date = date;
        }
    }
}
