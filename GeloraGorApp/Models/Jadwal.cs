using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeloraGorApp.Models
{
    public class Jadwal
    {
        public int Id { get; set; }
        public int LapanganId { get; set; }
        public int PegawaiId { get; set; }
        public DateTime WaktuAwal { get; set; }
        public DateTime WaktuAkhir { get; set; }
        public string Catatan { get; set; }
        public Lapangan Lapangan { get; set; }
        public Pegawai Pegawai { get; set; }
    }
}
