using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Proposal")]
    public class Proposal : BaseEntity
    {
        [Column("dateOfBirth")]
        public DateOnly? DateOfBirth { get; set; }

        //status (enum)
        [Column("status")]
        public Status Status { get; set; }

        //price
        [Column("price")]
        public decimal? Price { get; set; }

        //
        [Column("name")]
        public string Name { get; set; }
    }
}
