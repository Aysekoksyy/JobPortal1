using Microsoft.AspNetCore.Mvc;
using JobPortal1.Models;
using JobPortal1.Data;

namespace JobPortal1.Controllers
{
    public class PagesController : Controller
    {

        public IActionResult PageAbout()
        {
            return View("page-about"); // dosya adı Views/Pages/page-about.cshtml olmalı
        }

        public IActionResult PageContact()
        {
            return View("page-contact"); // dosya adı Views/Pages/page-contact.cshtml olmalı
        }
        public IActionResult PageRegister()
        {
            return View("~/Views/Pages/page-register.cshtml");
        }

        public IActionResult PageSignin()
        {
            return View("page-signin"); 
        }
        public IActionResult PageContentProtected()
        {
            return View("page-content-protected"); // dosya adı: Views/Pages/page-content-protected.cshtml
        }
        public IActionResult PageNotFound()
        {
            return View("page-404"); // Dosya: Views/Pages/page-404.cshtml
        }

        
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // örnek: AJAX form işlemi
        [HttpPost]
        public IActionResult SendContact([FromBody] ContactMessage contact)
        {
            if (!ModelState.IsValid)
                return BadRequest("Eksik veya hatalı veri");

            _context.ContactMessages.Add(contact);
            _context.SaveChanges();

            return Ok(new { message = "Mesaj başarıyla gönderildi." });
        }

        // Diğer view-return action'lar burada...
    }
}
