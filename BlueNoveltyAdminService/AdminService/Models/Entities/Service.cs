using AdminService.Enums;
using AdminService.SharedServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models.Entities
{
    [Table("Service")]
    public class Service : BaseEntity
    {
        [Column("serviceType")]
        public ServiceType ServiceType { get; set; }

        [Column("serviceDescription")]
        public string ServiceDescription { get; set; }

        [Column("instructions")]
        public string? Instructions { get; set; }

        [Column("prefferedDates")]
        public string PrefferedDates { get; set; }

        [Column("offeredRates")]
        public string OfferedRates { get; set; }

        [Column("SkillId")]
        public int SkillId { get; set; }

        public List<Skill> Skills { get; set; }

    }
}
