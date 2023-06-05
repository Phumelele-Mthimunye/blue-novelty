using SharedServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models.Entities
{
    public class BaseEntity : IEntityFrameworkObjectId<Guid>
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("active")]
        [Required]
        public bool Active { get; set; }
    }
}
