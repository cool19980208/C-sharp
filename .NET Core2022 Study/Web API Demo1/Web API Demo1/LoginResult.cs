namespace Web_API_Demo1
{
    public record LoginResult(bool IsOK,ProcessInfo[]? Processes);//检验用户账号和密码
    
}
