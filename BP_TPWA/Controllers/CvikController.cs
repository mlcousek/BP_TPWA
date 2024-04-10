﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Data;
using BP_TPWA.Models;
using System.Security.Claims;

namespace BP_TPWA.Controllers
{
    public class CvikController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CvikController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Akce pro přidání dat do databáze
        public async Task<IActionResult> PridejData()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                //BSH hlavni

                //VM podhlavni

                // Nohy

                var cvik1 = new Cvik { Název = "Dřepy s vlastní vahou", PopisCviku = "Zahřátí + aktivace", Partie = "Nohy", UzivatelId = userId };
                if (cvik1.TypyTreninku == null)
                {
                    cvik1.TypyTreninku = new List<string>();
                }
                if (cvik1.PočtySérií == null)
                {
                    cvik1.PočtySérií = new List<int>();
                    cvik1.PočtyOpakování = new List<string>();
                    cvik1.PauzyMeziSériemi = new List<int>();
                }
                cvik1.TypyTreninku.Add("BSHVMNohy");
                cvik1.PočtySérií.Add(3);
                cvik1.PočtyOpakování.Add("10, 10, 10");
                cvik1.PauzyMeziSériemi.Add(30);
                var cvik2 = new Cvik { Název = "Zadní dřepy", PopisCviku = "Silový cvik dřep", Partie = "Nohy", UzivatelId = userId };
                if (cvik2.TypyTreninku == null)
                {
                    cvik2.TypyTreninku = new List<string>();
                }
                if (cvik2.PočtySérií == null)
                {
                    cvik2.PočtySérií = new List<int>();
                    cvik2.PočtyOpakování = new List<string>();
                    cvik2.PauzyMeziSériemi = new List<int>();
                }
                cvik2.TypyTreninku.Add("BSHVMNohy");
                cvik2.PočtySérií.Add(5);
                cvik2.PočtyOpakování.Add("x");
                cvik2.PauzyMeziSériemi.Add(0);
                var cvik3 = new Cvik { Název = "Legpress", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik3.TypyTreninku == null)
                {
                    cvik3.TypyTreninku = new List<string>();
                }
                if (cvik3.PočtySérií == null)
                {
                    cvik3.PočtySérií = new List<int>();
                    cvik3.PočtyOpakování = new List<string>();
                    cvik3.PauzyMeziSériemi = new List<int>();
                }
                cvik3.TypyTreninku.Add("BSHVMNohy");
                cvik3.PočtySérií.Add(4);
                cvik3.PočtyOpakování.Add("10, 10, 12, 12");
                cvik3.PauzyMeziSériemi.Add(60);


                ////Test
                //if (cvik3.PočtySérií == null)
                //{
                //    cvik3.PočtySérií = new List<int>();
                //    cvik3.PočtyOpakování = new List<string>();
                //    cvik3.PauzyMeziSériemi = new List<int>();
                //}
                //cvik3.TypyTreninku.Add("BSHVMRamBic");
                //cvik3.PočtySérií.Add(2);
                //cvik3.PočtyOpakování.Add("10, 10");
                //cvik3.PauzyMeziSériemi.Add(100);

