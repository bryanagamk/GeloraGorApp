using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeloraGorApp.Models
{
    public class Pegawai
    {
        public int Id { get; set; }
        public string NamaPegawai { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Alamat { get; set; }
        public Double NoTelp { get; set; }
        public ICollection<Jadwal> Jadwals { get; set; } = new List<Jadwal>();
    }
}
