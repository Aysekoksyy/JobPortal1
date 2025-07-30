using System.Diagnostics;
using JobPortal1.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    public IActionResult About() => View("page-about");

    public IActionResult BlogDetails() => View("blog-details");

    public IActionResult BlogGrid() => View("blog-grid");

    public IActionResult BlogGrid2() => View("blog-grid-2");

    public IActionResult CandidateDetails() => View("candidate-details");

    public IActionResult CandidateProfile() => View("candidate-profile");

    public IActionResult CandidatesGrid() => View("candidates-grid");

    public IActionResult CompaniesGrid() => View("companies-grid");

    public IActionResult CompanyDetails() => View("company-details");

    public IActionResult Contact() => View("page-contact");

    public IActionResult ContentProtected() => View("page-content-protected");

    public IActionResult JobDetails() => View("job-details");

    public IActionResult JobDetails2() => View("job-details-2");

    public IActionResult JobsGrid() => View("jobs-grid");

    public IActionResult JobsList() => View("jobs-list");

    public IActionResult NotFoundPage() => View("page-404");

    public IActionResult Pricing() => View("page-pricing");

    public IActionResult Register() => View("page-register");

    public IActionResult ResetPassword() => View("page-reset-password");

    public IActionResult SignIn() => View("page-signin");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
