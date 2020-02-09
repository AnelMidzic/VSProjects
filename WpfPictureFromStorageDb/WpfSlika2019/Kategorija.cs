using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSlika2019
{
    class Kategorija
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public string Opis { get; set; }

        public override string ToString() => Naziv;
    }
}
