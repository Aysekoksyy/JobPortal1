using JobPortal1.Data;
using JobPortal1.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.Json;

namespace JobPortal1.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        
        public CandidatesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult CandidateProfile()
        {
            var candidate = _context.Candidates.FirstOrDefault();
            if (candidate == null)
                candidate = new Candidate();

            return View("candidate-profile", candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CandidateProfile(Candidate model, IFormFile? ResumeFile)
        {
            //model.ResumeFileName = "to be defined";
            if (ModelState.IsValid)
            {
                var candidate = _context.Candidates.FirstOrDefault(c => c.Id == model.Id);

                if (ResumeFile != null && ResumeFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string fileName = Path.GetFileName(ResumeFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ResumeFile.CopyTo(stream);
                    }

                    //model.ResumeFileName = fileName;
                }
                //else
                //{
                //    model.ResumeFileName = "to be defined";
                //}
                if (candidate != null)
                {
                    // Güncelle
                    candidate.FullName = model.FullName;
                    candidate.Email = model.Email;
                    candidate.Phone = model.Phone;
                    candidate.Bio = model.Bio;
                    candidate.PersonalWebsite = model.PersonalWebsite;
                    candidate.Country = model.Country;
                    candidate.State = model.State;
                    candidate.City = model.City;
                    candidate.ZipCode = model.ZipCode;
                    candidate.Skills = model.Skills;
                    //if (!string.IsNullOrEmpty(model.ResumeFileName))
                    //    candidate.ResumeFileName = model.ResumeFileName;

                    _context.SaveChanges();
                }
                else
                {
                    _context.Candidates.Add(model);
                    _context.SaveChanges();
                }
                return View("Success", model);

                //return Content($"Candidate Saved Succesfully CandidateID: {model.Id} Recorded Data: {JsonSerializer.Serialize(model)} ");
                //return RedirectToAction("CandidateProfile");
            }

            return View("candidate-profile", model);
        }
    }
}
