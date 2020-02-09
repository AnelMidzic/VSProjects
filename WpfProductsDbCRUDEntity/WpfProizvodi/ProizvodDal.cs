using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfProizvodi
{
    static class ProizvodDal
    {
        public static List<Proizvod> VratiProizvode()
        {
            List<Proizvod> listaProizvoda = new List<Proizvod>();

            string upit = "SELECT * FROM Proizvod ORDER BY KategorijaId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit,konekcija))
                {
                    try
                    {
                        konekcija.Open();
                        SqlDataReader dr = komanda.ExecuteReader();

                        while (dr.Read())
                        {
                            Proizvod p1 = new Proizvod
                            {
                                ProizvodId = dr.GetInt32(0),
                                KategorijaId = dr.GetInt32(1),
                                Naziv = dr.GetString(2),
                                Cijena = dr.GetDecimal(3),
                                Opis = dr[4].ToString()
                            };
                            listaProizvoda.Add(p1);
                        }
                        return listaProizvoda;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public static int UbaciProizvod(Proizvod p)
        {
            string upit = @"INSERT INTO Proizvod VALUES (@KategorijaId, @Naziv, @Cena, @Opis);
                            SELECT CAST(SCOPE_IDENTITY() AS int)";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@KategorijaId", p.KategorijaId);
                        komanda.Parameters.AddWithValue("@Naziv", p.Naziv);
                        komanda.Parameters.AddWithValue("@Cena", p.Cijena);
                        komanda.Parameters.AddWithValue("@Opis", p.Opis);

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

        public static int PromijeniProizvod(Proizvod p)
        {
            string upit = @"UPDATE Proizvod SET KategorijaId=@KategorijaId, Naziv=@Naziv, Cena=@Cena, Opis=@Opis
                            WHERE ProizvodId = @ProizvodId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        komanda.Parameters.AddWithValue("@KategorijaId", p.KategorijaId);
                        komanda.Parameters.AddWithValue("@Naziv", p.Naziv);
                        komanda.Parameters.AddWithValue("@Cena", p.Cijena);
                        komanda.Parameters.AddWithValue("@Opis", p.Opis);
                        komanda.Parameters.AddWithValue("@ProizvodId", p.ProizvodId);

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

        public static int ObrisiProizvod(int id)
        {
            string upit = @"DELETE FROM Proizvod WHERE ProizvodId =@ProizvodId;";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {                        
                        komanda.Parameters.AddWithValue("@ProizvodId", id);

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
    }
}
