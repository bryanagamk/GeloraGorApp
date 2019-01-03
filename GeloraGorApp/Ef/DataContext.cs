using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeloraGorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GeloraGorApp.Ef
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<JenisLapangan> JenisLapangan { get; set; }
        public DbSet<Lapangan> Lapangan { get; set; }
        public DbSet<Pegawai> Pegawai { get; set; }
        public DbSet<Jadwal> Jadwal { get; set; }
    }
}
