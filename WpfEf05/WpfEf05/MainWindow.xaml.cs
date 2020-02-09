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
using WpfEf05.Models;
using WpfEf05.DAL;

namespace WpfEf05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KategorijaDal kDal = null;
        private List<Kategorija> listaKategorija = null;


        public MainWindow()
        {
            InitializeComponent();
            Magacin db = new Magacin();
            kDal = new KategorijaDal(db);
        }

        private void PrikaziKategorije()
        {
            ComboBox1.ItemsSource = null;
            listaKategorija = kDal.VratiKategorije();
            ComboBox1.ItemsSource = kDal.VratiKategorije();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
        }

        private void Resetuj()
        {
            TextBoxId.Clear();
            TextBoxNaziv.Clear();
            TextBoxOpis.Clear();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
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
                Kategorija k1 = new Kategorija
                {
                    Naziv = TextBoxNaziv.Text,
                    Opis = TextBoxOpis.Text
                };

                int id = kDal.UbaciKategoriju(k1);

                if (id != -1)
                {
                    PrikaziKategorije();
                    int indeks = listaKategorija.FindIndex(k => k.KategorijaId == id);
                    ComboBox1.SelectedIndex = indeks;
                    MessageBox.Show("Ubacena nova kategorija");
                }
                else
                {
                    MessageBox.Show("Greska pri cuvanju podataka");
                }
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex > -1)
            {
                Kategorija k = ComboBox1.SelectedItem as Kategorija;
                TextBoxId.Text = k.KategorijaId.ToString();
                TextBoxNaziv.Text = k.Naziv;
                TextBoxOpis.Text = k.Opis;
            }
        }
    }
}
