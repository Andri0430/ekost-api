using System.ComponentModel.DataAnnotations;

namespace EKostApi.Models
{
    public class KostAdress
    {
        [Key]
        public int Id { get; set; }
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
    }
}
