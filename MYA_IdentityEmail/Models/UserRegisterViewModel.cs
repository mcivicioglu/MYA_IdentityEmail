using System.ComponentModel.DataAnnotations;

namespace MYA_IdentityEmail.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "İsim alanı zorunludur")]
        [RegularExpression("^[a-zA-ZığüşöçİĞÜŞÖÇ ]+$", ErrorMessage = "İsim sadece harf ve boşluk içerebilir")]
        [MaxLength(50, ErrorMessage = "İsim 50 karakterden fazla olamaz"), MinLength(2, ErrorMessage = "İsim en az 2 karakter olmalıdır")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı zorunludur")]
        [RegularExpression("^[a-zA-ZığüşöçİĞÜŞÖÇ ]+$", ErrorMessage = "Soyisim sadece harf ve boşluk içerebilir")]
        [MaxLength(50, ErrorMessage = "Soyisim 50 karakterden fazla olamaz"), MinLength(2, ErrorMessage = "Soyisim en az 2 karakter olmalıdır")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur")]
        [MaxLength(30, ErrorMessage = "Kullanıcı adı 30 karakterden fazla olamaz"), MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalıdır")]
        [RegularExpression("^[a-zA-Z0-9_.-]+$", ErrorMessage = "Kullanıcı adı sadece harf, rakam, . - _ içerebilir")]
        public string Username { get; set; }
        [Required(ErrorMessage = "E-posta alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Şifre en az 8 karakter olmalıdır")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "KVKK ve kullanıcı sözleşmesini kabul etmelisiniz")]
        public bool AcceptTerms { get; set; }

    }
}
