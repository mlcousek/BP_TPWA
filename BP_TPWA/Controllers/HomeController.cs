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

        //public async Task<IActionResult> ZmenitVek(DataZFrontendu data)
        //{
        //    if (data != null)
        //    {
        //        DateTime datum;
        //        if (DateTime.TryParse(data.Datum, out datum))
        //        {
        //            DateTime novyDatum = new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 0);
        //            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //            var uzivatel = _context.Users
        //                           .Where(dt => dt.Id == userId)
        //                           .ToList();

        //            uzivatel[0].Vìk = uzivatel[0].Vìk + 1;
        //            uzivatel[0].PomocneDatum = novyDatum;

        //            await _context.SaveChangesAsync();

        //            return RedirectToAction("Index", "Home");
        //        }

        //    }

        //    return View(data);
        //}

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
