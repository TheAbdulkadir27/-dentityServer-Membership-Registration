using İdentityServer.CustomerValidations;
using İdentityServer.Localizations;
using İdentityServer.Models;

namespace İdentityServer.extenition
{
    public static class StartupExtention
    {
        public static void AddİdentityWithEx(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890";
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = true;

                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                option.Lockout.MaxFailedAccessAttempts = 3;
            }).AddPasswordValidator<PasswordValidator>().AddUserValidator<UserValidator>().AddErrorDescriber<LocalizationİdentityErrorDescriber>().AddEntityFrameworkStores<İdentityServerDbContext>();
        }
    }
}
