using İdentityServer.Models;
using Microsoft.AspNetCore.Identity;

namespace İdentityServer.CustomerValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var error = new List<IdentityError>();
            var IsNumeric = int.TryParse(user.UserName[0].ToString(), out _);
            if (IsNumeric)
            {
                error.Add(new IdentityError() { Code = "UserNameContainsFirstLetterDigit", Description = "Kullanıcı Adının İlk Karakteri Sayısal Bir Karakter İçeremez!" });
            }
            if (error.Any())
            {
                return Task.FromResult(IdentityResult.Failed(error.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
