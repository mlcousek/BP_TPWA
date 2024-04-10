using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Data;
using System.Security.Claims;
using BP_TPWA.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
//using Rotativa;
using Rotativa.AspNetCore;
using System.Threading.Tasks;
using Rotativa;
//using System.Web.Mvc;


namespace BP_TPWA.Controllers
{
    public class TPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TPController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        //public void SetDenTréninku(string userId, DayOfWeek den, bool trénink)
        //{
        //    var tpRecord = _context.TP.FirstOrDefault(t => t.UzivatelID == userId);

        //    if (tpRecord != null)
        //    {
        //        var konkrétníDen = tpRecord.DnyVTydnu.FirstOrDefault(d => d.Den == den);
        //        if (konkrétníDen != null)
        //        {
        //            konkrétníDen.DenTréninku = trénink;
        //            _context.SaveChanges(); // Uložení změn do databáze
        //        }
        //        else
        //        {
        //            // Případ, kdy den není nalezen
        //            throw new Exception("Chyba, špatný den!");
        //        }
        //    }
        //}

        public class GeneratorTréninkovýchDat
        {
            public static List<DateTime> VytvářeníDatumůTréninku(int tréninkyZaTýden, int týdny, DayOfWeek[] dnyTréninku)
            {
                if (dnyTréninku.Length == 0 || tréninkyZaTýden <= 0 || týdny <= 0)
                {
                    throw new ArgumentException("Invalid input parameters");
                }

                List<DateTime> dataTréninků = new List<DateTime>();

                DateTime startovacíDatum = DateTime.Now.Date; // Zde nastavte počáteční datum podle potřeby
                DayOfWeek dnes = startovacíDatum.DayOfWeek;
                int dnyDoPondeli = (7 + (int)DayOfWeek.Monday - (int)dnes) % 7;
                startovacíDatum = startovacíDatum.AddDays(dnyDoPondeli);

                for (int týden = 0; týden < týdny; týden++)
                {
                    foreach (var denTréninku in dnyTréninku)
                    {
                        if((int)denTréninku == 0)
                        {
                            DateTime datumTréninku = startovacíDatum.AddDays((týden * 7) + (int)denTréninku + 6);
                            dataTréninků.Add(datumTréninku);
                        }
                        else
                        {

                            DateTime datumTréninku = startovacíDatum.AddDays((týden * 7) + (int)denTréninku -1);
                            dataTréninků.Add(datumTréninku);
                        }
                    }
                }

                return dataTréninků;
            }
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


        private string GetTypTreninkuVM(int cislodne)
        {
            // Implementujte logiku pro získání typu tréninku podle dne
            // Můžete například mít nějakou metodu nebo seznam, kde mapujete den na konkrétní typ tréninku
            // A vrátit odpovídající hodnotu pro daný den
            // Tato metoda by měla být upravena podle vaší konkrétní implementace
            if(cislodne == 0)
            {

                return "Hrudník + triceps";
            } 
            else if (cislodne == 1)
            {
                return "Nohy";
            }
            else if (cislodne == 2)
            {
                return "Ramena + biceps";
            }
            else if (cislodne == 3)
            {
                return "Záda";
            }

            return "Chyba";
        }
        private string GetTypTreninkuPPL(int cislodne)
        {
            // Implementujte logiku pro získání typu tréninku podle dne
            // Můžete například mít nějakou metodu nebo seznam, kde mapujete den na konkrétní typ tréninku
            // A vrátit odpovídající hodnotu pro daný den
            // Tato metoda by měla být upravena podle vaší konkrétní implementace
            if (cislodne == 0)
            {

                return "Push";
            }
            else if (cislodne == 1)
            {
                return "Pull";
            }
            else if (cislodne == 2)
            {
                return "Legs";
            }

            return "Chyba";
        }

