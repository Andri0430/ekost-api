using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKostApi.Models
{
    public class DetailKost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Kost Kost { get; set; }
        public Account Account { get; set; }
        public int QtyRoom { get; set; }
    }
}