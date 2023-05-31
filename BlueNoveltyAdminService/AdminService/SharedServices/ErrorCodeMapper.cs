using AdminService.Enums;

namespace AdminService.SharedServices
{
    public class ErrorCodeMapper
    {
        public static ErrorCodeEnum MapMessageToErrorCode(string message)
        {
            if(message.Contains("required"))
                return ErrorCodeEnum.Required;
            else if(message.Contains("maximum length"))
                return ErrorCodeEnum.MaxLength;

            return ErrorCodeEnum.Custom;
        }
    }
}
