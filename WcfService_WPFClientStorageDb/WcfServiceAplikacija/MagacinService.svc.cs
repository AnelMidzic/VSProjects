using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceAplikacija.Models;
using System.Data.SqlClient;

namespace WcfServiceAplikacija
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MagacinService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MagacinService.svc or MagacinService.svc.cs at the Solution Explorer and start debugging.
    public class MagacinService : IMagacinService
    {
        private string CnnMagacin
        {
            get
            {
                SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder();
                cnnSb.DataSource = @".\SqlExpress";
                cnnSb.InitialCatalog = "MagacinTehnika";
                cnnSb.IntegratedSecurity = true;
                return cnnSb.ToString();
            }
        }
        public List<Kategorija> VratiKategorije()
        {
            string upit = "SELECT * FROM Kategorija";
            List<Kategorija> listaKategorija = new List<Kategorija>();

            using (SqlConnection konekcija = new SqlConnection(CnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    try
                    {
                        konekcija.Open();
                        SqlDataReader dr = komanda.ExecuteReader();

                        while (dr.Read())
                        {
                            Kategorija k1 = new Kategorija
                            {
                                KategorijaId = dr.GetInt32(0),
                                NazivKategorije = dr.GetString(1),
                                OpisKategorije = dr.GetString(2)
                            };

                            listaKategorija.Add(k1);
                        }

                        return listaKategorija;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public List<Proizvod> VratiProizvode(int id = 0)
        {
            List<Proizvod> listaProizvoda = new List<Proizvod>();

            string upit = "SELECT * FROM Proizvod";

            if (id != 0)
            {
                upit = "SELECT * FROM Proizvod WHERE KategorijaId = @KategorijaId";
            }

            using (SqlConnection konekcija = new SqlConnection(CnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand(upit, konekcija))
                {
                    if (id != 0)
                    {
                        komanda.Parameters.AddWithValue("@KategorijaId", id);
                    }

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
                                NazivProizvoda = dr.GetString(2),
                                Cijena = dr.GetDecimal(3),
                                KolicinaNaLageru = dr.GetInt32(4)
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
    }
}
