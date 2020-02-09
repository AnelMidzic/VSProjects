using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace WpfKorpa2019
{
    static class ProizvodDal
    {
        public static List<Proizvod> VratiProizvode()
        {
            string upit = "SELECT * FROM Proizvod";

            using (SqlConnection konekcija = new SqlConnection(Konekcija.cnnProdavnicaDb))
            {
                try
                {
                    IEnumerable<Proizvod> listaProizvoda =
                        konekcija.Query<Proizvod>(upit).ToList();
                    return listaProizvoda.ToList();
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }
    }
}
