namespace WebAPI的技术及选择1
{
    public record ErrorInfo(int Code, string? Message);//Code代表业务错误码；Message代表错误相关的信息
}
