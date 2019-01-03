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
    public class JenisLapangansController : Controller
    {
        private readonly DataContext _context;

        public JenisLapangansController(DataContext context)
        {
            _context = context;
        }

        // GET: JenisLapangans
        public async Task<IActionResult> Index()
        {
            return View(await _context.JenisLapangan.ToListAsync());
        }

        // GET: JenisLapangans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisLapangan = await _context.JenisLapangan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jenisLapangan == null)
            {
                return NotFound();
            }

            return View(jenisLapangan);
        }

        // GET: JenisLapangans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisLapangans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaJenis")] JenisLapangan jenisLapangan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisLapangan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisLapangan);
        }

        // GET: JenisLapangans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisLapangan = await _context.JenisLapangan.FindAsync(id);
            if (jenisLapangan == null)
            {
                return NotFound();
            }
            return View(jenisLapangan);
        }

        // POST: JenisLapangans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaJenis")] JenisLapangan jenisLapangan)
        {
            if (id != jenisLapangan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisLapangan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisLapanganExists(jenisLapangan.Id))
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
            return View(jenisLapangan);
        }

        // GET: JenisLapangans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisLapangan = await _context.JenisLapangan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jenisLapangan == null)
            {
                return NotFound();
            }

            return View(jenisLapangan);
        }

        // POST: JenisLapangans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisLapangan = await _context.JenisLapangan.FindAsync(id);
            _context.JenisLapangan.Remove(jenisLapangan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisLapanganExists(int id)
        {
            return _context.JenisLapangan.Any(e => e.Id == id);
        }
    }
}
