using BP_TPWA.Data;
using BP_TPWA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BP_TPWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uzivatel =  _context.Users
                               .Where(dt => dt.Id == userId)
                               .ToList();

            // var tpInfo = _context.TP.ToList();
            ViewBag.Uzivatel = uzivatel;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/StatusCodeError/{statusCode}")]
        public IActionResult Errors(int statusCode)
        {
            if(statusCode == 404) 
            {
                ViewBag.ErrorMessage = "404 Strátka nebyla nalezena";
            }

            return View();
        }
    }
}
