using ExamAspPartTwo.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ExamAspPartTwo.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db;

        public AccountController(ApplicationDbContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync
                    (u => u.Email == model.Email && u.Password == model.Password);
                
                if (user != null)
                {
                    await Authenticate(model.Email);
                    return RedirectToAction("Product", "Market");
                }
                else
                    ModelState.AddModelError("", "Некорректный логин и(или)пороль");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RgisterModel model)
        {
            if (!ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.Users.Add(new User { Email = model.Email, Password = model.Password });
                    await db.SaveChangesAsync();
                    await Authenticate(model.Email);
                    return RedirectToAction("Product", "Market");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь уже сущиствует");
                }
            }
            return View(model);
        }


        private async Task Authenticate(string? email)
        {
            var claims = new List<Claim>
           {
               new Claim (ClaimsIdentity.DefaultNameClaimType, email)
           };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookies",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public IActionResult LabelEmail()
        {
            return Content(User.Identity.Name);
        }
    }
}
