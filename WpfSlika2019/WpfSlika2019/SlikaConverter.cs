using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfSlika2019
{
    class SlikaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ulaz = value?.ToString() ?? "";

            if (ulaz != "") 
            {
                string putanjaSlike = SlikaHelper.VratiPutanjuSlike(ulaz);
                Uri adresa = new Uri(putanjaSlike, UriKind.Absolute);
                BitmapImage bmp = SlikaHelper.KreirajBitmapu(adresa);
                return bmp;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
