using Domain.Models.Dtos.Create;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.Models.Dtos.Update
{
    public class CleaningRequestWithIdDTO : CleaningRequestDTO
    {
        [DataMember(Name = "id")]
        [Required]
        public long Id { get; set; }
    }
}
