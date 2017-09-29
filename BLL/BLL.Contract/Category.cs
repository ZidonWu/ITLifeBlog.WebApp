﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public int Count { get; set; }
    }
}
