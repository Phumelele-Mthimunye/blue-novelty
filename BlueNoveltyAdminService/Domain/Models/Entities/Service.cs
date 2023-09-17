using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Service")]
    public class Service : BaseEntity
    {
        //user id
        [Column("User_Id")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //Expertise id (enum)
        [Column("expertise_Id")]
        public string ExpertiseId { get; set; }

        [ForeignKey("ExpertiseId")]
        public virtual Expertise Expertise { get; set; }



        //description
        [Column("description")]
        public string Description { get; set; }

        //rate
        [Column("rate")]
        public decimal? Rate { get; set; }


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

        //list of tasks
        public List<Task> Tasks { get; set; }



    }
}
