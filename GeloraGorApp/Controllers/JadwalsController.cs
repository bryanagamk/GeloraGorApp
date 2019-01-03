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
    public class JadwalsController : Controller
    {
        private readonly DataContext _context;

        public JadwalsController(DataContext context)
        {
            _context = context;
        }

        // GET: Jadwals
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Jadwal.Include(j => j.Lapangan).Include(j => j.Pegawai);
            return View(await dataContext.ToListAsync());
        }

        // GET: Jadwals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwal
                .Include(j => j.Lapangan)
                .Include(j => j.Pegawai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jadwal == null)
            {
                return NotFound();
            }

            return View(jadwal);
        }

        // GET: Jadwals/Create
        public IActionResult Create()
        {
            ViewData["LapanganId"] = new SelectList(_context.Lapangan, "Id", "Id");
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "Id");
            return View();
        }

        // POST: Jadwals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LapanganId,PegawaiId,WaktuAwal,WaktuAkhir,Catatan")] Jadwal jadwal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jadwal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LapanganId"] = new SelectList(_context.Lapangan, "Id", "Id", jadwal.LapanganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "Id", jadwal.PegawaiId);
            return View(jadwal);
        }

        // GET: Jadwals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwal.FindAsync(id);
            if (jadwal == null)
            {
                return NotFound();
            }
            ViewData["LapanganId"] = new SelectList(_context.Lapangan, "Id", "Id", jadwal.LapanganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "Id", jadwal.PegawaiId);
            return View(jadwal);
        }

        // POST: Jadwals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LapanganId,PegawaiId,WaktuAwal,WaktuAkhir,Catatan")] Jadwal jadwal)
        {
            if (id != jadwal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jadwal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JadwalExists(jadwal.Id))
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
            ViewData["LapanganId"] = new SelectList(_context.Lapangan, "Id", "Id", jadwal.LapanganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "Id", jadwal.PegawaiId);
            return View(jadwal);
        }

        // GET: Jadwals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwal
                .Include(j => j.Lapangan)
                .Include(j => j.Pegawai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jadwal == null)
            {
                return NotFound();
            }

            return View(jadwal);
        }

        // POST: Jadwals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jadwal = await _context.Jadwal.FindAsync(id);
            _context.Jadwal.Remove(jadwal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JadwalExists(int id)
        {
            return _context.Jadwal.Any(e => e.Id == id);
        }
    }
}
