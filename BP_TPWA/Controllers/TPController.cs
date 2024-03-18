using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Data;
using BP_TPWA.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BP_TPWA.Controllers
{
    public class TPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TPController(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetDenTréninku(string userId, DayOfWeek den, bool trénink)
        {
            var tpRecord = _context.TP.FirstOrDefault(t => t.UzivatelID == userId);

            if (tpRecord != null)
            {
                var konkrétníDen = tpRecord.DnyVTydnu.FirstOrDefault(d => d.Den == den);
                if (konkrétníDen != null)
                {
                    konkrétníDen.DenTréninku = trénink;
                    _context.SaveChanges(); // Uložení změn do databáze
                }
                else
                {
                    // Případ, kdy den není nalezen
                    throw new Exception("Chyba, špatný den!");
                }
            }
        }

        // GET: TP
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TP.Include(t => t.User);
            var tpRecords = await applicationDbContext.ToListAsync();

            foreach (var tpRecord in tpRecords)
            {
                // Zde můžete pracovat s každým záznamem TP a přistupovat k jeho vlastnostem, včetně User.
                var ZkontrolovaneDny = tpRecord.ZkontrolovaneDny;
                if (ZkontrolovaneDny == false)
                {
                    var denVTydnuRecords = await _context.DenVTydnu.ToListAsync();
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
        public async Task<IActionResult> Create([Bind("Id,Délka,DruhTP,StylTP,PocetTreninkuZaTyden,DnyVTydnu,UzivatelID,ZkontorlovaneDny")] TP tP)
        {
            if (ModelState.ContainsKey("User"))
            {
                ModelState.Remove("User");
            }
           

            if (ModelState.IsValid)
            {

                _context.Add(tP);
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
    }
}
