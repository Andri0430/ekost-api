using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKostApi.Models
{
    public class Kost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string KostName { get; set; } = string.Empty;
        public int KostPrice { get; set;}
        public KostType KostType { get; set; }
        public KostAdress KostAdress { get; set; }
    }
}