                //var cvik4 = new Cvik { Název = "Zákopy", PočetSérií = 4, PočetOpakování = "10, 10, 12, 12", PauzaMeziSériemi = 60, PopisCviku = "Popis zákopy", Partie = "Nohy", UzivatelId = userId };
                //if (cvik4.TypyTreninku == null)
                //{
                //    cvik4.TypyTreninku = new List<string>();
                //}
                //cvik4.TypyTreninku.Add("BSHVMNohy");
                //var cvik5 = new Cvik { Název = "Předkopy", PočetSérií = 4, PočetOpakování = "10, 10, 12, 12", PauzaMeziSériemi = 60, PopisCviku = "Popis předkopy", Partie = "Nohy", UzivatelId = userId };
                //if (cvik5.TypyTreninku == null)
                //{
                //    cvik5.TypyTreninku = new List<string>();
                //}
                //cvik5.TypyTreninku.Add("BSHVMNohy");
                //var cvik6 = new Cvik { Název = "Bulharský dřep", PočetSérií = 4, PočetOpakování = "10, 10, 12, 12", PauzaMeziSériemi = 60, PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                //if (cvik6.TypyTreninku == null)
                //{
                //    cvik6.TypyTreninku = new List<string>();
                //}
                //cvik6.TypyTreninku.Add("BSHVMNohy");
                //var cvik7 = new Cvik { Název = "Rumunský dřep", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                //if (cvik7.TypyTreninku == null)
                //{
                //    cvik7.TypyTreninku = new List<string>();
                //}
                //cvik7.TypyTreninku.Add("BSHVMNohy");
                //var cvik8 = new Cvik { Název = "Hiptrusty", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                //if (cvik8.TypyTreninku == null)
                //{
                //    cvik8.TypyTreninku = new List<string>();
                //}
                //cvik8.TypyTreninku.Add("BSHVMNohy");
                //var cvik9 = new Cvik { Název = "Lýtka ve stoje", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                //if (cvik9.TypyTreninku == null)
                //{
                //    cvik9.TypyTreninku = new List<string>();
                //}
                //cvik9.TypyTreninku.Add("BSHVMNohy");
                ;
                //Ramena + biceps

                var cvik11 = new Cvik { Název = "Tlaky na ramena - rozcvička", PopisCviku = "Zahřátí + aktivace (velmi malá nebo žádná váha)", Partie = "Ramena", UzivatelId = userId };
                if (cvik11.TypyTreninku == null)
                {
                    cvik11.TypyTreninku = new List<string>();
                }
                if (cvik11.PočtySérií == null)
                {
                    cvik11.PočtySérií = new List<int>();
                    cvik11.PočtyOpakování = new List<string>();
                    cvik11.PauzyMeziSériemi = new List<int>();
                }
                cvik11.TypyTreninku.Add("BSHVMRamBic");
                cvik11.PočtySérií.Add(2);
                cvik11.PočtyOpakování.Add("10, 10");
                cvik11.PauzyMeziSériemi.Add(30);
                //var cvik12 = new Cvik { Název = "Tlaky na ramena s jednoručnou činkou", PočetSérií = 5, PočetOpakování = "12, 12, 10, 8, 5", PauzaMeziSériemi = 60, PopisCviku = "Tlaky na ramena", Partie = "Ramena", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik13 = new Cvik { Název = "Upažování s jednoručnou činkou", PočetSérií = 4, PočetOpakování = "12, 12, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Upažování s jednoručkama na ramena", Partie = "Ramena", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik14 = new Cvik { Název = "Stroj na zadky ramen", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Stroj na zadky ramen", Partie = "Ramena", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik15 = new Cvik { Název = "Upažování na kladce", PočetSérií = 3, PočetOpakování = "10, 10, 10", PauzaMeziSériemi = 50, PopisCviku = "Upažování na kladce zespodu", Partie = "Ramena", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik16 = new Cvik { Název = "Tlaky na stroji", PočetSérií = 4, PočetOpakování = "12, 10, 8, 6", PauzaMeziSériemi = 60, PopisCviku = "Tlaky na stroji, dodělání ramen", Partie = "Ramena", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik17 = new Cvik { Název = "Bicepsové přítahy jednoruček", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Přítahy jednoruček", Partie = "Biceps", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik18 = new Cvik { Název = "Bicepsové přítahy obouručky", PočetSérií = 3, PočetOpakování = "10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Přítahy obouručky", Partie = "Biceps", TypTreninku = "BSHVMRamBic", UzivatelId = userId };
                //var cvik19 = new Cvik { Název = "Bicepsové přítahy na stroji", PočetSérií = 3, PočetOpakování = "10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Přítahy na stroji", Partie = "Biceps", TypTreninku = "BSHVMRamBic", UzivatelId = userId };

                ////Hrudník + triceps

