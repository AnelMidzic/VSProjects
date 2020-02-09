using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEf05.Models;

namespace WpfEf05.DAL
{
    class KategorijaDal
    {
        private Magacin db;

        public KategorijaDal(Magacin _db)
        {
            db = _db;
        }

        public List<Kategorija> VratiKategorije()
        {
            return db.Kategorije.ToList();
        }

        public int UbaciKategoriju(Kategorija k)
        {
            try
            {
                db.Kategorije.Add(k);
                db.SaveChanges();
                return k.KategorijaId;
            }
            catch (Exception)
            {
                db.Entry(k).State = EntityState.Detached;
                return -1;
            }
        }

        public int PromeniKategoriju(Kategorija k)
        {
            Kategorija k1 = db.Kategorije.Find(k.KategorijaId);

            if (k1 != null)
            {
                try
                {
                    k1.Naziv = k.Naziv;
                    k1.Opis = k.Opis;
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    db.Entry(k).State = EntityState.Unchanged;
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public int ObrisiKategoriju(Kategorija k)
        {
            Kategorija k1 = db.Kategorije.Find(k.KategorijaId);
            
            if (k1 != null)
            {
                try
                {
                    db.Kategorije.Remove(k1);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    db.Entry(k).State = EntityState.Unchanged;
                    return -1;
                }
            }
            else
            {
                return -1;
            }
            
        }
    }
}
