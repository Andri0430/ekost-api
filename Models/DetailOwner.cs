using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EKostApi.Models
{
    public class DetailOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public OwnerAccount OwnerAccount { get; set; }
        public Owner Owner { get; set; }
    }
}
