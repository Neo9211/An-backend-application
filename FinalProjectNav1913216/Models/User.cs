using System.ComponentModel.DataAnnotations;

namespace FinalProjectNav1913216.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public User(string UserUId, string Name, string Email, string Password)
        {
            UserUId = UserUId;
            Name = Name;
            Email = Email;
            Password = Password;
        }
    }
}
