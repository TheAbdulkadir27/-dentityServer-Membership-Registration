using İdentityServer.Areas.Admin.Models;
using İdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace İdentityServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userManager) => this.userManager = userManager;
        public IActionResult Index() { return View(); }
        public async Task<IActionResult> UserList()
        {
            var UserList = await userManager.Users.ToListAsync();
            var UserModelList = UserList.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Name = x.UserName,
                Email = x.Email
            }).ToList();
            return View(UserModelList);
        }
    }
}
