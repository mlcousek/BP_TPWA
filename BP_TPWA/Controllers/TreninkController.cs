using BP_TPWA.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using BP_TPWA.Models;


namespace BP_TPWA.Controllers
{
    public class TreninkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TreninkController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Trenink()
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
            ViewBag.typTreninku = denTreninku[0].TypTreninku;
            ViewBag.cviky = cviky;
            ViewBag.datacviku = datacviku;

            return View();
        }

        //public IActionResult Nohy()
        //{
        //    var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

        //    // Extrahování posledních 10 znaků z URL
        //    var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var cviky = _context.Cvik
        //    //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
        //    //            .Where(id => id.UzivatelId == userId)
        //    //            .ToList();

        //    var uzivatel = _context.Users
        //                   .Where(id => id.Id == userId)
        //                   .ToList();

        //    // Přesné načtení data ze zadaného řetězce s určeným formátem
        //    DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

        //    var denTreninku = _context.DenTreninku
        //                      .Where(x => x.TPId == uzivatel[0].TPId)
        //                      .Where(d => d.DatumTreninku == inputDate)
        //                      .ToList();

        //    var cviky = denTreninku[0].Cviky;

        //    var datacviku = _context.TreninkoveData
        //                .Where(id => id.UzivatelId == userId)
        //                .ToList();

        //    var TPUzivatele = _context.TP
        //                      .Where(x => x.UzivatelID == userId)
        //                       .ToList();

        //    var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

        //    ViewBag.typTreninkuZkratka = typTreninkuZkratka;
        //    ViewBag.typTreninku = denTreninku[0].TypTreninku;
        //    ViewBag.cviky = cviky;
        //    ViewBag.datacviku = datacviku;

        //    return View();
        //}

        //public IActionResult Hrudník_triceps()
        //{
        //    var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

        //    // Extrahování posledních 10 znaků z URL
        //    var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var cviky = _context.Cvik
        //    //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
        //    //            .Where(id => id.UzivatelId == userId)
        //    //            .ToList();

        //    var uzivatel = _context.Users
        //                   .Where(id => id.Id == userId)
        //                   .ToList();

        //    // Přesné načtení data ze zadaného řetězce s určeným formátem
        //    DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

        //    var denTreninku = _context.DenTreninku
        //                      .Where(x => x.TPId == uzivatel[0].TPId)
        //                      .Where(d => d.DatumTreninku == inputDate)
        //                      .ToList();

        //    var cviky = denTreninku[0].Cviky;

        //    var datacviku = _context.TreninkoveData
        //                .Where(id => id.UzivatelId == userId)
        //                .ToList();

        //    var TPUzivatele = _context.TP
        //                      .Where(x => x.UzivatelID == userId)
        //                       .ToList();

        //    var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

        //    ViewBag.typTreninkuZkratka = typTreninkuZkratka;
        //    ViewBag.cviky = cviky;
        //    ViewBag.datacviku = datacviku;

        //    return View();
        //}

        //public IActionResult Ramena_biceps()
        //{
        //    var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

        //    // Extrahování posledních 10 znaků z URL
        //    var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var cviky = _context.Cvik
        //    //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
        //    //            .Where(id => id.UzivatelId == userId)
        //    //            .ToList();

        //    var uzivatel = _context.Users
        //                   .Where(id => id.Id == userId)
        //                   .ToList();

        //    // Přesné načtení data ze zadaného řetězce s určeným formátem
        //    DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

        //    var denTreninku = _context.DenTreninku
        //                      .Where(x => x.TPId == uzivatel[0].TPId)
        //                      .Where(d => d.DatumTreninku == inputDate)
        //                      .ToList();

        //    var cviky = denTreninku[0].Cviky;

        //    var datacviku = _context.TreninkoveData
        //                .Where(id => id.UzivatelId == userId)
        //                .ToList();

        //    var TPUzivatele = _context.TP
        //                      .Where(x => x.UzivatelID == userId)
        //                       .ToList();

        //    var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

        //    ViewBag.typTreninkuZkratka = typTreninkuZkratka;
        //    ViewBag.cviky = cviky;
        //    ViewBag.datacviku = datacviku;

        //    return View();
        //}

        //public IActionResult Záda()
        //{
        //    var requestUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();

        //    // Extrahování posledních 10 znaků z URL
        //    var last10Characters = requestUrl.Substring(Math.Max(0, requestUrl.Length - 10));

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    //var cviky = _context.Cvik
        //    //            .Where(tt => tt.TypTreninku == "BSHVMNohy")
        //    //            .Where(id => id.UzivatelId == userId)
        //    //            .ToList();

        //    var uzivatel = _context.Users
        //                   .Where(id => id.Id == userId)
        //                   .ToList();

        //    // Přesné načtení data ze zadaného řetězce s určeným formátem
        //    DateTime inputDate = DateTime.ParseExact(last10Characters, "yyyy-MM-dd", null);

        //    var denTreninku = _context.DenTreninku
        //                      .Where(x => x.TPId == uzivatel[0].TPId)
        //                      .Where(d => d.DatumTreninku == inputDate)
        //                      .ToList();

        //    var cviky = denTreninku[0].Cviky;

        //    var datacviku = _context.TreninkoveData
        //                .Where(id => id.UzivatelId == userId)
        //                .ToList();

        //    var TPUzivatele = _context.TP
        //                      .Where(x => x.UzivatelID == userId)
        //                       .ToList();

        //    var typTreninkuZkratka = GetTypTreninkuZkratka(TPUzivatele[0], denTreninku[0].TypTreninku);

        //    ViewBag.typTreninkuZkratka = typTreninkuZkratka;
        //    ViewBag.cviky = cviky;
        //    ViewBag.datacviku = datacviku;

        //    return View();
        //}
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
                    if (typTreninku == "Push")
                    {
                        return "BSHPPLPush";
                    }
                    else if (typTreninku == "Pull")
                    {
                        return "BSHPPLPull";
                    }
                    else if (typTreninku == "Legs")
                    {
                        return "BSHPPLLegs";
                    }
                }
                else if (TP.StylTP == "KR")
                {
                    if (typTreninku == "Kruhový trénink 1")
                    {
                        return "BSHKR1";
                    }
                    else if (typTreninku == "Kruhový trénink 2")
                    {
                        return "BSHKR2";
                    }
                    else if (typTreninku == "Kruhový trénink 3")
                    {
                        return "BSHKR3";
                    }
                }
            }
            else if (TP.DruhTP == "SR")
            {
                if (TP.StylTP == "VM")
                {
                    if (typTreninku == "Nohy")
                    {
                        return "SRVMNohy";
                    }
                    else if (typTreninku == "Ramena + biceps")
                    {
                        return "SRVMRamBic";
                    }
                    else if (typTreninku == "Záda")
                    {
                        return "SRVMZada";
                    }
                    else if (typTreninku == "Hrudník + triceps")
                    {
                        return "SRVMHrTric";
                    }
                }
                else if (TP.StylTP == "PPL")
                {
                    if (typTreninku == "Push")
                    {
                        return "SRPPLPush";
                    }
                    else if (typTreninku == "Pull")
                    {
                        return "SRPPLPull";
                    }
                    else if (typTreninku == "Legs")
                    {
                        return "SRPPLLegs";
                    }
                }
                else if (TP.StylTP == "KR")
                {
                    if (typTreninku == "Kruhový trénink 1")
                    {
                        return "SRKR1";
                    }
                    else if (typTreninku == "Kruhový trénink 2")
                    {
                        return "SRKR2";
                    }
                    else if (typTreninku == "Kruhový trénink 3")
                    {
                        return "SRKR3";
                    }
                }
            }
            else if (TP.DruhTP == "RV")
            {
                if (TP.StylTP == "VM")
                {
                    if (typTreninku == "Nohy")
                    {
                        return "RVVMNohy";
                    }
                    else if (typTreninku == "Ramena + biceps")
                    {
                        return "RVVMRamBic";
                    }
                    else if (typTreninku == "Záda")
                    {
                        return "RVVMZada";
                    }
                    else if (typTreninku == "Hrudník + triceps")
                    {
                        return "RVVMHrTric";
                    }
                }
                else if (TP.StylTP == "PPL")
                {
                    if (typTreninku == "Push")
                    {
                        return "RVPPLPush";
                    }
                    else if (typTreninku == "Pull")
                    {
                        return "RVPPLPull";
                    }
                    else if (typTreninku == "Legs")
                    {
                        return "RVPPLLegs";
                    }
                }
                else if (TP.StylTP == "KR")
                {
                    if (typTreninku == "Kruhový trénink 1")
                    {
                        return "RVKR1";
                    }
                    else if (typTreninku == "Kruhový trénink 2")
                    {
                        return "RVKR2";
                    }
                    else if (typTreninku == "Kruhový trénink 3")
                    {
                        return "RVKR3";
                    }
                }
            }
            return "CHYBA";
        }
    }
}


