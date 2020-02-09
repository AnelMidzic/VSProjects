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
//using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfSlika2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Kategorija> listaKategorija = null;
        private string odabranaSlika = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrikaziKategorije()
        {            
            listaKategorija = KategorijaDal.VratiKategorije();

            if (listaKategorija != null)
            {
                DataGrid1.ItemsSource = listaKategorija;
            }
        }

        private void Resetuj()
        {
            odabranaSlika = "";
            TextBoxId.Clear();
            TextBoxNaziv.Clear();
            TextBoxOpis.Clear();
            Image1.Source = null;
            DataGrid1.SelectedIndex = -1;
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite naziv");
                TextBoxNaziv.Focus();
                return false;
            }
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string folder = SlikaHelper.VratiFolderSaSlikama();

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                MessageBox.Show("Folder za slike je kreiran");
            }

            PrikaziKategorije();
        }

        private void ButtonResetuj_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            odabranaSlika = "";

            if (DataGrid1.SelectedIndex > -1)
            {
                Kategorija k = DataGrid1.SelectedItem as Kategorija;

                TextBoxId.Text = k.KategorijaId.ToString();
                TextBoxNaziv.Text = k.Naziv;
                TextBoxOpis.Text = k.Opis;

                string putanjaSlike = SlikaHelper.VratiPutanjuSlike(k.Slika);
                Uri adresa = new Uri(putanjaSlike, UriKind.Absolute);
                BitmapImage bmp = SlikaHelper.KreirajBitmapu(adresa);
                Image1.Source = bmp;
            }
        }

        private void ButtonOdaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.InitialDirectory = @"C:\Users\Anel\Pictures";
            openDlg.Filter = @"Slike|*.jpg;*.png;*.bmp;*.gif";

            if (openDlg.ShowDialog() == true)
            {
                odabranaSlika = openDlg.FileName;
                Uri adresa = new Uri(odabranaSlika, UriKind.Absolute);
                BitmapImage bmp = SlikaHelper.KreirajBitmapu(adresa);
                Image1.Source = bmp;
            }
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
            {
                return;
            }

            if (odabranaSlika == "")
            {
                MessageBox.Show("Odaberi sliku");
                return;
            }

            Kategorija k = new Kategorija
            {
                Naziv = TextBoxNaziv.Text,
                Opis = TextBoxOpis.Text
            };

            string ime = k.Naziv + Path.GetExtension(odabranaSlika);
            k.Slika = ime;

            int id = KategorijaDal.UbaciKategoriju(k);

            if (id == -1)
            {
                MessageBox.Show("Greska pri unosu");
            }
            else
            {
                string putanjaSlike = SlikaHelper.VratiPutanjuSlike(ime);

                try
                {
                    File.Copy(odabranaSlika, putanjaSlike);
                }
                catch (Exception xcp)
                {
                    MessageBox.Show(xcp.Message);
                    return;
                }

                PrikaziKategorije();

                int indeks = listaKategorija.FindIndex(k1 => k1.KategorijaId == id);
                DataGrid1.Focus();
                DataGrid1.SelectedIndex = indeks;
                DataGrid1.ScrollIntoView(DataGrid1.Items[indeks]);
                MessageBox.Show("Kreirana je kategorija");
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {

            if (DataGrid1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi kategoriju");
                return;
            }

            if (!Validacija())
            {
                return;
            }

            int indeks = DataGrid1.SelectedIndex;

            Kategorija k = DataGrid1.SelectedItem as Kategorija;

            string staraSlika = k.Slika;

            string novaSlika = "";

            if (odabranaSlika != "")
            {
                novaSlika = SlikaHelper.KreirajNovoImeSlike(staraSlika);
                k.Slika = novaSlika;
            }

            k.Naziv = TextBoxNaziv.Text;
            k.Opis = TextBoxOpis.Text;

            int rezultat = KategorijaDal.PromijeniKategoriju(k);

            if (rezultat == 0)
            {
                if (odabranaSlika != "")
                {
                    string putanjaStareSlike = SlikaHelper.VratiPutanjuSlike(staraSlika);
                    string putanjaNoveSlike = SlikaHelper.VratiPutanjuSlike(novaSlika);

                    try
                    {
                        File.Delete(putanjaStareSlike);
                        File.Copy(odabranaSlika, putanjaNoveSlike);
                    }
                    catch (Exception xcp)
                    {
                        MessageBox.Show(xcp.Message);
                        return;
                    }
                }
                MessageBox.Show("Promjenjena kategorija");
                PrikaziKategorije();
                DataGrid1.SelectedIndex = indeks;
            }            
            else
            {
                MessageBox.Show("Greska pri promjeni kategorije");
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi kategoriju");
                return;
            }

            Kategorija k = DataGrid1.SelectedItem as Kategorija;

            MessageBoxResult mbr = MessageBox.Show(k.Naziv, "Brisanje", MessageBoxButton.YesNo);

            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            int rezultat = KategorijaDal.ObrisiKategoriju(k.KategorijaId);

            if (rezultat == 0)
            {
                string putanjaSlike = SlikaHelper.VratiPutanjuSlike(k.Slika);

                try
                {
                    File.Delete(putanjaSlike);
                }
                catch (Exception xcp)
                {
                    MessageBox.Show(xcp.Message);
                    return;
                }

                MessageBox.Show("Kategorija obrisana");
                PrikaziKategorije();
                Resetuj();
            }
        }
    }
}
