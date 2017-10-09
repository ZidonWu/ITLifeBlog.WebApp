using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public int RoleId { get; set; }
    }
}
