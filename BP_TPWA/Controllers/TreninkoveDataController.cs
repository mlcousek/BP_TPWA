﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Data;
using BP_TPWA.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace BP_TPWA.Controllers
{
    [Authorize]
    public class TreninkoveDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreninkoveDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TreninkoveData
        public async Task<IActionResult> Index()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();
            var tpdata = _context.TP
                    .Where(id => id.UzivatelID == userId)
                    .ToList();

            ViewBag.treninkovedata = datacviku;
            ViewBag.tpdata = tpdata;

            var applicationDbContext = _context.TreninkoveData.Include(t => t.Cvik);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Maximalky
        public async Task<IActionResult> Maximalky()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var datacviku = _context.TreninkoveData
                        .Where(id => id.UzivatelId == userId)
                        .ToList();
            var tpdata = _context.TP
                    .Where(id => id.UzivatelID == userId)
                    .ToList();

            ViewBag.treninkovedata = datacviku;
            ViewBag.tpdata = tpdata;


            var applicationDbContext = _context.TreninkoveData.Include(t => t.Cvik);
            return View(await applicationDbContext.ToListAsync());
        }

        // POST: TreninkoveData/SaveToDatabase
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> SaveToDatabase(DataZFrontendu data)
        {
            if (data != null)
            {
                TreninkoveData kUlozeni = new TreninkoveData();
                kUlozeni.CisloSerie = data.CisloSerie;
                kUlozeni.PocetOpakovani = data.PocetOpakovani;
                kUlozeni.CvicenaVaha = data.CvicenaVaha;
                kUlozeni.CvikId = data.CvikId;

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                kUlozeni.UzivatelId = userId;


                if (data.Vaha != null)
                {
                    double cislo;

                    if (double.TryParse(data.Vaha, NumberStyles.Number, CultureInfo.InvariantCulture, out cislo))
                    {
                        kUlozeni.VahaUzivatele = cislo;
                    }
                    else
                    {
                        return BadRequest("Nepodařilo se převést váhu na desetinné číslo.");
                    }
                }

                DateTime datum;
                if (DateTime.TryParse(data.Datum, out datum))
                {
                    kUlozeni.Datum = datum;
                }
                else
                {
                    return RedirectToAction("Index", "TP");
                }

                if (data.Vaha == null)
                {
                    var uzivatelIdZaznam = await _context.Users.SingleOrDefaultAsync(tp => tp.Id == userId);
                    kUlozeni.VahaUzivatele = uzivatelIdZaznam.Váha;
                }

                _context.Add(kUlozeni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(data);
        }

        // POST: TreninkoveData/DeleteFromDatabase
        public async Task<IActionResult> DeleteFromDatabase(DataZFrontendu data)
        {
            if (data != null)
            {
                var cvikId = data.CvikId;
                var uzivatelId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                DateTime datum;
                if (DateTime.TryParse(data.Datum, out datum))
                {
                    var zaznamyKSmazani = await _context.TreninkoveData
                        .Where(t => t.CvikId == cvikId && t.Datum == datum && t.UzivatelId == uzivatelId)
                        .ToListAsync();

                    if (zaznamyKSmazani.Any())
                    {
                        _context.TreninkoveData.RemoveRange(zaznamyKSmazani);
                        await _context.SaveChangesAsync();
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Index", "TP");
                }
            }

            return View(data);
        }
    }
}
