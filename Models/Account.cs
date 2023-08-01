using System.ComponentModel.DataAnnotations;

namespace EKostApi.Models
{
    public class Account
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}