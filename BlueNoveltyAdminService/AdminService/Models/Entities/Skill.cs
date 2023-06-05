using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models.Entities
{
    [Table("Skill")]
    public class Skill : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public List<Service> Services { get; set; }

        public virtual List<User> User { get; set; }
    }
}
