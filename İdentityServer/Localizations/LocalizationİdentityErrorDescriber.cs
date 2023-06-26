using Microsoft.AspNetCore.Identity;

namespace İdentityServer.Localizations
{
    public class LocalizationİdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $" Bu {userName} Daha Önce Başka Bir Kullanıcı Tarafından Alınmıştır!" };
        }
        public override IdentityError PasswordTooShort(int length){return new(){ Code = "PasswordTooShort", Description = $"Şifre En Az 6 Karakter Uzunluğunda Olmalıdır!" }; }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"{email} Bu Email Adresi Başkası Tarafından Kullanılıyor!" };
        }
    }
}
