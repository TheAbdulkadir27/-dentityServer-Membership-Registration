using İdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace İdentityServer.CustomerValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if(password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError { Code = "Password can't be Contain UserName", Description = "Şifre alanı kullanıcı adı içeremez" });
            }
            if(password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new IdentityError { Code = "Password Can't be contain consecutive number", Description = "Şifre alanı Ardışık Sayı İçeremez" });
            }
            if(errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Failed());
        }
    }
}
