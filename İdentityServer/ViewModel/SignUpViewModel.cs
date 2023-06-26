using System.ComponentModel.DataAnnotations;

namespace İdentityServer.ViewModel
{
    public class SignUpViewModel
    {
        public SignUpViewModel() { }
        public SignUpViewModel(string? name, string? email, string? phone, string? password, string passwordConfirm)
        {
            UserName = name;
            Email = email;
            Phone = phone;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
        [Required(ErrorMessage = "Kullanıcı Adı Girilmesi Zorunludur ")]
        [Display(Name = "Kullanıcı Adı:")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email Adresi Yanlış")]
        [Required(ErrorMessage = "Email Girilmesi Zorunludur")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefon Numarası Zorunludur")]
        [Display(Name = "Telefon :")]
        public string? Phone { get; set; }
        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre Girilmesi Zorunludur")]
        public string? Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Şifreler Aynı Değil")]
        [Display(Name = "Şifre Tekrar:")]
        public string PasswordConfirm { get; set; } = string.Empty;
    }
}
