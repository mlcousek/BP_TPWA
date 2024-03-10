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

namespace BP_TPWA.Controllers
{
    public class TPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TPController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TP
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TP.Include(t => t.User);
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
        public async Task<IActionResult> Create([Bind("Id,Délka,DruhTP,StylTP,PocetTreninkuZaTyden,UzivatelID")] TP tP)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Délka,DruhTP,StylTP,PocetTreninkuZaTyden,UzivatelID")] TP tP)
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
