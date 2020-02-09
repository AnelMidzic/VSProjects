using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfWcfKlijent.MagacinServiceReference;

namespace WpfWcfKlijent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MagacinServiceClient klijent = new MagacinServiceClient();
            Kategorija[] listaKategorija = klijent.VratiKategorije();
            klijent.Close();
            ListBox1.DisplayMemberPath = "NazivKategorije";

            foreach (Kategorija k in listaKategorija)
            {
                ListBox1.Items.Add(k);
            }
            klijent.Close();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kategorija k = ListBox1.SelectedItem as Kategorija;
            MagacinServiceClient klijent = new MagacinServiceClient();
            Proizvod[] listaProizvoda = klijent.VratiProizvode(k.KategorijaId);
            StringBuilder sb = new StringBuilder();
            foreach (Proizvod p in listaProizvoda)
            {
                sb.AppendLine(p.NazivProizvoda + p.Cijena);                
            }
            TextBlock1.Text = sb.ToString();
        }
    }
}
