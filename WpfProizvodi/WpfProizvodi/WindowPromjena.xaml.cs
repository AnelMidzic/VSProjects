﻿using System;
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
    /// Interaction logic for WindowPromjena.xaml
    /// </summary>
    public partial class WindowPromjena : Window
    {
        private List<Kategorija> listaKategorija = null;

        private List<Proizvod> listaProizvoda = null;

        public WindowPromjena()
        {
            InitializeComponent();
        }

        private void PrikaziKategorije()
        {
            ComboBox1.Items.Clear();
            ComboKategorija.Items.Clear();

            listaKategorija = KategorijaDal.VratiKategorije();

            ComboBox1.Items.Add(new Kategorija { KategorijaId = 0, Naziv = "Svi proizvodi" });

            if (listaKategorija != null)
            {
                foreach (Kategorija k in listaKategorija)
                {
                    ComboBox1.Items.Add(k);
                    ComboKategorija.Items.Add(k);
                }
            }
        }

        private List<Proizvod> PronadjiProizvode(string pretraga, int id = 0)
        {
            listaProizvoda = ProizvodDal.VratiProizvode();

            

            if (listaProizvoda != null)
            {
                IEnumerable<Proizvod> filtriranaLista =
                listaProizvoda.Select(p => p);

                if (id > 0)
                {
                    filtriranaLista = filtriranaLista
                        .Where(p => p.KategorijaId == id);
                }

                pretraga = pretraga.Trim().ToLower();

                if (!string.IsNullOrWhiteSpace(pretraga))
                {
                    filtriranaLista = filtriranaLista
                        .Where(p => p.Naziv.ToLower().Contains(pretraga));
                }
                return filtriranaLista.ToList();
            }
            else
            {
                return null;
            }
        }

        private void PrikaziProizvode()
        {
            Kategorija k = ComboBox1.SelectedItem as Kategorija;
            string pretraga = TextBoxPretraga.Text.Trim().ToLower();

            DataGrid1.ItemsSource = PronadjiProizvode(pretraga, k.KategorijaId);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziKategorije();
            ComboBox1.SelectedIndex = 0;
            PrikaziProizvode();
        }

        private void ButtonPronadji_Click(object sender, RoutedEventArgs e)
        {
            PrikaziProizvode();
            Resetuj();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedIndex > -1)
            {
                Proizvod p = DataGrid1.SelectedItem as Proizvod;
                TextBoxId.Text = p.ProizvodId.ToString();
                ComboKategorija.SelectedIndex = listaKategorija
                    .FindIndex(k => k.KategorijaId == p.KategorijaId);
                TextBoxNaziv.Text = p.Naziv;
                TextBoxCijena.Text = p.Cijena.ToString();
                TextBoxOpis.Text = p.Opis;
            }
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

        private void Resetuj()
        {
            TextBoxId.Clear();
            ComboKategorija.SelectedIndex = -1;
            TextBoxNaziv.Clear();
            TextBoxCijena.Clear();
            TextBoxOpis.Clear();
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            int indeks = DataGrid1.SelectedIndex;

            if (indeks > -1)
            {
                if (Validacija())
                {
                    Proizvod p = DataGrid1.SelectedItem as Proizvod;

                    Kategorija k = ComboKategorija.SelectedItem as Kategorija;

                    p.KategorijaId = k.KategorijaId;
                    p.Naziv = TextBoxNaziv.Text;
                    p.Cijena = decimal.Parse(TextBoxCijena.Text);
                    p.Opis = TextBoxOpis.Text;

                    int rezultat = ProizvodDal.PromijeniProizvod(p);

                    if (rezultat == -1)
                    {
                        MessageBox.Show("Greska pri promjeni proizvoda");
                    }
                    else
                    {
                        PrikaziProizvode();
                        DataGrid1.Focus();
                        DataGrid1.SelectedIndex = indeks;
                        MessageBox.Show("Proizvod promijenjen");
                    }
                }
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex > -1)
            {
                Proizvod p = DataGrid1.SelectedItem as Proizvod;

                MessageBoxResult mbr = MessageBox.Show(p.Naziv, "Brisanje proizvoda", MessageBoxButton.YesNo);

                if (mbr == MessageBoxResult.No)
                {
                    return;
                }

                int rezultat = ProizvodDal.ObrisiProizvod(p.ProizvodId);

                if (rezultat == -1)
                {
                    MessageBox.Show("Greska pri brisanju proizvoda");
                }
                else
                {
                    PrikaziProizvode();
                    Resetuj();
                    MessageBox.Show("Obrisan proizvod");
                }
            }
            else
            {
                MessageBox.Show("Odaberi proizvod za brisanje");
            }
        }
    }
}
