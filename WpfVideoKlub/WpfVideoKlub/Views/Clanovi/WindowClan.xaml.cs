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
using WpfVideoKlub.Models;
using WpfVideoKlub.DAL;

namespace WpfVideoKlub.Views.Clanovi
{
    /// <summary>
    /// Interaction logic for WindowClan.xaml
    /// </summary>
    public partial class WindowClan : Window
    {
        private List<Clan> listaClanova = null;
        private ClanDal cDal = null;

        public WindowClan()
        {
            InitializeComponent();

            VideoKlub2019 db = new VideoKlub2019();
            cDal = new ClanDal(db);
        }

        private void PrikaziClanove()
        {
            listaClanova = cDal.VratiClanove();
            ListBox1.ItemsSource = null;
            ListBox1.ItemsSource = listaClanova;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziClanove();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1)
            {
                Clan c1 = ListBox1.SelectedItem as Clan;

                TextBoxIme.Text = c1.Ime;
                TextBoxPrezime.Text = c1.Prezime;
                TextBoxLicnaKarta.Text = c1.LicnaKarta;
                TextBoxUlicaBroj.Text = c1.UlicaBroj;
                TextBoxMesto.Text = c1.Mesto;
            }
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            WindowClanPromjena w1 = new WindowClanPromjena();
            w1.Title = "Unesite podatke o clanu";
            w1.Owner = this;

            if (w1.ShowDialog() == true)
            {
                Clan c1 = w1.Clan;

                int id = cDal.UbaciClana(c1);

                if (id != -1)
                {
                    PrikaziClanove();
                    ListBox1.SelectedIndex = listaClanova
                        .FindIndex(c => c.ClanId == id);
                    MessageBox.Show("Ubacen novi clan");
                }
                else
                {
                    MessageBox.Show("Greska pri unosu clana");
                }
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite clana");
                return;
            }
            Clan clanZaPromjenu = ListBox1.SelectedItem as Clan;
            WindowClanPromjena w1 = new WindowClanPromjena();
            w1.Title = "Promijeni podatke o clanu";
            w1.Owner = this;
            int id = clanZaPromjenu.ClanId;
            w1.Clan = clanZaPromjenu;

            if (w1.ShowDialog()==true)
            {
                clanZaPromjenu = w1.Clan;
                clanZaPromjenu.ClanId = id;

                int rezultat = cDal.PromeniClana(clanZaPromjenu);

                if (rezultat==0)
                {
                    PrikaziClanove();
                    ListBox1.SelectedIndex = listaClanova
                        .FindIndex(c => c.ClanId == id);
                    MessageBox.Show("Podaci promjenjeni");
                }
                else
                {
                    MessageBox.Show("Greska pri promjeni");
                }
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi clana");
                return;
            }
            Clan c1 = ListBox1.SelectedItem as Clan;

            MessageBoxResult mbr = MessageBox.Show("Brisanje clana: " + c1.ToString(), "Brisanje", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            int rezultat = cDal.ObrisiClana(c1);

            if (rezultat == 0)
            {
                PrikaziClanove();
                TextBoxIme.Clear();
                TextBoxPrezime.Clear();
                TextBoxLicnaKarta.Clear();
                TextBoxUlicaBroj.Clear();
                TextBoxMesto.Clear();
                MessageBox.Show("Clan obrisan");
            }
            else
            {
                MessageBox.Show("Greska pri brisanju clana");
            }
        }
    }
}
