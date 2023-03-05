using AdminService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        public string? Instructions { get; set; }
        [Required]
        public string PrefferedDates { get; set; }
        [Required]
        public string OfferedRates { get;set; }
        [Required]
        public int SkillId { get; set;}

        public List<Skill> Skills { get; set; }

    }
}