                var cvik20 = new Cvik { Název = "Kliky", PopisCviku = "Klasické kliky - záhřátí aktivace", Partie = "Hrudník", UzivatelId = userId };
                if (cvik20.TypyTreninku == null)
                {
                    cvik20.TypyTreninku = new List<string>();
                }
                if (cvik20.PočtySérií == null)
                {
                    cvik20.PočtySérií = new List<int>();
                    cvik20.PočtyOpakování = new List<string>();
                    cvik20.PauzyMeziSériemi = new List<int>();
                }
                cvik20.TypyTreninku.Add("BSHVMHrTric");
                cvik20.PočtySérií.Add(3);
                cvik20.PočtyOpakování.Add("10, 10, 10");
                cvik20.PauzyMeziSériemi.Add(40);
                //var cvik21 = new Cvik { Název = "Benchpress", PočetSérií = 5, PočetOpakování = "15, 10, 5, 2, 1 ", PauzaMeziSériemi = 60, PopisCviku = "Komplexni cvik benchpress", Partie = "Hrudník", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik22 = new Cvik { Název = "Tlaky na hrudník na nakloněné lavici", PočetSérií = 4, PočetOpakování = "12, 12, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Tlaky na lavici na hrudník", Partie = "Hrudník", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik23 = new Cvik { Název = "Pec deck", PočetSérií = 4, PočetOpakování = "12, 12, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Tlaky na stoji", Partie = "Hrudník", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik24 = new Cvik { Název = "Stahování kladek na hrudník", PočetSérií = 3, PočetOpakování = "12, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Stahování kladek v předklonu na hrudník", Partie = "Hrudník", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik25 = new Cvik { Název = "Dipy na bradle", PočetSérií = 3, PočetOpakování = "10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Dipy na bradle s vlastní váhou nebo se závažim", Partie = "Trieps", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik26 = new Cvik { Název = "Tricepsové stahování kladky", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Stahování kladky na triceps", Partie = "Trieps", TypTreninku = "BSHVMHrTric", UzivatelId = userId };
                //var cvik27 = new Cvik { Název = "Tricepsové stahování kladky za hlavu", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Stahování kladky na triceps za hlavu", Partie = "Trieps", TypTreninku = "BSHVMHrTric", UzivatelId = userId };

                ////Záda

                var cvik28 = new Cvik { Název = "Mrtvý tah bez závaží", PopisCviku = "Mrtvý tah bez závaží (zatínat svaly) - záhřátí aktivace", Partie = "Záda", UzivatelId = userId };
                if (cvik28.TypyTreninku == null)
                {
                    cvik28.TypyTreninku = new List<string>();
                }
                if (cvik28.PočtySérií == null)
                {
                    cvik28.PočtySérií = new List<int>();
                    cvik28.PočtyOpakování = new List<string>();
                    cvik28.PauzyMeziSériemi = new List<int>();
                }
                cvik28.TypyTreninku.Add("BSHVMZada");
                cvik28.PočtySérií.Add(3);
                cvik28.PočtyOpakování.Add("10, 10, 10");
                cvik28.PauzyMeziSériemi.Add(40);
                //var cvik29 = new Cvik { Název = "Mrtvý tah", PočetSérií = 5, PočetOpakování = "10, 5, 5, 3, 1", PauzaMeziSériemi = 90, PopisCviku = "Mrtvý tah - komplexni cvik", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik30 = new Cvik { Název = "Shyby nadhmatem", PočetSérií = 4, PočetOpakování = "10, 8, 6, 4", PauzaMeziSériemi = 60, PopisCviku = "Shyby", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik31 = new Cvik { Název = "Stahování tyče na stroji před hlavu - vertikálně", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Stahování na stoji", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik32 = new Cvik { Název = "Přitahování tyče na stroji - horizontálně", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Stahování na stoji", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik33 = new Cvik { Název = "Přitahování na stroji", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Přitahování na stoji", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik34 = new Cvik { Název = "Přitahování tyče ve stoje", PočetSérií = 3, PočetOpakování = "10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Přitahování ve stoje", Partie = "Záda", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik35 = new Cvik { Název = "Plank", PočetSérií = 3, PočetOpakování = "1min, 1min, co nejdéle", PauzaMeziSériemi = 60, PopisCviku = "Plank", Partie = "Břicho", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik36 = new Cvik { Název = "Sklapovačky", PočetSérií = 3, PočetOpakování = "10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Sklapovačky", Partie = "Břicho", TypTreninku = "BSHVMZada", UzivatelId = userId };
                //var cvik37 = new Cvik { Název = "Přitahování noh na bradlech", PočetSérií = 3, PočetOpakování = "10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Přitahování noh na bradlech", Partie = "Břicho", TypTreninku = "BSHVMZada", UzivatelId = userId };



