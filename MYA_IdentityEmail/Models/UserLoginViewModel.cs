using System.ComponentModel.DataAnnotations;

namespace MYA_IdentityEmail.Models
{
    public class UserLoginViewModel
    {
        public string Identifier { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
