using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace WpfSlika2019
{
    static class SlikaHelper
    {
        public static string VratiFolderSaSlikama()
        {
            string root = Directory.GetCurrentDirectory();
            string putanja = Path.Combine(root, "Slike");
            return putanja;
        }

        public static string VratiPutanjuSlike(string slika)
        {
            string folder = VratiFolderSaSlikama();
            return Path.Combine(folder, slika);
        }

        public static BitmapImage KreirajBitmapu(Uri adresa)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = adresa;
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();
            return bmp;
        }

        public static string KreirajNovoImeSlike(string slika)
        {
            string imeBezEkstenzije = Path.GetFileNameWithoutExtension(slika);
            string ekstenzija = Path.GetExtension(slika);
            string imeBezBrojeva = new string(imeBezEkstenzije.TakeWhile(c => char.IsLetter(c)).ToArray());
            string brojevi = new string(imeBezEkstenzije.SkipWhile(c => char.IsLetter(c)).ToArray());

            int broj = 1;
            if (brojevi != "")
            {
                broj = int.Parse(brojevi);
                broj++;
            }
            return imeBezBrojeva + broj + ekstenzija;
        }
    }
}
