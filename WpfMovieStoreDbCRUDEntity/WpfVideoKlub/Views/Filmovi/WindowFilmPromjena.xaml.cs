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

namespace WpfVideoKlub.Views.Filmovi
{
    /// <summary>
    /// Interaction logic for WindowFilmPromjena.xaml
    /// </summary>
    public partial class WindowFilmPromjena : Window
    {
        private ZanrDal zDal;
        private List<Zanr> listaZanrova;

        public WindowFilmPromjena()
        {
            InitializeComponent();

            VideoKlub2019 db = new VideoKlub2019();
            zDal = new ZanrDal(db);
            listaZanrova = zDal.VratiZanrove();
            ComboBox1.ItemsSource = listaZanrova;
        }

        

        public Film Film
        {
            get {
                Film f1 = new Film();
                f1.Naziv = TextBoxNaziv.Text;

                Zanr z1 = ComboBox1.SelectedItem as Zanr;
                f1.ZanrId = z1.ZanrId;
                f1.Reziser = TextBoxReziser.Text;
                f1.Godina = int.Parse(TextBoxGodina.Text);
                return f1;
            }
            set {
                TextBoxNaziv.Text = value.Naziv;
                ComboBox1.SelectedIndex = listaZanrova
                    .FindIndex(z => z.ZanrId == value.ZanrId);
                TextBoxReziser.Text = value.Reziser;
                TextBoxGodina.Text = value.Godina.ToString();
            }
        }


        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite naziv");
                TextBoxNaziv.Focus();
                return false;
            }

            if (ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberi zanr");
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(TextBoxNaziv.Text))
            {
                MessageBox.Show("Unesite rezisera");
                TextBoxReziser.Focus();
                return false;
            }

            if (!int.TryParse(TextBoxGodina.Text, out int godina))
            {
                MessageBox.Show("Unesite broj");
                TextBoxGodina.Focus();
                return false;
            }
            return true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                DialogResult = true;
            }
        }

        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
