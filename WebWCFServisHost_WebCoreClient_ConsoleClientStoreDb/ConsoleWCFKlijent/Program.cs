using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWCFKlijent.MagacinServiceReference;

namespace ConsoleWCFKlijent
{
    class Program
    {
        static void Main(string[] args)
        {
            MagacinServiceClient klijent = new MagacinServiceClient();

            ProizvodCon[] listaProizvoda = klijent.VratiProizvode(0);
            klijent.Close();

            foreach (ProizvodCon p in listaProizvoda)
            {
                Console.WriteLine(p.NazivProizvoda + " " + p.Cijena);
            }

            Console.ReadLine();
        }
    }
}
