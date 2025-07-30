using Microsoft.AspNetCore.Mvc;

namespace JobPortal1.Controllers
{
    public class RecruitersController : Controller
    {
        public IActionResult CompaniesGrid()
        {
            return View("~/Views/Recruiters/companies-grid.cshtml");

        }
        public IActionResult CompanyDetails()
        {
            return View("~/Views/Recruiters/company-details.cshtml");
        }
    


    }
}
