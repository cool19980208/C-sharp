namespace 自定义配置提供
{
    class WebConfig
    {
        public ConnectStr Connstr1 { get; set; }
        public appSettings appSettings { get; set; }
    }
     class ConnectStr
    {
        public string connectionString { get; set; }
        public string providerName { get; set; }
    }
    class appSettings
    {
        public Smtp Smtp { get; set; }
        public string RedisServer { get; set; }
        public string RedisPassword { get; set; }
    }
    class Smtp
    {
        public string Server { get; set; }//Smtp:Server
        public int Port { get; set; }//Smtp:Port
    }
 


}
