using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SharedServices
{
    [DataContract]
    public class GenericError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string FieldName { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Message { get; }

        public GenericError(string field, string code, string message) 
        {
            FieldName= field;
            Code= code; 
            Message= message;
        }

        public GenericError(string field, string message)
        {
            FieldName = field;
            Code = ErrorCodeMapper.MapMessageToErrorCode(message).GetDescription();
            Message = message;
        }

        public GenericError() { }
    }
}
