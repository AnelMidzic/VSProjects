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
using WpfVideoKlub.Views.Filmovi;

namespace WpfVideoKlub.Views.Filmovi
{
    /// <summary>
    /// Interaction logic for WindowFilm.xaml
    /// </summary>
    public partial class WindowFilm : Window
    {
        private List<Film> listaFilmova = null;
        private FilmDal fDal = null;

        public WindowFilm()
        {
            InitializeComponent();

            VideoKlub2019 db = new VideoKlub2019();
            fDal = new FilmDal(db);
            
        }

        private void PrikaziFilmove()
        {
            listaFilmova = fDal.VratiFilmove();
            ListBox1.ItemsSource = null;
            ListBox1.ItemsSource = listaFilmova;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziFilmove();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1)
            {
                Film f1 = ListBox1.SelectedItem as Film;

                TextBoxNaziv.Text = f1.Naziv;
                TextBoxZanr.Text = f1.Zanr.NazivZanra;
                TextBoxReziser.Text = f1.Reziser;
                TextBoxGodina.Text = f1.Godina.ToString();
            }
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            WindowFilmPromjena w1 = new WindowFilmPromjena();
            w1.Owner = this;
            w1.Title = "Unesi podatke o filmu";

            if (w1.ShowDialog() == true)
            {
                Film f1 = w1.Film;

                int id = fDal.UbaciFilm(f1);

                if (id != -1)
                {
                    PrikaziFilmove();
                    int indeks = listaFilmova.FindIndex(f => f.FilmId == id);
                    ListBox1.SelectedIndex = indeks;
                    ListBox1.ScrollIntoView(ListBox1.Items[indeks]);
                    MessageBox.Show("Ubacen film");
                }
                else
                {
                    MessageBox.Show("Greska pri unosu filma");
                }
            }
            
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite film");
                return;
            }
            Film filmZaPromjenu = ListBox1.SelectedItem as Film;
            WindowFilmPromjena w1 = new WindowFilmPromjena();
            w1.Title = "Promijeni podatke o filmu";
            w1.Owner = this;
            int id = filmZaPromjenu.FilmId;
            w1.Film = filmZaPromjenu;

            if (w1.ShowDialog() == true)
            {
                filmZaPromjenu = w1.Film;
                filmZaPromjenu.FilmId = id;

                int rezultat = fDal.PromijeniFilm(filmZaPromjenu);

                if (rezultat == 0)
                {
                    PrikaziFilmove();
                    ListBox1.SelectedIndex = listaFilmova
                        .FindIndex(c => c.FilmId == id);
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
                MessageBox.Show("Odaberi film");
                return;
            }
            Film c1 = ListBox1.SelectedItem as Film;

            MessageBoxResult mbr = MessageBox.Show("Brisanje filma: " + c1.ToString(), "Brisanje", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            int rezultat = fDal.ObrisiFilm(c1);

            if (rezultat == 0)
            {
                PrikaziFilmove();
                TextBoxNaziv.Clear();
                TextBoxZanr.Clear();
                TextBoxReziser.Clear();
                
                MessageBox.Show("Film obrisan");
            }
            else
            {
                MessageBox.Show("Greska pri brisanju filma");
            }
        }
    }
}
