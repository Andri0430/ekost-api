using System.ComponentModel.DataAnnotations;

namespace EKostApi.Models
{
    public class OwnerAccount
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
