using BP_TPWA.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using BP_TPWA.Models;

namespace BP_TPWA.Controllers
{
    public class BSHVMController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BSHVMController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Nohy()
        {
            var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

            // Extrahování posledních 10 znaků z URL
            var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cviky = _context.Cvik
            //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
            //            .Where(id => id.UzivatelId == userId)
            //            .ToList();

            var uzivatel = _context.Users
                           .Where(id => id.Id == userId)
                           .ToList();

            // Přesné načtení data ze zadaného řetězce s určeným formátem
            DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

            var denTreninku = _context.DenTreninku
                              .Where(x => x.TPId == uzivatel[0].TPId)
                              .Where(d => d.DatumTreninku == inputDate)
                              .ToList();

            var cviky = denTreninku[0].Cviky;

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var TPUzivatele = _context.TP
                              .Where(x => x.UzivatelID == userId)
                               .ToList();

            var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

            ViewBag.typTreninkuZkratka = typTreninkuZkratka;
            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        public IActionResult Hrudník_triceps()
        {
            var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

            // Extrahování posledních 10 znaků z URL
            var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cviky = _context.Cvik
            //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
            //            .Where(id => id.UzivatelId == userId)
            //            .ToList();

            var uzivatel = _context.Users
                           .Where(id => id.Id == userId)
                           .ToList();

            // Přesné načtení data ze zadaného řetězce s určeným formátem
            DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

            var denTreninku = _context.DenTreninku
                              .Where(x => x.TPId == uzivatel[0].TPId)
                              .Where(d => d.DatumTreninku == inputDate)
                              .ToList();

            var cviky = denTreninku[0].Cviky;

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var TPUzivatele = _context.TP
                              .Where(x => x.UzivatelID == userId)
                               .ToList();

            var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

            ViewBag.typTreninkuZkratka = typTreninkuZkratka;
            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        public IActionResult Ramena_biceps()
        {
            var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

            // Extrahování posledních 10 znaků z URL
            var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cviky = _context.Cvik
            //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
            //            .Where(id => id.UzivatelId == userId)
            //            .ToList();

            var uzivatel = _context.Users
                           .Where(id => id.Id == userId)
                           .ToList();

            // Přesné načtení data ze zadaného řetězce s určeným formátem
            DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

            var denTreninku = _context.DenTreninku
                              .Where(x => x.TPId == uzivatel[0].TPId)
                              .Where(d => d.DatumTreninku == inputDate)
                              .ToList();

            var cviky = denTreninku[0].Cviky;

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var TPUzivatele = _context.TP
                              .Where(x => x.UzivatelID == userId)
                               .ToList();

            var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

            ViewBag.typTreninkuZkratka = typTreninkuZkratka;
            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        public IActionResult Záda()
        {
            var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

            // Extrahování posledních 10 znaků z URL
            var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cviky = _context.Cvik
            //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
            //            .Where(id => id.UzivatelId == userId)
            //            .ToList();

            var uzivatel = _context.Users
                           .Where(id => id.Id == userId)
                           .ToList();

            // Přesné načtení data ze zadaného řetězce s určeným formátem
            DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

            var denTreninku = _context.DenTreninku
                              .Where(x => x.TPId == uzivatel[0].TPId)
                              .Where(d => d.DatumTreninku == inputDate)
                              .ToList();

            var cviky = denTreninku[0].Cviky;

            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();

            var TPUzivatele = _context.TP
                              .Where(x => x.UzivatelID == userId)
                               .ToList();

            var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

            ViewBag.typTreninkuZkratka = typTreninkuZkratka;
            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }
        private string GetTypTreninkuZkratka(TP TP, string typTreninku)
        {
            if (TP.DruhTP == "BSH")
            {
                if (TP.StylTP == "VM")
                {
                    if (typTreninku == "Nohy")
                    {
                        return "BSHVMNohy";
                    }
                    else if (typTreninku == "Ramena + biceps")
                    {
                        return "BSHVMRamBic";
                    }
                    else if (typTreninku == "Záda")
                    {
                        return "BSHVMZada";
                    }
                    else if (typTreninku == "Hrudník + triceps")
                    {
                        return "BSHVMHrTric";
                    }

                }
                else if (TP.StylTP == "PPL")
                {
                    return "Zatimnic";
                }
                else if (TP.StylTP == "KR")
                {
                    return "Zatimnic";
                }
            }
            else if (TP.DruhTP == "SR")
            {
                return "Zatimnic";
            }
            else if (TP.DruhTP == "RV")
            {
                return "Zatimnic";
            }
            return "CHYBA";
        }
    }
}

