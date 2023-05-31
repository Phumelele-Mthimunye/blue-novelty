using AdminService.Enums;
using System.Runtime.Serialization;

namespace AdminService.SharedServices
{
    [DataContract]
    public class GenericResponse<T>
    {
        [DataMember(Name = "data")]
        public T Data { get; set; }

        [DataMember(Name = "errors")]
        public List<GenericError> Error { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        public GenericResponse(T data) 
        {
            this.Data = data;
            this.Message = MessageOutcome.Success.GetDescription();
        }

        public GenericResponse(MessageOutcome outcome)
        {
            if (outcome.Equals(MessageOutcome.Success))
            {
                this.Message = MessageOutcome.Success.GetDescription();
            }
            else
            {
                var errors = new List<GenericError>
                {
                    new GenericError("Internal", ErrorCodeEnum.Internal.GetDescription(), "Error: An Internal error has occured")
                };
                this.Error = errors;
                this.Message = MessageOutcome.Failure.GetDescription();
            }
        }
    }
}
