using SharedServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class BaseEntity : IEntityFrameworkObjectId<long>
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("active")]
        [Required]
        public bool Active { get; set; }
    }
}
