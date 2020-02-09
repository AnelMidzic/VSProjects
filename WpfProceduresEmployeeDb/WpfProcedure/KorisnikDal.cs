using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfProcedure
{
    static class KorisnikDal
    {
        public static List<Korisnik> VratiKorisnike()
        {
            List<Korisnik> listaKorisnika = new List<Korisnik>();

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnKorisnikDB))
            {
                using (SqlCommand komanda = new SqlCommand("VratiKorisnike",konekcija))
                {
                    komanda.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        konekcija.Open();
                        SqlDataReader dr = komanda.ExecuteReader();
                        while (dr.Read())
                        {
                            Korisnik k = new Korisnik
                            {
                                KorisnikId = dr.GetInt32(0),
                                Ime = dr.GetString(1),
                                Prezime = dr.GetString(2),
                                Email = dr.GetString(3)
                            };

                            listaKorisnika.Add(k);
                        }
                        return listaKorisnika;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public static int UbaciKorisnika(Korisnik k)
        {
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnKorisnikDB))
            {
                using (SqlCommand komanda = new SqlCommand("UbaciKorisnike",konekcija))
                {
                    komanda.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        komanda.Parameters.AddWithValue("@Ime", k.Ime);
                        komanda.Parameters.AddWithValue("@Prezime", k.Prezime);
                        komanda.Parameters.AddWithValue("@Email", k.Email);

                        SqlParameter IdParametar = new SqlParameter("@KorisnikId", SqlDbType.Int);
                        IdParametar.Direction = ParameterDirection.Output;
                        komanda.Parameters.Add(IdParametar);
                        konekcija.Open();
                        komanda.ExecuteNonQuery();
                        int id = (int)IdParametar.Value;
                        return id;
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int PromijeniKorisnika(Korisnik k)
        {
            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnKorisnikDB))
            {
                using (SqlCommand komanda = new SqlCommand("PromijeniKorisnika", konekcija))
                {
                    komanda.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        komanda.Parameters.AddWithValue("@Ime", k.Ime);
                        komanda.Parameters.AddWithValue("@Prezime", k.Prezime);
                        komanda.Parameters.AddWithValue("@Email", k.Email);
                        komanda.Parameters.AddWithValue("@KorisnikId", k.KorisnikId);


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

        public static int ObrisiKorisnika(int id)
        {
            using (SqlConnection konekcija = new SqlConnection (Konekcija.cnnKorisnikDB))
            {
                using (SqlCommand komanda = new SqlCommand("ObrisiKorisnika", konekcija))
                {
                    komanda.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        komanda.Parameters.AddWithValue("@KorisnikId", id);
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
