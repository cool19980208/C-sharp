﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 乐观并发控制
{
    class House
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public byte[] RowVer { get; set; }
    }
}
