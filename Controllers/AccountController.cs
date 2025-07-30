using Microsoft.AspNetCore.Mvc;
using JobPortal1.Models; // RegisterViewModel ve AppUser burada ise
using JobPortal1.Data;   // ApplicationDbContext burada ise
using System.Linq;

namespace JobPortal1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("PageRegister"); // /Views/Pages/PageRegister.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FullName = model.FullName,
                    Email = model.EmailAddress,
                    UserName = model.Username,
                    Password = model.Password // Not: Hash önerilir
                };

                _context.AppUsers.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("RegisterSuccess");
            }

            return View("~/Views/Pages/PageRegister.cshtml", model);
        }

        [HttpGet]
        public IActionResult RegisterSuccess()
        {
            return View("~/Views/Account/RegisterSuccess.cshtml");
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View("~/Views/Pages/page-signin.cshtml"); // Dosya adı küçük harfli
        }

        [HttpPost]
        public IActionResult Signin(string emailaddress, string password)
        {
            if (string.IsNullOrWhiteSpace(emailaddress) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "E-posta ve şifre boş geçilemez.");
                return View("PageSignin");
            }

            var user = _context.AppUsers.FirstOrDefault(u => u.Email == emailaddress && u.Password == password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz e-posta veya şifre.");
                return View("PageSignin");
            }

            // Giriş başarılıysa yönlendir
            return RedirectToAction("Index", "Home");
        }


    }
}
