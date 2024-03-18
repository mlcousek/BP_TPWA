using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BP_TPWA.Data;
using BP_TPWA.Models;

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
        public IActionResult PridejData()
        {
            // Vytvořte instance cviků
          //  var cvik1 = new Cvik { Název = "Benchpress" }; musím pořešit ty serie a počet opáček

            // Přidejte cviky do databáze
           // _context.Cvik.Add(cvik1);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Přesměrujte na stránku s výpisem cviků https://localhost:xxxxx/Cvik/PridejData
        }


        // GET: Cvik
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> Create([Bind("CvikId,Název,PočetOpakování,PočetSérií,PauzaMeziSériemi,PopisCviku")] Cvik cvik)
        {
            if (ModelState.IsValid)
            {
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
