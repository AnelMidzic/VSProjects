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

namespace WpfProcedure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Korisnik> listaKorisnika = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrikaziKorisnike()
        {
            ComboBox1.Items.Clear();
            listaKorisnika = KorisnikDal.VratiKorisnike();

            if (listaKorisnika !=null)
            {
                foreach (Korisnik k in listaKorisnika)
                {
                    ComboBox1.Items.Add(k);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKorisnike();
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxIme.Clear();
            TextBoxPrezime.Clear();
            TextBoxEmail.Clear();
            ComboBox1.SelectedIndex = -1;
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxIme.Text))
            {
                MessageBox.Show("Niste unijeli ime");
                TextBoxIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxPrezime.Text))
            {
                MessageBox.Show("Niste unijeli prezime");
                TextBoxPrezime.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextBoxEmail.Text))
            {
                MessageBox.Show("Niste unijeli email");
                TextBoxEmail.Focus();
                return false;
            }

            return true;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex > -1)
            {
                Korisnik k = ComboBox1.SelectedItem as Korisnik;
                TextBoxId.Text = k.KorisnikId.ToString();
                TextBoxIme.Text = k.Ime;
                TextBoxPrezime.Text = k.Prezime;
                TextBoxEmail.Text = k.Email;
            }
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                Korisnik k1 = new Korisnik
                {
                    Ime = TextBoxIme.Text,
                    Prezime = TextBoxPrezime.Text,
                    Email = TextBoxEmail.Text
                };

                int id = KorisnikDal.UbaciKorisnika(k1);

                if(id==-1)
                {
                    MessageBox.Show("Greska pri unosu");
                }
                else
                {
                    PrikaziKorisnike();
                    ComboBox1.SelectedIndex = listaKorisnika.FindIndex(k => k.KorisnikId == id);
                    MessageBox.Show("Ubacen novi korisnik");
                }
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi korisnika");
                return;
            }

            if (Validacija())
            {
                Korisnik k = ComboBox1.SelectedItem as Korisnik;

                k.Ime = TextBoxIme.Text;
                k.Prezime = TextBoxPrezime.Text;
                k.Email = TextBoxEmail.Text;

                int rezultat = KorisnikDal.PromijeniKorisnika(k);

                if (rezultat==0)
                {
                    PrikaziKorisnike();
                    ComboBox1.SelectedIndex = listaKorisnika.FindIndex(k1 => k1.KorisnikId == k.KorisnikId);
                    MessageBox.Show("Podaci promijenjeni");
                }
                else
                {
                    MessageBox.Show("Greska pri promjeni");
                }
            }           
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex<0)
            {
                MessageBox.Show("Odaberi korisnika");
                return;
            }

            Korisnik k = ComboBox1.SelectedItem as Korisnik;
            
            MessageBoxResult mbr = MessageBox.Show($"Brisanje korisnika: {k.Ime}", "Brisanje", MessageBoxButton.YesNo);

            if (mbr==MessageBoxResult.No)
            {
                return;
            }

            int rezultat = KorisnikDal.ObrisiKorisnika(k.KorisnikId);

            if (rezultat==-1)
            {
                MessageBox.Show("Greska pri brisanju");
            }
            else
            {
                PrikaziKorisnike();
                Resetuj();
                MessageBox.Show("Podaci obrisani");
            }
        }
    }
}
