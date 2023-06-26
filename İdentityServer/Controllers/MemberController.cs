using İdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace İdentityServer.Controllers
{
    [Route("Member")]
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _UserManager;
        public MemberController(SignInManager<AppUser> userManager) => _UserManager = userManager;
        public async Task SignOut()
        {
            await _UserManager.SignOutAsync();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