        private string GetTypTreninkuKR(int cislodne)
        {
            // Implementujte logiku pro získání typu tréninku podle dne
            // Můžete například mít nějakou metodu nebo seznam, kde mapujete den na konkrétní typ tréninku
            // A vrátit odpovídající hodnotu pro daný den
            // Tato metoda by měla být upravena podle vaší konkrétní implementace
            if (cislodne == 0)
            {

                return "Kruhový trénink 1";
            }
            else if (cislodne == 1)
            {
                return "Kruhový trénink 2";
            }
            else if (cislodne == 2)
            {
                return "Kruhový trénink 3";
            }
            else if (cislodne == 3)
            {
                return "Kruhový trénink 4";
            }

            return "Chyba";
        }


        // GET: TP
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TP.Include(t => t.User);
            var tpRecords = await applicationDbContext.ToListAsync();


            // Získání ID aktuálně přihlášeného uživatele
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



            // Dotaz do databáze pro nalezení záznamů podle UživatelId
            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);
            
            if(uzivatelIdZaznam != null)
            {
                DateTime tedka = DateTime.Now;
                DateTime datumPoslednihoUlozeni = uzivatelIdZaznam.DatumPoslednihoUlozeniVahy;
                TimeSpan rozdil = tedka - datumPoslednihoUlozeni;

                if (rozdil.TotalDays >= 1)              /////NASTAVENI JAK CASTO BUDE KONTROLA VAHY, DAM CO DEN KVULI TESTOVANI
                {
                    uzivatelIdZaznam.AktualniVaha = false;
                    await _context.SaveChangesAsync();
                }

                foreach (var tpRecord in tpRecords)
                {
                    // Zde můžete pracovat s každým záznamem TP a přistupovat k jeho vlastnostem, včetně User.
                    var ZkontrolovaneDny = tpRecord.ZkontrolovaneDny;
                    if (ZkontrolovaneDny == false)
                    {
                        var denVTydnuRecords = await _context.TP
                                .Where(tp => tp.Id == uzivatelIdZaznam.Id)
                                .SelectMany(tp => tp.DnyVTydnu)
                                .ToListAsync();
                        var i = 1;
                        foreach (var denVTydnuRecord in denVTydnuRecords)
                        {
                            // Přistupujte k vlastnostem záznamu DenVTydnu podle potřeby.
                            denVTydnuRecord.Den = (DayOfWeek)i;

                            //var DenTreninkuVal = denVTydnuRecord.DenTréninku;
                            //var usrId = tpRecord.User.Id;
                            //SetDenTréninku(usrId, (DayOfWeek)i, DenTreninkuVal);
                            i++;
                            if (i == 7)
                            {
                                i = 0;
                            }
                        }
                        tpRecord.ZkontrolovaneDny = true;
                    }
                
                    await _context.SaveChangesAsync();
                }
            }

            if(uzivatelIdZaznam != null)
            {
                var denVTydnuRecords = await _context.TP
                            .Where(tp => tp.Id == uzivatelIdZaznam.Id)
                            .SelectMany(tp => tp.DnyVTydnu)
                            .ToListAsync();
                //  var denVTydnuRecords = await _context.DenVTydnu.ToListAsync();
                DayOfWeek[] dnyTréninku = new DayOfWeek[uzivatelIdZaznam.PocetTreninkuZaTyden];
                int i = 0;
                foreach (var denVTydnuRecord in denVTydnuRecords)
                {
                    if(denVTydnuRecord.DenTréninku == true)
                    {
                        dnyTréninku[i] = denVTydnuRecord.Den; 
                        i++;
                    }
                }

                

                List<DateTime> dataTréninkovýchDnů = GeneratorTréninkovýchDat.VytvářeníDatumůTréninku(uzivatelIdZaznam.PocetTreninkuZaTyden, uzivatelIdZaznam.Délka * 4, dnyTréninku);
                //Model.DataTreninkovychDnu = dataTréninkovýchDnů;
                var typTreninku = "";
                var typTreninkuZkratka = "";

                var typTreninkuCislo = 0;
                if (uzivatelIdZaznam.UlozenaDataDnu == false)
                {
                    try
                    {
                        foreach (var datumTreninkovehoDne in dataTréninkovýchDnů)
                        {
                            if(uzivatelIdZaznam.StylTP == "VM")
                            {
                                if(typTreninkuCislo == 4)
                                {
                                    typTreninkuCislo = 0;
                                }

                                typTreninku = GetTypTreninkuVM(typTreninkuCislo);
                                typTreninkuZkratka = GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);



                                var cviky =  _context.Cvik
                                            .Where(c => c.UzivatelId == userId)
                                            .AsEnumerable()
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka))
                                            .ToList();

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = cviky }; //musím si někam uložit ty hodnoty někde tu to vytáhnout a davat jednu po druhe
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;

                            } else if (uzivatelIdZaznam.StylTP == "PPL")
                            {
                                if (typTreninkuCislo == 3)
                                {
                                    typTreninkuCislo = 0;
                                }

                                typTreninku = GetTypTreninkuPPL(typTreninkuCislo);
                                typTreninkuZkratka = GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);



