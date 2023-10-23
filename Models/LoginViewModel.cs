using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string Password { get; set; }
    }
}
