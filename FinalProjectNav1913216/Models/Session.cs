using System.ComponentModel.DataAnnotations;

namespace FinalProjectNav1913216.Models
{
    public class Session
    {
        [Key]
        public string Token { get; set; }
        [Required]
        public string Email { get; set; }

        public Session(string token, string email)
        {
            Token = Guid.NewGuid().ToString();
        }
    }
}
