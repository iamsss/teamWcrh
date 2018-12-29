using System.ComponentModel.DataAnnotations;

namespace teamWcrh.Controllers.Resources
{
    public class LoginResource
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }

    }
}