using System;
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

namespace BP_TPWA.Controllers
{
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


            var applicationDbContext = _context.TreninkoveData.Include(t => t.Cvik).Include(t => t.Uzivatel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TreninkoveData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treninkoveData = await _context.TreninkoveData
                .Include(t => t.Cvik)
                .Include(t => t.Uzivatel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treninkoveData == null)
            {
                return NotFound();
            }

            return View(treninkoveData);
        }

        // GET: TreninkoveData/Create
        public IActionResult Create()
        {
            ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId");
            ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TreninkoveData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UzivatelId,Datum,CvikId,CisloSerie,PocetOpakovani,CvicenaVaha")] TreninkoveData treninkoveData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treninkoveData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId", treninkoveData.CvikId);
            ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id", treninkoveData.UzivatelId);
            return View(treninkoveData);
        }

        // GET: TreninkoveData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treninkoveData = await _context.TreninkoveData.FindAsync(id);
            if (treninkoveData == null)
            {
                return NotFound();
            }
            ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId", treninkoveData.CvikId);
            ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id", treninkoveData.UzivatelId);
            return View(treninkoveData);
        }

        // POST: TreninkoveData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UzivatelId,Datum,CvikId,CisloSerie,PocetOpakovani,CvicenaVaha")] TreninkoveData treninkoveData)
        {
            if (id != treninkoveData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treninkoveData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreninkoveDataExists(treninkoveData.Id))
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
            ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId", treninkoveData.CvikId);
            ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id", treninkoveData.UzivatelId);
            return View(treninkoveData);
        }

        // GET: TreninkoveData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treninkoveData = await _context.TreninkoveData
                .Include(t => t.Cvik)
                .Include(t => t.Uzivatel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treninkoveData == null)
            {
                return NotFound();
            }

            return View(treninkoveData);
        }

        // POST: TreninkoveData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treninkoveData = await _context.TreninkoveData.FindAsync(id);
            if (treninkoveData != null)
            {
                _context.TreninkoveData.Remove(treninkoveData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreninkoveDataExists(int id)
        {
            return _context.TreninkoveData.Any(e => e.Id == id);
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
                
                
                if(data.Vaha != null)
                {
                    double cislo;

                    if (double.TryParse(data.Vaha, NumberStyles.Number, CultureInfo.InvariantCulture, out cislo))
                    {
                        kUlozeni.VahaUzivatele = cislo;
                    }
                    else
                    {
                        // Něco provedete, když se nepodaří převést řetězec na double
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
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    kUlozeni.UzivatelId = userId;
                    var uzivatelIdZaznam = await _context.Users.SingleOrDefaultAsync(tp => tp.Id == userId);
                    kUlozeni.VahaUzivatele = uzivatelIdZaznam.Váha;
                }

                _context.Add(kUlozeni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            //ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId", data.CvikId);
            //ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id", treninkoveData.UzivatelId);
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
                    // Vyhledej všechny záznamy s odpovídajícím cvikId a datem
                    var zaznamyKSmazani = await _context.TreninkoveData
                        .Where(t => t.CvikId == cvikId && t.Datum == datum && t.UzivatelId == uzivatelId)
                        .ToListAsync();

                    // Ověř, zda byly nalezeny nějaké záznamy
                    if (zaznamyKSmazani.Any())
                    {
                        // Pokud ano, odeber všechny nalezené záznamy
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
