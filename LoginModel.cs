using System.ComponentModel.DataAnnotations;

namespace AuthApp.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
