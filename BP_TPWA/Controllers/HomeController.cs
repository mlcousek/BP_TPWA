using BP_TPWA.Data;
using BP_TPWA.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
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

        //public IActionResult Privacy()
        //{
        //    var viewName = "Privacy"; // N�zev pohledu, kter� chcete renderovat do PDF
        //    var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName);
        //    pdf.FileName = "Privacy.pdf";
        //    return pdf;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
