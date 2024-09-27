using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos.Delete
{
    public class DeleteDBRequest
    {
        [DataMember(Name = "id")]
        [Required]
        public long Id { get; set; }
    }
}
