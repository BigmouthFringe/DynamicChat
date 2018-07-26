using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DynamicChat.Models;
using System.Threading.Tasks;

namespace DynamicChat.Controllers 
{
    public class AccountController : Controller 
    {
        private UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> usrMgr) 
        {
            userManager = usrMgr;
        }

        public ViewResult List() => View(userManager.Users);

        public IActionResult Login(string returnUrl) 
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl) 
        {
            return View(details);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model) 
        {
            if (ModelState.IsValid) {
                AppUser user = new AppUser {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Message");
                } else {
                    foreach (IdentityError error in result.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}