                //KR podhlavni

                //Kruhový trénik 1

                //var cvik38 = new Cvik { Název = "Zadní dřepy", PočetSérií = 5, PočetOpakování = "x", PauzaMeziSériemi = 0, PopisCviku = "Silový cvik dřep", Partie = "Nohy", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik39 = new Cvik { Název = "Legpress", PočetSérií = 4, PočetOpakování = "10, 10, 12, 12", PauzaMeziSériemi = 60, PopisCviku = "Popis legpress", Partie = "Nohy", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik40 = new Cvik { Název = "Zákopy", PočetSérií = 4, PočetOpakování = "10, 10, 12, 12", PauzaMeziSériemi = 60, PopisCviku = "Popis zákopy", Partie = "Nohy", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik41 = new Cvik { Název = "Mrtvý tah", PočetSérií = 5, PočetOpakování = "10, 5, 5, 3, 1", PauzaMeziSériemi = 90, PopisCviku = "Mrtvý tah - komplexni cvik", Partie = "Záda", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik42 = new Cvik { Název = "Shyby nadhmatem", PočetSérií = 4, PočetOpakování = "10, 8, 6, 4", PauzaMeziSériemi = 60, PopisCviku = "Shyby", Partie = "Záda", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik43 = new Cvik { Název = "Stahování tyče na stroji před hlavu - vertikálně", PočetSérií = 4, PočetOpakování = "10, 10, 10, 10", PauzaMeziSériemi = 60, PopisCviku = "Stahování na stoji", Partie = "Záda", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik44 = new Cvik { Název = "Benchpress", PočetSérií = 5, PočetOpakování = "15, 10, 5, 2, 1 ", PauzaMeziSériemi = 60, PopisCviku = "Komplexni cvik benchpress", Partie = "Hrudník", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik45 = new Cvik { Název = "Tlaky na hrudník na nakloněné lavici", PočetSérií = 4, PočetOpakování = "12, 12, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Tlaky na lavici na hrudník", Partie = "Hrudník", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik46 = new Cvik { Název = "Bicepsové přítahy jednoruček", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Přítahy jednoruček", Partie = "Biceps", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik47 = new Cvik { Název = "Bicepsové přítahy obouručky", PočetSérií = 3, PočetOpakování = "10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Přítahy obouručky", Partie = "Biceps", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik48 = new Cvik { Název = "Tricepsové stahování kladky", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Stahování kladky na triceps", Partie = "Trieps", TypTreninku = "BSHKR1", UzivatelId = userId };
                //var cvik49 = new Cvik { Název = "Tricepsové stahování kladky za hlavu", PočetSérií = 4, PočetOpakování = "12, 10, 10, 8", PauzaMeziSériemi = 60, PopisCviku = "Stahování kladky na triceps za hlavu", Partie = "Trieps", TypTreninku = "BSHKR1", UzivatelId = userId };

                //vyhledat jeden cvik a podle toho v jakem je planu/treninku jej upravit

