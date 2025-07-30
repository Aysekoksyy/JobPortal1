using Microsoft.AspNetCore.Mvc;
using JobPortal1.Models;
using JobPortal1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;

namespace JobPortal1.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DashboardController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // === View Sayfaları ===
        public IActionResult Index() => View();
        public IActionResult Login() => View();
        public IActionResult Register() => View();
        public IActionResult MyTasksList() => View();
        public IActionResult MyResume() => View();
        public IActionResult Profile() => View();
        public IActionResult Settings() => View();
        public IActionResult Recruiters() => View();
        public IActionResult Authentication() => View();
        public IActionResult Candidates() => View();

        // === GET: İlan Oluşturma Sayfası ===
        [HttpGet]
        public IActionResult PostJob()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostJob(JobPost job, IFormFile? JobFile)
        {
            if (ModelState.IsValid)
            {
                if (JobFile != null && JobFile.Length > 0)
                {
                    string uploadFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadFolder);

                    string fileName = Path.GetFileName(JobFile.FileName);
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await JobFile.CopyToAsync(stream);
                    }

                    job.FilePath = fileName;
                }
                else
                {
                    // 📌 Dosya yüklenmemişse, varsayılan sahte dosya ismi atanıyor
                    job.FilePath = "default.pdf"; // veya "bos.pdf" gibi bir şey de olabilir
                }

                _context.JobPosts.Add(job);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "İlanınız başarıyla oluşturuldu!";
                return RedirectToAction("MyJobGrid");
            }

            return View(job); // Hatalıysa form tekrar gösterilir
        }


        public async Task<IActionResult> MyJobGrid()
        {
            var jobs = await _context.JobPosts.ToListAsync();
            return View(jobs);
        }


    }
}
