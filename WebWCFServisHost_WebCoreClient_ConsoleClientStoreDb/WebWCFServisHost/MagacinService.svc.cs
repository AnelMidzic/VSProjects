using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebWCFServisHost.Models;

namespace WebWCFServisHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MagacinService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MagacinService.svc or MagacinService.svc.cs at the Solution Explorer and start debugging.
    public class MagacinService : IMagacinService
    {
        private Magacin db = new Magacin();
        public IEnumerable<KategorijaCon> VratiKategorije()
        {
            IEnumerable<KategorijaCon> listaKategorija = db.Kategorije.Select(k => new KategorijaCon
            {
                KategorijaId = k.KategorijaId,
                NazivKategorije = k.NazivKategorije,
                OpisKategorije = k.OpisKategorije
            });

            return listaKategorija;
        }

        public KategorijaCon VratiKategoriju(int id)
        {
            Kategorija k1 = db.Kategorije.Find(id);

            if (k1 == null)
            {
                return new KategorijaCon { KategorijaId = 0 };
            }

            KategorijaCon k = new KategorijaCon
            {
                KategorijaId = k1.KategorijaId,
                NazivKategorije = k1.NazivKategorije,
                OpisKategorije = k1.OpisKategorije
            };

            return k;
        }

        public IEnumerable<ProizvodCon> VratiProizvode(int id = 0)
        {
            IEnumerable<ProizvodCon> listaProizvoda = db.Proizvodi.Select(p => new ProizvodCon
            {
                ProizvodId = p.ProizvodId,
                KategorijaId = p.KategorijaId,
                NazivProizvoda = p.NazivProizvoda,
                Cijena = p.Cijena,
                KolicinaNaLageru = p.KolicinaNaLageru
            });

            if (id != 0)
            {
                Kategorija k1 = db.Kategorije.Find(id);

                if (k1 != null)
                {
                    listaProizvoda = listaProizvoda.Where(p => p.KategorijaId == id);
                }
            }

            return listaProizvoda;
        }
    }
}
