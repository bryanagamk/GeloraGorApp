using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeloraGorApp.Ef;
using GeloraGorApp.Models;

namespace GeloraGorApp.Controllers
{
    public class LapangansController : Controller
    {
        private readonly DataContext _context;

        public LapangansController(DataContext context)
        {
            _context = context;
        }

        // GET: Lapangans
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Lapangan.Include(l => l.Jenis);
            return View(await dataContext.ToListAsync());
        }

        // GET: Lapangans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangan
                .Include(l => l.Jenis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lapangan == null)
            {
                return NotFound();
            }

            return View(lapangan);
        }

        // GET: Lapangans/Create
        public IActionResult Create()
        {
            ViewData["JenisId"] = new SelectList(_context.JenisLapangan, "Id", "Id");
            return View();
        }

        // POST: Lapangans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JenisId,NamaLapangan,Catatan,Harga,Foto")] Lapangan lapangan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lapangan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JenisId"] = new SelectList(_context.JenisLapangan, "Id", "Id", lapangan.JenisId);
            return View(lapangan);
        }

        // GET: Lapangans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangan.FindAsync(id);
            if (lapangan == null)
            {
                return NotFound();
            }
            ViewData["JenisId"] = new SelectList(_context.JenisLapangan, "Id", "Id", lapangan.JenisId);
            return View(lapangan);
        }

        // POST: Lapangans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JenisId,NamaLapangan,Catatan,Harga,Foto")] Lapangan lapangan)
        {
            if (id != lapangan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lapangan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LapanganExists(lapangan.Id))
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
            ViewData["JenisId"] = new SelectList(_context.JenisLapangan, "Id", "Id", lapangan.JenisId);
            return View(lapangan);
        }

        // GET: Lapangans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangan
                .Include(l => l.Jenis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lapangan == null)
            {
                return NotFound();
            }

            return View(lapangan);
        }

        // POST: Lapangans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lapangan = await _context.Lapangan.FindAsync(id);
            _context.Lapangan.Remove(lapangan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LapanganExists(int id)
        {
            return _context.Lapangan.Any(e => e.Id == id);
        }
    }
}
