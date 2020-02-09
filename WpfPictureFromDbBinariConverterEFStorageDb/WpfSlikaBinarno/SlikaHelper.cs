using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfSlikaBinarno
{
    static class SlikaHelper
    {
        public static byte[] KreirajNizBajtova(BitmapImage bmp)
        {
            BitmapFrame bf = BitmapFrame.Create(bmp);
            JpegBitmapEncoder enc = new JpegBitmapEncoder();
            enc.Frames.Add(bf);
            using (MemoryStream ms = new MemoryStream())
            {
                enc.Save(ms);
                return ms.ToArray();
            }
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

        public static BitmapImage KreirajBitmapuIzMemorije(byte[] podaci)
        {
            using (MemoryStream ms = new MemoryStream(podaci))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = ms;
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.EndInit();
                return bmp;
            }
        }

        public static List<Border> VratiListuBordera(List<Proizvodi> listaProizvoda)
        {
            List<Border> listaBordera = new List<Border>();

            foreach (Proizvodi p1 in listaProizvoda)
            {
                BitmapImage bmp = KreirajBitmapuIzMemorije(p1.Slika);
                Image img1 = new Image();
                img1.Source = bmp;
                img1.Stretch = Stretch.Fill;
                Border b = new Border
                {
                    Width = 80,
                    Height = 60,
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5),
                    Tag = p1
                };

                b.Child = img1;
                listaBordera.Add(b);
            }

            return listaBordera;
        }
    }
}
