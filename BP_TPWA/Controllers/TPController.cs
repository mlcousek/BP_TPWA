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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace BP_TPWA.Controllers
{
    [Authorize]
    public class TPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TPController(ApplicationDbContext context)
        {
            _context = context;
        }

        public class GeneratorTréninkovýchDat
        {
            public static List<DateTime> VytvářeníDatumůTréninku(int tréninkyZaTýden, int týdny, DayOfWeek[] dnyTréninku)
            {
                if (dnyTréninku.Length == 0 || tréninkyZaTýden <= 0 || týdny <= 0)
                {
                    throw new ArgumentException("Invalid input parameters");
                }

                List<DateTime> dataTréninků = new List<DateTime>();

                DateTime startovacíDatum = DateTime.Now.Date; 
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

        public static class TypTreninkuHelper
        {
            public static string GetTypTreninkuZkratka(TP TP, string typTreninku)
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

        private string GetTypTreninkuVM(int cislodne)
        {
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
            
            return "Chyba";
        }


        // GET: TP
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TP.Include(t => t.User);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uzivatel = _context.Users.Where(t => t.Id == userId).ToList();
            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.Id == uzivatel[0].TPId);

            var jakCastoDny = 0;
            foreach (var user in uzivatel)
            {
                jakCastoDny = user.JakCastoAktualizovatVahu;

            }

            if (uzivatelIdZaznam != null)
            {
                DateTime tedka = DateTime.Now;
                DateTime datumPoslednihoUlozeni = uzivatelIdZaznam.DatumPoslednihoUlozeniVahy;
                TimeSpan rozdil = tedka - datumPoslednihoUlozeni;

                if (rozdil.TotalDays >= jakCastoDny)              /////NASTAVENI JAK CASTO BUDE KONTROLA VAHY, DAM CO DEN KVULI TESTOVANI
                {
                    uzivatelIdZaznam.AktualniVaha = false;
                    await _context.SaveChangesAsync();
                }

                var ZkontrolovaneDny = uzivatelIdZaznam.ZkontrolovaneDny;
                if (ZkontrolovaneDny == false)
                {
                    var denVTydnuRecords = await _context.TP
                            .Where(tp => tp.Id == uzivatelIdZaznam.Id)
                            .SelectMany(tp => tp.DnyVTydnu)
                            .ToListAsync();
                    var i = 1;
                    foreach (var denVTydnuRecord in denVTydnuRecords)
                    {
                        denVTydnuRecord.Den = (DayOfWeek)i;

                        i++;
                        if (i == 7)
                        {
                            i = 0;
                        }
                    }
                        uzivatelIdZaznam.ZkontrolovaneDny = true;
                }
                
                await _context.SaveChangesAsync();
            }

            if(uzivatelIdZaznam != null)
            {
                var denVTydnuRecords = await _context.TP
                            .Where(tp => tp.Id == uzivatelIdZaznam.Id)
                            .SelectMany(tp => tp.DnyVTydnu)
                            .ToListAsync();
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
                                typTreninkuZkratka = TypTreninkuHelper.GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);


                                var poradiCviku = GetPoradiCviku(typTreninkuZkratka);
                                string[] poradiCvikuArray = poradiCviku.Split(',');


                                var cviky = _context.Cvik
                                            .Where(c => c.UzivatelId == userId)
                                            .AsEnumerable()
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka))
                                            .ToList();

                                List<Cvik> noveCviky = new List<Cvik>();
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    noveCviky.Add(cviky[j]);
                                }
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Název);
                                    noveCviky.RemoveAt(index);
                                    noveCviky.Insert(index, cviky[j]);
                                }

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = noveCviky };
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;

                            } else if (uzivatelIdZaznam.StylTP == "PPL")
                            {
                                if (typTreninkuCislo == 3)
                                {
                                    typTreninkuCislo = 0;
                                }

                                typTreninku = GetTypTreninkuPPL(typTreninkuCislo);
                                typTreninkuZkratka = TypTreninkuHelper.GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);


                                var poradiCviku = GetPoradiCviku(typTreninkuZkratka);
                                string[] poradiCvikuArray = poradiCviku.Split(',');


                                var cviky = _context.Cvik
                                            .Where(c => c.UzivatelId == userId) 
                                            .AsEnumerable() 
                                            .Where(c => c.TypyTreninku != null) 
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka)) 
                                            .ToList(); 

                                List<Cvik> noveCviky = new List<Cvik>();
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    noveCviky.Add(cviky[j]);
                                }
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Název);
                                    noveCviky.RemoveAt(index);
                                    noveCviky.Insert(index, cviky[j]);
                                }

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = noveCviky };
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;

                            }
                            else if (uzivatelIdZaznam.StylTP == "KR")
                            {
                                if (typTreninkuCislo == 3)
                                {
                                    typTreninkuCislo = 0;
                                }
                                typTreninku = GetTypTreninkuKR(typTreninkuCislo);
                                typTreninkuZkratka = TypTreninkuHelper.GetTypTreninkuZkratka(uzivatelIdZaznam, typTreninku);

                                var poradiCviku = GetPoradiCviku(typTreninkuZkratka);
                                string[] poradiCvikuArray = poradiCviku.Split(',');


                                var cviky = _context.Cvik
                                            .Where(c => c.UzivatelId == userId)
                                            .AsEnumerable()
                                            .Where(c => c.TypyTreninku.Contains(typTreninkuZkratka))
                                            .ToList();

                                List<Cvik> noveCviky = new List<Cvik>();
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    noveCviky.Add(cviky[j]);
                                }
                                for (int j = 0; j < cviky.Count; j++)
                                {
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Název);
                                    noveCviky.RemoveAt(index);
                                    noveCviky.Insert(index, cviky[j]);
                                }

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = noveCviky };
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;
                            }
                        }

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
                var treninkoveData = await _context.DenTreninku
                                .Where(dt => dt.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();

                var tpInfo = await _context.TP
                                .Where(dt => dt.Id == uzivatelIdZaznam.Id)
                                .ToListAsync();
                ViewBag.DenTreninku = treninkoveData;
                ViewBag.TP = tpInfo;
            }
                var datacviku = _context.TreninkoveData
                            .Where(id => id.UzivatelId == userId)
                            .ToList();

            ViewBag.Uzivatel = uzivatel;
            ViewBag.Datacviku = datacviku;

            return View(await applicationDbContext.ToListAsync());
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
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
                var currentUser = await _context.Users.FindAsync(userId); 
                currentUser.TPId = tP.Id;
                if(currentUser.TreninkovePlany == null)
                {
                    currentUser.TreninkovePlany = new List<int>();
                }
                currentUser.TreninkovePlany.Add(tP.Id);

                tP.User = currentUser;
                tP.AktualniVaha = true;
                
                tP.DatumPoslednihoUlozeniVahy = DateTime.Now;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["UzivatelID"] = new SelectList(_context.Users, "Id", "Id", tP.UzivatelID);
            return View(tP);
        }

        // GET: TP/Delete/5
        public async Task<IActionResult> Delete1(int? id)
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
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var uzivatelIdZaznam = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

                uzivatelIdZaznam.TPId = null;
                await _context.SaveChangesAsync();
            }
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
                    return BadRequest("Nepodařilo se převést váhu na desetinné číslo.");
                }
            }

            return View(vaha);
        }

        [HttpPost]
        public async Task<IActionResult> AktualizaceUrovne()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uzivatelIdZaznam = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
               
            uzivatelIdZaznam.Úroveň = 2;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                TP = uzivatelIdZaznam,
            };

   

            return View(model);
        }

        public async Task<IActionResult> NahledPlanuDny()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                TP = uzivatelIdZaznam,
            };

            return View(model);
        }

        public async Task<IActionResult> NahledPlanuTreninky()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == userId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)
                                .ToListAsync();

            var model = new NahledPlanuModel
            {
                Treninky = treninky,
                TP = uzivatelIdZaznam,
            };

            return View(model);
        }

        private string GetPoradiCviku(string typTreninkuZkratka)
        {
            if (typTreninkuZkratka == "BSHKR1")
            {
                return "Dřepy,Legpress,Lýtka ve stoje,Předkopy,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            } 
            else if(typTreninkuZkratka == "BSHKR2")
            {
                return "Dřepy,Legpress,Rumunský mrtvý tah,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "BSHKR3")
            {
                return "Dřepy,Legpress,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "BSHVMNohy")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "BSHVMRamBic")
            {
                return "Tlaky na ramena - rozcvička,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Stroj na zadky ramen,Upažování na kladce,Tlaky na stroji,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }
            else if (typTreninkuZkratka == "BSHVMHrTric")
            {
                return "Kliky,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Dipy na bradle,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "BSHVMZada")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování na stroji,Přitahování tyče ve stoje,Sklapovačky,Přitahování noh na bradlech";
            }
            else if (typTreninkuZkratka == "BSHPPLLegs")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "BSHPPLPush")
            {
                return "Kliky,Benchpress,Tlaky na ramena s jednoručnou činkou,Tlaky na stroji,Tlaky na hrudník na nakloněné lavici,Stahování kladek na hrudník,Upažování s jednoručnou činkou,Stroj na zadky ramen,Dipy na bradle,Tricepsové stahování kladky";
            }
            else if (typTreninkuZkratka == "BSHPPLPull")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování tyče ve stoje,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }




            else if (typTreninkuZkratka == "RVKR1")
            {
                return "Dřepy,Legpress,Lýtka ve stoje,Předkopy,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "RVKR2")
            {
                return "Dřepy,Legpress,Rumunský mrtvý tah,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "RVKR3")
            {
                return "Dřepy,Legpress,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "RVVMNohy")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "RVVMRamBic")
            {
                return "Tlaky na ramena - rozcvička,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Stroj na zadky ramen,Upažování na kladce,Tlaky na stroji,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }
            else if (typTreninkuZkratka == "RVVMHrTric")
            {
                return "Kliky,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Dipy na bradle,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "RVVMZada")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování na stroji,Přitahování tyče ve stoje,Sklapovačky,Přitahování noh na bradlech";
            }
            else if (typTreninkuZkratka == "RVPPLLegs")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "RVPPLPush")
            {
                return "Kliky,Benchpress,Tlaky na ramena s jednoručnou činkou,Tlaky na stroji,Tlaky na hrudník na nakloněné lavici,Stahování kladek na hrudník,Upažování s jednoručnou činkou,Stroj na zadky ramen,Dipy na bradle,Tricepsové stahování kladky";
            }
            else if (typTreninkuZkratka == "RVPPLPull")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování tyče ve stoje,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }


            if (typTreninkuZkratka == "SRKR1")
            {
                return "Dřepy,Legpress,Lýtka ve stoje,Předkopy,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "SRKR2")
            {
                return "Dřepy,Legpress,Rumunský mrtvý tah,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "SRKR3")
            {
                return "Dřepy,Legpress,Zákopy,Mrtvý tah,Stahování tyče na stroji před hlavu - vertikálně,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "SRVMNohy")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "SRVMRamBic")
            {
                return "Tlaky na ramena - rozcvička,Tlaky na ramena s jednoručnou činkou,Upažování s jednoručnou činkou,Stroj na zadky ramen,Upažování na kladce,Tlaky na stroji,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }
            else if (typTreninkuZkratka == "SRVMHrTric")
            {
                return "Kliky,Benchpress,Tlaky na hrudník na nakloněné lavici,Pec deck,Stahování kladek na hrudník,Dipy na bradle,Tricepsové stahování kladky,Tricepsové stahování kladky za hlavu";
            }
            else if (typTreninkuZkratka == "SRVMZada")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování na stroji,Přitahování tyče ve stoje,Sklapovačky,Přitahování noh na bradlech";
            }
            else if (typTreninkuZkratka == "SRPPLLegs")
            {
                return "Dřepy s vlastní vahou,Dřepy,Legpress,Zákopy,Předkopy,Bulharský dřep,Rumunský mrtvý tah,Hiptrusty,Lýtka ve stoje";
            }
            else if (typTreninkuZkratka == "SRPPLPush")
            {
                return "Kliky,Benchpress,Tlaky na ramena s jednoručnou činkou,Tlaky na stroji,Tlaky na hrudník na nakloněné lavici,Stahování kladek na hrudník,Upažování s jednoručnou činkou,Stroj na zadky ramen,Dipy na bradle,Tricepsové stahování kladky";
            }
            else if (typTreninkuZkratka == "SRPPLPull")
            {
                return "Mrtvý tah bez závaží,Mrtvý tah,Shyby nadhmatem,Stahování tyče na stroji před hlavu - vertikálně,Přitahování tyče na stroji - horizontálně,Přitahování tyče ve stoje,Bicepsové přítahy jednoruček,Bicepsové přítahy obouručky,Bicepsové přítahy na stroji";
            }

            return null;
        }

    }
}
