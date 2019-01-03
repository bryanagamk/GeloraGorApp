using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeloraGorApp.Models
{
    public class Lapangan
    {
        public int Id { get; set; }
        public int JenisId { get; set; }
        public string NamaLapangan { get; set; }
        public string Catatan { get; set; }
        public Double Harga { get; set; }
        public string Foto { get; set; }
        public JenisLapangan Jenis { get; set; }
        public ICollection<Jadwal> Jadwals { get; set; } = new List<Jadwal>();
    }
}
