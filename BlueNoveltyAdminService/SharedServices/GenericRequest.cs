using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SharedServices
{
    [DataContract]
    public class GenericRequest<T>
    {
        [Required]
        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
}
