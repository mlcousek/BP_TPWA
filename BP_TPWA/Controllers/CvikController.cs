using System;
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
                cvik2.PočtyOpakování.Add("12, 10, 5, 2, 1");
                cvik2.PauzyMeziSériemi.Add(0);
                var cvik3 = new Cvik { Název = "Legpress", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik3.TypyTreninku == null)
                {
                    cvik3.TypyTreninku = new List<string>();
                }
                cvik3.TypyTreninku.Add("BSHVMNohy");
                if (cvik3.PočtySérií == null)
                {
                    cvik3.PočtySérií = new List<int>();
                    cvik3.PočtyOpakování = new List<string>();
                    cvik3.PauzyMeziSériemi = new List<int>();
                }
                cvik3.PočtySérií.Add(4);
                cvik3.PočtyOpakování.Add("10, 10, 12, 12");
                cvik3.PauzyMeziSériemi.Add(60);


                //Test
                //if (cvik3.PočtySérií == null)
                //{
                //    cvik3.PočtySérií = new List<int>();
                //    cvik3.PočtyOpakování = new List<string>();
                //    cvik3.PauzyMeziSériemi = new List<int>();
                //}
                ////cvik3.TypyTreninku.Add("BSHVMRamBic");
                ////cvik3.PočtySérií.Add(2);
                ////cvik3.PočtyOpakování.Add("10, 10");
                ////cvik3.PauzyMeziSériemi.Add(100);

                var cvik4 = new Cvik { Název = "Zákopy", PopisCviku = "Popis zákopy", Partie = "Nohy", UzivatelId = userId };
                if (cvik4.TypyTreninku == null)
                {
                    cvik4.TypyTreninku = new List<string>();
                }
                cvik4.TypyTreninku.Add("BSHVMNohy");
                if (cvik4.PočtySérií == null)
                {
                    cvik4.PočtySérií = new List<int>();
                    cvik4.PočtyOpakování = new List<string>();
                    cvik4.PauzyMeziSériemi = new List<int>();
                }
                cvik4.PočtySérií.Add(4);
                cvik4.PočtyOpakování.Add("10, 10, 12, 12");
                cvik4.PauzyMeziSériemi.Add(60);

                var cvik5 = new Cvik { Název = "Předkopy", PopisCviku = "Popis předkopy", Partie = "Nohy", UzivatelId = userId };
                if (cvik5.TypyTreninku == null)
                {
                    cvik5.TypyTreninku = new List<string>();
                }
                cvik5.TypyTreninku.Add("BSHVMNohy");
                if (cvik5.PočtySérií == null)
                {
                    cvik5.PočtySérií = new List<int>();
                    cvik5.PočtyOpakování = new List<string>();
                    cvik5.PauzyMeziSériemi = new List<int>();
                }
                cvik5.PočtySérií.Add(4);
                cvik5.PočtyOpakování.Add("10, 10, 12, 12");
                cvik5.PauzyMeziSériemi.Add(60);
                var cvik6 = new Cvik { Název = "Bulharský dřep", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik6.TypyTreninku == null)
                {
                    cvik6.TypyTreninku = new List<string>();
                }
                cvik6.TypyTreninku.Add("BSHVMNohy");
                if (cvik6.PočtySérií == null)
                {
                    cvik6.PočtySérií = new List<int>();
                    cvik6.PočtyOpakování = new List<string>();
                    cvik6.PauzyMeziSériemi = new List<int>();
                }
                cvik6.PočtySérií.Add(4);
                cvik6.PočtyOpakování.Add("10, 10, 12, 12");
                cvik6.PauzyMeziSériemi.Add(60);
                var cvik7 = new Cvik { Název = "Rumunský dřep", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik7.TypyTreninku == null)
                {
                    cvik7.TypyTreninku = new List<string>();
                }
                cvik7.TypyTreninku.Add("BSHVMNohy");
                if (cvik7.PočtySérií == null)
                {
                    cvik7.PočtySérií = new List<int>();
                    cvik7.PočtyOpakování = new List<string>();
                    cvik7.PauzyMeziSériemi = new List<int>();
                }
                cvik7.PočtySérií.Add(4);
                cvik7.PočtyOpakování.Add("10, 10, 12, 12");
                cvik7.PauzyMeziSériemi.Add(60);
                var cvik8 = new Cvik { Název = "Hiptrusty", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik8.TypyTreninku == null)
                {
                    cvik8.TypyTreninku = new List<string>();
                }
                cvik8.TypyTreninku.Add("BSHVMNohy");
                if (cvik8.PočtySérií == null)
                {
                    cvik8.PočtySérií = new List<int>();
                    cvik8.PočtyOpakování = new List<string>();
                    cvik8.PauzyMeziSériemi = new List<int>();
                }
                cvik8.PočtySérií.Add(4);
                cvik8.PočtyOpakování.Add("10, 10, 10, 10");
                cvik8.PauzyMeziSériemi.Add(60);
                var cvik9 = new Cvik { Název = "Lýtka ve stoje", PopisCviku = "Popis legpress", Partie = "Nohy", UzivatelId = userId };
                if (cvik9.TypyTreninku == null)
                {
                    cvik9.TypyTreninku = new List<string>();
                }
                cvik9.TypyTreninku.Add("BSHVMNohy");
                if (cvik9.PočtySérií == null)
                {
                    cvik9.PočtySérií = new List<int>();
                    cvik9.PočtyOpakování = new List<string>();
                    cvik9.PauzyMeziSériemi = new List<int>();
                }
                cvik9.PočtySérií.Add(4);
                cvik9.PočtyOpakování.Add("10, 10, 12, 12");
                cvik9.PauzyMeziSériemi.Add(60);

                //Ramena + biceps

                var cvik11 = new Cvik { Název = "Tlaky na ramena - rozcvička", PopisCviku = "Zahřátí + aktivace (velmi malá nebo žádná váha)", Partie = "Ramena", UzivatelId = userId };
                if (cvik11.TypyTreninku == null)
                {
                    cvik11.TypyTreninku = new List<string>();
                    cvik11.PočtySérií = new List<int>();
                    cvik11.PočtyOpakování = new List<string>();
                    cvik11.PauzyMeziSériemi = new List<int>();
                }
                cvik11.TypyTreninku.Add("BSHVMRamBic");
                cvik11.PočtySérií.Add(2);
                cvik11.PočtyOpakování.Add("10, 10");
                cvik11.PauzyMeziSériemi.Add(30);
                var cvik12 = new Cvik { Název = "Tlaky na ramena s jednoručnou činkou", PopisCviku = "Tlaky na ramena", Partie = "Ramena", UzivatelId = userId };
                if (cvik12.TypyTreninku == null)
                {
                    cvik12.TypyTreninku = new List<string>();
                    cvik12.PočtySérií = new List<int>();
                    cvik12.PočtyOpakování = new List<string>();
                    cvik12.PauzyMeziSériemi = new List<int>();
                }
                cvik12.TypyTreninku.Add("BSHVMRamBic");
                cvik12.PočtySérií.Add(5);
                cvik12.PočtyOpakování.Add("12, 12, 10, 8, 5");
                cvik12.PauzyMeziSériemi.Add(60);
                var cvik13 = new Cvik { Název = "Upažování s jednoručnou činkou", PopisCviku = "Upažování s jednoručkama na ramena", Partie = "Ramena", UzivatelId = userId };
                if (cvik13.TypyTreninku == null)
                {
                    cvik13.TypyTreninku = new List<string>();
                    cvik13.PočtySérií = new List<int>();
                    cvik13.PočtyOpakování = new List<string>();
                    cvik13.PauzyMeziSériemi = new List<int>();
                }
                cvik13.TypyTreninku.Add("BSHVMRamBic");
                cvik13.PočtySérií.Add(4);
                cvik13.PočtyOpakování.Add("12, 12, 10, 10");
                cvik13.PauzyMeziSériemi.Add(60);
                var cvik14 = new Cvik { Název = "Stroj na zadky ramen", PopisCviku = "Stroj na zadky ramen", Partie = "Ramena", UzivatelId = userId };
                if (cvik14.TypyTreninku == null)
                {
                    cvik14.TypyTreninku = new List<string>();
                    cvik14.PočtySérií = new List<int>();
                    cvik14.PočtyOpakování = new List<string>();
                    cvik14.PauzyMeziSériemi = new List<int>();
                }
                cvik14.TypyTreninku.Add("BSHVMRamBic");
                cvik14.PočtySérií.Add(4);
                cvik14.PočtyOpakování.Add("10, 10, 10, 10");
                cvik14.PauzyMeziSériemi.Add(60);
                var cvik15 = new Cvik { Název = "Upažování na kladce", PopisCviku = "Upažování na kladce zespodu", Partie = "Ramena", UzivatelId = userId };
                if (cvik15.TypyTreninku == null)
                {
                    cvik15.TypyTreninku = new List<string>();
                    cvik15.PočtySérií = new List<int>();
                    cvik15.PočtyOpakování = new List<string>();
                    cvik15.PauzyMeziSériemi = new List<int>();
                }
                cvik15.TypyTreninku.Add("BSHVMRamBic");
                cvik15.PočtySérií.Add(3);
                cvik15.PočtyOpakování.Add("10, 10, 10");
                cvik15.PauzyMeziSériemi.Add(50);
                var cvik16 = new Cvik { Název = "Tlaky na stroji", PopisCviku = "Tlaky na stroji, dodělání ramen", Partie = "Ramena", UzivatelId = userId };
                if (cvik16.TypyTreninku == null)
                {
                    cvik16.TypyTreninku = new List<string>();
                    cvik16.PočtySérií = new List<int>();
                    cvik16.PočtyOpakování = new List<string>();
                    cvik16.PauzyMeziSériemi = new List<int>();
                }
                cvik16.TypyTreninku.Add("BSHVMRamBic");
                cvik16.PočtySérií.Add(4);
                cvik16.PočtyOpakování.Add("10, 10, 8, 6");
                cvik16.PauzyMeziSériemi.Add(60);
                var cvik17 = new Cvik { Název = "Bicepsové přítahy jednoruček", PopisCviku = "Přítahy jednoruček", Partie = "Biceps", UzivatelId = userId };
                if (cvik17.TypyTreninku == null)
                {
                    cvik17.TypyTreninku = new List<string>();
                    cvik17.PočtySérií = new List<int>();
                    cvik17.PočtyOpakování = new List<string>();
                    cvik17.PauzyMeziSériemi = new List<int>();
                }
                cvik17.TypyTreninku.Add("BSHVMRamBic");
                cvik17.PočtySérií.Add(4);
                cvik17.PočtyOpakování.Add("10, 10, 10, 8");
                cvik17.PauzyMeziSériemi.Add(60);
                var cvik18 = new Cvik { Název = "Bicepsové přítahy obouručky", PopisCviku = "Přítahy obouručky", Partie = "Biceps", UzivatelId = userId };
                if (cvik18.TypyTreninku == null)
                {
                    cvik18.TypyTreninku = new List<string>();
                    cvik18.PočtySérií = new List<int>();
                    cvik18.PočtyOpakování = new List<string>();
                    cvik18.PauzyMeziSériemi = new List<int>();
                }
                cvik18.TypyTreninku.Add("BSHVMRamBic");
                cvik18.PočtySérií.Add(3);
                cvik18.PočtyOpakování.Add("10, 10, 8");
                cvik18.PauzyMeziSériemi.Add(60);
                var cvik19 = new Cvik { Název = "Bicepsové přítahy na stroji", PopisCviku = "Přítahy na stroji", Partie = "Biceps", UzivatelId = userId };
                if (cvik19.TypyTreninku == null)
                {
                    cvik19.TypyTreninku = new List<string>();
                    cvik19.PočtySérií = new List<int>();
                    cvik19.PočtyOpakování = new List<string>();
                    cvik19.PauzyMeziSériemi = new List<int>();
                }
                cvik19.TypyTreninku.Add("BSHVMRamBic");
                cvik19.PočtySérií.Add(3);
                cvik19.PočtyOpakování.Add("10, 10, 8");
                cvik19.PauzyMeziSériemi.Add(60);

                ////Hrudník + triceps

                var cvik20 = new Cvik { Název = "Kliky", PopisCviku = "Klasické kliky - záhřátí aktivace", Partie = "Hrudník", UzivatelId = userId };
                if (cvik20.TypyTreninku == null)
                {
                    cvik20.TypyTreninku = new List<string>();
                    cvik20.PočtySérií = new List<int>();
                    cvik20.PočtyOpakování = new List<string>();
                    cvik20.PauzyMeziSériemi = new List<int>();
                }
                cvik20.TypyTreninku.Add("BSHVMHrTric");
                cvik20.PočtySérií.Add(3);
                cvik20.PočtyOpakování.Add("10, 10, 10");
                cvik20.PauzyMeziSériemi.Add(40);
                var cvik21 = new Cvik { Název = "Benchpress", PopisCviku = "Komplexni cvik benchpress", Partie = "Hrudník", UzivatelId = userId };
                if (cvik21.TypyTreninku == null)
                {
                    cvik21.TypyTreninku = new List<string>();
                    cvik21.PočtySérií = new List<int>();
                    cvik21.PočtyOpakování = new List<string>();
                    cvik21.PauzyMeziSériemi = new List<int>();
                }
                cvik21.TypyTreninku.Add("BSHVMHrTric");
                cvik21.PočtySérií.Add(5);
                cvik21.PočtyOpakování.Add("15, 10, 5, 2, 1");
                cvik21.PauzyMeziSériemi.Add(60);
                var cvik22 = new Cvik { Název = "Tlaky na hrudník na nakloněné lavici", PopisCviku = "Tlaky na lavici na hrudník", Partie = "Hrudník", UzivatelId = userId };
                if (cvik22.TypyTreninku == null)
                {
                    cvik22.TypyTreninku = new List<string>();
                    cvik22.PočtySérií = new List<int>();
                    cvik22.PočtyOpakování = new List<string>();
                    cvik22.PauzyMeziSériemi = new List<int>();
                }
                cvik22.TypyTreninku.Add("BSHVMHrTric");
                cvik22.PočtySérií.Add(4);
                cvik22.PočtyOpakování.Add("12, 12, 10, 8");
                cvik22.PauzyMeziSériemi.Add(60);
                var cvik23 = new Cvik { Název = "Pec deck", PopisCviku = "Tlaky na stoji", Partie = "Hrudník", UzivatelId = userId };
                if (cvik23.TypyTreninku == null)
                {
                    cvik23.TypyTreninku = new List<string>();
                    cvik23.PočtySérií = new List<int>();
                    cvik23.PočtyOpakování = new List<string>();
                    cvik23.PauzyMeziSériemi = new List<int>();
                }
                cvik23.TypyTreninku.Add("BSHVMHrTric");
                cvik23.PočtySérií.Add(4);
                cvik23.PočtyOpakování.Add("12, 12, 10, 10");
                cvik23.PauzyMeziSériemi.Add(60);
                var cvik24 = new Cvik { Název = "Stahování kladek na hrudník", PopisCviku = "Stahování kladek v předklonu na hrudník", Partie = "Hrudník", UzivatelId = userId };
                if (cvik24.TypyTreninku == null)
                {
                    cvik24.TypyTreninku = new List<string>();
                    cvik24.PočtySérií = new List<int>();
                    cvik24.PočtyOpakování = new List<string>();
                    cvik24.PauzyMeziSériemi = new List<int>();
                }
                cvik24.TypyTreninku.Add("BSHVMHrTric");
                cvik24.PočtySérií.Add(3);
                cvik24.PočtyOpakování.Add("12, 10, 8");
                cvik24.PauzyMeziSériemi.Add(60);
                var cvik25 = new Cvik { Název = "Dipy na bradle", PopisCviku = "Dipy na bradle s vlastní váhou nebo se závažim", Partie = "Trieps", UzivatelId = userId };
                if (cvik25.TypyTreninku == null)
                {
                    cvik25.TypyTreninku = new List<string>();
                    cvik25.PočtySérií = new List<int>();
                    cvik25.PočtyOpakování = new List<string>();
                    cvik25.PauzyMeziSériemi = new List<int>();
                }
                cvik25.TypyTreninku.Add("BSHVMHrTric");
                cvik25.PočtySérií.Add(3);
                cvik25.PočtyOpakování.Add("10, 10, 10");
                cvik25.PauzyMeziSériemi.Add(60);
                var cvik26 = new Cvik { Název = "Tricepsové stahování kladky", PopisCviku = "Stahování kladky na triceps", Partie = "Trieps", UzivatelId = userId };
                if (cvik26.TypyTreninku == null)
                {
                    cvik26.TypyTreninku = new List<string>();
                    cvik26.PočtySérií = new List<int>();
                    cvik26.PočtyOpakování = new List<string>();
                    cvik26.PauzyMeziSériemi = new List<int>();
                }
                cvik26.TypyTreninku.Add("BSHVMHrTric");
                cvik26.PočtySérií.Add(4);
                cvik26.PočtyOpakování.Add("12, 10, 10, 8");
                cvik26.PauzyMeziSériemi.Add(60);
                var cvik27 = new Cvik { Název = "Tricepsové stahování kladky za hlavu", PopisCviku = "Stahování kladky na triceps za hlavu", Partie = "Trieps", UzivatelId = userId };
                if (cvik27.TypyTreninku == null)
                {
                    cvik27.TypyTreninku = new List<string>();
                    cvik27.PočtySérií = new List<int>();
                    cvik27.PočtyOpakování = new List<string>();
                    cvik27.PauzyMeziSériemi = new List<int>();
                }
                cvik27.TypyTreninku.Add("BSHVMHrTric");
                cvik27.PočtySérií.Add(4);
                cvik27.PočtyOpakování.Add("12, 10, 10, 8");
                cvik27.PauzyMeziSériemi.Add(60);

                ////Záda

                var cvik28 = new Cvik { Název = "Mrtvý tah bez závaží", PopisCviku = "Mrtvý tah bez závaží (zatínat svaly) - záhřátí aktivace", Partie = "Záda", UzivatelId = userId };
                if (cvik28.TypyTreninku == null)
                {
                    cvik28.TypyTreninku = new List<string>();
                    cvik28.PočtySérií = new List<int>();
                    cvik28.PočtyOpakování = new List<string>();
                    cvik28.PauzyMeziSériemi = new List<int>();
                }
                cvik28.TypyTreninku.Add("BSHVMZada");
                cvik28.PočtySérií.Add(3);
                cvik28.PočtyOpakování.Add("10, 10, 10");
                cvik28.PauzyMeziSériemi.Add(40);
                // cvik29
                var cvik29 = new Cvik
                {
                    Název = "Mrtvý tah",
                    PopisCviku = "Mrtvý tah - komplexní cvik",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik29.TypyTreninku == null)
                {
                    cvik29.TypyTreninku = new List<string>();
                    cvik29.PočtySérií = new List<int>();
                    cvik29.PočtyOpakování = new List<string>();
                    cvik29.PauzyMeziSériemi = new List<int>();
                }
                cvik29.TypyTreninku.Add("BSHVMZada");
                cvik29.PočtySérií.Add(5);
                cvik29.PočtyOpakování.Add("10, 5, 5, 3, 1");
                cvik29.PauzyMeziSériemi.Add(90);

                // cvik30
                var cvik30 = new Cvik
                {
                    Název = "Shyby nadhmatem",
                    PopisCviku = "Shyby",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik30.TypyTreninku == null)
                {
                    cvik30.TypyTreninku = new List<string>();
                    cvik30.PočtySérií = new List<int>();
                    cvik30.PočtyOpakování = new List<string>();
                    cvik30.PauzyMeziSériemi = new List<int>();
                }
                cvik30.TypyTreninku.Add("BSHVMZada");
                cvik30.PočtySérií.Add(4);
                cvik30.PočtyOpakování.Add("10, 8, 6, 4");
                cvik30.PauzyMeziSériemi.Add(60);

                // cvik31
                var cvik31 = new Cvik
                {
                    Název = "Stahování tyče na stroji před hlavu - vertikálně",
                    PopisCviku = "Stahování na stoji",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik31.TypyTreninku == null)
                {
                    cvik31.TypyTreninku = new List<string>();
                    cvik31.PočtySérií = new List<int>();
                    cvik31.PočtyOpakování = new List<string>();
                    cvik31.PauzyMeziSériemi = new List<int>();
                }
                cvik31.TypyTreninku.Add("BSHVMZada");
                cvik31.PočtySérií.Add(4);
                cvik31.PočtyOpakování.Add("10, 10, 10, 10");
                cvik31.PauzyMeziSériemi.Add(60);

                // cvik32
                var cvik32 = new Cvik
                {
                    Název = "Přitahování tyče na stroji - horizontálně",
                    PopisCviku = "Stahování na stoji",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik32.TypyTreninku == null)
                {
                    cvik32.TypyTreninku = new List<string>();
                    cvik32.PočtySérií = new List<int>();
                    cvik32.PočtyOpakování = new List<string>();
                    cvik32.PauzyMeziSériemi = new List<int>();
                }
                cvik32.TypyTreninku.Add("BSHVMZada");
                cvik32.PočtySérií.Add(4);
                cvik32.PočtyOpakování.Add("10, 10, 10, 10");
                cvik32.PauzyMeziSériemi.Add(60);

                // cvik33
                var cvik33 = new Cvik
                {
                    Název = "Přitahování na stroji",
                    PopisCviku = "Přitahování na stoji",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik33.TypyTreninku == null)
                {
                    cvik33.TypyTreninku = new List<string>();
                    cvik33.PočtySérií = new List<int>();
                    cvik33.PočtyOpakování = new List<string>();
                    cvik33.PauzyMeziSériemi = new List<int>();
                }
                cvik33.TypyTreninku.Add("BSHVMZada");
                cvik33.PočtySérií.Add(4);
                cvik33.PočtyOpakování.Add("10, 10, 10, 10");
                cvik33.PauzyMeziSériemi.Add(60);

                // cvik34
                var cvik34 = new Cvik
                {
                    Název = "Přitahování tyče ve stoje",
                    PopisCviku = "Přitahování ve stoje",
                    Partie = "Záda",
                    UzivatelId = userId
                };
                if (cvik34.TypyTreninku == null)
                {
                    cvik34.TypyTreninku = new List<string>();
                    cvik34.PočtySérií = new List<int>();
                    cvik34.PočtyOpakování = new List<string>();
                    cvik34.PauzyMeziSériemi = new List<int>();
                }
                cvik34.TypyTreninku.Add("BSHVMZada");
                cvik34.PočtySérií.Add(3);
                cvik34.PočtyOpakování.Add("10, 10, 10");
                cvik34.PauzyMeziSériemi.Add(60);

                

                // cvik36
                var cvik36 = new Cvik
                {
                    Název = "Sklapovačky",
                    PopisCviku = "Sklapovačky",
                    Partie = "Břicho",
                    UzivatelId = userId
                };
                if (cvik36.TypyTreninku == null)
                {
                    cvik36.TypyTreninku = new List<string>();
                    cvik36.PočtySérií = new List<int>();
                    cvik36.PočtyOpakování = new List<string>();
                    cvik36.PauzyMeziSériemi = new List<int>();
                }
                cvik36.TypyTreninku.Add("BSHVMZada");
                cvik36.PočtySérií.Add(3);
                cvik36.PočtyOpakování.Add("10, 10, 10");
                cvik36.PauzyMeziSériemi.Add(60);

                // cvik37
                var cvik37 = new Cvik
                {
                    Název = "Přitahování noh na bradlech",
                    PopisCviku = "Přitahování noh na bradlech",
                    Partie = "Břicho",
                    UzivatelId = userId
                };
                if (cvik37.TypyTreninku == null)
                {
                    cvik37.TypyTreninku = new List<string>();
                    cvik37.PočtySérií = new List<int>();
                    cvik37.PočtyOpakování = new List<string>();
                    cvik37.PauzyMeziSériemi = new List<int>();
                }
                cvik37.TypyTreninku.Add("BSHVMZada");
                cvik37.PočtySérií.Add(3);
                cvik37.PočtyOpakování.Add("10, 10, 10");
                cvik37.PauzyMeziSériemi.Add(60);


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
                        cvik1, cvik2, cvik3, cvik4, cvik5, cvik6, cvik7, cvik8, cvik9,
                        cvik11, cvik12, cvik13, cvik14, cvik15, cvik16, cvik17, cvik18, cvik19,
                        cvik20, cvik21, cvik22, cvik23, cvik24, cvik25, cvik26, cvik27,
                        cvik28, cvik29, cvik30, cvik31, cvik32, cvik33, cvik34, cvik36, cvik37
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
