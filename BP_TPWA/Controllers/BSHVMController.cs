using BP_TPWA.Data;
using Microsoft.AspNetCore.Mvc;

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
            var cviky = _context.Cvik
                        .Where(tt => tt.TypTreninku == "BSHVMNohy")
                        .ToList();
            ViewBag.BSHVM = cviky;
            return View();
        }

        public IActionResult Hrudník_triceps()
        {
            return View();
        }

        public IActionResult Ramena_biceps()
        {
            return View();
        }

        public IActionResult Záda()
        {
            return View();
        }
    }
}

