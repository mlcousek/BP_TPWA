using BP_TPWA.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BP_TPWA.Controllers
{
    public class BSHKRController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BSHKRController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Kruhový_trénink_1()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHKR1")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        public IActionResult Kruhový_trénink_2()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHKR2")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
            .Where(id => id.UzivatelId == userId)
            .ToList();

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        public IActionResult Kruhový_trénink_3()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHKR3")
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;
            return View();
        }

        public IActionResult Kruhový_trénink_4()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHKR4")
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