                                var cviky = await _context.Cvik
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka))
                                            .Where(c => c.UzivatelId == userId)
                                            .ToListAsync();

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = cviky }; //musím si někam uložit ty hodnoty někde tu to vytáhnout a davat jednu po druhe
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;

                            }
                            else if (uzivatelIdZaznam.StylTP == "KR")
                            {
                                if (typTreninkuCislo == 4)
                                {
                                    typTreninkuCislo = 0;
                                }
                                typTreninku = GetTypTreninkuKR(typTreninkuCislo);
                                typTreninkuZkratka = GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);



                                var cviky = await _context.Cvik
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka))
                                            .Where(c => c.UzivatelId == userId)
                                            .ToListAsync();

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = cviky }; //musím si někam uložit ty hodnoty někde tu to vytáhnout a davat jednu po druhe
                                _context.DenTreninku.Add(treninkoveDataEntita);
                            }
                            // Vytvořte nový záznam v databázi pro každé datum tréninku
                        }

                        // Uložte změny do databáze
                        await _context.SaveChangesAsync();
                        uzivatelIdZaznam.UlozenaDataDnu = true;
                        await _context.SaveChangesAsync();

                        Ok("Data úspěšně uložena.");

                    }
                    catch (Exception ex)
                    {
                         BadRequest($"Chyba při ukládání dat: {ex.Message}");
                    }
                }
                //mám data tréninkových dnů v listu a teď si budu chctí ten list někam uložit do databáze a vytvořit z něj ty eventy
                //var treninkoveData = _context.DenTreninku.ToList();
                var treninkoveData = await _context.DenTreninku
                                .Where(dt => dt.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();

                var tpInfo = await _context.TP
                                .Where(dt => dt.Id == uzivatelIdZaznam.Id)
                                .ToListAsync();
                ViewBag.DenTreninku = treninkoveData;
                ViewBag.TP = tpInfo;
            }
                var uzivatel = await _context.Users
                                .Where(dt => dt.Id == userId)
                                .ToListAsync();

                // var tpInfo = _context.TP.ToList();
                ViewBag.Uzivatel = uzivatel;

            return View(await applicationDbContext.ToListAsync());
        }

       

        // GET: TP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tP = await _context.TP
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tP == null)
            {
                return NotFound();
            }

            return View(tP);
        }

        // GET: TP/Create
        public IActionResult Create()
        {
            ViewData["UzivatelID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Délka,DruhTP,StylTP,PocetTreninkuZaTyden,DnyVTydnu,UzivatelID,ZkontorlovaneDny,UlozenaDataDnu,AktualniVaha,DatumPoslednihoUlozeniVahy")] TP tP)
        {
            if (ModelState.ContainsKey("User"))
            {
                ModelState.Remove("User");
            }


            if (ModelState.IsValid)
            {

                _context.Add(tP);
                await _context.SaveChangesAsync();

                // Aktualizace záznamu v tabulce AspNetUsers
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Získání ID aktuálně přihlášeného uživatele
                var currentUser = await _context.Users.FindAsync(userId); // Načtení aktuálního uživatele z databáze
                currentUser.TPId = tP.Id; // Předpokládá se, že máte v modelu AspNetUsers vlastnost TPId

                tP.User = currentUser;
                tP.AktualniVaha = true;
                
                tP.DatumPoslednihoUlozeniVahy = DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UzivatelID"] = new SelectList(_context.Users, "Id", "Id", tP.UzivatelID);
            return View(tP);
        }

        // GET: TP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tP = await _context.TP.FindAsync(id);
            if (tP == null)
            {
                return NotFound();
            }
            ViewData["UzivatelID"] = new SelectList(_context.Users, "Id", "Id", tP.UzivatelID);
            return View(tP);
        }

        // POST: TP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Délka,DruhTP,StylTP,PocetTreninkuZaTyden,DnyVTydnu,UzivatelID")] TP tP)
        {
            if (id != tP.Id)
            {
                return NotFound();
            }
            if (ModelState.ContainsKey("User"))
            {
                ModelState.Remove("User");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPExists(tP.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UzivatelID"] = new SelectList(_context.Users, "Id", "Id", tP.UzivatelID);
            return View(tP);
        }

        // GET: TP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tP = await _context.TP
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tP == null)
            {
                return NotFound();
            }

            return View(tP);
        }

        // POST: TP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tP = await _context.TP.FindAsync(id);
            if (tP != null)
            {
                _context.TP.Remove(tP);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPExists(int id)
        {
            return _context.TP.Any(e => e.Id == id);
        }
        
        [HttpPost]
        public async Task<IActionResult> AktualizaceVahy(VahaZFrontendu vaha)
        {
            if (vaha != null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var uzivatelIdZaznam = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
                double cislo;

                if (double.TryParse(vaha.Váha, NumberStyles.Number, CultureInfo.InvariantCulture, out cislo))
                {
                    uzivatelIdZaznam.Váha = cislo;

                    var uzivatelTP = await _context.TP.SingleOrDefaultAsync(u => u.UzivatelID == userId);
                    if (uzivatelTP != null)
                    {
                        uzivatelTP.AktualniVaha = true;
                        uzivatelTP.DatumPoslednihoUlozeniVahy = DateTime.Now;
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Něco provedete, když se nepodaří převést řetězec na double
                    return BadRequest("Nepodařilo se převést váhu na desetinné číslo.");
                }

            }

            return View(vaha);
        }

        public IActionResult OfflineNahled()
        {
            return View();
        }

        public async Task<IActionResult> NahledPlanu()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)  
                                .ToListAsync();
            var cviky = await _context.Cvik
                                .Where(d => d.UzivatelId == userId)
                                .ToListAsync();

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                Cviky = cviky,
            };

            var viewName = "NahledPlanu";
            var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName, model);
            pdf.FileName = "Nahled planu.pdf";

            return pdf;
        }

        public async Task<IActionResult> NahledPlanuDny()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();
            var cviky = await _context.Cvik
                                .Where(d => d.UzivatelId == userId)
                                .ToListAsync();

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                Cviky = cviky,
            };

            var viewName = "NahledPlanuDny";
            var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName, model);
            pdf.FileName = "Nahled planu dny.pdf";

            return pdf;
        }

        public async Task<IActionResult> NahledPlanuTreninky()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();
            var cviky = await _context.Cvik
                                .Where(d => d.UzivatelId == userId)
                                .ToListAsync();

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                Cviky = cviky,
            };

            var viewName = "NahledPlanuTreninky";
            var pdf = new Rotativa.AspNetCore.ViewAsPdf(viewName, model);
            pdf.FileName = "Nahled planu treninky.pdf";

            return pdf;
        }


    }
}
