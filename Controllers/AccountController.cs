using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DynamicChat.Models;
using System.Threading.Tasks;

namespace DynamicChat.Controllers 
{
    public class AccountController : Controller 
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> usrMgr,
                SignInManager<AppUser> signinMgr) 
        {
            userManager = usrMgr;
            signInManager = signinMgr;
        }

        public ViewResult List() => View(userManager.Users);

        public IActionResult Login(string returnUrl) 
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details,
                string returnUrl) 
        {
            if (ModelState.IsValid) {
                AppUser user = await userManager.FindByEmailAsync(details.Email);
                if (user != null) {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(
                            user, details.Password, false, false);
                    if (result.Succeeded) {
                        return RedirectToAction("Index", "Message");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
                    "Invalid user or password");
            }
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