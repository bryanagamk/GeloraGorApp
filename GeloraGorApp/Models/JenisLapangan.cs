using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeloraGorApp.Models
{
    public class JenisLapangan
    {
        public int Id { get; set; }
        public string NamaJenis { get; set; }
        public ICollection<Lapangan> Lapangans { get; set; } = new List<Lapangan>();
    }
}
