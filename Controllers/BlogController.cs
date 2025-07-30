using Microsoft.AspNetCore.Mvc;

namespace JobPortal1.Controllers
{
    public class BlogController : Controller
    {
        // blog-details.cshtml için
        public IActionResult Details()
        {
            return View("blog-details");
        }
        public IActionResult BlogGrid()
        {
            return View("blog-grid");
        }
        public IActionResult BlogGrid2()
        {
            return View("blog-grid-2");
        }


    }
}
