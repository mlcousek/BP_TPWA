using BP_TPWA.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BP_TPWA.Controllers
{
    public class BSHVMController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BSHVMController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Nohy()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHVMNohy")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            ViewBag.BSHVM = cviky;
            ViewBag.BSHVMdata = datacviku;

            //var viewName = "Ramena_biceps"; // Název pohledu, který chcete renderovat do PDF
            //var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName);
            //pdf.FileName = "Ramena_biceps.pdf";
            //return pdf;

            return View();
        }

        public IActionResult Hrudník_triceps()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHVMHrTric")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
            .Where(id => id.UzivatelId == userId)
            .ToList();

            ViewBag.BSHVM = cviky;
            ViewBag.BSHVMdata = datacviku;

            //var viewName = "Hrudník_triceps"; // Název pohledu, který chcete renderovat do PDF
            //var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName);
            //pdf.FileName = "Hrudník_triceps.pdf";
            //return pdf;

            return View();
        }

        public IActionResult Ramena_biceps()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHVMRamBic")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            ViewBag.BSHVM = cviky;
            ViewBag.BSHVMdata = datacviku;
            return View();
        }

        public IActionResult Záda()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHVMZada")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();
            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            ViewBag.BSHVM = cviky;
            ViewBag.BSHVMdata = datacviku;
            return View();
        }
    }
}

