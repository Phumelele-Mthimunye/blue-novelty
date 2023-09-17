using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Tasks")]
    public class Task : BaseEntity
    {
        

        //fk expertise

        [Column("expertise_Id")]
        public string ExpertiseId { get; set; }

        [ForeignKey("ExpertiseId")]
        public virtual Expertise Expertise { get; set; }

        //name
        [Column("name")]
        public string Name { get; set; }

        public List<Service> Services { get; set; }
        public virtual List<User> User { get; set; }
    }
}
