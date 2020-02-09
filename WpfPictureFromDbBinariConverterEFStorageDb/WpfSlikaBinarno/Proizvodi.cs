using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSlikaBinarno
{
    class Proizvodi
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public byte[] Slika { get; set; }
        public string Opis { get; set; }
    }
}
