using Domain.Models.Dtos.Update;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos.Read
{
    public class ServiceDetailDTO : ServiceWithIdDTO
    {
        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
