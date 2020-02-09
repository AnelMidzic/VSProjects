using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace WpfSlika2019
{
    static class KategorijaDal
    {
        public static List<Kategorija> VratiKategorije()
        {
            string upit = "SELECT * FROM Kategorija";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                try
                {
                    IEnumerable<Kategorija> listaKategorija = 
                        konekcija.Query<Kategorija>(upit);
                    return listaKategorija.ToList();
                }
                catch (Exception xcp)
                {
                    return null;
                }
            }
        }

        public static int UbaciKategoriju(Kategorija k)
        {

            string upit = @"INSERT INTO Kategorija VALUES(@Naziv, @Slika, @Opis)
                            SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                try
                {
                    int id = konekcija.QuerySingleOrDefault<int>(upit, k);
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            
        }

        public static int PromijeniKategoriju(Kategorija k)
        {
            string upit = @"UPDATE Kategorija SET Naziv = @Naziv, Slika=@Slika, Opis=@Opis
                            WHERE KategorijaId =@KategorijaId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                try
                {
                    konekcija.Execute(upit, k);
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public static int ObrisiKategoriju(int id)
        {
            string upit = @"DELETE FROM Kategorija
                            WHERE KategorijaId=@KategorijaId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                try
                {
                    konekcija.Execute(upit, new { KategorijaId = id });
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
