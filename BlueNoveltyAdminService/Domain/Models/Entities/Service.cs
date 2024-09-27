using Domain.Enums;
using Domain.Models.Dtos.Create;
using Domain.Models.Dtos.Read;
using Domain.Models.Dtos.Update;
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

        public Service() { }

        public Service(ServiceDTO request)
        {

        }

        public ServiceDetailDTO ToDto()
        {
            return new ServiceDetailDTO()
            {

            };
        }

        public void MapUpdateValues(ServiceWithIdDTO request)
        {

        }
    }
}
