using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace WpfSlikaBinarno
{
    class ProizvodDal
    {
        public static List<Proizvodi> VratiProizvode()
        {
            string upit = "SELECT * FROM Proizvod";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnBazaSlika))
            {
                try
                {
                    IEnumerable<Proizvodi> listaProizvoda =
                        konekcija.Query<Proizvodi>(upit);
                    return listaProizvoda.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        //aaaa
        public static int UbaciProizvod(Proizvodi p)
        {
            string upit = @"INSERT INTO Proizvod VALUES (@Naziv, @Slika, @Opis)
                            SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnBazaSlika))
            {
                try
                {
                    int id = konekcija.QuerySingleOrDefault<int>(upit, p);
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }

            
        }

        public static int PromijeniProizvod(Proizvodi p)
        {
            string upit = @"UPDATE Proizvod SET Naziv=@Naziv, Slika=@Slika, Opis=@Opis
                            WHERE ProizvodId =@ProizvodId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnBazaSlika))
            {
                try
                {
                    konekcija.Execute(upit, p);
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public static int ObrisiProizvod(int id)
        {
            string upit = @"DELETE FROM Proizvod WHERE ProizvodId = @ProizvodId";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnBazaSlika))
            {
                try
                {
                    konekcija.Execute(upit, new { ProizvodId = id });
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
    }
}
