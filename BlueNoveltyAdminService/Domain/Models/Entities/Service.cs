using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    [Table("Services")]
    public class Service : BaseEntity
    {
        [Column("serviceName")]
        public string? ServiceName { get; set; }

        [Column("serviceDescription")]
        public string? ServiceDescription { get; set; }
    }
}
