﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    /// <summary>
    /// 帐户类
    /// </summary>
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool BRes { get; set; }

        public string Ticket { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
            
    }
}
