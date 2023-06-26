using İdentityServer.extenition;
using İdentityServer.Models;
using İdentityServer.ViewModel;
using İdentityServer.Views.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace İdentityServer.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> UserSıgnIn;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> userSıgnIn)
        {
            _logger = logger;
            this.userManager = userManager;
            UserSıgnIn = userSıgnIn;
        }
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Signİn()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Signİn(SignİnViewModel user, string? ReturnUrl)
        {
            ReturnUrl = ReturnUrl ?? Url.Action("Index", "Home");
            var HasUser = await userManager.FindByEmailAsync(user.Email);
            if(HasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email Veya Şifre Yanlış");
                return View();
            }
            var result = await UserSıgnIn.PasswordSignInAsync(HasUser, user.Password, user.RememberMe, true);
            if (result.Succeeded)
            {
                return Redirect(ReturnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 Dakika Boyunca Giriş Yapamazsınız..." });
                return View();
            }
            ModelState.AddModelErrorList(new List<string>() { "Email Veya Şifre Yanlış",$"Başarısız Giriş Sayısı={await userManager.GetAccessFailedCountAsync(HasUser)}" });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identityResult = await userManager.CreateAsync(new() { UserName = request.UserName, Email = request.Email, PhoneNumber = request.Phone }, request.PasswordConfirm);
            if (identityResult.Succeeded)
            {
                TempData["Message"] = "Üyelik Kayıt İşlemi Başarıyla Tamamlanmıştır";
                return RedirectToAction(nameof(HomeController.SignUp));
            }
            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
            return View();
        }
        public IActionResult Privacy() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
    }
}