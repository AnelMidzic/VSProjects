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
using System.Windows.Shapes;

namespace WpfProizvodi
{
    /// <summary>
    /// Interaction logic for WindowUnos.xaml
    /// </summary>
    public partial class WindowUnos : Window
    {
        private List<Kategorija> listaKategorija = null;

        public WindowUnos()
        {
            InitializeComponent();
        }

        private void PrikaziKategorije()
        {
            ComboKategorija.Items.Clear();

            listaKategorija = KategorijaDal.VratiKategorije();

            if (listaKategorija != null)
            {
                foreach (Kategorija k in listaKategorija)
                {
                    ComboKategorija.Items.Add(k);
                }
            }
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            ComboKategorija.SelectedIndex = -1;
            TextBoxNaziv.Clear();
            TextBoxCijena.Clear();
            TextBoxOpis.Clear();
        }

        private bool Validacija()
        {
            if (ComboKategorija.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi kategoriju");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite naziv proizvoda");
                TextBoxNaziv.Focus();
                return false;
            }

            if (!decimal.TryParse(TextBoxCijena.Text, out decimal cijena))
            {
                MessageBox.Show("Unesite ispravno cijenu");
                TextBoxCijena.Clear();
                TextBoxCijena.Focus();
                return false;
            }
            return true;
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                Kategorija k = ComboKategorija.SelectedItem as Kategorija;
                Proizvod p1 = new Proizvod
                {
                    KategorijaId = k.KategorijaId,
                    Naziv = TextBoxNaziv.Text,
                    Cijena = decimal.Parse(TextBoxCijena.Text),
                    Opis = TextBoxOpis.Text
                };

                int id = ProizvodDal.UbaciProizvod(p1);

                if (id == -1)
                {
                    MessageBox.Show("Greska pri unosu proizvoda");
                }
                else
                {
                    TextBoxId.Text = id.ToString();
                    MessageBox.Show("Proizvod sacuvan");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
        }
    }
}
