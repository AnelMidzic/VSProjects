using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfParametriVjezba
{
    static class KategorijaDal
    {
        public static List<Kategorija> VratiKategorije()
        {
            List<Kategorija> listaKategorija = new List<Kategorija>();

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                SqlCommand komanda = new SqlCommand("SELECT * FROM Kategorija", konekcija);

                try
                {
                    konekcija.Open();
                    SqlDataReader dr = komanda.ExecuteReader();
                    while (dr.Read())
                    {
                        Kategorija k = new Kategorija {
                            KategorijaId = dr.GetInt32(0),
                            Naziv = dr.GetString(1),
                            Opis = dr[2].ToString()
                        };

                        listaKategorija.Add(k);
                    }
                    return listaKategorija;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static int UbaciKategoriju(Kategorija k)
        {
            string upit = @"INSERT INTO Kategorija VALUES (@Naziv, @Opis);
                            SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlConnection konekcija= new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@Naziv", k.Naziv);
                        komanda.Parameters.AddWithValue("@Opis", k.Opis);
                        konekcija.Open();
                        int id = (int)komanda.ExecuteScalar();
                        return id;
                    }
                    catch (Exception)
                    {
                        return -1;                        
                    }

                }

            }

        }

        public static int PromjeniKategoriju(Kategorija k)
        {
            string upit = @"UPDATE Kategorija SET Naziv = @Naziv, Opis = @Opis
                            WHERE KategorijaId = @KategorijaId;";

            using (SqlConnection konekcija = new SqlConnection (Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@Naziv", k.Naziv);
                        komanda.Parameters.AddWithValue("@Opis", k.Opis);
                        komanda.Parameters.AddWithValue("@KategorijaId", k.KategorijaId);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        return 0;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int ObrisiKategoriju(int id)
        {
            string upit = "DELETE FROM Kategorija WHERE KategorijaId = @KategorijaId";

            using (SqlConnection konekcija=new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komannda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komannda.Parameters.AddWithValue("KategorijaId", id);
                        konekcija.Open();
                        komannda.ExecuteNonQuery();
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
}
