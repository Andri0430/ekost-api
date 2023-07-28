using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EKostApi.Models
{
    public class DetailUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public User User { get; set; }
    }
}