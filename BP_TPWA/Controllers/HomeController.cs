using BP_TPWA.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using System.Diagnostics;

namespace BP_TPWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();

        }

        //public IActionResult Privacy()
        //{
        //    var viewName = "Privacy"; // Název pohledu, který chcete renderovat do PDF
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