                var cviky = new List<Cvik> {
                        cvik1, cvik2, cvik3,// cvik4, cvik5, cvik6, cvik7, cvik8, cvik9,
                        cvik11,// cvik12, cvik13, cvik14, cvik15, cvik16, cvik17, cvik18, cvik19,
                        cvik20, //cvik21, cvik22, cvik23, cvik24, cvik25, cvik26, cvik27,
                        cvik28, //cvik29, cvik30, cvik31, cvik32, cvik33, cvik34, cvik35, cvik36, cvik37
                    };

                foreach (var cvik in cviky)
                {
                    _context.Cvik.Add(cvik);
                }

                var uzivatel = await _context.Users
                                .Where(dt => dt.Id == userId)
                                .ToListAsync();
                uzivatel[0].PridaneData = true;
                _context.SaveChanges();

            }
            return RedirectToAction("Index"); // Přesměrujte na stránku s výpisem cviků https://localhost:xxxxx/Cvik/PridejData
        }




        // GET: Cvik
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.uzivatelId = userId;
            return View(await _context.Cvik.ToListAsync());
        }

        // GET: Cvik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvik = await _context.Cvik
                .FirstOrDefaultAsync(m => m.CvikId == id);
            if (cvik == null)
            {
                return NotFound();
            }

            return View(cvik);
        }

        // GET: Cvik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cvik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CvikId,Název,PočetOpakování,PočetSérií,PauzaMeziSériemi,Partie,PopisCviku")] Cvik cvik)
        {
            if (ModelState.ContainsKey("UzivatelId"))
            {
                ModelState.Remove("UzivatelId");
            }
            if (ModelState.IsValid)
            {
                var uzivatelId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                cvik.UzivatelId = uzivatelId;

                var uzivatelTPZaznam = await _context.TP.SingleOrDefaultAsync(tp => tp.UzivatelID == uzivatelId);

                //if(uzivatelTPZaznam.DruhTP == "BSH")              JE TO BLBE UDELANE PREDELAT
                //{
                //    if(uzivatelTPZaznam.StylTP == "VM")
                //    {
                //        if (cvik.Partie == "Nohy")
                //        {
                //            cvik.TypTreninku = "BSHVMNohy";
                //        }
                //        else if (cvik.Partie == "Biceps")
                //        {
                //            cvik.TypTreninku = "BSHVMRamBic";
                //        }
                //        else if (cvik.Partie == "Ramena")
                //        {
                //            cvik.TypTreninku = "BSHVMRamBic";
                //        }
                //        else if (cvik.Partie == "Záda")
                //        {
                //            cvik.TypTreninku = "BSHVMZada";
                //        }
                //        else if (cvik.Partie == "Hrudník")
                //        {
                //            cvik.TypTreninku = "BSHVMHrTric";
                //        } 
                //        else if(cvik.Partie == "Triceps")
                //        {
                //            cvik.TypTreninku = "BSHVMHrTric";
                //        }
                //    } else if(uzivatelTPZaznam.StylTP == "PPL")
                //    {

                //    } else if(uzivatelTPZaznam.StylTP == "KR")
                //    {

                //    }
                //} else if (uzivatelTPZaznam.DruhTP == "SR")
                //{

                //} else if(uzivatelTPZaznam.DruhTP == "RV")
                //{

                //}

                _context.Add(cvik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cvik);
        }

        // GET: Cvik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvik = await _context.Cvik.FindAsync(id);
            if (cvik == null)
            {
                return NotFound();
            }
            return View(cvik);
        }

        // POST: Cvik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CvikId,Název,PočetOpakování,PočetSérií,PauzaMeziSériemi,PopisCviku")] Cvik cvik)
        {
            if (id != cvik.CvikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvikExists(cvik.CvikId))
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
            return View(cvik);
        }

        // GET: Cvik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cvik = await _context.Cvik
                .FirstOrDefaultAsync(m => m.CvikId == id);
            if (cvik == null)
            {
                return NotFound();
            }

            return View(cvik);
        }

        // POST: Cvik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cvik = await _context.Cvik.FindAsync(id);
            if (cvik != null)
            {
                _context.Cvik.Remove(cvik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvikExists(int id)
        {
            return _context.Cvik.Any(e => e.CvikId == id);
        }





    }
}
