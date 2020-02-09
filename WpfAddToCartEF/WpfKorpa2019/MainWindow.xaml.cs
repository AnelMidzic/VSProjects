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

namespace WpfKorpa2019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, int> korpa = new Dictionary<int, int>();

        private List<Proizvod> listaProizvoda = ProizvodDal.VratiProizvode();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrikaziKupce()
        {
            ComboBox1.ItemsSource = KupacDal.VratiKupce();
        }

        private void PrikaziProizvode()
        {
            ListBox1.ItemsSource = listaProizvoda;
        }

        private void DozvoliKupovinu(bool dozvola)
        {
            GroupBox1.IsEnabled = dozvola;
            ButtonNova.IsEnabled = !dozvola;
        }

        public void Resetuj()
        {
            ComboBox1.SelectedIndex = -1;
            ListBox1.SelectedIndex = -1;
            TextBlockCijena.Text = "";
            TextBoxKolicina.Text = "1";
            TextBlockVrijednost.Text = "";
            korpa.Clear();
            DataGrid1.Items.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKupce();
            PrikaziProizvode();

            DozvoliKupovinu(false);
        }

        private void ButtonNova_Click(object sender, RoutedEventArgs e)
        {
            DozvoliKupovinu(true);
            Resetuj();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1) 
            {
                Proizvod p = ListBox1.SelectedItem as Proizvod;
                TextBlockCijena.Text = p.Cena.ToString();
            }
        }

        private void ButtonOdustani_Click(object sender, RoutedEventArgs e)
        {
            Resetuj();
            DozvoliKupovinu(false);
        }

        public void DodajUkorpu(StavkeKorpe st)
        {
            int id = st.ProizvodId;

            if (korpa.ContainsKey(id))
            {
                korpa[id] += st.Kolicina;
            }
            else
            {
                korpa.Add(id, st.Kolicina);
            }
        }

        private decimal VrijednostKorpe()
        {
            decimal vrijednost = 0;

            foreach (var stavka in korpa)
            {
                Proizvod p1 = listaProizvoda.SingleOrDefault(p => p.ProizvodId == stavka.Key);
                vrijednost += stavka.Value * p1.Cena;
            }

            return vrijednost;
        }

        private void StampajKorpu()
        {
            DataGrid1.Items.Clear();

            foreach (var stavka in korpa)
            {
                Proizvod p1 = listaProizvoda.SingleOrDefault(p => p.ProizvodId == stavka.Key);
                StavkaView sv = new StavkaView
                {
                    ProizvodId = stavka.Key,
                    Naziv = p1.Naziv,
                    Cena = p1.Cena,
                    Kolicina = stavka.Value
                };

                DataGrid1.Items.Add(sv);
            }

            int indeks = DataGrid1.Items.Count - 1;

            if (indeks > -1)
            {
                DataGrid1.Focus();
                DataGrid1.SelectedIndex = indeks;
                DataGrid1.ScrollIntoView(DataGrid1.Items[indeks]);
            }

            TextBlockVrijednost.Text = VrijednostKorpe().ToString();
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedIndex > -1)
            {
                if (int.TryParse(TextBoxKolicina.Text, out int kolicina))
                {
                    Proizvod p = ListBox1.SelectedItem as Proizvod;

                    StavkeKorpe sk = new StavkeKorpe
                    {
                        ProizvodId = p.ProizvodId,
                        Kolicina = kolicina
                    };

                    DodajUkorpu(sk);
                    StampajKorpu();
                }
            }
            else
            {
                MessageBox.Show("Odaberi proizvod");
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = (int)b.CommandParameter;
            Proizvod p = listaProizvoda.SingleOrDefault(p1 => p1.ProizvodId == id);

            Window1 w1 = new Window1();
            w1.Title = "Promijeni proizvod";
            w1.TextBlockProizvod.Text = p.Naziv;
            w1.TextBox1.Text = korpa[id].ToString();
            int indeks= DataGrid1.SelectedIndex;

            if (w1.ShowDialog()==true)
            {
                korpa[id] = int.Parse(w1.TextBox1.Text);
                StampajKorpu();
                DataGrid1.SelectedIndex = indeks;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = (int)b.CommandParameter;
            korpa.Remove(id);
            StampajKorpu();
        }

        private void ButtonKupi_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex > -1)
            {
                Kupac k = ComboBox1.SelectedItem as Kupac;

                if (korpa.Count > 0)
                {
                    int rezultat = KorpaDal.SacuvajKorpu(korpa, k.KupacId);

                    if (rezultat == 0)
                    {
                        MessageBox.Show("Korpa sacuvana");
                    }
                    else
                    {
                        MessageBox.Show("Greska pri cuvanju podataka");
                    }
                }
            }
            else
            {
                MessageBox.Show("Odaberi kupca");
            }
        }
    }
}
