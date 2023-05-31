using System.ComponentModel;

namespace AdminService.Enums
{
    public enum ErrorCodeEnum
    {
        [Description("001")]
        Internal,
        [Description("002")]
        Required,
        [Description("003")]
        MaxLength,
        [Description("004")]
        MinLength,
        [Description("005")]
        OutOfRange,
        [Description("006")]
        Custom,
    }
}
