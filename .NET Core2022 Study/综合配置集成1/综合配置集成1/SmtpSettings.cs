﻿namespace 综合配置集成1
{
    public record SmtpSettings
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
