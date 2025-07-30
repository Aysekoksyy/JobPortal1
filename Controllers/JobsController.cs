using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult BasvuruBasarili()
        {
            return View();
        }

        public IActionResult JobsList()
        {
            return View("jobs-list");
        }
        public IActionResult JobDetails()
        {
            return View("job-details");
        }

    }
}
