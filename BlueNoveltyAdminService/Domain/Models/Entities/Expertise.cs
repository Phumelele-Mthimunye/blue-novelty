using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Expertise")]
    public class Expertise : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
