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

    public static class PridaneTestovaciDataGlobalni
    {
        public static int PridaneTestovaciDataDoAplikace { get; set; } = 0;


    }

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

            public static List<DateTime> VytvářeníDatumůTréninkuTestovaci(int tréninkyZaTýden, int týdny, DayOfWeek[] dnyTréninku)
            {
                if (dnyTréninku.Length == 0 || tréninkyZaTýden <= 0 || týdny <= 0)
                {
                    throw new ArgumentException("Invalid input parameters");
                }

                List<DateTime> dataTréninků = new List<DateTime>();

                DateTime startovacíDatum;
                DateTime tedka = DateTime.Now.Date;
                if(tedka.DayOfWeek == DayOfWeek.Monday)
                {
                    startovacíDatum = DateTime.Now.Date.AddDays(-21);
                }
                else
                {
                    startovacíDatum = DateTime.Now.Date.AddDays(-28);
                }

                DayOfWeek dnes = startovacíDatum.DayOfWeek;
                int dnyDoPondeli = (7 + (int)DayOfWeek.Monday - (int)dnes) % 7;
                startovacíDatum = startovacíDatum.AddDays(dnyDoPondeli);

                for (int týden = 0; týden < týdny; týden++)
                {
                    foreach (var denTréninku in dnyTréninku)
                    {
                        if ((int)denTréninku == 0)
                        {
                            DateTime datumTréninku = startovacíDatum.AddDays((týden * 7) + (int)denTréninku + 6);
                            dataTréninků.Add(datumTréninku);
                        }
                        else
                        {
                            DateTime datumTréninku = startovacíDatum.AddDays((týden * 7) + (int)denTréninku - 1);
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
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
                                .Where(dt => dt.TPId == uzivatel[0].TPId)
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

            if (uzivatel[0].TPId != null)
            {
                var TPP = _context.TP
                                .FirstOrDefault(dt => dt.Id == uzivatel[0].TPId);
                ViewBag.TPP = TPP;

                var treninkoveDny = await _context.DenTreninku
                                .Where(dt => dt.TPId == uzivatel[0].TPId)
                                .ToListAsync();
                ViewBag.treninkoveDny = treninkoveDny;
            }

            //var dnes1 = DateTime.Now;
            //var denDnes1 = dnes1.DayOfWeek;
            //var denDnes2 = (int)denDnes1;
            //ViewBag.DenDnes = denDnes2;

            return View(await applicationDbContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PridatTrenink(string typTreninku, DateTime datumTreninku)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var uzivatel = _context.Users.FirstOrDefault(t => t.Id == userId);

            var ideckoPlanu = uzivatel.TPId;
            if(ideckoPlanu != null)
            {
                var novyTrenink = new DenTreninku
                {
                    TypTreninku = typTreninku,
                    DatumTreninku = datumTreninku,
                    TPId = (int)ideckoPlanu,
                    Cviky = new List<Cvik>(),
                };

                _context.DenTreninku.Add(novyTrenink);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return BadRequest("Uživatel nebo plán není platný.");
        }


        //funkce pro vytvoreni testovacich dat
        public async Task<IActionResult> PridatTestovaciData()
        {
            var currentUser = _context.Users.FirstOrDefault(t => t.UserName == "test@test.cz");

            var tP = new TP
            {
                Délka = 3,
                DruhTP = "BSH",
                StylTP = "VM",
                PocetTreninkuZaTyden = 4,
                UzivatelID = currentUser.Id,
                ZkontrolovaneDny = false,
                UlozenaDataDnu = false,
            };
            PridaneTestovaciDataGlobalni.PridaneTestovaciDataDoAplikace = 3;
            _context.TP.Add(tP);
            await _context.SaveChangesAsync();

            currentUser.TPId = tP.Id;
            if (currentUser.TreninkovePlany == null)
            {
                currentUser.TreninkovePlany = new List<int>();
            }
            currentUser.TreninkovePlany.Add(tP.Id);

            tP.User = currentUser;
            tP.AktualniVaha = true;

            tP.DatumPoslednihoUlozeniVahy = DateTime.Now;

            await _context.SaveChangesAsync();

            var po = new DenVTydnu
            {
                Den = (DayOfWeek)1,
                DenTréninku = true,
            };
            var ut = new DenVTydnu
            {
                Den = (DayOfWeek)2,
                DenTréninku = false,
            };
            var st = new DenVTydnu
            {
                Den = (DayOfWeek)3,
                DenTréninku = true,
            };
            var ct = new DenVTydnu
            {
                Den = (DayOfWeek)4,
                DenTréninku = false,
            };
            var pa = new DenVTydnu
            {
                Den = (DayOfWeek)5,
                DenTréninku = true,
            };
            var so = new DenVTydnu
            {
                Den = (DayOfWeek)6,
                DenTréninku = true,
            };
            var ne = new DenVTydnu
            {
                Den = (DayOfWeek)0,
                DenTréninku = false,
            };

            var dny = new List<DenVTydnu> {
                        po, ut, st, ct, pa, so, ne
            };

            tP.DnyVTydnu = dny;

            await _context.SaveChangesAsync();


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

            if (uzivatelIdZaznam != null)
            {
                var denVTydnuRecords = await _context.TP
                            .Where(tp => tp.Id == uzivatelIdZaznam.Id)
                            .SelectMany(tp => tp.DnyVTydnu)
                            .ToListAsync();
                DayOfWeek[] dnyTréninku = new DayOfWeek[uzivatelIdZaznam.PocetTreninkuZaTyden];
                int i = 0;
                foreach (var denVTydnuRecord in denVTydnuRecords)
                {
                    if (denVTydnuRecord.DenTréninku == true)
                    {
                        dnyTréninku[i] = denVTydnuRecord.Den;
                        i++;
                    }
                }

                List<DateTime> dataTréninkovýchDnů = GeneratorTréninkovýchDat.VytvářeníDatumůTréninkuTestovaci(uzivatelIdZaznam.PocetTreninkuZaTyden, uzivatelIdZaznam.Délka * 4, dnyTréninku);
                var typTreninku = "";
                var typTreninkuZkratka = "";

                var typTreninkuCislo = 0;
                if (uzivatelIdZaznam.UlozenaDataDnu == false)
                {
                    try
                    {
                        foreach (var datumTreninkovehoDne in dataTréninkovýchDnů)
                        {
                            if (uzivatelIdZaznam.StylTP == "VM")
                            {
                                if (typTreninkuCislo == 4)
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
                                    noveCviky.RemoveAt(index);
                                    noveCviky.Insert(index, cviky[j]);
                                }

                                var treninkoveDataEntita = new DenTreninku { DatumTreninku = datumTreninkovehoDne, TPId = uzivatelIdZaznam.Id, TypTreninku = typTreninku, Cviky = noveCviky };
                                _context.DenTreninku.Add(treninkoveDataEntita);
                                typTreninkuCislo++;

                            }
                            else if (uzivatelIdZaznam.StylTP == "PPL")
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
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
                                    int index = Array.IndexOf(poradiCvikuArray, cviky[j].Nazev);
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
            }

            //var dnes1 = DateTime.Now;
            ////var denDnes1 = dnes1.DayOfWeek;
            //var denDnes2 = (int)denDnes1;
            //ViewBag.DenDnes = denDnes2;


            var dnes = DateTime.Now;
            var denDnes = dnes.DayOfWeek;
            var denDnes1 = (int)denDnes;
            var dnyTreninkuNaZapsani = _context.DenTreninku.ToList();



            var serie1 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie2 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie3 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie4 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie5 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie6 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie7 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie8 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie9 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie10 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie11 = new TreninkoveData{UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie12 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie13 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie14 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie15 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie16 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie17 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie18 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie19 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie20 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie21 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie22 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie23 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie24 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie25 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie26 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie27 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie28 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie29 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie30 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75, Datum = dnyTreninkuNaZapsani[0].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            //prvni hrudnik a ticak

            var serie31 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie32 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie33 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie34 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie35 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie36 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie37 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
            var serie38 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie39 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie40 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie41 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 140, TpId = (int)currentUser.TPId };
            var serie42 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 180, TpId = (int)currentUser.TPId };
            var serie43 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie44 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie45 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie46 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie47 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie48 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie49 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie50 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
            var serie51 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie52 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie53 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie54 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie55 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie56 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie57 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie58 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie59 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie60 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie61 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie62 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie63 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie64 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie65 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie66 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[1].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            //druhy nohy

            var serie97 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
            var serie98 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie99 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie100 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie101 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie102 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie103 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie104 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie105 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie106 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie107 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie108 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 13, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie109 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 13, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie110 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 13, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie111 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 13, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie112 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 14, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 7, TpId = (int)currentUser.TPId };
            var serie113 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 14, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie114 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 14, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie115 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 15, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie116 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 15, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie117 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 15, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie118 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 15, CisloSerie = 4, PocetOpakovani = 6, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie119 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 16, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie120 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 16, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie121 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 16, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie122 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 16, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie123 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 17, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie124 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 17, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie125 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 17, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie126 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 18, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie127 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 18, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie128 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[2].DatumTreninku, CvikId = 18, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            //treti ramena bicak

            var serie129 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 27, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie130 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 27, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie131 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 27, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie132 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 28, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie133 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 28, CisloSerie = 2, PocetOpakovani = 5, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie134 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 28, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 120, TpId = (int)currentUser.TPId };
            var serie135 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 28, CisloSerie = 4, PocetOpakovani = 3, CvicenaVaha = 130, TpId = (int)currentUser.TPId };
            var serie136 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 28, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 140, TpId = (int)currentUser.TPId };
            var serie137 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 29, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie138 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 29, CisloSerie = 2, PocetOpakovani = 8, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie139 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 29, CisloSerie = 3, PocetOpakovani = 6, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie140 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 29, CisloSerie = 4, PocetOpakovani = 4, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie141 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 30, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie142 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 30, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie143 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 30, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie144 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 30, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie145 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 31, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie146 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 31, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie147 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 31, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie148 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 31, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie149 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 32, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie150 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 32, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie151 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 32, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie152 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 32, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie153 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 33, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie154 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 33, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie155 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 33, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie156 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 34, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie157 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 34, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie158 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 34, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie159 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 35, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie160 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 35, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie161 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.2, Datum = dnyTreninkuNaZapsani[3].DatumTreninku, CvikId = 35, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            //ctvrty zada

            var serie67 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie68 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie69 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie70 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie71 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie72 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 75, TpId = (int)currentUser.TPId };
            var serie73 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie74 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
            var serie75 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie76 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie77 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie78 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 32, TpId = (int)currentUser.TPId };
            var serie79 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie80 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie81 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie82 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie83 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie84 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie85 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie86 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie87 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie88 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie89 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie90 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie91 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie92 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie93 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie94 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie95 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie96 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76, Datum = dnyTreninkuNaZapsani[4].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            //paty hrudik a tricak

            var serie162 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie163 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie164 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie165 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie166 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie167 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie168 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
            var serie169 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie170 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie171 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie172 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 140, TpId = (int)currentUser.TPId };
            var serie173 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 180, TpId = (int)currentUser.TPId };
            var serie174 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie175 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie176 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie177 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie178 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie179 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie180 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie181 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
            var serie182 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie183 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie184 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie185 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie186 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie187 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie188 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie189 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie190 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie191 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie192 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie193 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie194 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie195 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie196 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie197 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[5].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            //sesty nohy

            var serie198 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
            var serie199 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie200 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie201 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie202 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie203 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie204 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie205 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie206 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie207 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie208 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie209 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 13, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie210 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 13, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie211 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 13, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie212 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 13, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie213 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 14, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 7, TpId = (int)currentUser.TPId };
            var serie214 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 14, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie215 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 14, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie216 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 15, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie217 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 15, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie218 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 15, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie219 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 15, CisloSerie = 4, PocetOpakovani = 6, CvicenaVaha = 93, TpId = (int)currentUser.TPId };
            var serie220 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 16, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie221 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 16, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie222 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 16, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie223 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 16, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie224 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 17, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
            var serie225 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 17, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
            var serie226 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 17, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie227 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 18, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie228 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 18, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie229 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.2, Datum = dnyTreninkuNaZapsani[6].DatumTreninku, CvikId = 18, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            //sedmi ramena bicak

            var serie262 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 27, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie230 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 27, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie231 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 27, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie232 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 28, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie233 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 28, CisloSerie = 2, PocetOpakovani = 5, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie234 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 28, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 120, TpId = (int)currentUser.TPId };
            var serie235 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 28, CisloSerie = 4, PocetOpakovani = 3, CvicenaVaha = 135, TpId = (int)currentUser.TPId };
            var serie236 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 28, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 145, TpId = (int)currentUser.TPId };
            var serie237 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 29, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie238 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 29, CisloSerie = 2, PocetOpakovani = 8, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie239 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 29, CisloSerie = 3, PocetOpakovani = 6, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie240 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 29, CisloSerie = 4, PocetOpakovani = 4, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie241 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 30, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie242 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 30, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie243 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 30, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie244 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 30, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
            var serie245 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 31, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie246 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 31, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie247 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 31, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie248 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 31, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie249 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 32, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie250 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 32, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
            var serie251 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 32, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie252 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 32, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 85, TpId = (int)currentUser.TPId };
            var serie253 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 33, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie254 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 33, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie255 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 33, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 45, TpId = (int)currentUser.TPId };
            var serie256 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 34, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie257 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 34, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie258 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 34, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie259 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 35, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie260 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 35, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie261 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[7].DatumTreninku, CvikId = 35, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            //osmi zada

            var serie263 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie264 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie265 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie270 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie271 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
            var serie272 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie273 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie274 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie275 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie276 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie277 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
            var serie278 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie279 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
            var serie280 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie281 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie282 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
            var serie283 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie284 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie285 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie286 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie287 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie288 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie289 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie290 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie291 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie292 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie293 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie294 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie295 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie296 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[8].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            //devaty hrudik a tricak

            var serie266 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie267 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie268 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie269 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie297 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie298 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
            var serie299 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
            var serie300 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie301 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie302 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie303 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 140, TpId = (int)currentUser.TPId };
            var serie304 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 180, TpId = (int)currentUser.TPId };
            var serie305 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie306 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie307 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie308 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie309 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie310 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie311 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie312 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
            var serie313 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie314 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie315 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie316 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie317 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie318 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie319 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie320 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie321 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie322 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie323 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie324 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie325 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie326 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie327 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie328 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 75.3, Datum = dnyTreninkuNaZapsani[9].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            //desaty nohy

            var serie329 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
            var serie330 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie331 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie332 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie333 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie334 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie335 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
            var serie336 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie337 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie338 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie339 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie340 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 13, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie341 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 13, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie342 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 13, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie343 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 13, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie344 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 14, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 7, TpId = (int)currentUser.TPId };
            var serie345 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 14, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie346 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 14, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
            var serie347 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 15, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie348 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 15, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie349 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 15, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
            var serie350 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 15, CisloSerie = 4, PocetOpakovani = 6, CvicenaVaha = 93, TpId = (int)currentUser.TPId };
            var serie351 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 16, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
            var serie352 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 16, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie353 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 16, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
            var serie354 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 16, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
            var serie355 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 17, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
            var serie356 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 17, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
            var serie357 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 17, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie358 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 18, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie359 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 18, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
            var serie360 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77.2, Datum = dnyTreninkuNaZapsani[10].DatumTreninku, CvikId = 18, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            //jedenacty ramena bicak

            var serie361 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 27, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie362 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 27, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie363 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 27, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie364 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 28, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie365 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 28, CisloSerie = 2, PocetOpakovani = 5, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
            var serie366 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 28, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 120, TpId = (int)currentUser.TPId };
            var serie367 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 28, CisloSerie = 4, PocetOpakovani = 3, CvicenaVaha = 135, TpId = (int)currentUser.TPId };
            var serie368 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 28, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 145, TpId = (int)currentUser.TPId };
            var serie369 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 29, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie370 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 29, CisloSerie = 2, PocetOpakovani = 8, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie371 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 29, CisloSerie = 3, PocetOpakovani = 6, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie372 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 29, CisloSerie = 4, PocetOpakovani = 4, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie373 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 30, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
            var serie374 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 30, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie375 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 30, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie376 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 30, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
            var serie377 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 31, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie378 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 31, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie379 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 31, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
            var serie380 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 31, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
            var serie381 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 32, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie382 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 32, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
            var serie383 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 32, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
            var serie384 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 32, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 85, TpId = (int)currentUser.TPId };
            var serie385 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 33, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
            var serie386 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 33, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
            var serie387 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 33, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 45, TpId = (int)currentUser.TPId };
            var serie388 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 34, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie389 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 34, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie390 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 34, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie391 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 35, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie392 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 35, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            var serie393 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 76.8, Datum = dnyTreninkuNaZapsani[11].DatumTreninku, CvikId = 35, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
            //dvanacty zada


            var serie = new List<TreninkoveData> {
                        serie1, serie2, serie3, serie4, serie5, serie6, serie7, serie8, serie9, serie10, serie11, serie12, serie13, serie14, serie15, serie16, serie17, serie18, serie19, serie20, serie21, serie22, serie23, serie24, serie25, serie26, serie27, serie28, serie29, serie30, //prvni hrudnik + tricak
                        serie31, serie32, serie33, serie34, serie35, serie36, serie37, serie38, serie39, serie40, serie41, serie42, serie43, serie44, serie45, serie46, serie47, serie48, serie49, serie50, serie51, serie52, serie53, serie54, serie55, serie56, serie57, serie58, serie59, serie60, serie61, serie62, serie63, serie64, serie65, serie66, //nohy
                        serie97, serie98, serie99, serie100, serie101, serie102, serie103, serie104, serie105,  serie106, serie107, serie108, serie109, serie110, serie111, serie112, serie113, serie114, serie115, serie116, serie117, serie118, serie119, serie120, serie121, serie122, serie123, serie124, serie125, serie126, serie127, serie128, serie129, serie130, serie131, serie132, serie133, serie134, serie135, serie136, serie137, serie138, serie139, serie140,
                        serie141, serie142, serie143, serie144, serie145, serie146, serie147, serie148, serie149, serie150, serie151, serie152, serie153, serie154, serie155, serie156, serie157, serie158, serie159, serie160, serie161, serie162, serie163, serie164, serie165, serie166, serie167, serie168, serie169, serie170, serie171, serie172, serie173, serie174, serie175, serie176, serie177, serie178, serie179, serie180, serie181, serie182, serie183, serie184,
                        serie185, serie186, serie187, serie188, serie189, serie190, serie191, serie192, serie193, serie194, serie195, serie196, serie197, serie198, serie199, serie200, serie201, serie202, serie203, serie204, serie205, serie206, serie207, serie208, serie209, serie210, serie211, serie212, serie213, serie214, serie215, serie216, serie217, serie218, serie219, serie220, serie221, serie222, serie223, serie224, serie225, serie226, serie227, serie228,
                        serie229, serie230, serie231, serie232, serie233, serie234, serie235, serie236, serie237, serie238, serie239, serie240, serie241, serie242, serie243, serie244, serie245, serie246, serie247, serie248, serie249, serie250, serie251, serie252, serie253, serie254, serie255, serie256, serie257, serie258, serie259, serie260, serie261,
                        serie262, serie263, serie264, serie265, serie266, serie267, serie268, serie269, serie260, serie261, serie262, serie263,serie264, serie265, serie266, serie267, serie268, serie269, serie270, serie271, serie272, serie273, serie274, serie275, serie276, serie277, serie278, serie279, serie280, serie281, serie282, serie283, serie284, serie285, serie286, serie287, serie288, serie289, serie290, serie291, serie292, serie293, serie294,
                        serie295, serie296, serie297, serie298, serie299, serie290, serie291, serie292, serie293, serie294, serie295, serie296, serie297, serie298, serie299, serie300, serie301, serie302, serie303, serie304, serie305, serie306, serie307, serie308, serie309, serie310, serie311, serie312, serie313, serie314, serie315, serie316, serie317, serie318, serie319, serie320, serie321, serie322, serie323, serie324, serie325, serie326,
                        serie327, serie328, serie329, serie330, serie331, serie332, serie333, serie334, serie335, serie336, serie337, serie338, serie339, serie340, serie341, serie342, serie343, serie344, serie345, serie346, serie347, serie348, serie349, serie350, serie351, serie352, serie353, serie354, serie355, serie356, serie357, serie358, serie359, serie360, serie361, serie362, serie363, serie364, serie364, serie365, serie366, serie365,
                        serie367, serie368, serie369, serie370, serie371, serie372, serie373, serie374, serie375, serie376, serie377, serie378, serie379, serie380, serie381, serie382, serie383, serie384, serie385, serie386, serie387, serie388, serie389, serie390, serie391, serie392, serie393,
                        serie67, serie68, serie69, serie70, serie71, serie72, serie73, serie74, serie75, serie76, serie77, serie78, serie79, serie80, serie81, serie82, serie83, serie84, serie85, serie86, serie87, serie88, serie89, serie90, serie91, serie92, serie93, serie94, serie95, serie96,
            };

            if(denDnes1 == 1)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli rozdelany
                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
            }
            else if(denDnes1 == 2)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy
                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);
            }
            else if(denDnes1 == 3)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy + rozdelany ve stredu
                var serie424 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie425 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie426 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie427 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie428 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie429 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie430 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie431 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie432 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie433 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie434 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 140, TpId = (int)currentUser.TPId };
                var serie435 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 180, TpId = (int)currentUser.TPId };

                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);

                serie.Add(serie424);
                serie.Add(serie425);
                serie.Add(serie426);
                serie.Add(serie427);
                serie.Add(serie428);
                serie.Add(serie429);
                serie.Add(serie430);
                serie.Add(serie431);
                serie.Add(serie432);
                serie.Add(serie433);
                serie.Add(serie434);
                serie.Add(serie435);



                //pridat trenink pondeli hotovy + rozdelany ve stredu
            }
            else if(denDnes1 == 4)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy + rozdelany ve stredu
                var serie424 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie425 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie426 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie427 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie428 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie429 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie430 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie431 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie432 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie433 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 110, TpId = (int)currentUser.TPId };
                var serie434 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 150, TpId = (int)currentUser.TPId };
                var serie435 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 190, TpId = (int)currentUser.TPId };
                var serie436 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie437 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie438 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie439 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie440 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie441 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie442 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie443 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie444 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie445 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie446 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie447 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie448 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie449 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
                var serie450 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie451 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie452 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie453 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie454 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie455 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie456 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie457 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie458 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie459 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);

                serie.Add(serie424);
                serie.Add(serie425);
                serie.Add(serie426);
                serie.Add(serie427);
                serie.Add(serie428);
                serie.Add(serie429);
                serie.Add(serie430);
                serie.Add(serie431);
                serie.Add(serie432);
                serie.Add(serie433);
                serie.Add(serie434);
                serie.Add(serie435);
                serie.Add(serie436);
                serie.Add(serie437);
                serie.Add(serie438);
                serie.Add(serie439);
                serie.Add(serie440);
                serie.Add(serie441);
                serie.Add(serie442);
                serie.Add(serie443);
                serie.Add(serie444);
                serie.Add(serie445);
                serie.Add(serie446);
                serie.Add(serie447);
                serie.Add(serie448);
                serie.Add(serie449);
                serie.Add(serie450);
                serie.Add(serie451);
                serie.Add(serie452);
                serie.Add(serie453);
                serie.Add(serie454);
                serie.Add(serie455);
                serie.Add(serie456);
                serie.Add(serie457);
                serie.Add(serie458);
                serie.Add(serie459);
            }
            else if(denDnes1 == 5)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy + rozdelany ve stredu
                var serie424 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie425 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie426 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie427 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie428 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie429 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie430 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie431 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie432 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie433 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 110, TpId = (int)currentUser.TPId };
                var serie434 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 150, TpId = (int)currentUser.TPId };
                var serie435 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 190, TpId = (int)currentUser.TPId };
                var serie436 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie437 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie438 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie439 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie440 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie441 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie442 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie443 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie444 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie445 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie446 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie447 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie448 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie449 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
                var serie450 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie451 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie452 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie453 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie454 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie455 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie456 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie457 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie458 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie459 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };

                var serie460 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
                var serie461 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie462 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie463 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie464 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie465 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie466 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie467 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie468 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie469 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie470 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };

                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);

                serie.Add(serie424);
                serie.Add(serie425);
                serie.Add(serie426);
                serie.Add(serie427);
                serie.Add(serie428);
                serie.Add(serie429);
                serie.Add(serie430);
                serie.Add(serie431);
                serie.Add(serie432);
                serie.Add(serie433);
                serie.Add(serie434);
                serie.Add(serie435);
                serie.Add(serie436);
                serie.Add(serie437);
                serie.Add(serie438);
                serie.Add(serie439);
                serie.Add(serie440);
                serie.Add(serie441);
                serie.Add(serie442);
                serie.Add(serie443);
                serie.Add(serie444);
                serie.Add(serie445);
                serie.Add(serie446);
                serie.Add(serie447);
                serie.Add(serie448);
                serie.Add(serie449);
                serie.Add(serie450);
                serie.Add(serie451);
                serie.Add(serie452);
                serie.Add(serie453);
                serie.Add(serie454);
                serie.Add(serie455);
                serie.Add(serie456);
                serie.Add(serie457);
                serie.Add(serie458);
                serie.Add(serie459);

                serie.Add(serie460);
                serie.Add(serie461);
                serie.Add(serie462);
                serie.Add(serie463);
                serie.Add(serie464);
                serie.Add(serie465);
                serie.Add(serie466);
                serie.Add(serie467);
                serie.Add(serie468);
                serie.Add(serie469);
                serie.Add(serie470);
                //pridat hotovy pondeli a streda a rozdelany dneska
            }
            else if(denDnes1 == 6)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy + rozdelany ve stredu
                var serie424 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie425 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie426 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie427 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie428 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie429 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie430 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie431 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie432 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie433 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 110, TpId = (int)currentUser.TPId };
                var serie434 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 150, TpId = (int)currentUser.TPId };
                var serie435 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 190, TpId = (int)currentUser.TPId };
                var serie436 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie437 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie438 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie439 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie440 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie441 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie442 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie443 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie444 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie445 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie446 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie447 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie448 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie449 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
                var serie450 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie451 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie452 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie453 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie454 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie455 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie456 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie457 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie458 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie459 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };

                var serie460 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
                var serie461 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie462 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie463 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie464 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie465 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 32, TpId = (int)currentUser.TPId };
                var serie466 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 36, TpId = (int)currentUser.TPId };
                var serie467 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 16, TpId = (int)currentUser.TPId };
                var serie468 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie469 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie470 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie491 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie471 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie472 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie473 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie474 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 7, TpId = (int)currentUser.TPId };
                var serie475 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie476 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie477 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie478 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie479 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie480 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 4, PocetOpakovani = 6, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie481 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie482 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie483 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie484 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie485 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
                var serie486 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
                var serie487 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie488 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie489 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie490 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };

                var serie492 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie493 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie494 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie495 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie496 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 2, PocetOpakovani = 5, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie497 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 120, TpId = (int)currentUser.TPId };
                var serie498 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 4, PocetOpakovani = 3, CvicenaVaha = 135, TpId = (int)currentUser.TPId };
                var serie499 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = currentUser.Vaha, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 150, TpId = (int)currentUser.TPId };

                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);

                serie.Add(serie424);
                serie.Add(serie425);
                serie.Add(serie426);
                serie.Add(serie427);
                serie.Add(serie428);
                serie.Add(serie429);
                serie.Add(serie430);
                serie.Add(serie431);
                serie.Add(serie432);
                serie.Add(serie433);
                serie.Add(serie434);
                serie.Add(serie435);
                serie.Add(serie436);
                serie.Add(serie437);
                serie.Add(serie438);
                serie.Add(serie439);
                serie.Add(serie440);
                serie.Add(serie441);
                serie.Add(serie442);
                serie.Add(serie443);
                serie.Add(serie444);
                serie.Add(serie445);
                serie.Add(serie446);
                serie.Add(serie447);
                serie.Add(serie448);
                serie.Add(serie449);
                serie.Add(serie450);
                serie.Add(serie451);
                serie.Add(serie452);
                serie.Add(serie453);
                serie.Add(serie454);
                serie.Add(serie455);
                serie.Add(serie456);
                serie.Add(serie457);
                serie.Add(serie458);
                serie.Add(serie459);

                serie.Add(serie460);
                serie.Add(serie461);
                serie.Add(serie462);
                serie.Add(serie463);
                serie.Add(serie464);
                serie.Add(serie465);
                serie.Add(serie466);
                serie.Add(serie467);
                serie.Add(serie468);
                serie.Add(serie469);
                serie.Add(serie470);
                serie.Add(serie471);
                serie.Add(serie472);
                serie.Add(serie473);
                serie.Add(serie474);
                serie.Add(serie475);
                serie.Add(serie476);
                serie.Add(serie477);
                serie.Add(serie478);
                serie.Add(serie479);
                serie.Add(serie480);
                serie.Add(serie481);
                serie.Add(serie482);
                serie.Add(serie483);
                serie.Add(serie484);
                serie.Add(serie485);
                serie.Add(serie486);
                serie.Add(serie487);
                serie.Add(serie488);
                serie.Add(serie489);
                serie.Add(serie490);
                serie.Add(serie491);

                serie.Add(serie492);
                serie.Add(serie493);
                serie.Add(serie494);
                serie.Add(serie495);
                serie.Add(serie496);
                serie.Add(serie497);
                serie.Add(serie498);
                serie.Add(serie499);
                //pridat hotovy pondeli, streda, patek a pridat rozdelany sobota
            }
            else if(denDnes1 == 0)
            {
                var serie394 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie395 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie396 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 19, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie397 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 1, PocetOpakovani = 15, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie398 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie399 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie400 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie401 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 20, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie402 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie403 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie404 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie405 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 21, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie406 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 42, TpId = (int)currentUser.TPId };
                var serie407 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie408 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie409 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 22, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie410 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie411 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie412 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 23, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie413 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie414 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie415 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 24, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie416 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie417 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie418 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie419 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 25, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie420 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie421 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie422 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie423 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 77, Datum = dnyTreninkuNaZapsani[12].DatumTreninku, CvikId = 26, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                //pridat trenink pondeli hotovy + rozdelany ve stredu
                var serie424 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie425 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie426 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 1, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie427 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie428 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie429 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 90, TpId = (int)currentUser.TPId };
                var serie430 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 4, PocetOpakovani = 2, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie431 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 2, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie432 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie433 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 110, TpId = (int)currentUser.TPId };
                var serie434 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 150, TpId = (int)currentUser.TPId };
                var serie435 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 3, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 190, TpId = (int)currentUser.TPId };
                var serie436 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie437 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie438 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 35, TpId = (int)currentUser.TPId };
                var serie439 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 4, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie440 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie441 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie442 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie443 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 5, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 65, TpId = (int)currentUser.TPId };
                var serie444 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie445 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie446 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie447 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 6, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie448 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie449 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
                var serie450 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie451 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 7, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie452 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie453 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie454 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie455 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 8, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie456 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie457 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie458 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 3, PocetOpakovani = 12, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie459 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78, Datum = dnyTreninkuNaZapsani[13].DatumTreninku, CvikId = 9, CisloSerie = 4, PocetOpakovani = 12, CvicenaVaha = 60, TpId = (int)currentUser.TPId };

                var serie460 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 5, TpId = (int)currentUser.TPId };
                var serie461 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 10, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie462 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie463 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie464 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie465 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 32, TpId = (int)currentUser.TPId };
                var serie466 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 11, CisloSerie = 5, PocetOpakovani = 5, CvicenaVaha = 36, TpId = (int)currentUser.TPId };
                var serie467 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 1, PocetOpakovani = 12, CvicenaVaha = 16, TpId = (int)currentUser.TPId };
                var serie468 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 2, PocetOpakovani = 12, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie469 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie470 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 12, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie491 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie471 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie472 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 22, TpId = (int)currentUser.TPId };
                var serie473 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 13, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie474 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 7, TpId = (int)currentUser.TPId };
                var serie475 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie476 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 14, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 10, TpId = (int)currentUser.TPId };
                var serie477 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie478 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie479 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 80, TpId = (int)currentUser.TPId };
                var serie480 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 15, CisloSerie = 4, PocetOpakovani = 6, CvicenaVaha = 95, TpId = (int)currentUser.TPId };
                var serie481 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 17, TpId = (int)currentUser.TPId };
                var serie482 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie483 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 15, TpId = (int)currentUser.TPId };
                var serie484 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 16, CisloSerie = 4, PocetOpakovani = 8, CvicenaVaha = 12, TpId = (int)currentUser.TPId };
                var serie485 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
                var serie486 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 23, TpId = (int)currentUser.TPId };
                var serie487 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 17, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie488 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie489 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 25, TpId = (int)currentUser.TPId };
                var serie490 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.2, Datum = dnyTreninkuNaZapsani[14].DatumTreninku, CvikId = 18, CisloSerie = 3, PocetOpakovani = 8, CvicenaVaha = 20, TpId = (int)currentUser.TPId };

                var serie492 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie493 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie494 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 27, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie495 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie496 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 2, PocetOpakovani = 5, CvicenaVaha = 100, TpId = (int)currentUser.TPId };
                var serie497 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 3, PocetOpakovani = 5, CvicenaVaha = 120, TpId = (int)currentUser.TPId };
                var serie498 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 4, PocetOpakovani = 3, CvicenaVaha = 135, TpId = (int)currentUser.TPId };
                var serie499 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 28, CisloSerie = 5, PocetOpakovani = 1, CvicenaVaha = 150, TpId = (int)currentUser.TPId };
                var serie500 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 29, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie501 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 29, CisloSerie = 2, PocetOpakovani = 8, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie502 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 29, CisloSerie = 3, PocetOpakovani = 6, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie503 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 29, CisloSerie = 4, PocetOpakovani = 4, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie504 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 30, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 20, TpId = (int)currentUser.TPId };
                var serie505 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 30, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie506 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 30, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie507 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 30, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
                var serie508 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 31, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie509 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 31, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie510 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 31, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 50, TpId = (int)currentUser.TPId };
                var serie511 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 31, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 60, TpId = (int)currentUser.TPId };
                var serie512 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 32, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie513 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 32, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 55, TpId = (int)currentUser.TPId };
                var serie514 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 32, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 70, TpId = (int)currentUser.TPId };
                var serie515 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 32, CisloSerie = 4, PocetOpakovani = 10, CvicenaVaha = 85, TpId = (int)currentUser.TPId };
                var serie516 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 33, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 30, TpId = (int)currentUser.TPId };
                var serie517 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 33, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 40, TpId = (int)currentUser.TPId };
                var serie518 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 33, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 45, TpId = (int)currentUser.TPId };
                var serie519 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 34, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie520 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 34, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie521 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 34, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie522 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 35, CisloSerie = 1, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie523 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 35, CisloSerie = 2, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };
                var serie524 = new TreninkoveData { UzivatelId = currentUser.Id, VahaUzivatele = 78.8, Datum = dnyTreninkuNaZapsani[15].DatumTreninku, CvikId = 35, CisloSerie = 3, PocetOpakovani = 10, CvicenaVaha = 0, TpId = (int)currentUser.TPId };



                serie.Add(serie394);
                serie.Add(serie395);
                serie.Add(serie396);
                serie.Add(serie397);
                serie.Add(serie398);
                serie.Add(serie399);
                serie.Add(serie400);
                serie.Add(serie401);
                serie.Add(serie402);
                serie.Add(serie403);
                serie.Add(serie404);
                serie.Add(serie405);
                serie.Add(serie406);
                serie.Add(serie407);
                serie.Add(serie408);
                serie.Add(serie409);
                serie.Add(serie410);
                serie.Add(serie411);
                serie.Add(serie412);
                serie.Add(serie413);
                serie.Add(serie414);
                serie.Add(serie415);
                serie.Add(serie416);
                serie.Add(serie417);
                serie.Add(serie418);
                serie.Add(serie419);
                serie.Add(serie420);
                serie.Add(serie421);
                serie.Add(serie422);
                serie.Add(serie423);

                serie.Add(serie424);
                serie.Add(serie425);
                serie.Add(serie426);
                serie.Add(serie427);
                serie.Add(serie428);
                serie.Add(serie429);
                serie.Add(serie430);
                serie.Add(serie431);
                serie.Add(serie432);
                serie.Add(serie433);
                serie.Add(serie434);
                serie.Add(serie435);
                serie.Add(serie436);
                serie.Add(serie437);
                serie.Add(serie438);
                serie.Add(serie439);
                serie.Add(serie440);
                serie.Add(serie441);
                serie.Add(serie442);
                serie.Add(serie443);
                serie.Add(serie444);
                serie.Add(serie445);
                serie.Add(serie446);
                serie.Add(serie447);
                serie.Add(serie448);
                serie.Add(serie449);
                serie.Add(serie450);
                serie.Add(serie451);
                serie.Add(serie452);
                serie.Add(serie453);
                serie.Add(serie454);
                serie.Add(serie455);
                serie.Add(serie456);
                serie.Add(serie457);
                serie.Add(serie458);
                serie.Add(serie459);

                serie.Add(serie460);
                serie.Add(serie461);
                serie.Add(serie462);
                serie.Add(serie463);
                serie.Add(serie464);
                serie.Add(serie465);
                serie.Add(serie466);
                serie.Add(serie467);
                serie.Add(serie468);
                serie.Add(serie469);
                serie.Add(serie470);
                serie.Add(serie471);
                serie.Add(serie472);
                serie.Add(serie473);
                serie.Add(serie474);
                serie.Add(serie475);
                serie.Add(serie476);
                serie.Add(serie477);
                serie.Add(serie478);
                serie.Add(serie479);
                serie.Add(serie480);
                serie.Add(serie481);
                serie.Add(serie482);
                serie.Add(serie483);
                serie.Add(serie484);
                serie.Add(serie485);
                serie.Add(serie486);
                serie.Add(serie487);
                serie.Add(serie488);
                serie.Add(serie489);
                serie.Add(serie490);
                serie.Add(serie491);

                serie.Add(serie492);
                serie.Add(serie493);
                serie.Add(serie494);
                serie.Add(serie495);
                serie.Add(serie496);
                serie.Add(serie497);
                serie.Add(serie498);
                serie.Add(serie499);
                serie.Add(serie501);
                serie.Add(serie502);
                serie.Add(serie503);
                serie.Add(serie504);
                serie.Add(serie505);
                serie.Add(serie506);
                serie.Add(serie507);
                serie.Add(serie508);
                serie.Add(serie509);
                serie.Add(serie510);
                serie.Add(serie511);
                serie.Add(serie512);
                serie.Add(serie513);
                serie.Add(serie514);
                serie.Add(serie515);
                serie.Add(serie516);
                serie.Add(serie517);
                serie.Add(serie518);
                serie.Add(serie519);
                serie.Add(serie520);
                serie.Add(serie521);
                serie.Add(serie522);
                serie.Add(serie523);
                serie.Add(serie524);
            }

            

            foreach (var ser in serie)
            {
                _context.TreninkoveData.Add(ser);
            }

            var novyCvik = new Cvik { Nazev = "Dřep na jedné noze", PopisCviku = "Dřep na jedné noze", Partie = "Nohy", UzivatelId = userId, cvikVytvorenUzivatelem = true };
            if (novyCvik.TypyTreninku == null)
            {
                novyCvik.TypyTreninku = new List<string>();
                novyCvik.PočtySérií = new List<int>();
                novyCvik.PočtyOpakování = new List<string>();
                novyCvik.PauzyMeziSériemi = new List<int>();
            }
            _context.Cvik.Add(novyCvik);
            await _context.SaveChangesAsync();

            PridaneTestovaciDataGlobalni.PridaneTestovaciDataDoAplikace = 8;

            return RedirectToAction("Index", "Home");
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
                    uzivatelIdZaznam.Vaha = cislo;

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
               
            uzivatelIdZaznam.Uroven = 2;
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
            var uzivatel = _context.Users.FirstOrDefault(t => t.Id == userId);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.Id == uzivatel.TPId);

            var treninky = await _context.DenTreninku
                                .Where(d => d.TPId == uzivatelIdZaznam.Id)
                                .OrderBy(t => t.DatumTreninku)
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
            var uzivatel = _context.Users.FirstOrDefault(t => t.Id == userId);

            var uzivatelIdZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.Id == uzivatel.TPId);

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
