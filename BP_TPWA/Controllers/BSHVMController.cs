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

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

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

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

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

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;
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

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;
            return View();
        }
    }
}

