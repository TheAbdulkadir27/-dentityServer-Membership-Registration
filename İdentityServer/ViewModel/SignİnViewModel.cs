using System.ComponentModel.DataAnnotations;

namespace İdentityServer.ViewModel
{
    public class SignİnViewModel
    {
        public SignİnViewModel() { }
        public SignİnViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress(ErrorMessage = "Email Adresi Yanlış")]
        [Required(ErrorMessage = "Email Girilmesi Zorunludur")]
        [Display(Name = "Email :")]
        public string Email { get; set; }
        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre Girilmesi Zorunludur")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; } = false;
    }
}
