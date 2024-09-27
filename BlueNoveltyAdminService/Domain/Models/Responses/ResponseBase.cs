using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Models.Responses
{
    public class ResponseBase
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
