using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wiki_UnitTest.Mold.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class WUserInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
    }
}
