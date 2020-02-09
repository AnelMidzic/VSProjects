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

namespace WpfParametriVjezba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Kategorija> listaKategorija = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrikaziKategorije()
        {
            listaKategorija = KategorijaDal.VratiKategorije();

            if (listaKategorija != null)
            {
                foreach (Kategorija k in listaKategorija)
                {
                    ComboBox1.Items.Add(k);
                }
            }
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxNaziv.Clear();
            TextBoxOpis.Clear();
            ComboBox1.SelectedIndex = -1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox1.SelectedIndex > -1)
            {
                Kategorija k = ComboBox1.SelectedItem as Kategorija;
                TextBoxId.Text = k.KategorijaId.ToString();
                TextBoxNaziv.Text = k.Naziv;
                TextBoxOpis.Text = k.Opis;
            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite naziv kategorije");
                TextBoxNaziv.Focus();
                return false;
            }
            return true;
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                Kategorija k = new Kategorija
                {
                    Naziv = TextBoxNaziv.Text,
                    Opis = TextBoxOpis.Text
                };

                int id = KategorijaDal.UbaciKategoriju(k);

                if (id==-1)
                {
                    MessageBox.Show("Greska pri cuvanju podataka");
                }
                else
                {
                    PrikaziKategorije();
                    ComboBox1.SelectedIndex = listaKategorija.FindIndex(k1 => k1.KategorijaId == id);
                    MessageBox.Show("Sacuvani podaci");
                }
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex <0)
            {
                MessageBox.Show("Odaberi kategoriju");
                return;
            }

            if (Validacija())
            {
                Kategorija k = ComboBox1.SelectedItem as Kategorija;
                k.Naziv = TextBoxNaziv.Text;
                k.Opis = TextBoxOpis.Text;

                int rezultat = KategorijaDal.PromjeniKategoriju(k);

                if(rezultat == -1)
                {
                    MessageBox.Show("Greska pri promjeni podataka");
                }
                else
                {
                    PrikaziKategorije();
                    ComboBox1.SelectedIndex = listaKategorija.FindIndex(k1 => k1.KategorijaId == k.KategorijaId);
                    MessageBox.Show("Podaci promjenjeni");
                }
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex <0)
            {
                MessageBox.Show("Odaberi kategoriju");
                return;
            }

            Kategorija k = ComboBox1.SelectedItem as Kategorija;

            MessageBoxResult mbr = MessageBox.Show($"Brisanje kategorije: {k.Naziv}", "Brisanje", MessageBoxButton.YesNo);

            if (mbr==MessageBoxResult.No)
            {
                return;
            }

            int rezultat = KategorijaDal.ObrisiKategoriju(k.KategorijaId);

            if (rezultat == -1)
            {
                MessageBox.Show("Greska pri brisanju");
            }
            else
            {
                PrikaziKategorije();
                Resetuj();
                MessageBox.Show("Podaci obrisani");
            }
        }
    }
}
