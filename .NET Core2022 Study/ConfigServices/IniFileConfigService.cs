﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigServices
{
    public class IniFileConfigService:IConfigService
    {
        public string FilePath { get; set; }
        public string GetValue(string name)
        {
            //分割文件的内容
            var kv = File.ReadAllLines(FilePath).Select(s => s.Split('='))
                .Select(strs => new { Name = strs[0], Value = strs[1] }).SingleOrDefault(kv => kv.Name == name);
            if (kv != null)//判断文件是否为空
            {
                return kv.Value;
            }
            else
            {
                return null;
            }
        }
    }
}
