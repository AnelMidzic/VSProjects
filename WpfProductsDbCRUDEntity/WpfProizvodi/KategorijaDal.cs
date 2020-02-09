﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfProizvodi
{
    class KategorijaDal
    {
        public static List<Kategorija> VratiKategorije()
        {
            List<Kategorija> listaKategorija = new List<Kategorija>();

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnMagacin))
            {
                using (SqlCommand komanda = new SqlCommand("SELECT * FROM Kategorija;", konekcija))
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
                                Naziv = dr.GetString(1),
                                Opis = dr[2].ToString()
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
    }
}