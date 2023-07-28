using System.ComponentModel.DataAnnotations;

namespace EKostApi.Models
{
    public class UserAccount
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
