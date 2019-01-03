using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeloraGorApp.Models;
using GeloraGorApp.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace GeloraGorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        // GET: Jadwals
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Jadwal.Include(j => j.Lapangan).Include(j => j.Pegawai);
            return View(await dataContext.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
