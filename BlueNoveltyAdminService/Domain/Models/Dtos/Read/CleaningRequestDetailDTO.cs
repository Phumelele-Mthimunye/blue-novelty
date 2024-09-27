using Domain.Models.Dtos.Update;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos.Read
{
    public class CleaningRequestDetailDTO : CleaningRequestWithIdDTO
    {
        [DataMember(Name = "active")]
        public bool Active { get; set; }
    }
}
