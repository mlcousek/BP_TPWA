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
                DateTime datum;
                if (DateTime.TryParse(data.Datum, out datum))
                {
                    kUlozeni.Datum = datum;
                }
                else
                {
                    return RedirectToAction("Index", "TP");
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                kUlozeni.UzivatelId = userId;

                _context.Add(kUlozeni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

              //ViewData["CvikId"] = new SelectList(_context.Cvik, "CvikId", "CvikId", data.CvikId);
            //ViewData["UzivatelId"] = new SelectList(_context.Users, "Id", "Id", treninkoveData.UzivatelId);
            return View(data);
        }
    }
}
