using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class SignUpViewModel
    {
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
