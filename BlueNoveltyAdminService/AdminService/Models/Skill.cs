using BlueNoveltyAdminService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminService.Models
{
    [Table("Skill")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<User> Users { get;set; }
        public List<Service> Services { get;set; }

        public virtual List<User> User { get; set; }
    }
}
